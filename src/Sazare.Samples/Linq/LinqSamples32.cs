namespace Sazare.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-32
  /// <summary>
  /// Linqのサンプルです。
  /// </summary>
  [Sample]
  public class LinqSamples32 : IExecutable
  {
    class Person
    {
      public string Name { get; set; }

      public override string ToString()
      {
        return string.Format("[NAME={0}]", Name);
      }
    }

    public void Execute()
    {
      var people = new Person[]
               {
                 new Person{ Name = "gsf_zero1" },
                 new Person{ Name = "gsf_zero2" },
                 new Person{ Name = "gsf_zero3" },
                 new Person{ Name = "gsf_zero4" }
               };

      //
      // Count拡張メソッドは、シーケンスの要素数を取得するメソッドである。
      //
      // Count拡張メソッドには、predicateを指定できるオーバーロードが存在し
      // それを利用すると、特定の条件に一致するデータのみの件数を求める事が出来る。
      //
      // 尚、非常に多くの件数を返す可能性がある場合は、Countの代わりにLongCount拡張メソッドを
      // 使用する。使い方は、Count拡張メソッドと同じ。



      //
      // predicate無しで実行. 
      //
      Console.WriteLine("COUNT = {0}", people.Count());

      //
      // predicate有りで実行.
      //
      Console.WriteLine("COUNT = {0}", people.Count(person => int.Parse(person.Name.Last().ToString()) % 2 == 0));

      //
      // predicate無しで実行.（LongCount)
      //
      Console.WriteLine("COUNT = {0}", people.LongCount());

      //
      // predicate有りで実行.（LongCount)
      //
      Console.WriteLine("COUNT = {0}", people.LongCount(person => int.Parse(person.Name.Last().ToString()) % 2 == 0));
    }
  }
  #endregion
}
