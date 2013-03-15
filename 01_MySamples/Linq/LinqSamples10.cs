namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-10
  /// <summary>
  /// Linqのサンプルです。
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

    // メンバー
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

    // チーム
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

    // プロジェクト
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
      // グループ化結合のサンプル
      //
      // join時にintoキーワードを利用して結果を保持した
      // ものをグループ化結合という。
      //

      //
      // 所属するプロジェクトをメンバー単位で取得.
      // (Person側からProjectへのアプローチ)
      //
      // Project.MembersはN件存在するので、joinするために
      // 平坦化する必要がある。(SelectMany)
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
      // プロジェクトに所属するメンバーをプロジェクト単位で取得.
      // (Project側からPersonへのアプローチ)
      //
      // 以下の行程を経る必要がある。
      //
      // 1.Project.MembersはN件となるので平坦化.
      //   (メンバーが2人いるプロジェクトだと２データとなる。）
      // 2.1の結果とPersonを結合.
      // 3.2の結果をグルーピング.
      //
      var query2 = from project in
                     (
                       // 1の処理.
                       from project in projects
                       from member in project.Members
                       select new
                       {
                         Id = project.Id,
                         Name = project.Name,
                         Member = member
                       }
                       )
                   // 2の処理.
                   join person in persons on project.Member equals person.Id into personByProject
                   select new
                   {
                     Id = project.Id,
                     Name = project.Name,
                     Persons = personByProject
                   } into selectResult
                   // 3の処理.
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
      // joinを利用せずに記述した版.
      // (PersonからProject)
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