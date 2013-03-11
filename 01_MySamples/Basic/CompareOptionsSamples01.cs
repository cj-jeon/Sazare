namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.Linq;

  /// <summary>
  /// CompareOptions�񋓌^�̃T���v���ł��B
  /// </summary>
  public class CompareOptionsSamples01 : IExecutable
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
      string ja1 = "�͂�[��[���";
      string ja2 = "�n���[���[���h";

      CultureInfo ci = new CultureInfo("ja-JP");

      // �W���̔�r���@�Ŕ�r
      Console.WriteLine("{0}", string.Compare(ja1, ja2, ci, CompareOptions.None).ToStringResult());
      // �啶���������𖳎����Ĕ�r.
      Console.WriteLine("{0}", string.Compare(ja1, ja2, ci, CompareOptions.IgnoreCase).ToStringResult());
      // �Ђ炪�ȂƃJ�^�J�i�̈Ⴂ�𖳎����Ĕ�r
      // �܂�A�u�͂�[��[��ǁv�Ɓu�n���[���[���h�v�𓯂�������Ƃ��Ĕ�r
      Console.WriteLine("{0}", string.Compare(ja1, ja2, ci, CompareOptions.IgnoreKanaType).ToStringResult());

      //
      // string.Compare���\�b�h�́A������CutureInfo����A���̃J���`���[�ɕR�Â�
      // CompareInfo�����o���āA��r�������s���Ă���̂ŁA���O�Œ���CompareInfo��
      // �p�ӂ��āACompare���\�b�h���Ăяo���Ă��������ʂƂȂ�B
      //
      CompareInfo compInfo = CompareInfo.GetCompareInfo("ja-JP");
      Console.WriteLine("{0}", compInfo.Compare(ja1, ja2, CompareOptions.IgnoreKanaType).ToStringResult());
    }
  }
}
