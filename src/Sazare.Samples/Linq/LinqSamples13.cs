namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-13
  /// <summary>
  /// Linqのサンプルです。
  /// </summary>
  [Sample]
  public class LinqSamples13 : IExecutable
  {
    class Person
    {
      public int Id { get; set; }
      public string Name { get; set; }
    }

    public void Execute()
    {
      var persons = new List<Person>
        {
           new Person{ Id = 1, Name = "gsf_zero1" }
          ,new Person{ Id = 2, Name = "gsf_zero2" }
          ,new Person{ Id = 3, Name = "gsf_zero3" }
          ,new Person{ Id = 4, Name = "gsf_zero4" }
          ,new Person{ Id = 5, Name = "gsf_zero5" }
        };

      var query = from aPerson in persons
                  where (aPerson.Id % 2) != 0
                  select aPerson;

      Console.WriteLine("============ クエリを表示 ============");
      foreach (var aPerson in query)
      {
        Console.WriteLine("ID={0}, NAME={1}", aPerson.Id, aPerson.Name);
      }

      //
      // ToListを利用して、明示的にリストに変換.
      // (このタイミングでクエリが評価され、結果が構築される。)
      //
      List<Person> filteredPersons = query.ToList();

      Console.WriteLine("============ ToListで作成したリストを表示 ============");
      foreach (var aPerson in filteredPersons)
      {
        Console.WriteLine("ID={0}, NAME={1}", aPerson.Id, aPerson.Name);
      }

      //
      // 元のリストを変更.
      //
      persons.Add(new Person { Id = 6, Name = "gsf_zero6" });
      persons.Add(new Person { Id = 7, Name = "gsf_zero7" });

      //
      // もう一度、各結果を表示.
      //
      Console.WriteLine("============ クエリを表示（2回目） ============");
      foreach (var aPerson in query)
      {
        Console.WriteLine("ID={0}, NAME={1}", aPerson.Id, aPerson.Name);
      }

      Console.WriteLine("============ ToListで作成したリストを表示 （2回目）============");
      foreach (var aPerson in filteredPersons)
      {
        Console.WriteLine("ID={0}, NAME={1}", aPerson.Id, aPerson.Name);
      }
    }
  }
  #endregion
}