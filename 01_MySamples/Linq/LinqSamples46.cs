namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-46
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples46 : IExecutable
  {
    public void Execute()
    {
      //
      // FirstOrDefault�g�����\�b�h�́AFirst�g�����\�b�h�Ɠ������������B
      // �Ⴂ�́A�V�[�P���X�ɗv�f�����݂��Ȃ��ꍇ�ɋK��l��Ԃ��_�ł���B
      //
      var emptySequence = Enumerable.Empty<string>();
      var languages = new string[] { "csharp", "visualbasic", "java", "python", "ruby", "php", "c++" };

      try
      {
        // First�g�����\�b�h�͗v�f�����݂��Ȃ��ꍇ��O����������.
        emptySequence.First();
      }
      catch
      {
        Console.WriteLine("First�g�����\�b�h�ŗ�O����");
      }

      Console.WriteLine("FirstOrDefault�̏ꍇ: {0}", emptySequence.FirstOrDefault() ?? "null");
      Console.WriteLine("FirstOrDefault�̏ꍇ(predicate): {0}", languages.FirstOrDefault(item => item.EndsWith("z")) ?? "null");

      //
      // LastOrDefault�g�����\�b�h�́ALast�g�����\�b�h�Ɠ������������B
      // �Ⴂ�́A�V�[�P���X�ɗv�f�����݂��Ȃ��ꍇ�ɋK��l��Ԃ��_�ł���B
      //
      try
      {
        // Last�g�����\�b�h�͗v�f�����݂��Ȃ��ꍇ��O����������.
        emptySequence.Last();
      }
      catch
      {
        Console.WriteLine("Last�g�����\�b�h�ŗ�O����");
      }

      Console.WriteLine("LastOrDefault�̏ꍇ: {0}", emptySequence.LastOrDefault() ?? "null");
      Console.WriteLine("LastOrDefault�̏ꍇ(predicate): {0}", languages.LastOrDefault(item => item.EndsWith("z")) ?? "null");

      //
      // SingleOrDefault�g�����\�b�h�́ASingle�g�����\�b�h�Ɠ������������B
      // �Ⴂ�́A�V�[�P���X�ɗv�f�����݂��Ȃ��ꍇ�ɋK��l��Ԃ��_�ł���B
      //
      try
      {
        // Last�g�����\�b�h�͗v�f�����݂��Ȃ��ꍇ��O����������.
        emptySequence.Single();
      }
      catch
      {
        Console.WriteLine("Single�g�����\�b�h�ŗ�O����");
      }

      Console.WriteLine("SingleOrDefault�̏ꍇ: {0}", emptySequence.SingleOrDefault() ?? "null");
      Console.WriteLine("SingleOrDefault�̏ꍇ(predicate): {0}", languages.SingleOrDefault(item => item.EndsWith("z")) ?? "null");

      //
      // DefaultIfEmpty�g�����\�b�h�́A�V�[�P���X����̏ꍇ�ɋK��l��Ԃ����\�b�h�B
      //
      // �V�[�P���X�ɗv�f�����݂���ꍇ�́A���̂܂܂̏�ԂŕԂ��B
      // LINQ�ɂĊO���������s���ۂɕK�{�ƂȂ郁�\�b�h�B
      //
      Console.WriteLine("================ DefaultIfEmpty ====================");

      var emptyIntegers = Enumerable.Empty<int>();
      foreach (var item in emptyIntegers.DefaultIfEmpty())
      {
        Console.WriteLine("��{�^�̏ꍇ: {0}", item);
      }

      foreach (var item in emptySequence.DefaultIfEmpty())
      {
        Console.WriteLine("�Q�ƌ^�̏ꍇ: {0}", item ?? "null");
      }

      foreach (var item in languages.DefaultIfEmpty())
      {
        Console.WriteLine(item ?? "null");
      }

      foreach (var item in emptySequence.DefaultIfEmpty("�f�t�H���g�l"))
      {
        Console.WriteLine(item ?? "null");
      }
    }
  }
  #endregion
}
