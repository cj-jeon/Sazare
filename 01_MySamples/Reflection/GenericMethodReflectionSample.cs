namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;

  #region Generic�ȃ��\�b�h�����t���N�V�����Ŏ擾
  /// <summary>
  /// �W�F�l���b�N���\�b�h�����t���N�V�����Ŏ擾����T���v���ł��B
  /// </summary>
  public class GenericMethodReflectionSample : IExecutable
  {
    public void Execute()
    {
      Type type = typeof(GenericMethodReflectionSample);
      BindingFlags flags = (BindingFlags.NonPublic | BindingFlags.Instance);

      //
      // �W�F�l���b�N���\�b�h��������Ȃ��ꍇ�͈ȉ��̂悤�ɂ��Ď擾�ł���B
      // 
      // �W�F�l���b�N��`����Ă����Ԃ̃��\�b�h�����擾.
      // MethodInfo mi = type.GetMethod("SetPropertyValue", flags);
      // �^������ݒ肵�āA�����\�b�h�����擾
      // MethodInfo genericMi = mi.MakeGenericMethod(new Type[]{ typeof(DateTime) });
      //
      // �������A�������\�b�h�̃I�[�o�[���[�h���������݂���ꍇ�͈�UGetMethods�ɂ�
      // ���[�v�����A�Y�����郁�\�b�h���������Ƃ��K�v�ƂȂ�B
      //
      // [�Q��URL]
      // http://www.codeproject.com/KB/dotnet/InvokeGenericMethods.aspx
      //
      string methodName = "SetPropertyValue";
      Type[] paramTypes = new Type[] { typeof(string), typeof(DateTime), typeof(DateTime) };
      foreach (MethodInfo mi in type.GetMethods(flags))
      {
        if (mi.IsGenericMethod && mi.IsGenericMethodDefinition && mi.ContainsGenericParameters)
        {
          if (mi.Name == methodName && mi.GetParameters().Length == paramTypes.Length)
          {
            MethodInfo genericMi = mi.MakeGenericMethod(new Type[] { typeof(DateTime) });
            Console.WriteLine(genericMi);
          }
        }
      }
    }

    protected void SetPropertyValue(string propName, ref int refVal, int val)
    {
      //
      // nop.
      //
    }

    protected void SetPropertyValue<T>(string propName, ref T refVal, T val)
    {
      //
      // nop.
      //
    }
  }  
#endregion
}
