namespace Sazare.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.InteropServices;

  #region RuntimeEnvironmentSamples-01
  /// <summary>
  /// RuntimeEnvironmentクラスについてのサンプルです。
  /// </summary>
  [Sample]
  public class RuntimeEnvironmentSamples01 : Sazare.Common.IExecutable
  {
    public void Execute()
    {
      //
      // System.Runtime.InteropServices.RuntimeEnvironmentクラスを利用する事で
      // .NETのランタイムパスなどを取得することができる。
      //
      Console.WriteLine("Runtime PATH:{0}", RuntimeEnvironment.GetRuntimeDirectory());
      Console.WriteLine("System Version:{0}", RuntimeEnvironment.GetSystemVersion());
    }
  }
  #endregion
}
