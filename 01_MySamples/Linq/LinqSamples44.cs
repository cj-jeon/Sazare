namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-44
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples44 : IExecutable
  {
    public void Execute()
    {
      //
      // Skip�g�����\�b�h�́A�V�[�P���X�̐擪����w�肳�ꂽ���������X�L�b�v���郁�\�b�h�B
      //
      //   �E�V�[�P���X�̗v�f����葽�������w�肵���ꍇ�A��̃V�[�P���X���Ԃ�.
      //   �E0�ȉ��̒l���w�肵���ꍇ�A�V�[�P���X�̑S�Ă̗v�f���Ԃ�.
      //
      var names = new string[] { "gsf_zero1", "gsf_zero2", "gsf_zero3", "gsf_zero4", "gsf_zero5" };

      Console.WriteLine("================ Skip ===========================");
      var last2Elements = names.Skip(3);
      foreach (var item in last2Elements)
      {
        Console.WriteLine(item);
      }

      Console.WriteLine("�V�[�P���X�̗v�f���ȏ�̐����w��: COUNT={0}", names.Skip(20).Count());

      foreach (var item in names.Skip(-1))
      {
        Console.WriteLine(item);
      }

      //
      // SkipWhile�g�����\�b�h�́A�w�肳�ꂽ���������������ԃV�[�P���X����v�f�𒊏o��
      // �Ԃ����\�b�h�B
      //
      Console.WriteLine("================ SkipWhile ======================");
      var greaterThan4 = names.SkipWhile(name => int.Parse(name.Last().ToString()) <= 3);
      foreach (var item in greaterThan4)
      {
        Console.WriteLine(item);
      }
    }
  }
  #endregion
}
