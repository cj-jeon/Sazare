namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-36
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples36 : IExecutable
  {
    public void Execute()
    {
      //
      // Zip�g�����\�b�h.
      //
      // Zip�g�����\�b�h�́APython��zip�֐��Ɠ���������������̂ł���B
      // �܂�A2�̃V�[�P���X�𓯎��Ƀ��[�v�����邱�Ƃ��o����B
      //
      // �������ɂ́AresultSelector���w�肷��K�v������A�D���ȃf�[�^��Ԃ������ł���B
      //
      // ���̃��\�b�h�́A�ǂ��炩�̃V�[�P���X���I���܂ŏ����𑱂���Ƃ����d�l�ɂȂ��Ă���̂�
      // �Q�̃V�[�P���X�̗v�f�����قȂ�ꍇ�́A���ӂ��K�v�ł���B
      //
      // �܂�A�Е��̃V�[�P���X����̏ꍇ�A���̃��\�b�h�͈�x�����[�v����Ȃ��B
      //
      IEnumerable<int> numbers1 = new int[] { 1, 2, 3, 4, 5 };
      IEnumerable<int> numbers2 = new int[] { 6, 7, 8, 9, 0 };

      var query = numbers1.Zip(numbers2, (first, second) => Tuple.Create(first, second));

      Console.WriteLine("========= 2�̃V�[�P���X�̗v�f���������ꍇ ===========");
      foreach (var item in query)
      {
        Console.WriteLine("FIRST={0}, SECOND={1}", item.Item1, item.Item2);
      }

      numbers1 = new int[] { 1, 2, 3 };
      numbers2 = new int[] { 6, 7, 8, 9, 0 };

      query = numbers1.Zip(numbers2, (first, second) => Tuple.Create(first, second));

      Console.WriteLine("========= 1�ڂ̃V�[�P���X�̗v�f��2�ڂ������Ȃ��ꍇ ===========");
      foreach (var item in query)
      {
        Console.WriteLine("FIRST={0}, SECOND={1}", item.Item1, item.Item2);
      }

      numbers1 = new int[] { 1, 2, 3, 4, 5 };
      numbers2 = new int[] { 6, 7, 8 };

      query = numbers1.Zip(numbers2, (first, second) => Tuple.Create(first, second));

      Console.WriteLine("========= 2�ڂ̃V�[�P���X�̗v�f��1�ڂ������Ȃ��ꍇ ===========");
      foreach (var item in query)
      {
        Console.WriteLine("FIRST={0}, SECOND={1}", item.Item1, item.Item2);
      }

      numbers1 = Enumerable.Empty<int>();
      numbers2 = new int[] { 6, 7, 8 };

      query = numbers1.Zip(numbers2, (first, second) => Tuple.Create(first, second));

      Console.WriteLine("========= �ǂ��炩�̃V�[�P���X����̏ꍇ ===========");
      foreach (var item in query)
      {
        Console.WriteLine("FIRST={0}, SECOND={1}", item.Item1, item.Item2);
      }
    }
  }
  #endregion
}
