namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region ByteArraySamples-08
  /// <summary>
  /// �o�C�g�z��ɂ��ẴT���v���ł��B
  /// </summary>
  public class ByteArraySamples08 : IExecutable
  {
    public void Execute()
    {
      //
      // ���l�����낢��Ȋ�ɕϊ�.
      //
      int i = 123;

      Console.WriteLine(Convert.ToString(i, 16));
      Console.WriteLine(Convert.ToString(i, 8));
      Console.WriteLine(Convert.ToString(i, 2));
    }
  }
  #endregion
}
