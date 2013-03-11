namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-05
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples05 : IExecutable
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
      // into����g�p���Ȃ��W���I��group�̗��p
      // (Person.Country�ŃO���[�s���O)
      //
      var query1 = from person in persons
                   group person by person.Country;

      //
      // ���ʂ́A�L�[�ƊY������O���[�v�̏�ԂŎ擾�ł���.
      //
      foreach (var groupedPerson in query1)
      {
        // �L�[
        Console.WriteLine("Country={0}", groupedPerson.Key);

        // �O���[�v
        // �O���[�v���擾����ɂ́A������x���[�v����K�v������B
        foreach (var person in groupedPerson)
        {
          Console.WriteLine("\tId={0}, Name={1}", person.Id, person.Name);
        }
      }

      //
      // �������ʂ��Avar�����ŕ\��.
      //
      // group�L�[���[�h�̌��ʂ͈ȉ��̌^�ƂȂ�B
      //    IGrouping<TKey, TElement>
      // IGrouping�C���^�[�t�F�[�X�́AIEnumerable<TElement>��
      // �p�����Ă���̂ŁA���[�v�������TElement�������擾�ł���悤�ɂȂ��Ă���B
      //
      foreach (IGrouping<Country, Person> groupedPerson in query1)
      {
        Console.WriteLine("Country={0}", groupedPerson.Key);

        foreach (Person person in groupedPerson)
        {
          Console.WriteLine("\tId={0}, Name={1}", person.Id, person.Name);
        }
      }
    }
  }
  #endregion
}
