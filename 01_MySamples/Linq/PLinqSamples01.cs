namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;

  #region PLinqSamples-01
  public class PLinqSamples01 : IExecutable
  {
    public void Execute()
    {
      byte[] numbers = GetRandomNumbers();

      Stopwatch watch = Stopwatch.StartNew();

      // ���ʂ�LINQ
      // var query1 = from x in numbers
      // ����LINQ�i�P�j�iExecutionMode��t�^���Ă��Ȃ��̂ŁA����Ŏ��s���邩�ۂ���TPL�����肷��j
      // var query1 = from x in numbers.AsParallel()
      // ����LINQ�i�Q�j�iExecutionMode��t�^���Ă���̂ŁA�����I�ɕ���Ŏ��s����悤�w���j
      var query1 = from x in numbers.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                   select Math.Pow(x, 2);

      foreach (var item in query1)
      {
        Console.WriteLine(item);
      }

      watch.Stop();
      Console.WriteLine(watch.Elapsed);
    }

    byte[] GetRandomNumbers()
    {
      byte[] result = new byte[10];
      Random rnd = new Random();

      rnd.NextBytes(result);

      return result;
    }
  }
  #endregion
}
