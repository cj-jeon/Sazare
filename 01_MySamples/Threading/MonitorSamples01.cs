namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  #region MonitorSample-01
  /// <summary>
  /// Monitor�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  public class MonitorSamples01 : IExecutable
  {
    object _lock = new object();
    bool _go;

    public void Execute()
    {
      new Thread(Waiter).Start();

      Thread.Sleep(TimeSpan.FromSeconds(1));
      lock (_lock)
      {
        _go = true;
        //
        // �u���b�N���Ă���X���b�h�ɑ΂��āA�ʒm�𔭍s.
        //   Monitor.Pulse�́Alock���ł������s�ł��Ȃ�.
        //
        Monitor.Pulse(_lock);
      }

      Console.WriteLine("Main thread end.");
    }

    void Waiter()
    {
      lock (_lock)
      {
        while (!_go)
        {
          //
          // �ʒm������܂ŁA�X���b�h���u���b�N.
          //   Monitor.Wait�́Alock���ł������s�ł��Ȃ�.
          //
          Monitor.Wait(_lock);
        }
      }

      Console.WriteLine("awake!!");
    }
  }
  #endregion
}
