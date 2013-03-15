namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region AppDomainSamples-02
  /// <summary>
  /// AppDomainクラスのサンプルです。
  /// </summary>
  public class AppDomainSamples02 : MarshalByRefObject, IExecutable
  {
    public void Execute()
    {
      AppDomain defaultDomain = AppDomain.CurrentDomain;
      AppDomain anotherDomain = AppDomain.CreateDomain("AnotherAppDomain");

      //
      // DomainUnloadイベントのハンドル.
      //
      // 既定のアプリケーションドメインでは、Unloadは登録できるが発行されることは
      // 無いので、設定する意味がない.
      //defaultDomain.DomainUnload += AppDomain_Unload;
      anotherDomain.DomainUnload += AppDomain_Unload;

      //
      // ProcessExitイベントのハンドル.
      //
      defaultDomain.ProcessExit += AppDomain_ProcessExit;
      anotherDomain.ProcessExit += AppDomain_ProcessExit;

      //
      // 既定のアプリケーションドメインをアンロードしようとするとエラーとなる.
      // ** appdomain をアンロード中にエラーが発生しました。 (HRESULT からの例外: 0x80131015) **
      //AppDomain.Unload(defaultDomain);

      //
      // AppDomain.Unloadを呼び出すと、DomainUnloadイベントが発生する.
      // AppDomain.Unloadを呼び出さずにプロセスが終了させようとすると
      // ProcessExitイベントが発生する。両方のイベントが同時に発生することは無い.
      //
      // 以下をコメントアウトすると、ProcessExitイベントが発生する.
      //
      //AppDomain.Unload(anotherDomain);
    }

    void AppDomain_Unload(object sender, EventArgs e)
    {
      AppDomain domain = sender as AppDomain;
      Console.WriteLine("AppDomain.Unload: {0}", domain.FriendlyName);
    }

    void AppDomain_ProcessExit(object sender, EventArgs e)
    {
      //
      // ProcessExitイベントには、タイムアウトが存在する。（既定は2秒）
      // 以下、MSDNの記述.
      // (http://msdn.microsoft.com/ja-jp/library/system.appdomain.processexit.aspx)
      //
      // 「プロセス シャットダウン時における全ファイナライザーの合計実行時間が限られているように、ProcessExit の
      // すべてのイベント ハンドラーに対して割り当てられる合計実行時間も限られています。 既定値は 2 秒です。」
      //
      // 以下のコメントを外して実行すると、タイムアウト時間を過ぎるので
      // イベントをハンドルしていても、後続の処理は実行されない。
      //
      // わざとタイムアウト時間が過ぎるように待機.
      //Console.WriteLine("AppDomain.ProcessExit Thread.Sleep()");
      //Thread.Sleep(TimeSpan.FromSeconds(3));

      AppDomain domain = sender as AppDomain;
      Console.WriteLine("AppDomain.ProcessExit: {0}", domain.FriendlyName);
    }
  }
  #endregion
}
