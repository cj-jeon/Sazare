namespace Sazare.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  using Sazare.Common;
  
  #region String::IsNullOrWhiteSpaceメソッドのサンプル
  /// <summary>
  /// String.IsNullOrWhiteSpaceメソッドについてのサンプルです。
  /// </summary>
  /// <remarks>
  /// .NET 4.0から追加されたメソッドです。
  /// </remarks>
  [Sample]
  public class StringIsNullOrWhiteSpaceSamples01 : Sazare.Common.IExecutable
  {
    public void Execute()
    {
      //
      // String::IsNullOrWhiteSpaceメソッドは、IsNullOrEmptyメソッドの動作に
      // 加え、更に空白文字のみの場合もチェックしてくれる。
      //
      string nullStr = null;
      string emptyStr = string.Empty;
      string spaceStr = "    ";
      string normalStr = "hello world";
      string zenkakuSpaceStr = "　　　";

      //
      // String::IsNullOrEmptyでの結果.
      //
      Output.WriteLine("============= String::IsNullOrEmpty ==============");
      Output.WriteLine("nullStr   = {0}", string.IsNullOrEmpty(nullStr));
      Output.WriteLine("emptyStr  = {0}", string.IsNullOrEmpty(emptyStr));
      Output.WriteLine("spaceStr  = {0}", string.IsNullOrEmpty(spaceStr));
      Output.WriteLine("normalStr = {0}", string.IsNullOrEmpty(normalStr));
      Output.WriteLine("zenkakuSpaceStr = {0}", string.IsNullOrEmpty(zenkakuSpaceStr));

      //
      // String::IsNullOrWhiteSpaceでの結果.
      //  全角空白もスペースと見なされる点に注意。
      //
      Output.WriteLine("============= String::IsNullOrWhiteSpace ==============");
      Output.WriteLine("nullStr   = {0}", string.IsNullOrWhiteSpace(nullStr));
      Output.WriteLine("emptyStr  = {0}", string.IsNullOrWhiteSpace(emptyStr));
      Output.WriteLine("spaceStr  = {0}", string.IsNullOrWhiteSpace(spaceStr));
      Output.WriteLine("normalStr = {0}", string.IsNullOrWhiteSpace(normalStr));
      Output.WriteLine("zenkakuSpaceStr = {0}", string.IsNullOrWhiteSpace(zenkakuSpaceStr));
    }
  }
  #endregion
}
