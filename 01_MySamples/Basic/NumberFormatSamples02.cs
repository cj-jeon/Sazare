namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region NumberFormatSamples-02
  /// <summary>
  /// ���l�t�H�[�}�b�g�̃T���v���ł��B
  /// </summary>
  public class NumberFormatSamples02 : IExecutable
  {
    public void Execute()
    {
      int i = 123456;
      Console.WriteLine("{0:N0}", i);

    }
  }
  #endregion
}
