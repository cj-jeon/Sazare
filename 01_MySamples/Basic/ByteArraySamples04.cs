namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region ByteArraySamples-04
  /// <summary>
  /// �o�C�g�z��ɂ��ẴT���v���ł��B
  /// </summary>
  public class ByteArraySamples04 : IExecutable
  {
    public void Execute()
    {
      //
      // ���l����o�C�g��֕ϊ�
      //
      int i = 123456;
      byte[] buf = BitConverter.GetBytes(i);

      Console.WriteLine(BitConverter.ToString(buf));
    }
  }
  #endregion
}
