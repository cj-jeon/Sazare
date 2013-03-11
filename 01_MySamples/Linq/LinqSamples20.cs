namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-20
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples20 : IExecutable
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
      // Select�g�����\�b�h�𗘗p�B
      //   �N�G�����ŗ��p���Ă���select��Ɨ��p���@�͓����B
      //   select�g�����\�b�h�́A�Q�̃I�[�o�[���[�h�������Ă���
      //
      //   ��́AFunc<TSource, TResult>�̃^�C�v�B������́AFunc<TSource, int, TResult>�̃^�C�v�ƂȂ�B
      //   2�ڂ̃^�C�v�̏ꍇ�A���̎��̃C���f�b�N�X�������Ƃ��Đݒ肳���B
      //
      Console.WriteLine("===== Func<TSource, TResult>�̃^�C�v =====");
      foreach (var name in persons.Select(item => item.Name))
      {
        Console.WriteLine("NAME={0}", name);
      }

      Console.WriteLine("===== Func<TSource, int, TResult>�̃^�C�v =====");
      foreach (var name in persons.Select((item, index) => string.Format("{0}_{1}", item.Name, index)))
      {
        Console.WriteLine("NAME={0}", name);
      }
    }
  }
  #endregion
}
