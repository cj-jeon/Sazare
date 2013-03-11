namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.IO.Compression;
  using System.Linq;

  #region ZipFileSamples-03
  /// <summary>
  /// System.IO.Compression.ZipFile�N���X�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// ZipFile�N���X�́A.NET Framework 4.5�Œǉ����ꂽ�N���X�ł��B
  /// ���̃N���X�𗘗p����ɂ́A�uSystem.IO.Compression.FileSystem.dll�v��
  /// �Q�Ɛݒ�ɒǉ�����K�v������܂��B
  /// ���̃N���X�́AMetro�A�v���ł͗��p�ł��܂���B
  /// Metro�A�v���ł́A�����ZipArchive�N���X�𗘗p���܂��B
  ///
  /// ���AZipArchive�N���X�𗘗p����ꍇ
  ///   System.IO.Compression.dll
  /// ���Q�Ɛݒ�ɒǉ�����K�v������܂��B
  /// </remarks>
  public class ZipFileSamples03 : IExecutable
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
      // ZIP�t�@�C���̍쐬����эX�V.
      //   �쐬����эX�V�̏ꍇ�AZipArchive�N���X�𗘗p����.
      // 
      // �E�G���g���̒ǉ��F ZipArchive.CreateEntryFromFile OR ZipArchive.CreateEntry
      //
      // CreateEntryFromFile�́A���\�b�h�̖��O�������ʂ茳�t�@�C��������ꍇ�ɗ��p����B
      // ���ƂȂ�t�@�C�������݂���ꍇ�͂��ꂪ�y�ł���B
      //
      // CreateEntry�́A�G���g���݂̂�V�K�쐬���郁�\�b�h�B�f�[�^�͎��O�ŗ������ޕK�v������B
      //
      Prepare();

      //
      // Zip�t�@�C����V�K�쐬.
      //
      using (var archive = ZipFile.Open(_zipFilePath, ZipArchiveMode.Create))
      {
        //
        // ���t�@�C�������݂��Ă���ꍇ�́ACreateEntryFromFile�𗘗p����̂��y.
        //
        archive.CreateEntryFromFile("Persons.txt", "Persons.txt");
      }

      //
      // Zip�t�@�C���̓��e���X�V.
      //
      using (var archive = ZipFile.Open(_zipFilePath, ZipArchiveMode.Update))
      {
        //
        // ���t�@�C���͑��݂��邪�A���x��CreateEntry���\�b�h�ŐV�K�G���g���݂̂��쐬���f�[�^�́A�蓮�ŗ�������.
        //
        using (var reader = new BinaryReader(File.Open("database.png", FileMode.Open)))
        {
          var newEntry = archive.CreateEntry("database.png");
          using (var writer = new BinaryWriter(newEntry.Open()))
          {
            WriteAllBytes(reader, writer);
          }
        }
      }

      File.Delete(_zipFilePath);
    }

    void Prepare()
    {
      _zipFilePath = Path.Combine(DesktopPath, "ZipTest2.zip");
      if (File.Exists(_zipFilePath))
      {
        File.Delete(_zipFilePath);
      }
    }

    void WriteAllBytes(BinaryReader reader, BinaryWriter writer)
    {
      try
      {
        for (; ; )
        {
          writer.Write(reader.ReadByte());
        }
      }
      catch (EndOfStreamException)
      {
        writer.Flush();
      }
    }
  }
  #endregion
}
