namespace Sazare.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  #region TaskSamples-02
  /// <summary>
  /// タスク並列ライブラリについてのサンプルです。
  /// </summary>
  /// <remarks>
  /// タスク並列ライブラリは4.0から追加されたライブラリです。
  /// </remarks>
  [Sample]
  public class TaskSamples02 : Sazare.Common.IExecutable
  {
    public void Execute()
    {
      //
      // タスクを直接Newして実行.
      // 
      // タスクは直接Newして実行することも出来る。
      // コンストラクタに実行するActionデリゲートを指定し
      // Startを呼ぶと起動される。
      //

      // 別スレッドでタスクが実行されている事を確認する為に、メインスレッドのスレッドIDを表示
      Console.WriteLine("Main Thread : {0}", Thread.CurrentThread.ManagedThreadId);

      //
      // Actionデリゲートを明示的に指定.
      //
      Task t = new Task(DoAction);
      t.Start();
      t.Wait();

      //
      // ラムダを指定.
      //
      Task t2 = new Task(() => DoAction());
      t2.Start();
      t2.Wait();

      //
      // 多数のタスクを作成して実行.
      //
      List<Task> tasks = Enumerable.Range(1, 20).Select(i => new Task(DoActionWithSleep)).ToList();

      tasks.ForEach(task => task.Start());

      Task.WaitAll(
        tasks.ToArray()
      );
    }

    private void DoAction()
    {
      Console.WriteLine("DoAction: {0}", Thread.CurrentThread.ManagedThreadId);
    }

    private void DoActionWithSleep()
    {
      DoAction();
      Thread.Sleep(200);
    }
  }
  #endregion
}
