namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-22
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples22 : IExecutable
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
      var persons = new List<Person>
                {
                  new Person{ Id = 1001, Name = "gsf_zero1" },
                  new Person{ Id = 1000, Name = "gsf_zero2" },
                  new Person{ Id = 111,  Name = "gsf_zero3" },
                  new Person{ Id = 9889, Name = "gsf_zero4" },
                  new Person{ Id = 9889, Name = "gsf_zero5" },
                  new Person{ Id = 100,  Name = "gsf_zero6" }
                };

      //
      // �����t�����Z�q�ɂ́A�ȉ��̂��̂����݂���B
      //
      //   �EOrderBy
      //   �EOrderByDescending
      //   �EThenBy
      //   �EThenByDescending
      //
      // OrderBy�͏����\�[�g�AOrderByDescending�͍~���\�[�g���s���B�ǂ�����P��L�[�ɂă\�[�g���s���B
      // �����L�[�ɂāA�\�[�g�������s���ꍇ�́AOrderBy�y��OrderByDescending�ɑ����āAThenBy�y��ThenByDescending�𗘗p����B
      //
      // OrderBy�y��OrderByDescending���\�b�h�́A����LINQ�W�����Z�q�Ɩ߂�l���قȂ��Ă���
      //   IOrderedEnumerable<T>
      // ��Ԃ��B�܂��AThenBy�y��ThenByDescending���\�b�h�́A������IOrderedEnumerable<T>��n���K�v������B
      // �Ȃ̂ŁA�K�R�I�ɁAThenBy��OrderBy�̌�ŌĂяo���Ȃ��Ɨ��p�o���Ȃ��B
      //
      // LINQ�̕��ёւ������́A����\�[�g(Stable Sort)�ł���B
      // �܂�A�����L�[�̗v�f���V�[�P���X���ɕ������݂����ꍇ�A���ёւ������ʂ͌��̏��Ԃ�ێ����Ă���B
      //

      //
      // ID�ŏ����\�[�g.
      //
      var sortByIdAsc = persons.OrderBy(aPerson => aPerson.Id);

      Console.WriteLine("================= ID�ŏ����\�[�g =================");
      Console.WriteLine(string.Join(Environment.NewLine, sortByIdAsc));

      //
      // ID�ō~���\�[�g.
      //
      var sortByIdDesc = persons.OrderByDescending(aPerson => aPerson.Id);

      Console.WriteLine("================= ID�ō~���\�[�g =================");
      Console.WriteLine(string.Join(Environment.NewLine, sortByIdDesc));

      //
      // ����\�[�g�̊m�F�B
      //
      var sortByIdAscAndDesc = persons.OrderByDescending(aPerson => aPerson.Id).OrderBy(aPerson => aPerson.Id);

      Console.WriteLine("================= ����\�[�g�̊m�F =================");
      Console.WriteLine(string.Join(Environment.NewLine, sortByIdAscAndDesc));
    }
  }
  #endregion
}
