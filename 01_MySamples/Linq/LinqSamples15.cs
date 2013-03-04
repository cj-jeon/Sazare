namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-15
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples15 : IExecutable
  {
    class Person
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Team { get; set; }
    }

    public void Execute()
    {
      var persons = new List<Person>
        {
           new Person{ Id = 1, Name = "gsf_zero1", Team = "TeamA" }
          ,new Person{ Id = 2, Name = "gsf_zero2", Team = "TeamB" }
          ,new Person{ Id = 3, Name = "gsf_zero3", Team = "TeamA" }
          ,new Person{ Id = 4, Name = "gsf_zero4", Team = "TeamA" }
          ,new Person{ Id = 5, Name = "gsf_zero5", Team = "TeamB" }
          ,new Person{ Id = 6, Name = "gsf_zero6", Team = "TeamC" }
        };

      var query = from aPerson in persons
                  select aPerson;

      //
      // Team�̒l���L�[�Ƃ��āA�O���[�s���O����.
      // ����ɂ��A�e�L�[���ɍ��v����Person�I�u�W�F�N�g���R�t�����\���ɕϊ������B
      //
      // ���ۂ̃I�u�W�F�N�g�̌^��
      //   Lookup<Grouping<string, Person>>
      // �ƂȂ��Ă���B
      //
      // ���ALookup�I�u�W�F�N�g���O������V�K�ō\�z���邱�Ƃ͂ł��Ȃ��B
      //
      // �ȉ��ł́AkeySelector���w�肵�Ă���B
      ILookup<string, Person> lookup = query.ToLookup(aPerson => aPerson.Team);

      //
      // ILookup�ɒ�`����Ă���v���p�e�B�ɃA�N�Z�X.
      //   �ʏ�ALookup�I�u�W�F�N�g�̓��[�v���o�R���ăf�[�^���擾���邪�A�L�[���w�肵�āA�A�N�Z�X���邱�Ƃ��ł���B
      //
      Console.WriteLine("�J�E���g={0}", lookup.Count);
      foreach (Person teamAPerson in lookup["TeamA"])
      {
        Console.WriteLine(teamAPerson);
      }

      //
      // ILookup<TKey, TElement>�́AIEnumerable<IGrouping<TKey, TElement>>���p�����Ă���̂�
      // ���[�v�����邱�ƂŁAIGrouping<TKey, TElement>���擾���邱�Ƃ��ł���B
      //
      // ����IGrouping<TKey, TElement>����Α��̃}�b�s���O���������Ă���B
      // ���AIGrouping<TKey, TElement>�́A�N�G�����ɂ�group by���s�����ۂɂ��擾�ł���B
      //
      Console.WriteLine("=========== ToLookup�ɑ΂���keySelector���w�肵���� =============");
      foreach (IGrouping<string, Person> grouping in lookup)
      {
        Console.WriteLine("KEY={0}", grouping.Key);
        foreach (var aPerson in grouping)
        {
          Console.WriteLine("\tID={0}, NAME={1}", aPerson.Id, aPerson.Name);
        }
      }

      //
      // keySelector��elementSelector���w�肵�Ă݂�B
      //
      var lookup2 = query.ToLookup(aPerson => aPerson.Team, aPerson => string.Format("{0}_{1}", aPerson.Id, aPerson.Name));

      Console.WriteLine("=========== ToLookup�ɑ΂���keySelector��elementSelector���w�肵���� =============");
      foreach (var grouping in lookup2)
      {
        Console.WriteLine("KEY={0}", grouping.Key);
        foreach (var element in grouping)
        {
          Console.WriteLine("\t{0}", element);
        }
      }
    }
  }
  #endregion
}
