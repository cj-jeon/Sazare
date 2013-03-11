namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.IO;
  using System.Linq;

  #region LinqSamples-49
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples49 : IExecutable
  {
    public void Execute()
    {
      //
      // Directory.EnumerateFiles���\�b�h�́A�]���܂ł�
      // Directory.GetFiles���\�b�h�Ɠ������삷�郁�\�b�h�ł���B
      //
      // �Ⴂ�́A�߂�l��IEnumerable<string>�ƂȂ��Ă���
      // �x���]�������B
      //
      // GetFiles���\�b�h�̏ꍇ�́A�S���X�g���\�z���Ă���
      // �߂�l���ԋp�����̂ŁA�R���N�V�������\�z�����܂�
      // �ҋ@����K�v�����邪�AEnumerateFiles���\�b�h�̏ꍇ��
      // �R���N�V�����S�̂��Ԃ����O�ɁA�񋓉\�ł���B
      //
      // EnumerateDirectories���\�b�h�y��EnumerateFileSystemEntries���\�b�h����L�Ɠ��l�B
      //
      var path = @"c:\windows";
      var filter = @"*.exe";
      var watch = Stopwatch.StartNew();
      var elapsed = string.Empty;

      //
      // EnumerateFiles.
      //
      var query = from file in Directory.EnumerateFiles(path, filter, SearchOption.AllDirectories)
                  select file;

      foreach (var item in query)
      {
        if (watch != null)
        {
          watch.Stop();
          elapsed = watch.Elapsed.ToString();
          watch = null;
        }

        //Console.WriteLine(item);
      }

      Console.WriteLine("================== EnumereteFiles       : {0} ==================", elapsed);

      //
      // EnumerateDirectories.
      //
      watch = Stopwatch.StartNew();
      elapsed = string.Empty;

      query = from directory in Directory.EnumerateDirectories(path)
              select directory;

      foreach (var item in query)
      {
        if (watch != null)
        {
          watch.Stop();
          elapsed = watch.Elapsed.ToString();
          watch = null;
        }

        //Console.WriteLine(item);
      }

      Console.WriteLine("================== EnumerateDirectories     : {0} ==================", elapsed);

      //
      // EnumerateFileSystemEntries.
      //
      watch = Stopwatch.StartNew();
      elapsed = string.Empty;

      query = from directory in Directory.EnumerateFileSystemEntries(path)
              select directory;

      foreach (var item in query)
      {
        if (watch != null)
        {
          watch.Stop();
          elapsed = watch.Elapsed.ToString();
          watch = null;
        }

        //Console.WriteLine(item);
      }

      Console.WriteLine("================== EnumerateFileSystemEntries : {0} ==================", elapsed);

      //
      // GetFiles.
      //
      watch = Stopwatch.StartNew();
      elapsed = string.Empty;

      var files = Directory.GetFiles(path, filter, SearchOption.AllDirectories);

      foreach (var item in files)
      {
        if (watch != null)
        {
          watch.Stop();
          elapsed = watch.Elapsed.ToString();
          watch = null;
        }

        //Console.WriteLine(item);
      }

      Console.WriteLine("================== GetFiles           : {0} ==================", elapsed);

      //
      // GetDirectories.
      //
      watch = Stopwatch.StartNew();
      elapsed = string.Empty;

      var dirs = Directory.GetDirectories(path);

      foreach (var item in dirs)
      {
        if (watch != null)
        {
          watch.Stop();
          elapsed = watch.Elapsed.ToString();
          watch = null;
        }

        //Console.WriteLine(item);
      }

      Console.WriteLine("================== GetDirectories       : {0} ==================", elapsed);

      //
      // GetFileSystemEntries.
      //
      watch = Stopwatch.StartNew();
      elapsed = string.Empty;

      var entries = Directory.GetFileSystemEntries(path);

      foreach (var item in entries)
      {
        if (watch != null)
        {
          watch.Stop();
          elapsed = watch.Elapsed.ToString();
          watch = null;
        }

        //Console.WriteLine(item);
      }

      Console.WriteLine("================== GetFileSystemEntries     : {0} ==================", elapsed);
    }
  }
  #endregion
}
