namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region ComparerSamples-01
  /// <summary>
  /// Comparer�ɂ��ẴT���v���ł��B
  /// </summary>
  public class ComparerSamples01 : IExecutable
  {
    enum CompareResult : int
    {
      SMALL = -1,
      EQUAL = 0,
      BIG = 1
    }

    class Person
    {
      public int Id { get; set; }
      public string Name { get; set; }

      public override string ToString()
      {
        return string.Format("[ID={0}, NAME={1}]", Id, Name);
      }
    }

    //
    // Comparer<T>�N���X�́A���ۃN���X�ƂȂ��Ă���B
    // IComparer�C���^�[�t�F�[�X��IComparer<T>�C���^�[�t�F�[�X�̗������������Ă���B
    //
    // ���ۂɁA��������K�v������͈̂ȉ��̃��\�b�h�����ł���B
    //   int Compare(T x, T y)
    //
    // IComparer.Compare���\�b�h�ɂ��ẮA���ۃN���X���ɂĖ����I�������s���Ă���B
    //
    class PersonIdComparer : Comparer<Person>
    {
      public override int Compare(Person x, Person y)
      {
        if (object.Equals(x, y))
        {
          return (int)CompareResult.EQUAL;
        }

        int xId = x.Id;
        int yId = y.Id;

        return xId.CompareTo(yId);
      }
    }

    class PersonNameComparer : Comparer<Person>
    {
      public override int Compare(Person x, Person y)
      {
        if (object.Equals(x, y))
        {
          return (int)CompareResult.EQUAL;
        }

        string xName = x.Name;
        string yName = y.Name;

        return xName.CompareTo(yName);
      }
    }

    public void Execute()
    {
      //
      // IComparer�C���^�[�t�F�[�X�y��IComparer<T>�C���^�[�t�F�[�X�́A�Ƃ��ɏ����̔�r���T�|�[�g���邽�߂�
      // �C���^�[�t�F�[�X�ł���B
      //
      // �����ړI�ŗ��p�����C���^�[�t�F�[�X�ɁAIComparable�C���^�[�t�F�[�X�����݂��邪�A�Ⴂ��
      // IComparable�C���^�[�t�F�[�X���A�ΏۂƂȂ�N���X���g�Ɏ�������K�v������̂ɑ΂���
      // IComparer�C���^�[�t�F�[�X�́A�ʂɔ�r�����݂̂����������N���X��p�ӂ��邱�Ƃɂ���B
      //
      // ����ɂ��A�����I�u�W�F�N�g�ɑ΂��āA�����̔�r���@���������邱�Ƃ��o����B
      // (�\�[�g�������s���ۂɁA��r������S������I�u�W�F�N�g��I�����邱�Ƃ��ł���悤�ɂȂ�B�j
      //
      // List.Sort��SortedList��SortedDictionary��������T�|�[�g����B
      //
      var person1 = new Person { Id = 1, Name = "gsf_zero1" };
      var person2 = new Person { Id = 2, Name = "gsf_zero2" };
      var person3 = new Person { Id = 3, Name = "gsf_zero3" };
      var person4 = new Person { Id = 4, Name = "gsf_zero1" };

      var persons = new List<Person> { person3, person2, person4, person1 };

      // �\�[�g�����ɂ��̂܂܏o��.
      persons.ForEach(Console.WriteLine);

      // Id�Ŕ�r�������s��Comparer���w�肵�ă\�[�g.
      Console.WriteLine(string.Empty);
      persons.Sort(new PersonIdComparer());
      persons.ForEach(Console.WriteLine);

      // NAME�Ŕ�r�������s��Comparer���w�肵�ă\�[�g.
      Console.WriteLine(string.Empty);
      persons.Sort(new PersonNameComparer());
      persons.ForEach(Console.WriteLine);
    }
  }
  #endregion
}
