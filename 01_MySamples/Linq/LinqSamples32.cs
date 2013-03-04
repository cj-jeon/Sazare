namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-32
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples32 : IExecutable
  {
    class Person
    {
      public string Name { get; set; }

      public override string ToString()
      {
        return string.Format("[NAME={0}]", Name);
      }
    }

    public void Execute()
    {
      var people = new Person[]
               {
                 new Person{ Name = "gsf_zero1" },
                 new Person{ Name = "gsf_zero2" },
                 new Person{ Name = "gsf_zero3" },
                 new Person{ Name = "gsf_zero4" }
               };

      //
      // Count�g�����\�b�h�́A�V�[�P���X�̗v�f�����擾���郁�\�b�h�ł���B
      //
      // Count�g�����\�b�h�ɂ́Apredicate���w��ł���I�[�o�[���[�h�����݂�
      // ����𗘗p����ƁA����̏����Ɉ�v����f�[�^�݂̂̌��������߂鎖���o����B
      //
      // ���A���ɑ����̌�����Ԃ��\��������ꍇ�́ACount�̑����LongCount�g�����\�b�h��
      // �g�p����B�g�����́ACount�g�����\�b�h�Ɠ����B



      //
      // predicate�����Ŏ��s. 
      //
      Console.WriteLine("COUNT = {0}", people.Count());

      //
      // predicate�L��Ŏ��s.
      //
      Console.WriteLine("COUNT = {0}", people.Count(person => int.Parse(person.Name.Last().ToString()) % 2 == 0));

      //
      // predicate�����Ŏ��s.�iLongCount)
      //
      Console.WriteLine("COUNT = {0}", people.LongCount());

      //
      // predicate�L��Ŏ��s.�iLongCount)
      //
      Console.WriteLine("COUNT = {0}", people.LongCount(person => int.Parse(person.Name.Last().ToString()) % 2 == 0));
    }
  }
  #endregion
}
