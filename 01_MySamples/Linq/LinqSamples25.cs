namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-25
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples25 : IExecutable
  {
    class Person
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Team { get; set; }
      public string Project { get; set; }

      public override string ToString()
      {
        return string.Format("[ID={0}, NAME={1}]", Id, Name);
      }
    }

    public void Execute()
    {
      var persons = new List<Person>
                {
                  new Person{ Id = 1001, Name = "gsf_zero1", Team = "A", Project = "P1" },
                  new Person{ Id = 1000, Name = "gsf_zero2", Team = "B", Project = "P1" },
                  new Person{ Id = 111,  Name = "gsf_zero3", Team = "B", Project = "P2" },
                  new Person{ Id = 9889, Name = "gsf_zero4", Team = "C", Project = "P2" },
                  new Person{ Id = 9889, Name = "gsf_zero5", Team = "A", Project = "P1" },
                  new Person{ Id = 100,  Name = "gsf_zero6", Team = "C", Project = "P2" }
                };

      //
      // GroupBy�g�����\�b�h�́A�V�[�P���X�̗v�f���O���[�v������ۂɗ��p�ł���B
      // �N�G�����ɂāA[group xx by xx.xx]�Ƃ���ꍇ�A���s����GroupBy�g�����\�b�h�ɒu����������B
      //
      // �T�O�Ƃ��ẮASQL��GROUP BY�Ɠ����ł���B
      //
      // GroupBy�g�����\�b�h�ɂ́A�S����8�̃I�[�o�[���[�h�����݂���B
      // �悭���p�����̂́A�ȉ��̂��̂ƂȂ�Ǝv����B
      //
      //   �EkeySelector�݂̂��w�肷�����
      //   �EkeySelector��elementSelector���w�肷����́B
      //   �E�����L�[�ł̃O���[�v��
      //
      // GroupBy�g�����\�b�h�̖߂�l�́A
      //   IEnumerable<IGrouping<TKey, TElement>>
      // �ƂȂ�BIGrouping�C���^�[�t�F�[�X�́A�O���[�s���O��\���C���^�[�t�F�[�X�ł���
      // Key�v���p�e�B����`����Ă���B
      //
      // ���̃C���^�[�t�F�[�X���g���AIEnumerable�C���^�[�t�F�[�X���p�����Ă���̂�
      // �O���[�s���O���s�����ꍇ�́A�ȉ��̂悤�ɂ���2�d�̃��[�v�Ńf�[�^���擾����B
      //
      // var query = xxx.GroupBy(item => item.Key);
      // foreach (var group in query)
      // {
      //   Console.WriteLine(group.Key);
      //   foreach (var item in group)
      //   {
      //     Console.WriteLine(item);
      //   }
      // }
      //

      //
      // keySelector�݂̂��w��.
      //
      // �ȉ��̃N�G�����Ɠ����ƂȂ�B
      //   from  thePerson in persons
      //   group thePerson by thePerson.Team
      //
      Console.WriteLine("============ keySelector�݂̂�GroupBy ==============");
      var query1 = persons.GroupBy(thePerson => thePerson.Team);
      foreach (var group in query1)
      {
        Console.WriteLine("=== {0}", group.Key);
        foreach (var thePerson in group)
        {
          Console.WriteLine("\t{0}", thePerson);
        }
      }

      //
      // keySelector��elementSelector���w��.
      //
      // �ȉ��̃N�G�����Ɠ����ƂȂ�B
      //   from   thePerson in persons
      //   group  thePerson.Name by thePerson.Team
      //
      Console.WriteLine("\n============ elementSelector���w�肵��GroupBy ==============");
      var query2 = persons.GroupBy(thePerson => thePerson.Team, thePerson => thePerson.Name);
      foreach (var group in query2)
      {
        Console.WriteLine("=== {0}", group.Key);
        foreach (var name in group)
        {
          Console.WriteLine("\t{0}", name);
        }
      }

      //
      // �����L�[�ɂăO���[�v��.
      //
      // �ȉ��̃N�G�����Ɠ����ƂȂ�B
      //   from  thePerson in persons
      //   group thePerson by new { thePerson.Project, thePerson.Team }
      //
      Console.WriteLine("\n============ �����L�[���w�肵��GroupBy ==============");
      var query3 = persons.GroupBy(thePerson => new { thePerson.Project, thePerson.Team });
      foreach (var group in query3)
      {
        Console.WriteLine("=== {0}", group.Key);
        foreach (var thePerson in group)
        {
          Console.WriteLine("\t{0}", thePerson);
        }
      }

      //
      // �ȉ��̃N�G�����Ɠ����ƂȂ�B
      //   from  thePerson in persons
      //   group   thePerson by new { thePerson.Project, thePerson.Team } into p
      //   orderby p.Key.Project descending, p.Key.Team descending
      //   select  p;
      //
      Console.WriteLine("\n============ �����L�[��orderby���w�肵��GroupBy ==============");
      var query4 = persons
              .GroupBy(thePerson => new { thePerson.Project, thePerson.Team })
              .OrderByDescending(group => group.Key.Project)
              .ThenByDescending(group => group.Key.Team);

      foreach (var group in query4)
      {
        Console.WriteLine("=== {0}", group.Key);
        foreach (var thePerson in group)
        {
          Console.WriteLine("\t{0}", thePerson);
        }
      }
    }
  }
  #endregion
}
