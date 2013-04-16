namespace Gsf.Samples
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-16
  /// <summary>
  /// Linqのサンプルです。
  /// </summary>
  [Sample]
  public class LinqSamples16 : IExecutable
  {
    class Person
    {
      public int Id { get; set; }
      public string Name { get; set; }
    }

    class Customer : Person
    {
      public IEnumerable<Order> Orders { get; set; }
    }

    class Order
    {
      public int Id { get; set; }
      public int Quantity { get; set; }
    }

    public void Execute()
    {
      List<Person> persons = new List<Person>
        {
           new Person { Id = 1, Name = "gsf_zero1" }
          ,new Person { Id = 2, Name = "gsf_zero2" }
          ,new Customer { Id = 3, Name = "gsf_zero3", Orders = Enumerable.Empty<Order>() }
          ,new Customer 
             { 
               Id = 4
              ,Name = "gsf_zero4"
              ,Orders =  new List<Order>
                 {
                    new Order { Id = 1, Quantity = 10 }
                   ,new Order { Id = 2, Quantity = 2  }
                 }
             }
          ,new Person { Id = 5, Name = "gsf_zero5" }
        };

      //
      // OfTypeメソッドを利用することにより、特定の型のみのシーケンスに変換することができる。
      // 例えば、リストの中に基底クラスであるPersonクラスと派生クラスであるCustomerクラスの
      // オブジェクトが混在している場合、OfType<Person>とすると、そのまま。
      // OfType<Customer>とすると、Customerオブジェクトのみのシーケンスに変換される。
      //
      // 尚、OfTypeメソッドは他の変換演算子とは違い、ソースシーケンスのスナップショットを作成しない。
      // つまり、通常のクエリと同じく、OfTypeで取得したシーケンスが列挙される度に評価される。
      // 変換演算子の中で、このような動作を行うのはAsEnumerableとOfTypeとCastである。
      //
      Console.WriteLine("========== OfType<Person>の結果 ==========");
      foreach (var data in persons.OfType<Person>())
      {
        Console.WriteLine(data);
      }

      Console.WriteLine("========== OfType<Customer>の結果 ==========");
      foreach (var data in persons.OfType<Customer>())
      {
        Console.WriteLine(data);
      }

      /*
        IEnumerable<Customer> c = persons.OfType<Customer>();
        persons.Add(new Customer { Id = 99, Name = "gsf_zero3", Orders = Enumerable.Empty<Order>() });
        
        foreach (var data in c)
        {
          Console.WriteLine(data);
        }
      */

      //
      // 元々GenericではないリストをIEnumerable<T>に変換する場合にも利用出来る.
      //
      ArrayList arrayList = new ArrayList();
      arrayList.Add(10);
      arrayList.Add(20);
      arrayList.Add(30);
      arrayList.Add(40);

      Console.WriteLine("========== Genericではないコレクションを変換 ==========");
      IEnumerable<int> intList = arrayList.OfType<int>();
      foreach (var data in intList)
      {
        Console.WriteLine(data);
      }
    }
  }
  #endregion
}