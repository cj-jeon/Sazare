namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-06
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples06 : IExecutable
  {
    enum Country
    {
      Japan,
      America,
      China
    }

    class Person
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
      public AddressInfo Address
      {
        get;
        set;
      }
      public Country Country
      {
        get;
        set;
      }
    }

    class AddressInfo
    {
      public string PostCode
      {
        get;
        set;
      }
      public string Prefecture
      {
        get;
        set;
      }
      public string Municipality
      {
        get;
        set;
      }
      public string HouseNumber
      {
        get;
        set;
      }
      public string[] Tel
      {
        get;
        set;
      }
      public string[] Frends
      {
        get;
        set;
      }
    }


    IEnumerable<Person> CreateSampleData()
    {
      return new Person[]{
           new Person{ 
               Id="00001"
              ,Name="gsf_zero1"
              ,Address=new AddressInfo{
                       PostCode="999-8888"
                      ,Prefecture="�����s"
                      ,Municipality="�ǂ����P"
                      ,HouseNumber="�Ԓn�P"
                      ,Tel=new []{"090-xxxx-xxxx"}
                      ,Frends=new string[]{}
              }
              ,Country=Country.Japan
           }
          ,new Person{ 
               Id="00002"
              ,Name="gsf_zero2"
              ,Address=new AddressInfo{
                       PostCode="888-7777"
                      ,Prefecture="���s�{"
                      ,Municipality="�ǂ����Q"
                      ,HouseNumber="�Ԓn�Q"
                      ,Tel=new []{"080-xxxx-xxxx"}
                      ,Frends=new []{"00001"}
              }
              ,Country=Country.Japan
          }
          ,new Person{ 
               Id="00003"
              ,Name="gsf_zero3"
              ,Address=new AddressInfo{
                       PostCode="777-6666"
                      ,Prefecture="�k�C��"
                      ,Municipality="�ǂ����R"
                      ,HouseNumber="�Ԓn�R"
                      ,Tel=new []{"070-xxxx-xxxx"}
                      ,Frends=new []{"00001", "00002"}
              }
              ,Country=Country.America
          }
          ,new Person{ 
               Id="00004"
              ,Name="gsf_zero4"
              ,Address=new AddressInfo{
                       PostCode="777-6666"
                      ,Prefecture="�k�C��"
                      ,Municipality="�ǂ����S"
                      ,HouseNumber="�Ԓn�S"
                      ,Tel=new []{"060-xxxx-xxxx", "111-111-1111", "222-222-2222"}
                      ,Frends=new []{"00001", "00003"}
              }
              ,Country=Country.America
          }
        };
    }

    public void Execute()
    {
      IEnumerable<Person> persons = CreateSampleData();

      // 
      //  ����.
      //  (�����̏ꍇ��ascending�͕t���Ă��t���Ȃ��Ă��ǂ�)
      //
      var query1 = from person in persons
                   orderby person.Id.ToInt() ascending
                   select person;

      Console.WriteLine("============================================");
      foreach (Person person in query1)
      {
        Console.WriteLine("Id={0}, Name={1}", person.Id, person.Name);
      }

      //
      // �~��.
      //
      var query2 = from person in persons
                   orderby person.Id.ToInt() descending
                   select person;

      Console.WriteLine("============================================");
      foreach (Person person in query2)
      {
        Console.WriteLine("Id={0}, Name={1}", person.Id, person.Name);
      }

      //
      // �����̏����Ń\�[�g.
      //
      var query3 = from person in persons
                   orderby person.Address.PostCode, person.Id.ToInt()
                   select person;

      Console.WriteLine("============================================");
      foreach (Person person in query3)
      {
        Console.WriteLine("Id={0}, Name={1}", person.Id, person.Name);
      }

      //
      // ������orderby.
      // (query3�̏ꍇ�ƌ��ʂ��قȂ鎖�ɒ���)
      //
      // query3�̏ꍇ�͈�x��2�̏����ɂă\�[�g�������s���邪
      // query4�́A2��ɕ����ă\�[�g�������s����B
      //
      // �܂�Aorderby person.Address.PostCode�ň�U�\�[�g��
      // �s���邪�A���̌�orderby person.Id�ɂ����ID���Ƀ\�[�g
      // ���꒼����Ă��܂��B
      //
      var query4 = from person in persons
                   orderby person.Address.PostCode
                   orderby person.Id.ToInt()
                   select person;

      Console.WriteLine("============================================");
      foreach (Person person in query4)
      {
        Console.WriteLine("Id={0}, Name={1}", person.Id, person.Name);
      }
    }
  }
  #endregion
}
