namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;

  #region GetInvalidPathCharsAndGetInvalidFileNameCharsSamples-01
  /// <summary>
  /// Path�N���X��GetInvalidPathChars���\�b�h��GetInvalidFileNameChars���\�b�h�̃T���v���ł��B
  /// </summary>
  public class GetInvalidPathCharsAndGetInvalidFileNameCharsSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // Path�N���X�ɂ́A�p�X���y�уt�@�C�����ɗ��p�ł��Ȃ��������擾���郁�\�b�h�����݂���B
      //   �p�X���FGetInvalidPathChars
      // �t�@�C�����FGetInvalidFileNameChars
      //
      // �����Ȃǂœn���ꂽ�p�X��t�@�C�����ɑ΂��ĕs���ȕ��������p����Ă��Ȃ���
      // �`�F�b�N����ۂȂǂɗ��p�ł���B
      //
      // �߂�l�́A�ǂ����char�̔z��ƂȂ��Ă���B
      //
      char[] invalidPathChars = Path.GetInvalidPathChars();
      char[] invalidFileNameChars = Path.GetInvalidFileNameChars();

      string tmpPath = @"c:usrlocaltmp_<path>_tmp";
      string tmpFileName = @"tmp_<filename>_tmp.|||";

      Console.WriteLine("�s���ȃp�X���������݂��Ă�H     = {0}", invalidPathChars.Any(ch => tmpPath.Contains(ch)));
      Console.WriteLine("�s���ȃt�@�C�������������݂��Ă�H = {0}", invalidFileNameChars.Any(ch => tmpFileName.Contains(ch)));
    }
  }
  #endregion
}
