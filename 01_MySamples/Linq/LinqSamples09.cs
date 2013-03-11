namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-09
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples09 : IExecutable
  {
    public class Person
    {
      public string Id
      {
        get;
        set;
      }
      public string Name
      {
        get;
        set;
      }
      public int Age
      {
        get;
        set;
      }
      public DateTime Birthday
      {
        get;
        set;
      }
    }

    public class Team
    {
      public string Id
      {
        get;
        set;
      }
      public string Name
      {
        get;
        set;
      }
      public IEnumerable<string> Members
      {
        get;
        set;
      }
    }

    public enum ProjectState
    {
      NotStarted
     ,
      Processing
        ,
      Done
    }

    public class Project
    {
      public string Id
      {
        get;
        set;
      }
      public string Name
      {
        get;
        set;
      }
      public IEnumerable<string> Members
      {
        get;
        set;
      }
      public DateTime From
      {
        get;
        set;
      }
      public DateTime? To
      {
        get;
        set;
      }
      public ProjectState State
      {
        get;
        set;
      }
    }

    // �����o�[
    IEnumerable<Person> persons =
                new[]{
                     new Person
                     {
                        Id   = "001"
                       ,Name = "gsf_zero1"
                       ,Age  = 30
                       ,Birthday = new DateTime(1979, 11, 18)
                     }
                    ,new Person
                    {
                        Id   = "002"
                       ,Name = "gsf_zero2"
                       ,Age  = 20
                       ,Birthday = new DateTime(1989, 11, 18)
                     }
                    ,new Person
                    {
                        Id   = "003"
                       ,Name = "gsf_zero3"
                       ,Age  = 18
                       ,Birthday = new DateTime(1991, 11, 18)
                    }
                    ,new Person
                    {
                        Id   = "004"
                       ,Name = "gsf_zero4"
                       ,Age  = 40
                       ,Birthday = new DateTime(1969, 11, 18)
                    }
                    ,new Person
                    {
                        Id   = "005"
                       ,Name = "gsf_zero5"
                       ,Age  = 44
                       ,Birthday = new DateTime(1965, 11, 18)
                    }
                  };

    // �`�[��
    IEnumerable<Team> teams =
                new[]{
                     new Team
                     {
                        Id    = "001"
                       ,Name  = "team_1"
                       ,Members = new []{ "001", "004" }
                     }
                    ,new Team
                    {
                        Id    = "002"
                       ,Name  = "team_2"
                       ,Members = new []{ "002", "003" }
                     }
                  };

    // �v���W�F�N�g
    IEnumerable<Project> projects =
                new[]{
                     new Project
                     {
                        Id    = "001"
                       ,Name  = "project_1"
                       ,Members = new []{ "001", "002" }
                       ,From  = new DateTime(2009, 8, 1)
                       ,To    = new DateTime(2009, 10, 15)
                       ,State   = ProjectState.Done
                     }
                    ,new Project
                    {
                        Id    = "002"
                       ,Name  = "project_2"
                       ,Members = new []{ "003", "004" }
                       ,From  = new DateTime(2009, 9, 1)
                       ,To    = new DateTime(2009, 11, 25)
                       ,State   = ProjectState.Done
                     }
                    ,new Project
                    {
                        Id    = "003"
                       ,Name  = "project_3"
                       ,Members = new []{ "001" }
                       ,From  = new DateTime(2007, 1, 10)
                       ,To    = null
                       ,State   = ProjectState.Processing
                     }
                    ,new Project
                    {
                        Id    = "004"
                       ,Name  = "project_4"
                       ,Members = new []{ "001", "002", "003", "004" }
                       ,From  = new DateTime(2010, 1, 5)
                       ,To    = null
                       ,State   = ProjectState.NotStarted
                     }
                  };

    public void Execute()
    {
      //
      // join��p������������(INNER JOIN)�̃T���v��.
      //
      // join�L�[���[�h�̍\���͈ȉ��̒ʂ�.
      //    join �������̕ϐ� in �������̃V�[�P���X on �O�����̃L�[ equals �������̃L�[
      //
      // Linq��join�ł͓������i�܂蓙�l�̏ꍇ�̌����j�݂̂��s����B
      //
      //====================================================================================
      // Team����H��p�^�[��
      var query1 = from team in teams
                   from personId in team.Members
                   join person in persons on personId equals person.Id
                   orderby team.Id ascending, person.Id ascending
                   select new
                   {
                     Team = team.Name
                    ,
                     Person = person.Name
                   };

      Console.WriteLine("=========================================");
      foreach (var item in query1)
      {
        Console.WriteLine(item);
      }

      //
      // Person����H��p�^�[��.
      // join�L�[���[�h�𗘗p�����Ɏ蓮�Ō�������.
      //
      // ���̏ꍇ�A��L�Ɠ����悤��
      //
      // from person   in persons
      // from team   in teams
      // join personId in team.Members on person.Id equals personId
      //
      // �Ƃ���ƁA�R���e�X�g���Ⴄ�Ƃ����G���[�ƂȂ�B
      // ����́Ajoin�����ŐV���ȃR���e�L�X�g���������邩��ł���B
      // query1�ł́A�������̃V�[�P���X��join���������ŗ��p���Ă����̂�
      // ���Ȃ�.
      //
      var query2 = from person in persons
                   from team in teams
                   where team.Members.Contains(person.Id)
                   orderby team.Id ascending, person.Id ascending
                   select new
                   {
                     Team = team.Name
                     ,
                     Person = person.Name
                   };

      Console.WriteLine("=========================================");
      foreach (var item in query2)
      {
        Console.WriteLine(item);
      }

      //
      // query2��join�Ŏ��߂�p�^�[��.
      //
      // ��L�̗��join�Ɏ��߂邽�߂ɂ́Ajoin���ŖړI�̃V�[�P���X��
      // �\�z����K�v������B���̂��߁A�ȉ��̗�ł͖ړI�̃V�[�P���X���쐬���邽�߂�
      // join���ɂāA����ɃT�u�N�G�����쐬���Ă���B
      //
      var query3 = from person in persons
                   join team in
                     (
                       from team in teams
                       from member in team.Members
                       select new
                       {
                         Id = team.Id
                         ,
                         Name = team.Name
                         ,
                         PersonId = member
                       }
                       ) on person.Id equals team.PersonId
                   orderby team.Id ascending, person.Id ascending
                   select new
                   {
                     Team = team.Name
                     ,
                     Person = person.Name
                   };

      Console.WriteLine("=========================================");
      foreach (var item in query3)
      {
        Console.WriteLine(item);
      }

      //
      // CROSS JOIN.
      //
      // ���ʂ�from����ׂ��CROSS JOIN��ԂƂȂ�B
      //
      var query4 = from person in persons
                   from team in teams
                   orderby team.Id ascending, person.Id ascending
                   select new
                   {
                     Team = team.Name
                     ,
                     Person = person.Name
                   };

      Console.WriteLine("=========================================");
      foreach (var item in query4)
      {
        Console.WriteLine(item);
      }
    }
  }
  #endregion
}
