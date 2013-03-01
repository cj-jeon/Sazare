namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  #region �X���b�h�v�[���𗘗p�����X���b�h����
  /// <summary>
  /// �X���b�h�v�[��(ThreadPool)�𗘗p�����X���b�h�����̃T���v���ł��B
  /// </summary>
  public class ThreadPoolSample : IExecutable
  {
    /// <summary>
    /// �X���b�h�̏�Ԃ�\���f�[�^�N���X�ł��B
    /// </summary>
    class StateInfo
    {
      public int Count
      {
        get;
        set;
      }

      public DateTime Time
      {
        get;
        set;
      }
    }

    /// <summary>
    /// ���������s���܂��B
    /// </summary>
    public void Execute()
    {
      for (int i = 0; i < 15; i++)
      {
        ThreadPool.QueueUserWorkItem((stateInfo) =>
        {
          StateInfo p = stateInfo as StateInfo;
          Thread.Sleep(150);
          Console.WriteLine("Thread Count:{0}, Time:{1}", p.Count, p.Time.ToString("hh:mm:ss.fff"));
        },
        new StateInfo
        {
          Count = i,
          Time = DateTime.Now
        });
      }

      Thread.Sleep(2000);
    }
  }
  #endregion
}
