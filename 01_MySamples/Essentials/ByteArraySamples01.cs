namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region ByteArraySamples-01
  /// <summary>
  /// �o�C�g�z��ɂ��ẴT���v���ł��B
  /// </summary>
  public class ByteArraySamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // �o�C�g�z���2�i���\��.
      //
      byte[] buf = new byte[4];
      buf[0] = 0;
      buf[1] = 0;
      buf[2] = 0;
      buf[3] = 98;

      Console.WriteLine(
            string.Join(
              "",
              buf.Take(4).Select(b => Convert.ToString(b, 2).PadLeft(8, '0'))
            ));
    }
  }
  #endregion
}
