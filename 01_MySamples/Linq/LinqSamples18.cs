namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// ���̃T���v���́A�ȉ���2��LINQ�T���v�����L�q����Ă��܂��B
  ///
  ///  �ELinqSamples-18
  ///  �ELinqSamples-19
  ///
  /// ����Ɉȉ��̎����ɂ��G��Ă��܂��B
  ///
  ///  �E�g�����\�b�h����
  /// </remarks>
  public class LinqSamples18 : IExecutable
  {
    public void Execute()
    {
      Persons persons = new Persons
        {
           new Person { Id = 1, Name = "gsf_zero1" }
          ,new Person { Id = 2, Name = "gsf_zero2" }
          ,new Person { Id = 3, Name = "gsf_zero3" }
        };

      //
      // PersonExtension����`����Ă���̂�
      // ���̂܂܎��s����ƁAWhere�̕����ɂ�PersonExtension.Where��
      // �Ă΂��.
      //
      Console.WriteLine("===== �g�����\�b�h���`������Ԃł��̂܂܃N�G�����s =====");
      var query = from aPerson in persons
                  where aPerson.Id == 2
                  select aPerson;

      foreach (var aPerson in query)
      {
        Console.WriteLine(aPerson);
      }

      //
      // AsEnumerable���\�b�h�𗘗p���āAPersons��IEnumerable<Person>��
      // �ϊ�����ƁA�J�X�^��Where�g�����\�b�h�͌Ă΂�Ȃ��B
      //
      Console.WriteLine("===== AsEnumerable���\�b�h�𗘗p���Ă���A�N�G�����s =====");
      var query2 = from aPerson in persons.AsEnumerable()
                   where aPerson.Id == 2
                   select aPerson;

      foreach (var aPerson in query2)
      {
        Console.WriteLine(aPerson);
      }
    }
  }
}
