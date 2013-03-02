namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  #region ThreadingNamespaceSamples-03
  public class ThreadingNamespaceSamples03 : IExecutable
  {

    public void Execute()
    {
      Thread thread = new Thread(ThreadProcess);

      thread.IsBackground = true;
      thread.Start();

      thread.Join();
    }

    void ThreadProcess()
    {
      ///////////////////////////////////////////////////
      //
      // �X���b�h�N���X�������̑��̃v���p�e�B�ɂ���
      //
      Thread currentThread = Thread.CurrentThread;

      // 
      // IsAlive�v���p�e�B
      //    �˃X���b�h���N������Ă���A�܂��I���܂��͒��~����Ă��Ȃ��ꍇ��
      //    �@true�ƂȂ�B
      //
      Console.WriteLine("IsAlive={0}", currentThread.IsAlive);

      //
      // IsThreadPoolThread, ManagedThreadId�v���p�e�B
      //    �˂��ꂼ��A�X���b�h�v�[���X���b�h���ǂ����ƃ}�l�[�W�X���b�h������
      //    �@����l���擾�ł���B
      //
      Console.WriteLine("IsThreadPoolThread={0}", currentThread.IsThreadPoolThread);
      Console.WriteLine("ManagedThreadId={0}", currentThread.ManagedThreadId);

      //
      // Priority�v���p�e�B
      //    �ˑΏۂ̃X���b�h�̗D��x�i�v���C�I���e�B�j���擾�y�ѐݒ肵�܂��B
      //    �@Highest���ł������ALowest���ł��Ⴂ.
      //
      Console.WriteLine("Priority={0}", currentThread.Priority);
    }
  }
  #endregion
}
