namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-41
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples41 : IExecutable
  {
    public void Execute()
    {
      //
      // Empty���\�b�h�́A�����ʂ��̃V�[�P���X���쐬���郁�\�b�h�ł���B
      // Union����ۂ�AAggregate����ۂ̒��Ԓl�Ƃ��ė��p����邱�Ƃ������B
      //
      Console.WriteLine("COUNT = {0}", Enumerable.Empty<string>().Count());

      //
      // �w�肳�ꂽ�V�[�P���X���獇�v�l��100�𒴂��Ă���V�[�P���X�݂̂𒊏o.
      // Aggregate��seed�l�Ƃ��āA��̃V�[�P���X��n�����߂�Enumerable.Empty��
      // �g�p���Ă���B
      //
      var sequences = new List<IEnumerable<int>> 
                { 
                  Enumerable.Range(1, 10), 
                  Enumerable.Range(30, 3), 
                  Enumerable.Range(50, 2),
                  Enumerable.Range(200, 1)
                };

      var query =
          sequences.Aggregate(
            Enumerable.Empty<int>(),
            (current, next) => next.Sum() > 100 ? current.Union(next) : current
          );

      foreach (var item in query)
      {
        Console.WriteLine(item);
      }
    }
  }
  #endregion
}
