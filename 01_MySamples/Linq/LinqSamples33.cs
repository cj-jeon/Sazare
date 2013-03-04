namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSample-33
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples33 : IExecutable
  {
    public void Execute()
    {
      var numbers = new int[]
                {
                  1, 2, 3, 4, 5
                };

      // 
      // Sum�g�����\�b�h�́A�����ʂ荇�v�����߂�g�����\�b�h�B
      //
      // Sum�g�����\�b�h�ɂ́A�e��{�^�̃I�[�o�[���[�h���p�ӂ���Ă���
      // (decimal, double, int, long, single�y�т��ꂼ���Nullable�^)
      // ���ꂼ��ɁA����������selector���w�肷��o�[�W�����̃��\�b�h������B
      //

      //
      // ����������Sum�g�����\�b�h�̎g�p.
      //
      Console.WriteLine("�������� = {0}", numbers.Sum());

      //
      // selector���w�肷��Sum�g�����\�b�h�̎g�p.
      //
      Console.WriteLine("�����L�� = {0}", numbers.Sum(item => (item % 2 == 0) ? item : 0));
    }
  }
  #endregion
}
