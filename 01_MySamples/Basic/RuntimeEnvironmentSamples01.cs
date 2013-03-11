namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.InteropServices;

  #region RuntimeEnvironmentSamples-01
  /// <summary>
  /// RuntimeEnvironment�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  public class RuntimeEnvironmentSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // System.Runtime.InteropServices.RuntimeEnvironment�N���X�𗘗p���鎖��
      // .NET�̃����^�C���p�X�Ȃǂ��擾���邱�Ƃ��ł���B
      //
      Console.WriteLine("Runtime PATH:{0}", RuntimeEnvironment.GetRuntimeDirectory());
      Console.WriteLine("System Version:{0}", RuntimeEnvironment.GetSystemVersion());
    }
  }
  #endregion
}
