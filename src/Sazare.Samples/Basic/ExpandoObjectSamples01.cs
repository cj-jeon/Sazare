using System;
using System.Dynamic;
using Sazare.Common;

// ReSharper disable once CheckNamespace
namespace Sazare.Samples
{

    #region ExpandoObjectクラスのサンプル-01

    /// <summary>
    ///     ExpandoObjectクラスについてのサンプルです。
    /// </summary>
    /// <remarks>
    ///     .NET 4.0から追加されたクラスです。
    /// </remarks>
    [Sample]
    public class ExpandoObjectSamples01 : IExecutable
    {
        public void Execute()
        {
            //////////////////////////////////////////////////////////////////////
            //
            // 動的オブジェクトを作成.
            //
            // System.Dynamic名前空間は、「System.Core.dll」内に存在する。
            // 動的オブジェクトを利用するには、上記のDLLの他に以下のDLLも参照設定
            // する必要がある。
            //
            // ・Microsoft.CSharp.dll
            //
            dynamic obj = new ExpandoObject();

            //
            // メンバーを定義.
            //
            // プロパティ.
            obj.Value = 10;

            // メソッド.
            var action = new Action<string>(line => { Output.WriteLine(line); });

            obj.WriteLine = action;

            //
            // 呼び出してみる.
            //
            obj.WriteLine(obj.Value.ToString());

            obj.Value = 100;
            obj.WriteLine(obj.Value.ToString());

            obj.Value = "hoge";
            obj.WriteLine(obj.Value.ToString());
        }
    }

    #endregion
}