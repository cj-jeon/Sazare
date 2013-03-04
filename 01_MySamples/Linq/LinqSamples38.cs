namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-38
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples38 : IExecutable
  {
    public void Execute()
    {
      //
      // Range�g�����\�b�h.
      // ���̊g�����\�b�h�́A�����ʂ�w�肳�ꂽ�͈͂̐��l�V�[�P���X�𐶐����Ă����B
      //
      Console.WriteLine("=============== Range�g�����\�b�h ================");

      int start = 0;
      int count = 20;
      foreach (var i in Enumerable.Range(start, count).Where(item => (item % 2) == 0))
      {
        Console.WriteLine(i);
      }
      Console.WriteLine("===============================================");

      //
      // Repeat�g�����\�b�h.
      // ���̊g�����\�b�h�́A�����ʂ�w�肳�ꂽ�񐔕��A�v�f���J��Ԃ��������Ă����B
      //
      Console.WriteLine("=============== Repeat�g�����\�b�h ================");

      foreach (var i in Enumerable.Repeat(100, 5))
      {
        Console.WriteLine(i);
      }

      foreach (var s in Enumerable.Repeat("gsf_zero1", 5))
      {
        Console.WriteLine(s);
      }

      Console.WriteLine("===============================================");
    }
  }
  #endregion
}
