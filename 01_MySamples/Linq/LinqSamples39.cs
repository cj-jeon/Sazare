namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-39
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples39 : IExecutable
  {
    public void Execute()
    {
      var numbers = new int[] { 1, 2, 3 };

      // 
      // Any�g�����\�b�h�́A��ł������ɓ��Ă͂܂���̂����݂��邩�ۂ��𔻕ʂ��郁�\�b�h�ł���B
      // ���̊g�����\�b�h�́A���������̃o�[�W�����ƈ�����predicate��n���o�[�W�����̂Q�����݂���B
      //
      // ������n����Any�g�����\�b�h���Ă񂾏ꍇ�AAny�g�����\�b�h��
      // �Y���V�[�P���X�ɗv�f�����݂��邩�ۂ��݂̂Ŕ��f����B
      // �܂�A�v�f����ł����݂���ꍇ�́ATrue�ƂȂ�B
      //
      // ������predicate���w�肷��o�[�W�����́A�V�[�P���X�̊e�v�f�ɑ΂���predicate��K�p��
      // ��ł������ɍ��v������̂����݂������_�ŁATrue�ƂȂ�B
      //
      Console.WriteLine("=========== ����������Any�g�����\�b�h�𗘗p ===========");
      Console.WriteLine("�v�f�L��? = {0}", numbers.Any());
      Console.WriteLine("================================================");

      Console.WriteLine("=========== predicate���w�肵��Any�g�����\�b�h�𗘗p ===========");
      Console.WriteLine("�v�f�L��? = {0}", numbers.Any(item => item >= 5));
      Console.WriteLine("�v�f�L��? = {0}", numbers.Any(item => item <= 5));
      Console.WriteLine("================================================================");
    }
  }
  #endregion
}
