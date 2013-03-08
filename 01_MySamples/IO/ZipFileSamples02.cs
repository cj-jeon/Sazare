namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.IO.Compression;
  using System.Linq;
  using System.Text;

  #region ZipFileSamples-02
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
  public class ZipFileSamples02 : IExecutable
  {
    string _zipFilePath;

    string DesktopPath
    {
      get
      {
        return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      }
    }

    public void Execute()
    {
      //
      // ZipFile�N���X�̈ȉ��̃��\�b�h�𗘗p����ƁA������ZIP�t�@�C�����J�������o����B
      //   �EOpenRead
      //   �EOpen(string, ZipArchiveMode)
      //   �EOpen(string, ZipArchiveMode, Encoding)
      // �ǂ̃��\�b�h���A�߂�l�Ƃ���ZipArchive�N���X�̃C���X�^���X��Ԃ��B
      // ���ۂ�ZIP�t�@�C�����̃G���g���擾�́AZipArchive����s��.
      // ZipArchive�N���X�́AIDisposable���������Ă���̂�using�u���b�N��
      // ���p����̂��D�܂����B
      //
      // ���AZipArchive�N���X�𗘗p����ꍇ�A�Q�Ɛݒ��
      //   System.IO.Compression.dll
      // ��ǉ�����K�v������B
      //
      Prepare();

      //
      // OpenRead
      //
      using (var archive = ZipFile.OpenRead(_zipFilePath))
      {
        archive.Entries.ToList().ForEach(PrintEntry);
      }

      //
      // Open(string, ZipArchiveMode)
      //
      using (var archive = ZipFile.Open(_zipFilePath, ZipArchiveMode.Read))
      {
        //
        // ZipArchive.Entries�v���p�e�B����́AReadOnlyCollection<ZipArchiveEntry>���擾�ł���B
        // 1�G���g���̏��́AZipArchiveEntry����擾�ł���B
        //
        // ZipArchiveEntry�ɂ́AName�Ƃ����v���p�e�B�����݂��A���̃v���p�e�B������ۂ̃t�@�C�������擾�ł���B
        // �܂��ALength�v���p�e�B��舳�k�O�̃t�@�C���T�C�Y���擾�ł���B���k��̃T�C�Y�́ACompressedLength����擾�ł���B
        // �G���g���̓��e��ǂݏo���ɂ́AZipArchiveEntry.Open���\�b�h�𗘗p����B
        //
        archive.Entries.ToList().ForEach(PrintEntry);
      }

      //
      // Open(string, ZipArchiveMode, Encoding)
      //   �e�L�X�g�t�@�C���̂݁A���g��ǂݏo���ďo��.
      //
      using (var archive = ZipFile.Open(_zipFilePath, ZipArchiveMode.Read, Encoding.GetEncoding("sjis")))
      {
        archive.Entries.Where(entry => entry.Name.EndsWith("txt")).ToList().ForEach(PrintEntryContents);
      }

      File.Delete(_zipFilePath);
      Directory.Delete(Path.Combine(DesktopPath, "ZipTest"), recursive: true);
    }

    void Prepare()
    {
      //
      // �T���v��ZIP�t�@�C�����쐬���Ă���.
      // (�f�X�N�g�b�v���ZipTest.zip�Ƃ������̂ŏo�͂����)
      //
      new ZipFileSamples01().Execute();
      _zipFilePath = Path.Combine(DesktopPath, "ZipTest.zip");
    }

    void PrintEntry(ZipArchiveEntry entry)
    {
      Console.WriteLine("[{0}, {1}]", entry.Name, entry.Length);
    }

    void PrintEntryContents(ZipArchiveEntry entry)
    {
      using (var reader = new StreamReader(entry.Open(), Encoding.GetEncoding("sjis")))
      {
        for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
        {
          Console.WriteLine(line);
        }
      }
    }
  }
  #endregion
}
