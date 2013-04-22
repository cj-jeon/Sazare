namespace Sazare.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  using Sazare.Common;
  
  #region ExpandoObjectクラスのサンプル-03
  /// <summary>
  /// ExpandoObjectについてのサンプルです。
  /// </summary>
  /// <remarks>
  /// .NET 4.0から追加されたクラスです。
  /// </remarks>
  [Sample]
  public class ExpandoObjectSamples03 : Sazare.Common.IExecutable
  {
    public void Execute()
    {
      ///////////////////////////////////////////////////////////////////////
      //
      // ExpandoObjectをDictionaryとして扱う. (メンバーの追加/削除)
      //   ExpandoObjectはIDictionary<string, object>を実装しているので
      //   Dictionaryとしても利用出来る.
      //
      dynamic obj = new System.Dynamic.ExpandoObject();
      obj.Name = "gsf_zero1";
      obj.Age = 30;

      //
      // 定義されているメンバーを列挙.
      //
      IDictionary<string, object> map = obj as IDictionary<string, object>;
      foreach (var pair in map)
      {
        Output.WriteLine("{0}={1}", pair.Key, pair.Value);
      }

      //
      // Ageメンバーを削除.
      //
      map.Remove("Age");

      //
      // 確認.
      //
      foreach (var pair in map)
      {
        Output.WriteLine("{0}={1}", pair.Key, pair.Value);
      }

      // エラーとなる.
      //Output.WriteLine(obj.Age);
    }
  }
  #endregion
}
