namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region BitConverterSamples-01
  /// <summary>
  /// System.BitConverter�N���X�̃T���v���ł��B
  /// </summary>
  public class BitConverterSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // �o�C�g�񂩂�16�i������ւ̕ϊ�.
      //
      byte[] bytes = new byte[] { 1, 2, 10, 15, (byte)'a', (byte)'b', (byte)'q' };
      Console.WriteLine(BitConverter.ToString(bytes));

      //
      // ���l����o�C�g��ւ̕ϊ�.
      // (��U���l���o�C�g��ɕϊ����Ă���A16�i�ɕϊ����ĕ\��)
      //
      int i = 100;
      Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(i)));

      int i2 = 0x12345678;
      Console.WriteLine(BitConverter.ToString(BitConverter.GetBytes(i2)));

      //
      // �o�C�g�񂩂琔�l�ւ̕ϊ�.
      //
      bytes = new byte[] { 1 };
      Console.WriteLine(BitConverter.ToBoolean(bytes, 0));

      bytes = new byte[] { 1, 0, 0, 0 };
      Console.WriteLine(BitConverter.ToInt32(bytes, 0));

      bytes = BitConverter.GetBytes((byte)'a');
      Console.WriteLine(BitConverter.ToChar(bytes, 0));
    }
  }
  #endregion
}
