namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  #region ThreadStaticAttributeSamples-01
  /// <summary>
  /// ThreadStatic�����Ɋւ���T���v���ł��B
  /// </summary>
  public class ThreadStaticAttributeSamples01 : IExecutable
  {
    private class ThreadState
    {
      /// <summary>
      /// �e�X���b�h���ɌŗL�̒l�����t�B�[���h.
      /// </summary>
      [ThreadStatic]
      static KeyValuePair<string, int> NameAndId;
      /// <summary>
      /// �e�X���b�h�ŋ��L�����t�B�[���h.
      /// </summary>
      static KeyValuePair<string, int> SharedNameAndId;

      public static void DoThreadProcess()
      {
        Thread thread = Thread.CurrentThread;

        //
        // ThreadStatic�������t�����ꂽ�t�B�[���h�Ƌ��L���ꂽ�t�B�[���h�̗����ɒl��ݒ�.
        //
        NameAndId = new KeyValuePair<string, int>(thread.Name, thread.ManagedThreadId);
        SharedNameAndId = new KeyValuePair<string, int>(thread.Name, thread.ManagedThreadId);

        Console.WriteLine("[BEFORE] ThreadStatic={0} Shared={1}", NameAndId, SharedNameAndId);

        //
        // ���̃X���b�h������ł���悤�ɂ���.
        //
        Thread.Sleep(TimeSpan.FromMilliseconds(200));

        Console.WriteLine("[AFTER ] ThreadStatic={0} Shared={1}", NameAndId, SharedNameAndId);
      }
    }

    public void Execute()
    {
      List<Thread> threads = new List<Thread>();
      for (int i = 0; i < 5; i++)
      {
        Thread thread = new Thread(ThreadState.DoThreadProcess);

        thread.Name = string.Format("Thread-{0}", i);
        thread.IsBackground = true;

        threads.Add(thread);

        thread.Start();
      }

      threads.ForEach(thread =>
      {
        thread.Join();
      });
    }
  }
  #endregion
}
