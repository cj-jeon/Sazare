namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;
  using System.Reflection.Emit;

  #region Emit�̃T���v��3
  /// <summary>
  /// Emit�̃T���v���R�ł��B
  /// </summary>
  /// <remarks>
  /// �J�X�^�����������N���X�𓮓I�������܂��B
  /// </remarks>
  public class EmitSample3 : IExecutable
  {
    [AttributeUsage(AttributeTargets.Class)]
    public class IsDynamicTypeAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class CreatorAttribute : Attribute
    {
      public CreatorAttribute(string name)
      {
        CreatorName = name;
      }

      public string CreatorName
      {
        get;
        set;
      }
    }

    private static readonly string ASM_NAME = "DynamicTypes";
    private static readonly string MOD_NAME = string.Format("{0}.dll", ASM_NAME);

    public void Execute()
    {
      AssemblyName asmName = new AssemblyName
      {
        Name = ASM_NAME
      };

      AppDomain appDomain = AppDomain.CurrentDomain;
      AssemblyBuilder asmBuilder = appDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave);
      ModuleBuilder modBuilder = asmBuilder.DefineDynamicModule(ASM_NAME, MOD_NAME);
      TypeBuilder typeBuilder = modBuilder.DefineType("AttrTest", TypeAttributes.Public, typeof(object), Type.EmptyTypes);

      //
      // �^�ɑ΂��ăJ�X�^��������t������B
      // �����̑�����t����ꍇ�́AAddAttribute���\�b�h���̂悤��SetCustomAttribute���\�b�h��
      // �����Ăт܂��B
      //
      AddAttribute(typeBuilder, typeof(IsDynamicTypeAttribute), Type.EmptyTypes, new object[] { });
      AddAttribute(typeBuilder, typeof(CreatorAttribute), new Type[] { typeof(string) }, new object[] { "gsf.zero1" });

      Type type = typeBuilder.CreateType();
      object obj = Activator.CreateInstance(type);

      object[] attrs = type.GetCustomAttributes(true);
      if (attrs.Length > 0)
      {
        foreach (object attr in attrs)
        {
          Console.WriteLine(attr);

          if (attr is CreatorAttribute)
          {
            Console.WriteLine("\tName={0}", (attr as CreatorAttribute).CreatorName);
          }
        }
      }

      asmBuilder.Save(MOD_NAME);
    }

    private void AddAttribute(TypeBuilder typeBuilder, Type attrType, Type[] attrCtorParamTypes, object[] attrCtorParams)
    {
      ConstructorInfo ctorInfo = attrType.GetConstructor(attrCtorParamTypes);

      if (ctorInfo != null)
      {
        CustomAttributeBuilder attrBuilder = new CustomAttributeBuilder(ctorInfo, attrCtorParams);
        typeBuilder.SetCustomAttribute(attrBuilder);
      }
    }
  }
  #endregion
}
