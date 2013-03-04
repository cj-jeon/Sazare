namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-10
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples10 : IExecutable
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
      // join����into�L�[���[�h�𗘗p���Č��ʂ�ێ�����
      // ���̂��O���[�v�������Ƃ����B
      //

      //
      // ��������v���W�F�N�g�������o�[�P�ʂŎ擾.
      // (Person������Project�ւ̃A�v���[�`)
      //
      // Project.Members��N�����݂���̂ŁAjoin���邽�߂�
      // ���R������K�v������B(SelectMany)
      //
      var query1 = from person in persons
                   join prj in
                     (
                       from project in projects
                       from member in project.Members
                       select new
                       {
                         Id = project.Id
                         ,
                         Name = project.Name
                         ,
                         PersonId = member
                       }
                       ) on person.Id equals prj.PersonId into personProjects
                   select new
                   {
                     Name = person.Name
                     ,
                     Projects = personProjects
                   };

      foreach (var item in query1)
      {
        Console.WriteLine("Name={0}", item.Name);

        foreach (var project in item.Projects)
        {
          Console.WriteLine("\tProject={0}", project.Name);
        }
      }

      //
      // �v���W�F�N�g�ɏ������郁���o�[���v���W�F�N�g�P�ʂŎ擾.
      // (Project������Person�ւ̃A�v���[�`)
      //
      // �ȉ��̍s�����o��K�v������B
      //
      // 1.Project.Members��N���ƂȂ�̂ŕ��R��.
      //   (�����o�[��2�l����v���W�F�N�g���ƂQ�f�[�^�ƂȂ�B�j
      // 2.1�̌��ʂ�Person������.
      // 3.2�̌��ʂ��O���[�s���O.
      //
      var query2 = from project in
                     (
                       // 1�̏���.
                       from project in projects
                       from member in project.Members
                       select new
                       {
                         Id = project.Id,
                         Name = project.Name,
                         Member = member
                       }
                       )
                   // 2�̏���.
                   join person in persons on project.Member equals person.Id into personByProject
                   select new
                   {
                     Id = project.Id,
                     Name = project.Name,
                     Persons = personByProject
                   } into selectResult
                   // 3�̏���.
                   group selectResult by new
                   {
                     selectResult.Id,
                     selectResult.Name
                   };

      Console.WriteLine("======================================================");
      foreach (var item in query2)
      {
        Console.WriteLine("Name={0}", item.Key.Name);

        foreach (var groupedItem in item)
        {

          foreach (var belongPerson in groupedItem.Persons)
          {
            Console.WriteLine("\tPerson={0}", belongPerson.Name);
          }
        }
      }

      //
      // join�𗘗p�����ɋL�q������.
      // (Person����Project)
      //
      var query3 = from person in persons
                   from project in projects
                   where project.Members.Contains(person.Id)
                   select new
                   {
                     Person = person,
                     Project = project
                   } into selectResult
                   group selectResult by selectResult.Project.Name into groupByResult
                   orderby groupByResult.Key ascending
                   select groupByResult;

      Console.WriteLine("======================================================");
      foreach (var item in query3)
      {
        Console.WriteLine("Project={0}", item.Key);

        foreach (var groupedItem in item)
        {
          Console.WriteLine("\tPerson={0}", groupedItem.Person.Name);
        }
      }
    }
  }
  #endregion
}
