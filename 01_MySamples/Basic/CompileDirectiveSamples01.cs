namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region CompileDirectiveSamples-01
  /// <summary>
  /// コンパイルディレクティブのサンプル1です。
  /// </summary>
  public class CompileDirectiveSamples01 : IExecutable
  {

    public void Execute()
    {
      Console.WriteLine("001:HELLO C#");

#if(DEBUG)
      Console.WriteLine("002:HELLO C# (DEBUG)");
#else
        Console.WriteLine("003:HELLO C# (ELSE)");
#endif
    }
  }
  #endregion
}