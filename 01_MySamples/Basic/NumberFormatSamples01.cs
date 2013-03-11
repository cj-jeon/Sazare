namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region NumberFormatSamples-01
  /// <summary>
  /// ���l�t�H�[�}�b�g�̃T���v���ł��B
  /// </summary>
  public class NumberFormatSamples01 : IExecutable
  {
    public void Execute()
    {
      decimal d = 99M;
      Console.WriteLine(Math.Round(d, 1));
      Console.WriteLine("{0:##0.0}", d);
    }
  }
  #endregion
}
