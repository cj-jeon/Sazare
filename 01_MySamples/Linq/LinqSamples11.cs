namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-11
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples11 : IExecutable
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
      // �O���[�v�������̃T���v��
      //
      // �O���[�v�������������̂�DefaultIfEmpty���\�b�h��K�p�������̂�
      // Linq�ł̍��O�������ƂȂ�B
      //

      //
      // �O���������Ă��Ȃ���.
      //
      // �ȉ��̃N�G���̏ꍇ�Agsf_zero5���\������Ȃ��B
      // (�Ō��from personProject in personProjects�̕����ŏ��O�����B�j
      var query = from person in persons
                  join prj in
                    (
                      from project in projects
                      from member in project.Members
                      select new { Id = project.Id, Name = project.Name, Member = member }
                      ) on person.Id equals prj.Member into personProjects
                  from personProject in personProjects
                  select new
                  {
                    Id = person.Id
                    ,
                    Name = person.Name
                    ,
                    Project = personProject.Name
                  };

      query.ToList().ForEach(Console.WriteLine);

      //
      // �O��������
      //
      var query2 = from person in persons
                   join prj in
                     (
                       from project in projects
                       from member in project.Members
                       select new { Id = project.Id, Name = project.Name, Member = member }
                       ) on person.Id equals prj.Member into personProjects
                   // �O���������邽�߂�DefaultIfEmpty���g�p.
                   from personProject in personProjects.DefaultIfEmpty()
                   select new
                   {
                     Id = person.Id
                     ,
                     Name = person.Name
                       // �����Ώۂ����݂��Ȃ������ꍇ�A���̌^��default(T)�̒l�ƂȂ��Ă̂�
                       // �]�݂̌`�ɕϊ�����.
                     ,
                     Project = (personProject == null) ? "''" : personProject.Name
                   };

      Console.WriteLine("======================================================");
      query2.ToList().ForEach(Console.WriteLine);
    }
  }
  #endregion
}
