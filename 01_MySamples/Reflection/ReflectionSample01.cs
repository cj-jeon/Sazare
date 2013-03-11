namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region Reflection-01
  /// <summary>
  /// ���t���N�V�����̃T���v��1�ł��B
  /// </summary>
  public class ReflectionSample01 : IExecutable
  {
    public void Execute()
    {
      //
      // Type�I�u�W�F�N�g�̎擾.
      //
      // 1.typeof���g�p.
      Type type1 = typeof(string);

      //
      // 2.�^������擾.
      //
      string typeName = "System.String";
      Type type2 = Type.GetType(typeName);

      //
      // 3.�W�F�l���b�N�^��typeof�Ŏ擾.
      //
      Type type3 = typeof(List<string>);

      //
      // 4.�W�F�l���b�N�^���^������擾.
      //
      typeName = "System.Collections.Generic.List`1[System.String]";
      Type type4 = Type.GetType(typeName);

      //
      // 5.�^������1�ȏ�̏ꍇ.
      //
      typeName = "System.Collections.Generic.Dictionary`2[System.String, System.Int32]";
      Type type5 = Type.GetType(typeName);

      //
      // 6.�W�F�l���b�N�^���^����������Type�I�u�W�F�N�g�Ƃ��Ď擾���A�ォ��^������^����ꍇ.
      //
      typeName = "System.Collections.Generic.List`1";
      Type type6 = Type.GetType(typeName);

      Type type7 = null;
      if (type6.IsGenericType && type6.IsGenericTypeDefinition)
      {
        type7 = type6.MakeGenericType(new Type[] { typeof(string) });
      }

      Console.WriteLine(type1);
      Console.WriteLine(type2);
      Console.WriteLine(type3);
      Console.WriteLine(type4);
      Console.WriteLine(type5);
      Console.WriteLine(type6);
      Console.WriteLine(type7);

    }
  }  
#endregion
}
