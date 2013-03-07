namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region ByteArraySamples-05
  /// <summary>
  /// �o�C�g�z��ɂ��ẴT���v���ł��B
  /// </summary>
  public class ByteArraySamples05 : IExecutable
  {
    public void Execute()
    {
      //
      // �o�C�g��𐔒l��
      //
      byte[] buf = new byte[4];
      new Random().NextBytes(buf);

      int i = BitConverter.ToInt32(buf, 0);

      Console.WriteLine(i);
    }
  }
  #endregion
}
