namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-42
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples42 : IExecutable
  {
    class Language
    {
      public string Name { get; set; }

      public static Language Create(string name)
      {
        return new Language { Name = name };
      }
    }

    class LanguageNameComparer : EqualityComparer<Language>
    {
      public override bool Equals(Language l1, Language l2)
      {
        return (l1.Name == l2.Name);
      }

      public override int GetHashCode(Language l)
      {
        return l.Name.GetHashCode();
      }
    }

    public void Execute()
    {
      //
      // Contains���\�b�h�́A�w�肳�ꂽ�v�f���V�[�P���X���ɑ��݂��邩�ۂ���Ԃ��B
      //
      // IEqualityComparer<T>���w�肷��I�[�o�[���[�h�����݂���B
      //
      var names = new string[] { "csharp", "visualbasic", "java", "python", "ruby", "php" };
      Console.WriteLine("�v�f[python]�͑��݂���? = {0}", names.Contains("python"));

      //
      // IEqualityComparer<T>���w�肷��o�[�W����.
      //
      var languages = new Language[] 
                { 
                  Language.Create("csharp"), 
                  Language.Create("visualbasic"), 
                  Language.Create("java"),
                  Language.Create("python"),
                  Language.Create("ruby"),
                  Language.Create("php")
                };

      Console.WriteLine(
          "�v�f[python]�͑��݂���? = {0}",
          languages.Contains(Language.Create("python"), new LanguageNameComparer())
      );
    }
  }
  #endregion
}
