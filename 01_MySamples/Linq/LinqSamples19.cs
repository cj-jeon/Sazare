namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-19
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples19 : IExecutable
  {
    class Person
    {
      public int Id { get; set; }
      public string Name { get; set; }
    }

    public void Execute()
    {
      var persons = new List<Person>
        {
           new Person { Id = 1, Name = "gsf_zero1" }
          ,new Person { Id = 2, Name = "gsf_zero2" }
          ,new Person { Id = 3, Name = "gsf_zero3" }
        };

      //
      // Where�g�����\�b�h�𗘗p�B
      //   �N�G�����ŗ��p���Ă���where��Ɨ��p���@�͓����B
      //   Where�g�����\�b�h�́A�Q�̃I�[�o�[���[�h�������Ă���
      //
      //   ��́AFunc<T, bool>�̃^�C�v�B������́AFunc<T, int, bool>�̃^�C�v�ƂȂ�B
      //   2�ڂ̃^�C�v�̏ꍇ�A���̎��̃C���f�b�N�X�������Ƃ��Đݒ肳���B
      //
      Console.WriteLine("===== Func<T, bool>�̃^�C�v =====");
      foreach (var aPerson in persons.Where(item => item.Id == 2))
      {
        Console.WriteLine("ID={0}, NAME={1}", aPerson.Id, aPerson.Name);
      }

      Console.WriteLine("===== Func<T, int, bool>�̃^�C�v =====");
      foreach (var aPerson in persons.Where((item, index) => index == 2))
      {
        Console.WriteLine("ID={0}, NAME={1}", aPerson.Id, aPerson.Name);
      }
    }
  }
  #endregion
}
