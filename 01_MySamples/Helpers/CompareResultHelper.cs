namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region CompareOptionsSamples-01
  /// <summary>
  /// ��r���\�b�h�̌��ʒl��ϊ����邽�߂̃w���p�[�N���X.
  /// </summary>
  public static class CompareResultHelper
  {
    static readonly string[] CompResults = { "������", "������", "�傫��" };

    // ��r���ʂ̐��l�𕶎���ɕϊ�.
    public static string ToStringResult(this int self)
    {
      return CompResults[self + 1];
    }
  }
  #endregion
}
