namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.IO.Compression;
  using System.Linq;

  #region ZipFileSamples-01
  /// <summary>
  /// System.IO.Compression.ZipFile�N���X�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// ZipFile�N���X�́A.NET Framework 4.5�Œǉ����ꂽ�N���X�ł��B
  /// ���̃N���X�𗘗p����ɂ́A�uSystem.IO.Compression.FileSystem.dll�v��
  /// �Q�Ɛݒ�ɒǉ�����K�v������܂��B
  /// ���̃N���X�́AMetro�A�v���ł͗��p�ł��܂���B
  /// Metro�A�v���ł́A�����ZipArchive�N���X�𗘗p���܂��B
  /// </remarks>
  public class ZipFileSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // ZipFile�N���X�́AZIP�`���̃t�@�C�����������߂̃N���X�ł���B
      // ���������o����N���X�Ƃ��āAZipArchive�N���X�����݂��邪
      // ������́A���ߍׂ����������s����N���X�ƂȂ��Ă���
      // ZipFile�N���X�́A���[�e�B���e�B�N���X�̈����ɋ߂��B
      //
      // ZipFile�N���X�ɒ�`����Ă��郁�\�b�h�́A�S��static���\�b�h�ƂȂ��Ă���B
      //
      // �ȒP�Ɉ��k�E�𓀂��邽�߂̃��\�b�h�Ƃ���
      //   �ECreateFromDirectory(string, string)
      //   �EExtractToDirectory(string, string)
      // ���p�ӂ���Ă���B
      //
      // ���A���̃N���X��Metro�X�^�C���A�v�� (�V�������O��Windows 8�X�^�C��UI�H)
      // �ł͗��p�ł��Ȃ��N���X�ł���BMetro�ł́AZipArchive�𗘗p���邱�ƂɂȂ�B
      // (http://msdn.microsoft.com/en-us/library/system.io.compression.zipfile)
      //

      //
      // ���k.
      //
      string srcDirectory = Environment.CurrentDirectory;
      string dstDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      string dstFilePath = Path.Combine(dstDirectory, "ZipTest.zip");

      if (File.Exists(dstFilePath))
      {
        File.Delete(dstFilePath);
      }

      ZipFile.CreateFromDirectory(srcDirectory, dstFilePath);

      //
      // ��.
      //
      string extractDirectory = Path.Combine(dstDirectory, "ZipTest");
      if (Directory.Exists(extractDirectory))
      {
        Directory.Delete(extractDirectory, recursive: true);
        Directory.CreateDirectory(extractDirectory);
      }

      ZipFile.ExtractToDirectory(dstFilePath, extractDirectory);
    }
  }
  #endregion
}
