namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region IComparableSamples-01
  /// <summary>
  /// IComparable�ɂ��ẴT���v���ł��B
  /// </summary>
  public class IComparableSamples01 : IExecutable
  {
    enum CompareResult : int
    {
      SMALL = -1,
      EQUAL = 0,
      BIG = 1
    }

    class Person : IComparable<Person>
    {
      public int Id { get; set; }
      public string Name { get; set; }

      public int CompareTo(Person other)
      {
        if (other == null)
        {
          return (int)CompareResult.SMALL;
        }

        int result = (int)CompareResult.SMALL;
        int otherId = other.Id;

        if (Id == otherId)
        {
          result = (int)CompareResult.EQUAL;
        }
        else if (Id > otherId)
        {
          result = (int)CompareResult.BIG;
        }

        return result;
      }

      public override string ToString()
      {
        return string.Format("[ID={0}, NAME={1}]", Id, Name);
      }
    }

    public void Execute()
    {
      //
      // IComparable�C���^�[�t�F�[�X�́A�C���X�^���X�̕��ёւ����T�|�[�g���邽�߂̃C���^�[�t�F�[�X�ł���B
      //
      // ���̃C���^�[�t�F�[�X���������邱�ƂŁA�N���X�ɑ΂��ď����̔�r�@�\��t�^���邱�Ƃ��o����B
      // �iList.Sort�Ȃǂ̃\�[�g�������ɁA�Ǝ��̃\�[�g���[����K�p���邱�Ƃ��ł���悤�ɂȂ�B�j
      //  (�������ADictionary��HashTable�Ȃǂɂ͓K�p�ł��Ȃ��B�����̏ꍇ�́AIEqualityComparable����������B�j
      //
      var person1 = new Person { Id = 1, Name = "gsf_zero1" };
      var person2 = new Person { Id = 2, Name = "gsf_zero2" };
      var person3 = new Person { Id = 3, Name = "gsf_zero3" };
      var person4 = new Person { Id = 4, Name = "gsf_zero1" };

      var persons = new List<Person> { person1, person2, person3, person4 };
      var random = new Random();

      //
      // �I�u�W�F�N�g���m�̔�r.
      //
      for (int i = 0; i < 15; i++)
      {
        int index1 = random.Next(persons.Count);
        int index2 = random.Next(persons.Count);

        var p1 = persons[index1];
        var p2 = persons[index2];

        Console.WriteLine("person{0} CompareTo person{1} = {2}", index1, index2, (CompareResult)p1.CompareTo(p2));
      }

      //
      // ���X�g�̃\�[�g.
      //
      var persons2 = new List<Person> { person3, person2, person4, person1 };

      // �\�[�g�����A���̂܂܏o��.
      Console.WriteLine("\n============== �\�[�g�������̂܂܏o��. ================");
      persons2.ForEach(Console.WriteLine);

      // �\�[�g���s���Ă���A�o��.
      Console.WriteLine("\n============== �\�[�g���Ă���o��. ================");
      persons2.Sort();
      persons2.ForEach(Console.WriteLine);
    }
  }
  #endregion
}
