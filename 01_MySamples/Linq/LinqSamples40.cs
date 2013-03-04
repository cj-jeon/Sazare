namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-40
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples40 : IExecutable
  {
    public void Execute()
    {
      //
      // All�g�����\�b�h�́A�V�[�P���X�̑S�v�f���w�肳�ꂽ�����ɍ��v���Ă��邩�ۂ��𔻕ʂ��郁�\�b�h�ł���B
      //
      // �����ɂ͏����Ƃ���predicate���w�肷��B
      // ���̃��\�b�h�́A�ΏۃV�[�P���X���̑S�v�f�������ɍ��v���Ă���ꍇ�̂�True��Ԃ��B
      // (�t��Any�g�����\�b�h�́A��ł����v������̂����݂������_��True�ƂȂ�B)
      //
      var names = new string[] { "gsf_zero1", "gsf_zero2", "gsf_zero3", "2222" };

      Console.WriteLine("All���\�b�h�̌��� = {0}", names.All(item => Char.IsDigit(item.Last())));
      Console.WriteLine("All���\�b�h�̌��� = {0}", names.All(item => item.StartsWith("g")));
      Console.WriteLine("All���\�b�h�̌��� = {0}", names.All(item => !string.IsNullOrEmpty(item)));
    }
  }
  #endregion
}
