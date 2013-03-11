namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  #region ThreadingNamespaceSamples-01
  /// <summary>
  /// System.Threading���O��Ԃɑ��݂���N���X�̃T���v���ł��B
  /// </summary>
  public class ThreadingNamespaceSamples01 : IExecutable
  {

    private class ThreadStartDelegateState
    {
      public Thread TargetThread
      {
        get;
        set;
      }
      public string ArgumentData
      {
        get;
        set;
      }
      public string ReturnData
      {
        get;
        set;
      }

      public void ThreadStartHandlerMethod()
      {
        Thread.Sleep(TimeSpan.FromSeconds(1));
        ReturnData = Thread.CurrentThread.ManagedThreadId.ToString();
      }

      public void ParameterizedThreadStartHandlerMethod(object threadArgument)
      {
        ArgumentData = threadArgument as string;

        ThreadStartHandlerMethod();
      }

      public override string ToString()
      {
        return string.Format("Argument:{0}  Return:{1}", ArgumentData, ReturnData);
      }
    }

    public void Execute()
    {
      //
      // Thread�N���X (1)
      //    ��{�I�ȃ��\�b�h�Ȃǂɂ���.
      //

      //////////////////////////////////////////////////////////////////////////////
      //
      // ThreadStart�f���Q�[�g��p�������@.
      //    ThreadStart�f���Q�[�g�͈������߂�l�������Ă��܂���B
      //    ���̃f���Q�[�g�𗘗p�����p�^�[���Ŋe�X���b�h�ɂăf�[�^��
      //    ��������ꍇ�́A�f���Q�[�g���\�b�h��������ԃN���X���쐬���܂��B
      //    ��Ō��ʂ��󂯎��K�v������ꍇ�����l�ł��B
      //
      List<ThreadStartDelegateState> states = new List<ThreadStartDelegateState>();
      for (int i = 0; i < 5; i++)
      {
        ThreadStartDelegateState state = new ThreadStartDelegateState();
        Thread thread = new Thread(state.ThreadStartHandlerMethod);

        state.ArgumentData = string.Format("{0}�Ԗڂ̃X���b�h", i);
        state.TargetThread = thread;

        states.Add(state);

        //
        // �V�K�ō쐬����Thread�̓f�t�H���g�Ńt�H�A�O���E���h�X���b�h�ƂȂ��Ă���B
        // �iThreadPool�X���b�h�̏ꍇ�̓f�t�H���g�Ńo�b�N�O���E���h�X���b�h�ƂȂ��Ă���B)
        //
        thread.IsBackground = true;

        // 
        // �ʃX���b�h�������J�n����B
        // Start���\�b�h�͑����ɐ�����Ăь��ɖ߂��B
        //
        thread.Start();
      }

      //
      // �S�X���b�h���I����Ă��猋�ʂ��m�F�������̂ŁA�҂����킹.
      // (�ȉ��̈�s���R�����g�A�E�g���Ď��s����ƁA�����m����ReturnData�v���p�e�B�̒l��
      //  �ݒ肳��Ă��Ȃ���ԂŌ��ʂ��o�͂����͂��ł��B(���ʂ��Z�b�g�����O�Ƀ��C��������
      //  ���ʊm�F�����ւƐi�ނ���))
      //
      states.ForEach(state =>
      {
        state.TargetThread.Join();
      });

      // ���ʊm�F.
      states.ForEach(Console.WriteLine);

      //////////////////////////////////////////////////////////////////////////////
      //
      // ParameterizedThreadStart�f���Q�[�g��p�������@.
      //    ParameterizedThreadStart�f���Q�[�g�͈�������^���鎖���o���܂��B
      //    ���̃f���Q�[�g�𗘗p�����p�^�[���Ŋe�X���b�h�ɂăf�[�^��
      //    ��������ꍇ�́AThread.Start���\�b�h�ɂĈ����������n���܂��B
      //    ��Ō��ʂ��󂯎��K�v������ꍇ�́AThreadStart�f���Q�[�g�Ɠ�����
      //    ��ԃN���X���쐬���A�߂�l��ݒ肷��K�v������܂��B
      //
      states.Clear();
      for (int i = 0; i < 5; i++)
      {
        ThreadStartDelegateState state = new ThreadStartDelegateState();
        Thread thread = new Thread(state.ParameterizedThreadStartHandlerMethod);

        state.TargetThread = thread;
        states.Add(state);

        thread.IsBackground = true;
        thread.Start(string.Format("{0}�Ԗڂ̃X���b�h", i));
      }

      states.ForEach(state =>
      {
        state.TargetThread.Join();
      });
      states.ForEach(Console.WriteLine);
    }
  }
  #endregion
}
