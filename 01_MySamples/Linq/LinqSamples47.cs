namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSample-47
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples47 : IExecutable
  {
    public void Execute()
    {
      //
      // ElementAt�g�����\�b�h�́A�w�肵���ʒu�̗v�f���擾���郁�\�b�h�B
      //
      // �͈͊O�̃C���f�b�N�X���w�肵���ꍇ�͗�O����������.
      //
      var languages = new string[] { "csharp", "visualbasic", "java", "python", "ruby", "php", "c++" };
      Console.WriteLine(languages.ElementAt(1));

      try
      {
        languages.ElementAt(100);
      }
      catch (ArgumentOutOfRangeException)
      {
        Console.WriteLine("�v�f�͈̔͊O�̃C���f�b�N�X���w�肵�Ă���B");
      }

      //
      // ElementAtOrDefault�g�����\�b�h�́AElementAt�g�����\�b�h�Ɠ��������
      // ���Ȃ���A�͈͊O�̃C���f�b�N�X���w�肳�ꂽ�ꍇ�ɋK��l��Ԃ����\�b�h�B
      //
      Console.WriteLine(languages.ElementAtOrDefault(-1) ?? "null");
      Console.WriteLine(languages.ElementAtOrDefault(100) ?? "null");
    }
  }
  #endregion
}
