namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region NumberFormatSamples-04
  /// <summary>
  /// ���l�t�H�[�}�b�g�̃T���v���ł��B
  /// </summary>
  public class NumberFormatSamples04 : IExecutable
  {
    public void Execute()
    {
      int iTestValue1 = 1;
      int iTestValue2 = 10;

      Console.WriteLine("iTestValue1: {0:D2}", iTestValue1);
      Console.WriteLine("iTestValue2: {0:D2}", iTestValue2);

      string sTestValue1 = iTestValue1.ToString();
      string sTestValue2 = iTestValue2.ToString();

      //
      // ���ƂȂ�f�[�^�̌^�����l�ł͂Ȃ��ꍇ�A2���ŕ\���Ǝw�肵�Ă�
      // �t�H�[�}�b�g����Ȃ��B(������̏ꍇ�͂��̂܂�"1"�ƕ\�������B)
      //
      Console.WriteLine("sTestValue1: {0:D2}", sTestValue1);
      Console.WriteLine("sTestValue2: {0:D2}", sTestValue2);
    }
  }
  #endregion
}
