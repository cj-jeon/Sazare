namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-01
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples01 : IExecutable
  {
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
      public string Tel
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
                      ,Tel="090-xxxx-xxxx"
              }
           }
          ,new Person{ 
               Id="00002"
              ,Name="gsf_zero2"
              ,Address=new AddressInfo{
                       PostCode="888-7777"
                      ,Prefecture="���s�{"
                      ,Municipality="�ǂ����Q"
                      ,HouseNumber="�Ԓn�Q"
                      ,Tel="080-xxxx-xxxx"
              }
          }
          ,new Person{ 
               Id="00003"
              ,Name="gsf_zero3"
              ,Address=new AddressInfo{
                       PostCode="777-6666"
                      ,Prefecture="�k�C��"
                      ,Municipality="�ǂ����R"
                      ,HouseNumber="�Ԓn�R"
                      ,Tel="070-xxxx-xxxx"
              }
          }
          ,new Person{ 
               Id="0000x"
              ,Name="gsf_zero3"
              ,Address=new AddressInfo{
                       PostCode="777-6666"
                      ,Prefecture="�k�C��"
                      ,Municipality="�ǂ����R"
                      ,HouseNumber="�Ԓn�R"
                      ,Tel="070-xxxx-xxxx"
              }
          }
        };
    }

    public void Execute()
    {
      IEnumerable<Person> persons = CreateSampleData();

      var query = from person in persons
                  where int.Parse(person.Id) >= 2
                  select person;

      try
      {

        foreach (Person person in query)
        {
          Console.WriteLine("{0},{1}", person.Id, person.Name);
        }

      }
      catch (Exception ex)
      {
        Console.WriteLine("�N�G�����s���ɃG���[������: {0}", ex.Message);
      }
    }

  }
  #endregion
}
