namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;
  using System.Runtime.Remoting;

  #region Reflection-02
  /// <summary>
  /// ���t���N�V�����̃T���v��2�ł��B
  /// </summary>
  public class ReflectionSample02 : IExecutable
  {
    public void Execute()
    {
      Type type = typeof(List<string>);

      //
      // Activator�𗘗p���ăC���X�^���X��.�iType�݂̂̎w��j
      //
      object obj = Activator.CreateInstance(type);
      Console.WriteLine(obj.GetType());

      //
      // Activator�𗘗p���ăC���X�^���X��.(Assembly���ƌ^��)
      // ���̏ꍇ�A�߂�l��System.Runtime.Remoting.ObjectHandle�ɂȂ�܂��B
      //
      ObjectHandle objHandle = Activator.CreateInstance(Assembly.GetAssembly(type).FullName, type.FullName);
      obj = objHandle.Unwrap();
      Console.WriteLine(objHandle.GetType());
      Console.WriteLine(obj.GetType());

      //
      // Assembly�𗘗p���ăC���X�^���X��.
      // �ȉ����g����̂́A�ΏۂƂȂ�N���X�����ɓǂݍ��ݍς݂̃A�Z���u���̏ꍇ�ł��B
      // �܂��ǂݍ��܂�Ă��Ȃ��A�Z���u���Ɋ܂܂��N���X�̏ꍇ�͐��Load���Ă���g���܂��B
      //
      obj = Assembly.GetAssembly(type).CreateInstance(type.FullName);
      Console.WriteLine(obj.GetType());
    }
  }
  #endregion
}
