namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  #region CountdownEventSamples-02
  /// <summary>
  /// CountdownEvent�N���X�ɂ��ẴT���v���ł��B(2)
  /// </summary>
  /// <remarks>
  /// CountdownEvent�N���X�́A.NET 4.0����ǉ����ꂽ�N���X�ł��B
  /// Java��CountDownLatch�N���X�Ɠ����@�\�������Ă��܂��B
  /// </remarks>
  public class CountdownEventSamples02 : IExecutable
  {
    public void Execute()
    {
      const int LEAST_TASK_FINISH_COUNT = 3;

      //
      // �����̃X���b�h������CountdownEvent���V�O�i������.
      //
      // CountdownEvent���悭���p�����p�^�[���ƂȂ�B
      // N�̏������K�萔�I������܂ŁA���C���X���b�h�̑��s��ҋ@����C���[�W.
      //
      // �ȉ��̏����ł́A5�^�X�N���쐬���āA3�I��������_��
      // ���C���X���b�h�͏����𑱍s����悤�ɂ���.
      //
      // N�̏������S���I������܂ŁA���C���X���b�h�̑��s��ҋ@����ꍇ��
      // CountdownEvent�̃J�E���g���^�X�N�̏������Ɠ����ɂ���Ηǂ��B
      //
      using (CountdownEvent cde = new CountdownEvent(LEAST_TASK_FINISH_COUNT))
      {
        // �����̏�Ԃ�\��.
        Console.WriteLine("InitialCount={0}", cde.InitialCount);
        Console.WriteLine("CurrentCount={0}", cde.CurrentCount);
        Console.WriteLine("IsSet={0}", cde.IsSet);

        Task[] tasks = new Task[]
          {
            Task.Factory.StartNew(TaskProc, cde),
            Task.Factory.StartNew(TaskProc, cde),
            Task.Factory.StartNew(TaskProc, cde),
            Task.Factory.StartNew(TaskProc, cde),
            Task.Factory.StartNew(TaskProc, cde)
          };

        //
        // 3�I���܂őҋ@.
        //
        cde.Wait();
        Console.WriteLine("5�̃^�X�N�̓��A3�I��");

        Console.WriteLine("���C���X���b�h ���s�J�n�E�E�E");
        Thread.Sleep(TimeSpan.FromSeconds(1));

        //
        // �c��̃^�X�N��ҋ@.
        //
        Task.WaitAll(tasks);
        Console.WriteLine("�S�Ẵ^�X�N�I��");

        // ���݂̏�Ԃ�\��.
        Console.WriteLine("InitialCount={0}", cde.InitialCount);
        Console.WriteLine("CurrentCount={0}", cde.CurrentCount);
        Console.WriteLine("IsSet={0}", cde.IsSet);
      }
    }

    void TaskProc(object data)
    {
      Console.WriteLine("Task ID={0} �J�n", Task.CurrentId);
      Thread.Sleep(TimeSpan.FromSeconds(new Random().Next(10)));

      //
      // ����3�I�����Ă��邩�ۂ����m�F���A�܂��Ȃ�V�O�i��.
      //
      CountdownEvent cde = data as CountdownEvent;
      if (!cde.IsSet)
      {
        cde.Signal();
        Console.WriteLine("�������J�E���g���f�N�������g������ Task ID={0} CountdownEvent.CurrentCount={1}", Task.CurrentId, cde.CurrentCount);
      }

      Console.WriteLine("Task ID={0} �I��", Task.CurrentId);
    }
  }
  #endregion
}
