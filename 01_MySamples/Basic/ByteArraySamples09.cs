namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region ByteArraySamples-09
  /// <summary>
  /// �o�C�g�z��ɂ��ẴT���v���ł��B
  /// </summary>
  public class ByteArraySamples09 : IExecutable
  {
    public void Execute()
    {
      //
      // ���p���Ă���A�[�L�e�N�`���̃G���f�B�A���𔻒�.
      //
      Console.WriteLine(BitConverter.IsLittleEndian);
    }
  }
  #endregion
}
