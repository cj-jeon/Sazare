namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;
  using System.Reflection.Emit;

  #region Emit�̃T���v���Q
  /// <summary>
  /// Emit�̃T���v���Q�ł��B
  /// </summary>
  /// <remarks>
  /// �v���p�e�B�����N���X�𓮓I�������܂��B
  /// </remarks>
  public class EmitSample2 : IExecutable
  {
    public void Execute()
    {
      //////////////////////////////////////////////////////////////////
      //
      // �v���p�e�B�t���̌^���쐬.
      //
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
      AssemblyBuilder asmBuilder = domain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave);
      //
      // 2.ModuleBuilder�̐���.
      //
      ModuleBuilder modBuilder = asmBuilder.DefineDynamicModule(asmName.Name, string.Format("{0}.dll", asmName.Name));
      //
      // 3.TypeBuilder�̐���.
      //
      TypeBuilder typeBuilder = modBuilder.DefineType("WithPropClass", TypeAttributes.Public, typeof(object), Type.EmptyTypes);
      //
      // 4.FieldBuilder�̐���.
      //
      FieldBuilder fieldBuilder = typeBuilder.DefineField("_message", typeof(string), FieldAttributes.Private);
      //
      // 5.PropertyBuilder�̐���.
      //
      PropertyBuilder propBuilder = typeBuilder.DefineProperty("Message", System.Reflection.PropertyAttributes.HasDefault, typeof(string), Type.EmptyTypes);
      //
      // 6.�v���p�e�B�͎��ۂɂ�Getter/Setter���\�b�h�̌Ăяo���ƂȂ�ׁA�����̃��\�b�h���쐬����K�v������B
      //   �����̃��\�b�h�ɕt�����郁�\�b�h�������`.
      //
      MethodAttributes propAttr = (MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig);
      //
      // 7.Get���\�b�h�̐���.
      //
      MethodBuilder getterMethodBuilder = typeBuilder.DefineMethod("get_Message", propAttr, typeof(string), Type.EmptyTypes);
      //
      // 8.ILGenerator�𐶐����AGetter�p��IL�R�[�h��ݒ�.
      //
      ILGenerator il = getterMethodBuilder.GetILGenerator();
      il.Emit(OpCodes.Ldarg_0);
      il.Emit(OpCodes.Ldfld, fieldBuilder);
      il.Emit(OpCodes.Ret);
      //
      // 9.Set���\�b�h�𐶐�
      //
      MethodBuilder setterMethodBuilder = typeBuilder.DefineMethod("set_Message", propAttr, null, new Type[] { typeof(string) });
      //
      // 10.ILGenerator�𐶐����ASetter�p��IL�R�[�h��ݒ�.
      //
      il = setterMethodBuilder.GetILGenerator();
      il.Emit(OpCodes.Ldarg_0);
      il.Emit(OpCodes.Ldarg_1);
      il.Emit(OpCodes.Stfld, fieldBuilder);
      il.Emit(OpCodes.Ret);
      //
      // 11.PropertyBuilder��Getter/Setter��R�t����.
      //
      propBuilder.SetGetMethod(getterMethodBuilder);
      propBuilder.SetSetMethod(setterMethodBuilder);
      //
      // 12.�쐬�����^���擾.
      //
      Type type = typeBuilder.CreateType();
      //
      // 13.�^�����.
      //
      object withPropObj = Activator.CreateInstance(type);
      //
      // 14.���s.
      //
      PropertyInfo propInfo = type.GetProperty("Message");
      propInfo.SetValue(withPropObj, "HelloWorld", null);
      Console.WriteLine(propInfo.GetValue(withPropObj, null));
      //
      // 15.(option) �쐬�����A�Z���u����ۑ�.
      //
      asmBuilder.Save(string.Format("{0}.dll", asmName.Name));
    }
  }
  #endregion
}
