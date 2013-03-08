namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region PLinqSamples-02
  public class PLinqSamples02 : IExecutable
  {
    public void Execute()
    {
      // ����LINQ�ɂāA���̏�����ێ����ď�������ɂ�AsOrdered�𗘗p����B
      // AsOrdered���w�肵�Ă��Ȃ��ꍇ�A�ǂ̏����ŏ�������Ă����̂��͕ۏ؂���Ȃ��B
      var query1 = from x in Enumerable.Range(1, 20)
                   select Math.Pow(x, 2);

      foreach (var item in query1)
      {
        Console.WriteLine(item);
      }

      Console.WriteLine("===============");

      //
      // �ȉ��̂悤�ɁA���̃f�[�^�V�[�P���X��IEnumerable<T>�Ǝw�肵����ŕ���LINQ���s�����Ƃ��Ă�
      // ���񉻂���Ȃ��B���̂Ȃ�AIEnumerable<T>�ł́ALINQ�̓V�[�P���X���ɂ����v�f�����݂���̂���
      // ���ʂ��邱�Ƃ��o���Ȃ����߂ł���B
      //
      // ����LINQ�́A���̃V�[�P���X��Partioner�𗘗p���āA���̃T�C�Y�̃`�����N�ɕ�����
      // �������s���邽�߂̋@�\�ł��邽�߁A���̗v�f����������Ȃ��ꍇ�̓`�����N�ɕ����邱�Ƃ��o���Ȃ��B
      //
      // ���񏈗����s���ׂɂ́AToList��ToArray�Ȃǂ��s���ϊ����Ă��珈����i�߂邩
      // ParallelEnumerable.Range�𗘗p�����肷��Ƃ��܂������B
      //
      // �ȉ��̗�ł͕��񏈗����s���Ȃ��B
      //var query2 = from x in Enumerable.Range(1, 20).AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism)
      // �ȉ��̗�ł�LINQ�����X�g�̗v�f���𔻕ʂ��邱�Ƃ��o����̂ŁA���񏈗����s����B
      var query2 = from x in Enumerable.Range(1, 20).ToList().AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                   select Math.Pow(x, 2);

      foreach (var item in query2)
      {
        Console.WriteLine(item);
      }

      Console.WriteLine("===============");

      var query3 = from x in ParallelEnumerable.Range(1, 20).AsParallel().AsOrdered().WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                   select Math.Pow(x, 2);

      foreach (var item in query3)
      {
        Console.WriteLine(item);
      }

      Console.WriteLine("===============");
    }
  }
  #endregion
}
