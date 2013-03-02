namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net.NetworkInformation;
  using System.Threading;

  #region PingSamples-01
  /// <summary>
  /// Ping�N���X�Ɋւ���T���v���ł��B
  /// </summary>
  public class PingSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // �����ł̑��M.
      // 
      string hostName = "localhost";
      int timeOut = 3000;

      Ping p = new Ping();
      PingReply r = p.Send(hostName, timeOut);

      if (r.Status == IPStatus.Success)
      {
        Console.WriteLine("Ping.Send() Success.");
      }
      else
      {
        Console.WriteLine("Ping.Send() Failed.");
      }

      //
      // �񓯊��ł̑��M.
      //
      hostName = "www.google.com";
      object userToken = null;

      p.PingCompleted += (s, e) =>
      {

        if (e.Cancelled)
        {
          Console.WriteLine("Cancelled..");
          return;
        }

        if (e.Error != null)
        {
          Console.WriteLine(e.Error.ToString());
          return;
        }

        if (e.Reply.Status != IPStatus.Success)
        {
          Console.WriteLine("Ping.SendAsync() Failed");
          return;
        }

        Console.WriteLine("Ping.SendAsync() Success.");
      };

      p.SendAsync(hostName, timeOut, userToken);
      Thread.Sleep(3000);
    }
  }
  #endregion
}
