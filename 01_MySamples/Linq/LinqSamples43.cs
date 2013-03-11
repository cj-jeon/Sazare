namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-43
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples43 : IExecutable
  {
    public void Execute()
    {
      //
      // Take�g�����\�b�h�́A�V�[�P���X�̐擪����w�肳�ꂽ��������Ԃ����\�b�h�B
      //
      //   �E�V�[�P���X�̗v�f����葽�������w�肵���ꍇ�A���̃V�[�P���X�S�Ă��Ԃ�.
      //   �E0�ȉ��̒l���w�肵���ꍇ�A��̃V�[�P���X���Ԃ�.
      //
      var names = new string[] { "gsf_zero1", "gsf_zero2", "gsf_zero3", "gsf_zero4", "gsf_zero5" };

      Console.WriteLine("================ Take ======================");
      var top3 = names.Take(3);
      foreach (var item in top3)
      {
        Console.WriteLine(item);
      }

      foreach (var item in names.Take(20))
      {
        Console.WriteLine(item);
      }

      Console.WriteLine("0�ȉ��̐��l���w��: COUNT={0}", names.Take(-1).Count());

      //
      // TakeWhile�g�����\�b�h�́A�w�肳�ꂽ���������������ԃV�[�P���X����v�f�𒊏o��
      // �Ԃ����\�b�h�B
      //
      Console.WriteLine("================ TakeWhile ======================");
      var lessThan4 = names.TakeWhile(name => int.Parse(name.Last().ToString()) <= 4);
      foreach (var item in lessThan4)
      {
        Console.WriteLine(item);
      }
    }
  }
  #endregion
}
