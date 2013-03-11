namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Globalization;
  using System.IO;
  using System.Linq;

  #region LinqSamples-50
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples50 : IExecutable
  {
    public void Execute()
    {
      //
      // File.ReadLines���\�b�h�́A�]���܂ł�
      // File.ReadAllLines���\�b�h�Ɠ������삷�郁�\�b�h�ł���B
      //
      // �Ⴂ�́A�߂�l��IEnumerable<string>�ƂȂ��Ă���
      // �x���]�������B
      //
      // ReadAllLines���\�b�h�̏ꍇ�́A�S���X�g���\�z���Ă���
      // �߂�l���ԋp�����̂ŁA�R���N�V�������\�z�����܂�
      // �ҋ@����K�v�����邪�AReadLines���\�b�h�̏ꍇ��
      // �R���N�V�����S�̂��Ԃ����O�ɁA�񋓉\�ł���B
      //
      Console.WriteLine("�t�@�C���쐬���E�E�E�E");

      var tmpFilePath = CreateSampleFile(1000000);
      if (string.IsNullOrEmpty(tmpFilePath))
      {
        Console.WriteLine("�t�@�C���쐬���ɃG���[����");
      }

      Console.WriteLine("�t�@�C���쐬����");

      try
      {
        var watch = Stopwatch.StartNew();
        var elapsed = string.Empty;

        var numberFormatInfo = new NumberFormatInfo { CurrencySymbol = "gsf_zero" };

        //
        // File.ReadAllLines
        //
        var query = from line in File.ReadAllLines(tmpFilePath)
                    where int.Parse(line, NumberStyles.AllowCurrencySymbol, numberFormatInfo) % 2 == 0
                    select line;

        foreach (var element in query)
        {
          if (watch != null)
          {
            watch.Stop();
            elapsed = watch.Elapsed.ToString();
            watch = null;
          }

          //Console.WriteLine(element);
        }

        Console.WriteLine("================== ReadAllLines      : {0} ==================", elapsed);

        //
        // File.ReadLines
        //
        watch = Stopwatch.StartNew();
        elapsed = string.Empty;

        query = from line in File.ReadLines(tmpFilePath)
                where int.Parse(line, NumberStyles.AllowCurrencySymbol, numberFormatInfo) % 2 == 0
                select line;

        foreach (var element in query)
        {
          if (watch != null)
          {
            watch.Stop();
            elapsed = watch.Elapsed.ToString();
            watch = null;
          }

          //Console.WriteLine(element);
        }

        Console.WriteLine("================== ReadLines       : {0} ==================", elapsed);
      }
      finally
      {
        if (File.Exists(tmpFilePath))
        {
          File.Delete(tmpFilePath);
        }
      }
    }

    string CreateSampleFile(int lineCount)
    {
      var tmpFileName = Path.GetTempFileName();

      try
      {
        //
        // ����ȃt�@�C�����쐬����.
        //
        using (var writer = new StreamWriter(new BufferedStream(File.OpenWrite(tmpFileName))))
        {
          for (int i = 0; i < lineCount; i++)
          {
            writer.WriteLine(string.Format("gsf_zero{0}", i));
          }

          writer.Flush();
          writer.Close();
        }
      }
      catch
      {
        if (File.Exists(tmpFileName))
        {
          File.Delete(tmpFileName);
        }

        return string.Empty;
      }

      return tmpFileName;
    }
  }
  #endregion
}
