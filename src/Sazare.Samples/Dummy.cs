namespace Sazare.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  using Sazare.Common;
  
  #region ダミークラス
  /// <summary>
  /// ダミークラス
  /// </summary>
  [Sample]
  public class Dummy : Sazare.Common.IExecutable
  {
    /// <summary>
    /// 処理を実行します。
    /// </summary>
    public void Execute()
    {
      Output.WriteLine("THIS IS DUMMY CLASS.");
    }
  }
  #endregion
}
