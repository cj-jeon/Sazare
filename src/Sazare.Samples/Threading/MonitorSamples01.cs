// ReSharper disable CheckNamespace

using System;
using System.Threading;
using Sazare.Common;

namespace Sazare.Samples
{

    #region MonitorSample-01

    /// <summary>
    ///     Monitorクラスについてのサンプルです。
    /// </summary>
    [Sample]
    public class MonitorSamples01 : IExecutable
    {
        private bool _go;
        private readonly object _lock = new object();

        public void Execute()
        {
            new Thread(Waiter).Start();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            lock (_lock)
            {
                _go = true;
                //
                // ブロックしているスレッドに対して、通知を発行.
                //   Monitor.Pulseは、lock内でしか実行できない.
                //
                Monitor.Pulse(_lock);
            }

            Output.WriteLine("Main thread end.");
        }

        private void Waiter()
        {
            lock (_lock)
            {
                while (!_go)
                {
                    //
                    // 通知が来るまで、スレッドをブロック.
                    //   Monitor.Waitは、lock内でしか実行できない.
                    //
                    Monitor.Wait(_lock);
                }
            }

            Output.WriteLine("awake!!");
        }
    }

    #endregion
}