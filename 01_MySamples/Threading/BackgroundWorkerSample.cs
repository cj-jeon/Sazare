namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Linq;
  using System.Threading;

  #region BackgroundWorker�𗘗p�����X���b�h����
  /// <summary>
  /// BackgroundWorker�𗘗p�����X���b�h�����̃T���v���ł��B
  /// </summary>
  public class BackgroundWorkerSample : IExecutable
  {
    /// <summary>
    /// ���������s���܂��B
    /// </summary>
    public void Execute()
    {
      Console.WriteLine("[MAIN] START. ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);

      BackgroundWorker worker = new BackgroundWorker();

      //
      // �񓯊������̃C�x���g���n���h��.
      //
      worker.DoWork += (s, e) =>
      {
        Console.WriteLine("[WORK] START. ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);

        for (int i = 0; i < 10; i++)
        {
          Console.WriteLine("[WORK] PROCESSING. ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);
          Thread.Sleep(105);
        }
      };

      //
      // �񓯊��������I�������ۂ̃C�x���g���n���h��.
      //
      worker.RunWorkerCompleted += (s, e) =>
      {
        if (e.Error != null)
        {
          Console.WriteLine("[WORK] ERROR OCCURED. ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);
        }

        Console.WriteLine("[WORK] END. ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);
      };

      //
      // �񓯊��������J�n.
      //
      worker.RunWorkerAsync();

      //
      // ���C���X���b�h�̏���.
      //
      for (int i = 0; i < 10; i++)
      {
        Console.WriteLine("[MAIN] PROCESSING. ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(100);
      }

      Thread.Sleep(1000);
      Console.WriteLine("[MAIN] END. ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);
    }
  }
  #endregion
}
