namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;

  #region ByRef�̈����������\�b�h�����t�N���N�V�����Ŏ擾
  /// <summary>
  /// ByRef�̈����������\�b�h�����t���N�V�����Ŏ擾����T���v���ł��B
  /// </summary>
  public class HasByRefParameterMethodReflectionSample : IExecutable
  {
    public void Execute()
    {
      Type type = typeof(HasByRefParameterMethodReflectionSample);
      BindingFlags flags = (BindingFlags.NonPublic | BindingFlags.Instance);
      Type[] paramTypes = new Type[] { typeof(string), Type.GetType("System.Int32&"), typeof(int) };

      MethodInfo methodInfo = type.GetMethod("SetPropertyValue", flags, null, paramTypes, null);
      Console.WriteLine(methodInfo);
    }

    // <summary>
    // Dummy Method.
    // </summary>
    protected void SetPropertyValue(string propName, ref int refVal, int val)
    {
      //
      // nop.
      //
    }
  }
  #endregion
}
