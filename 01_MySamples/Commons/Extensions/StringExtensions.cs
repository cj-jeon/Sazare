namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region ���ʊg���N���X
  /// <summary>
  /// ���ʂŗ��p���Ă���String�g���N���X�ł��B
  /// </summary>
  public static class StringExtensions
  {
    /// <summary>
    /// ���l�ɕϊ����܂��B
    /// </summary>
    /// <param name="self">�������g</param>
    /// <return>�������g�𐔒l�ɕϊ������l.</return>
    public static int ToInt(this string self)
    {
      int i;
      if (!int.TryParse(self, out i))
      {
        return int.MinValue;
      }

      return i;
    }
  }
  #endregion
}
