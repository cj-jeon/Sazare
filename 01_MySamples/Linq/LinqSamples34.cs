namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-34
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples34 : IExecutable
  {
    public void Execute()
    {
      var numbers = new int[]
                {
                  1, 2, 3, 4, 5, 0, 10, 98, 99
                };

      // 
      // Min, Max�g�����\�b�h�́A�����ʂ�ŏ��l�A�ő�l�����߂�g�����\�b�h�B
      //
      // Min, Max�g�����\�b�h�ɂ́A�e��{�^�̃I�[�o�[���[�h���p�ӂ���Ă���
      // (decimal, double, int, long, single�y�т��ꂼ���Nullable�^)
      // ���ꂼ��ɁA����������selector���w�肷��o�[�W�����̃��\�b�h������B
      //

      //
      // ����������Min, Max�g�����\�b�h�̎g�p.
      //
      Console.WriteLine("��������[Min] = {0}", numbers.Min());
      Console.WriteLine("��������[Max] = {0}", numbers.Max());

      //
      // selector���w�肷��Min, Max�g�����\�b�h�̎g�p.
      //
      Console.WriteLine("�����L��[Min] = {0}", numbers.Min(item => (item % 2 == 0) ? item : 0));
      Console.WriteLine("�����L��[Max] = {0}", numbers.Max(item => (item % 2 == 0) ? item : 0));
    }
  }
  #endregion
}
