namespace Sazare.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region ByteArraySamples-02
  /// <summary>
  /// バイト配列についてのサンプルです。
  /// </summary>
  [Sample]
  public class ByteArraySamples02 : Sazare.Common.IExecutable
  {
    public void Execute()
    {
      //
      // バイト列を16進数文字列へ
      //
      byte[] buf = new byte[5];
      new Random().NextBytes(buf);

      Console.WriteLine(BitConverter.ToString(buf));
    }
  }
  #endregion
}
