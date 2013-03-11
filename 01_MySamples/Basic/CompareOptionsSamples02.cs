namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.Linq;

  #region CompareOptionsSamples-02
  /// <summary>
  /// CompareOptions�񋓌^�̃T���v���ł��B
  /// </summary>
  public class CompareOptionsSamples02 : IExecutable
  {
    public void Execute()
    {
      //
      // string.Compare���\�b�h�ɂ́ACultureInfo��CompareOptions��
      // �����ɂƂ�I�[�o�[���[�h����`����Ă���B(���ɂ��I�[�o�[���[�h���\�b�h�����݂��܂��B)
      //
      // ���̃I�[�o�[���[�h�𗘗p����ہACompareOptions.IgnoreKanaType���w�肷���
      // �u�Ђ炪�ȁv�Ɓu�J�^�J�i�v�̈Ⴂ�𖳎����āA�������r���s�������o����B
      //
      // ����ɁACompareOptions�ɂ́AIgnoreWidth�Ƃ����l�����݂�
      // ������w�肷��ƁA�S�p�Ɣ��p�̈Ⴂ�𖳎����āA�������r���s�������o����B
      //
      string ja1 = "�n���[���[���h";
      string ja2 = "�۰ܰ���";
      string ja3 = "�͂�[��[���";

      CultureInfo ci = new CultureInfo("ja-JP");

      // �S�p���p�̈Ⴂ�𖳎����āA�u�n���[���[���h�v�Ɓu�۰ܰ��ށv���r
      Console.WriteLine("{0}", string.Compare(ja1, ja2, ci, CompareOptions.IgnoreWidth).ToStringResult());
      // �S�p���p�̈Ⴂ�𖳎����āA�u�͂�[��[��ǁv�Ɓu�۰ܰ��ށv���r
      Console.WriteLine("{0}", string.Compare(ja3, ja2, ci, CompareOptions.IgnoreWidth).ToStringResult());
      // �S�p���p�̈Ⴂ�𖳎����A���A�Ђ炪�ȂƃJ�^�J�i�̈Ⴂ�𖳎����āA�u�͂�[��[��ǁv�Ɓu�۰ܰ��ށv���r
      Console.WriteLine("{0}", string.Compare(ja3, ja2, ci, (CompareOptions.IgnoreWidth | CompareOptions.IgnoreKanaType)).ToStringResult());
    }
  }
  #endregion
}
