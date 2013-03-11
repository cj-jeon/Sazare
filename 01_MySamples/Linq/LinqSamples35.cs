namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-35
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples35 : IExecutable
  {
    public void Execute()
    {
      var numbers = new int[]
                {
                  1, 2, 3, 4, 5, 6, 7, 8, 9, 10
                };

      // 
      // Average�g�����\�b�h�́A�����ʂ蕽�ς����߂�g�����\�b�h�B
      //
      // Average�g�����\�b�h�ɂ́A�e��{�^�̃I�[�o�[���[�h���p�ӂ���Ă���
      // (decimal, double, int, long, single�y�т��ꂼ���Nullable�^)
      // ���ꂼ��ɁA����������selector���w�肷��o�[�W�����̃��\�b�h������B
      //

      //
      // ����������Average�g�����\�b�h�̎g�p.
      //
      Console.WriteLine("�������� = {0}", numbers.Average());

      //
      // selector���w�肷��Average�g�����\�b�h�̎g�p.
      //
      Console.WriteLine("�����L�� = {0}", numbers.Average(item => (item % 2 == 0) ? item : 0));
    }
  }
  #endregion
}
