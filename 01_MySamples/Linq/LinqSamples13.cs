namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-13
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
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

      Console.WriteLine("============ �N�G����\�� ============");
      foreach (var aPerson in query)
      {
        Console.WriteLine("ID={0}, NAME={1}", aPerson.Id, aPerson.Name);
      }

      //
      // ToList�𗘗p���āA�����I�Ƀ��X�g�ɕϊ�.
      // (���̃^�C�~���O�ŃN�G�����]������A���ʂ��\�z�����B)
      //
      List<Person> filteredPersons = query.ToList();

      Console.WriteLine("============ ToList�ō쐬�������X�g��\�� ============");
      foreach (var aPerson in filteredPersons)
      {
        Console.WriteLine("ID={0}, NAME={1}", aPerson.Id, aPerson.Name);
      }

      //
      // ���̃��X�g��ύX.
      //
      persons.Add(new Person { Id = 6, Name = "gsf_zero6" });
      persons.Add(new Person { Id = 7, Name = "gsf_zero7" });

      //
      // ������x�A�e���ʂ�\��.
      //
      Console.WriteLine("============ �N�G����\���i2��ځj ============");
      foreach (var aPerson in query)
      {
        Console.WriteLine("ID={0}, NAME={1}", aPerson.Id, aPerson.Name);
      }

      Console.WriteLine("============ ToList�ō쐬�������X�g��\�� �i2��ځj============");
      foreach (var aPerson in filteredPersons)
      {
        Console.WriteLine("ID={0}, NAME={1}", aPerson.Id, aPerson.Name);
      }
    }
  }
  #endregion
}
