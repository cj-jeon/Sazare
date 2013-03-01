namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;
  using System.Reflection.Emit;

  #region Emit�̃T���v��
  /// <summary>
  /// Emit�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// HelloWorld���o�͂���N���X�𓮓I�������܂��B
  /// </remarks>
  public class EmitSample : IExecutable
  {
    public interface ISayHello
    {
      void SayHello();
    }

    public void Execute()
    {
      //
      // 0.���ꂩ��쐬����^���i�[����A�Z���u�����쐬.
      //
      AssemblyName asmName = new AssemblyName
      {
        Name = "DynamicTypes"
      };

      //
      // 1.AssemlbyBuilder�̐���
      //
      AppDomain domain = AppDomain.CurrentDomain;
      AssemblyBuilder asmBuilder = domain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Run);
      //
      // 2.ModuleBuilder�̐���.
      //
      ModuleBuilder modBuilder = asmBuilder.DefineDynamicModule("HelloWorld");
      //
      // 3.TypeBuilder�̐���.
      //
      TypeBuilder typeBuilder = modBuilder.DefineType("SayHelloImpl", TypeAttributes.Public, typeof(object), new Type[] { typeof(ISayHello) });
      //
      // 4.MethodBuilder�̐���
      //
      MethodAttributes methodAttr = (MethodAttributes.Public | MethodAttributes.Virtual);
      MethodBuilder methodBuilder = typeBuilder.DefineMethod("SayHello", methodAttr, typeof(void), new Type[] { });
      typeBuilder.DefineMethodOverride(methodBuilder, typeof(ISayHello).GetMethod("SayHello"));
      //
      // 5.ILGenerator�𐶐����AIL�R�[�h��ݒ�.
      //
      ILGenerator il = methodBuilder.GetILGenerator();
      il.Emit(OpCodes.Ldstr, "Hello World");
      il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }));
      il.Emit(OpCodes.Ret);
      //
      // 6.�쐬�����^���擾.
      //
      Type type = typeBuilder.CreateType();
      //
      // 7.�^�����.
      //
      ISayHello hello = (ISayHello)Activator.CreateInstance(type);
      //
      // 8.���s.
      //
      hello.SayHello();
    }
  }
  #endregion
}
