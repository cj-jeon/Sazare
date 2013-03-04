namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-45
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples45 : IExecutable
  {
    public void Execute()
    {
      var languages = new string[] { "csharp", "visualbasic", "java", "python", "ruby", "php", "c++" };

      //
      // First�g�����\�b�h�́A�V�[�P���X�̍ŏ��̗v�f��Ԃ����\�b�h�B
      //
      // predicate���w�肵���ꍇ�́A���̏����ɍ��v����ŏ��̗v�f���Ԃ�B
      //
      Console.WriteLine("============ First ============");
      Console.WriteLine(languages.First());
      Console.WriteLine(languages.First(item => item.StartsWith("v")));

      //
      // Last�g�����\�b�h�́A�V�[�P���X�̍Ō�̗v�f��Ԃ����\�b�h�B
      //
      // predicate���w�肵���ꍇ�́A���̏����ɍ��v����Ō�̗v�f���Ԃ�B
      //
      Console.WriteLine("============ Last ============");
      Console.WriteLine(languages.Last());
      Console.WriteLine(languages.Last(item => item.StartsWith("p")));

      //
      // Single�g�����\�b�h�́A�V�[�P���X�̗B��̗v�f��Ԃ����\�b�h�B
      //
      // Single�𗘗p����ꍇ�A�ΏۂƂȂ�V�[�P���X�ɂ͗v�f�������
      // �łȂ��Ƃ����Ȃ��B�����̗v�f�����݂���ꍇ��O����������B
      //
      // �܂��A��̃V�[�P���X�ɑ΂���Single���ĂԂƗ�O����������B
      //
      // predicate���w�肵���ꍇ�́A���̏����ɍ��v����V�[�P���X�̗B���
      // �v�f���Ԃ����B���̏ꍇ���A���ʂ̃V�[�P���X�ɂ͗v�f���������
      // ��Ԃł���K�v������B�����ɍ��v����v�f�������ł���Ɨ�O����������A
      //
      Console.WriteLine("============ Single ============");
      var onlyOne = new string[] { "csharp" };
      Console.WriteLine(onlyOne.Single());

      try
      {
        languages.Single();
      }
      catch
      {
        Console.WriteLine("�����̗v�f�����݂����Ԃ�Single���ĂԂƗ�O����������B");
      }

      Console.WriteLine(languages.Single(item => item.EndsWith("y")));

      try
      {
        languages.Single(item => item.StartsWith("p"));
      }
      catch
      {
        Console.WriteLine("�����ɍ��v����v�f���������݂���ꍇ��O����������B");
      }
    }
  }
  #endregion
}
