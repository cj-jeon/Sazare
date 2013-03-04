namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-24
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples24 : IExecutable
  {
    class Person
    {
      public int Id { get; set; }
      public string Name { get; set; }

      public override string ToString()
      {
        return string.Format("[ID={0}, NAME={1}]", Id, Name);
      }
    }

    public void Execute()
    {
      IEnumerable<int> numbers = new int[] { 1, 2, 3, 4, 5 };
      IEnumerable<Person> persons = new List<Person>
                            {
                              new Person{ Id = 1001, Name = "gsf_zero1" },
                              new Person{ Id = 1000, Name = "gsf_zero2" },
                              new Person{ Id = 111,  Name = "gsf_zero3" },
                              new Person{ Id = 9889, Name = "gsf_zero4" },
                              new Person{ Id = 9889, Name = "gsf_zero5" },
                              new Person{ Id = 100,  Name = "gsf_zero6" }
                            };

      //
      // Reverse�g�����\�b�h�́A�����ʂ�\�[�X�V�[�P���X���t���ɕϊ����郁�\�b�h�ł���B
      // ���̃��\�b�h�́A���̂܂܃\�[�X�V�[�P���X���t���ɕϊ����邾���ł���B
      //
      // ���A�{���\�b�h�́A����LINQ���Z�q�Ɠ��l�ɒx�����s�����B
      //
      var reverseNumbers = numbers.Reverse();
      var reversePersons = persons.Reverse();

      Console.WriteLine(string.Join(",", reverseNumbers.Select(element => element.ToString())));
      Console.WriteLine(string.Join(",", reversePersons.Select(element => element.ToString())));
    }
  }
  #endregion
}
