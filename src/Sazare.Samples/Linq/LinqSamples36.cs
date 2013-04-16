namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-36
  /// <summary>
  /// Linqのサンプルです。
  /// </summary>
  [Sample]
  public class LinqSamples36 : IExecutable
  {
    public void Execute()
    {
      //
      // Zip拡張メソッド.
      //
      // Zip拡張メソッドは、Pythonのzip関数と同じ動きをするものである。
      // つまり、2つのシーケンスを同時にループさせることが出来る。
      //
      // 第二引数には、resultSelectorを指定する必要があり、好きなデータを返す事ができる。
      //
      // このメソッドは、どちらかのシーケンスが終わるまで処理を続けるという仕様になっているので
      // ２つのシーケンスの要素数が異なる場合は、注意が必要である。
      //
      // つまり、片方のシーケンスが空の場合、このメソッドは一度もループされない。
      //
      IEnumerable<int> numbers1 = new int[] { 1, 2, 3, 4, 5 };
      IEnumerable<int> numbers2 = new int[] { 6, 7, 8, 9, 0 };

      var query = numbers1.Zip(numbers2, (first, second) => Tuple.Create(first, second));

      Console.WriteLine("========= 2つのシーケンスの要素数が同じ場合 ===========");
      foreach (var item in query)
      {
        Console.WriteLine("FIRST={0}, SECOND={1}", item.Item1, item.Item2);
      }

      numbers1 = new int[] { 1, 2, 3 };
      numbers2 = new int[] { 6, 7, 8, 9, 0 };

      query = numbers1.Zip(numbers2, (first, second) => Tuple.Create(first, second));

      Console.WriteLine("========= 1つ目のシーケンスの要素が2つ目よりも少ない場合 ===========");
      foreach (var item in query)
      {
        Console.WriteLine("FIRST={0}, SECOND={1}", item.Item1, item.Item2);
      }

      numbers1 = new int[] { 1, 2, 3, 4, 5 };
      numbers2 = new int[] { 6, 7, 8 };

      query = numbers1.Zip(numbers2, (first, second) => Tuple.Create(first, second));

      Console.WriteLine("========= 2つ目のシーケンスの要素が1つ目よりも少ない場合 ===========");
      foreach (var item in query)
      {
        Console.WriteLine("FIRST={0}, SECOND={1}", item.Item1, item.Item2);
      }

      numbers1 = Enumerable.Empty<int>();
      numbers2 = new int[] { 6, 7, 8 };

      query = numbers1.Zip(numbers2, (first, second) => Tuple.Create(first, second));

      Console.WriteLine("========= どちらかのシーケンスが空の場合 ===========");
      foreach (var item in query)
      {
        Console.WriteLine("FIRST={0}, SECOND={1}", item.Item1, item.Item2);
      }
    }
  }
  #endregion
}