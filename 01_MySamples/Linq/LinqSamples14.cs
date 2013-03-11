namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-14
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples14 : IExecutable
  {
    class Person
    {
      public int Id { get; set; }
      public string Name { get; set; }

      public override string ToString()
      {
        return string.Format("[{0}, {1}]", Id, Name);
      }
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
      // ToDictionary�𗘗p���āA�����I�Ƀ}�b�v�ɕϊ�.
      // (���̃^�C�~���O�ŃN�G�����]������A���ʂ��\�z�����B)
      //
      // ToDictionary�́A�L�[�v�f�𒊏o���邽�߂̈�����v������B(keySelector)
      // ������keySelector�݂̂��w�肵�Ă���ꍇ�A�}�b�v�̒l�͂��̃I�u�W�F�N�g���g�ƂȂ�B
      //   �L�[�Fint32�^ (Person.Id)
      //   �l�@�FPerson�I�u�W�F�N�g
      //
      // ���̂ق��ɂ��AelementSelector���w�肷��I�[�o�[���[�h�����݂���B
      //
      Dictionary<int, Person> filteredPersons = query.ToDictionary(item => item.Id);

      Console.WriteLine("============ ToDictionary�ō쐬�������X�g��\�� ============");
      foreach (var pair in filteredPersons)
      {
        Console.WriteLine("KEY={0}, VALUE={1}", pair.Key, pair.Value);
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

      Console.WriteLine("============ ToDictionary�ō쐬�������X�g��\�� �i2��ځj============");
      foreach (var pair in filteredPersons)
      {
        Console.WriteLine("KEY={0}, VALUE={1}", pair.Key, pair.Value);
      }

      //
      // ToDictionary���\�b�h��keySelector��elementSelector���w�肵���o�[�W����.
      //
      Console.WriteLine("============ keySelector��elementSelector�̗������w�肵���o�[�W���� ============");
      foreach (var pair in query.ToDictionary(item => item.Id, item => string.Format("{0}_{1}", item.Id, item.Name)))
      {
        Console.WriteLine("KEY={0}, VALUE={1}", pair.Key, pair.Value);
      }
    }
  }
  #endregion
}
