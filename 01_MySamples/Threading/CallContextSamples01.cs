namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.Remoting.Messaging;
  using System.Threading;

  #region CallContextSamples-01
  /// <summary>
  /// ���s�R���e�L�X�g(ExecutionContext)�Ƙ_���Ăяo���R���e�L�X�g(CallContext)�̃T���v���ł��B
  /// </summary>
  public class CallContextSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // ���ׂẴX���b�h�ɂ́A���s�R���e�L�X�g (Execution Context) ���֘A�t�����Ă���B
      // ���s�R���e�L�X�g�ɂ�
      //    �E���̃X���b�h�̃Z�L�����e�B�ݒ� (���k�X�^�b�N�AThread.Principal, Windows�̔F�؏��)
      //    �E�z�X�g�ݒ� (HostExecutionContextManager)
      //    �E�_���Ăяo���R���e�L�X�g�f�[�^ (CallContext)
      // ���R�t���Ă���B
      // 
      // ���̒��ł��A�_���Ăяo���R���e�L�X�g (CallContext) �́ALogicalSetData���\�b�h�ALogicalGetData���\�b�h��
      // ���p���邱�Ƃɂ��A�������s�R���e�L�X�g�����X���b�h�ԂŃf�[�^�����L���邱�Ƃ��ł���B
      // ����ł́ACLR�͋N�����̃X���b�h�̎��s�R���e�L�X�g�������I�ɓ`�d�����悤�ɂ��Ă����B
      //
      // ���s�R���e�L�X�g�̓`�d���@�́AExecutionContext�N���X�𗘗p���邱�Ƃɂ��ύX���邱�Ƃ��ł���B
      // ExecutionContext.SuppressFlow���\�b�h�ɂ�SerucityCriticalAttribute
      // ���t�^����Ă���̂ŁA���ɂ���Ă͓��삵�Ȃ��Ȃ�\��������B
      // (SerucityCriticalAttribute�́A���S�M����v�����鑮��)
      //
      var numberOfThreads = 5;

      using (var cde = new CountdownEvent(numberOfThreads))
      {
        //
        // ���C���X���b�h��ɂāA�_���Ăяo���R���e�L�X�g�f�[�^��ݒ�.
        //
        CallContext.LogicalSetData("Message", "Hello World");

        //
        // ����̐ݒ�̂܂� (�e����ExecutionContext�����̂܂܌p���j �ŁA�ʃX���b�h����.
        //
        ThreadPool.QueueUserWorkItem(ShowCallContextLogicalData, new ThreadData("First Thread", cde));

        //
        // ���s�R���e�L�X�g�̓`�d���@��ύX.
        //   SuppressFlow���\�b�h�́A���s�R���e�L�X�g�t���[��}�����郁�\�b�h.
        // SuppressFlow���\�b�h�́AAsyncFlowControl��߂�l�Ƃ��ĕԋp����B
        // �}���������s�R���e�L�X�g�𕜌�����ɂ́AAsyncFlowControl.Undo���Ăяo���B
        //
        AsyncFlowControl flowControl = ExecutionContext.SuppressFlow();

        //
        // �}�����ꂽ���s�R���e�X�g�̏�ԂŁA�ʃX���b�h����.
        //
        ThreadPool.QueueUserWorkItem(ShowCallContextLogicalData, new ThreadData("Second Thread", cde));

        //
        // ���s�R���e�L�X�g�𕜌�.
        //
        flowControl.Undo();

        //
        // �ēx�A�ʃX���b�h����.
        //
        ThreadPool.QueueUserWorkItem(ShowCallContextLogicalData, new ThreadData("Third Thread", cde));

        //
        // �ēx�A���s�R���e�L�X�g��}�����A�}������Ă���Ԃɘ_���Ăяo���R���e�L�X�g�f�[�^��ύX��
        // ���̌�A���s�R���e�L�X�g�𕜌�����.
        //
        flowControl = ExecutionContext.SuppressFlow();
        CallContext.LogicalSetData("Message", "Modified....");

        ThreadPool.QueueUserWorkItem(ShowCallContextLogicalData, new ThreadData("Fourth Thread", cde));
        flowControl.Undo();
        ThreadPool.QueueUserWorkItem(ShowCallContextLogicalData, new ThreadData("Fifth Thread", cde));

        cde.Wait();
      }
    }

    void ShowCallContextLogicalData(object state)
    {
      var data = state as ThreadData;

      Console.WriteLine(
         "Thread: {0, -15}, Id: {1}, Message: {2}"
        , data.Name
        , Thread.CurrentThread.ManagedThreadId
        , CallContext.LogicalGetData("Message")
      );

      data.Counter.Signal();
    }

    #region Inner Classes
    class ThreadData
    {
      public string Name { get; private set; }
      public CountdownEvent Counter { get; private set; }

      public ThreadData(string name, CountdownEvent cde)
      {
        Name = name;
        Counter = cde;
      }
    }
    #endregion
  }
  #endregion
}
