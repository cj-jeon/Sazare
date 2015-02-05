namespace Sazare.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Windows.Forms;
  
  using Sazare.Common;
  
  #region 非同期デリゲートを利用したスレッド処理
  /// <summary>
  /// 非同期デリゲートを利用したスレッド処理のサンプルです。
  /// </summary>
  [Sample]
  public class AsyncDelegateSample : Sazare.Common.IExecutable
  {
    /// <summary>
    /// 処理を実行します。
    /// </summary>
    public void Execute()
    {
      Output.WriteLine("[MAIN] START. ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);

      MethodInvoker invoker = () =>
      {
        Output.WriteLine("[DELE] START. ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);

        for (int i = 0; i < 10; i++)
        {
          Output.WriteLine("[DELE] PROCESSING. ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);
          Thread.Sleep(105);
        }
      };

      invoker.BeginInvoke((ar) =>
        {
          MethodInvoker caller = ar.AsyncState as MethodInvoker;
          caller.EndInvoke(ar);
          Output.WriteLine("[DELE] END. ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);
        },
        invoker
      );

      for (int i = 0; i < 10; i++)
      {
        Output.WriteLine("[MAIN] PROCESSING. ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(100);
      }

      Thread.Sleep(3500);
      Output.WriteLine("[MAIN] END. ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);
    }
  }
  #endregion
}
