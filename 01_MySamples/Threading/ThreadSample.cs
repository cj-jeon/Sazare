namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  #region �X���b�h�𒼐ڍ쐬
  /// <summary>
  /// �X���b�h�𒼐ڍ쐬����T���v��.
  /// </summary>
  public class ThreadSample : IExecutable
  {
    /// <summary>
    /// ���b�N�I�u�W�F�N�g
    /// </summary>
    object _lockObject = new object();
    /// <summary>
    /// ����
    /// </summary>
    int _count = 0;

    /// <summary>
    /// �X���b�h�����s����ۂ̈����Ƃ��ė��p�����N���X�ł��B
    /// </summary>
    class ThreadParameter
    {
      public int Count
      {
        get;
        set;
      }

      public DateTime Time
      {
        get;
        set;
      }
    }

    /// <summary>
    /// ���������s���܂��B
    /// </summary>
    public void Execute()
    {
      //
      // ThreadStart�f���Q�[�g��p�����ꍇ.
      //
      ThreadStart ts = () =>
      {
        lock (_lockObject)
        {
          if (_count < 10)
          {
            _count++;
          }
        }

        Console.WriteLine("Count={0}", _count);
      };

      for (int i = 0; i < 15; i++)
      {
        Thread t = new Thread(ts);
        t.IsBackground = false;

        t.Start();

        //
        // �m���ɃX���b�h�̑��鏇���𑵂���ɂ͈ȉ��̂悤�ɂ���B
        // (�����Ƃ���������ƃX���b�h�̈Ӗ����Ȃ����E�E)
        //
        //t.Join();
      }

      //
      // ParameterizedThreadStart��p�����ꍇ.
      //
      ParameterizedThreadStart pts = (data) =>
      {
        ThreadParameter p = data as ThreadParameter;
        Thread.Sleep(150);
        Console.WriteLine("Thread Count:{0}, Time:{1}", p.Count, p.Time.ToString("hh:mm:ss.fff"));
      };

      for (int i = 0; i < 15; i++)
      {
        Thread t = new Thread(pts);
        t.IsBackground = false;

        t.Start(new ThreadParameter
        {
          Count = i,
          Time = DateTime.Now
        });

        //
        // �m���ɃX���b�h�̑��鏇���𑵂���ɂ͈ȉ��̂悤�ɂ���B
        // (�����Ƃ���������ƃX���b�h�̈Ӗ����Ȃ����E�E)
        //
        //t.Join();
      }
    }
  }
  #endregion
}
