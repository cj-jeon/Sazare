namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region ByteArraySamples-02
  /// <summary>
  /// �o�C�g�z��ɂ��ẴT���v���ł��B
  /// </summary>
  public class ByteArraySamples02 : IExecutable
  {
    public void Execute()
    {
      //
      // �o�C�g���16�i���������
      //
      byte[] buf = new byte[5];
      new Random().NextBytes(buf);

      Console.WriteLine(BitConverter.ToString(buf));
    }
  }
  #endregion
}
