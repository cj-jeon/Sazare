namespace Sazare.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;
  using System.Runtime.Remoting;

  using Sazare.Common;
  
  #region Reflection-02
  /// <summary>
  /// リフレクションのサンプル2です。
  /// </summary>
  [Sample]
  public class ReflectionSample02 : Sazare.Common.IExecutable
  {
    public void Execute()
    {
      Type type = typeof(List<string>);

      //
      // Activatorを利用してインスタンス化.（Typeのみの指定）
      //
      object obj = Activator.CreateInstance(type);
      Output.WriteLine(obj.GetType());

      //
      // Activatorを利用してインスタンス化.(Assembly名と型名)
      // この場合、戻り値はSystem.Runtime.Remoting.ObjectHandleになります。
      //
      ObjectHandle objHandle = Activator.CreateInstance(Assembly.GetAssembly(type).FullName, type.FullName);
      obj = objHandle.Unwrap();
      Output.WriteLine(objHandle.GetType());
      Output.WriteLine(obj.GetType());

      //
      // Assemblyを利用してインスタンス化.
      // 以下が使えるのは、対象となるクラスが既に読み込み済みのアセンブリの場合です。
      // まだ読み込まれていないアセンブリに含まれるクラスの場合は先にLoadしてから使います。
      //
      obj = Assembly.GetAssembly(type).CreateInstance(type.FullName);
      Output.WriteLine(obj.GetType());
    }
  }
  #endregion
}
