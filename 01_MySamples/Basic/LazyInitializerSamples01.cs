namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  #region LazyInitializerSamples-01
  public class LazyInitializerSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // LazyInitializer�́ALazy�Ɠ��l�ɒx�����������s�����߂�
      // �N���X�ł���B���̃N���X�́Astatic���\�b�h�݂̂ō\������
      // Lazy�ł̋L�q���ȕ։����邽�߂ɑ��݂���B
      //
      // EnsureInitialized���\�b�h��
      // Lazy�N���X�ɂāALazyThreadSafetyMode.PublicationOnly��
      // �w�肵���ꍇ�Ɠ�������ƂȂ�B(race-to-initialize)
      //
      var hasHeavy = new HasHeavyData();

      Parallel.Invoke
      (
        () =>
        {
          Console.WriteLine("Created. [{0}]", hasHeavy.Heavy.CreatedThreadId);
        },
        () =>
        {
          Console.WriteLine("Created. [{0}]", hasHeavy.Heavy.CreatedThreadId);
        },
        // �����ҋ@���Ă���A�쐬�ς݂̒l�ɃA�N�Z�X.
        () =>
        {
          Thread.Sleep(TimeSpan.FromMilliseconds(2000));
          Console.WriteLine(">>�����ҋ@���Ă���A�쐬�ς݂̒l�ɃA�N�Z�X.");
          Console.WriteLine(">>Created. [{0}]", hasHeavy.Heavy.CreatedThreadId);
        }
      );
    }

    class HasHeavyData
    {
      HeavyObject _heavy;

      public HeavyObject Heavy
      {
        get
        {
          //
          // LazyInitializer�𗘗p���āA�x��������.
          //
          Console.WriteLine("[ThreadId {0}] �l�����������J�n. start", Thread.CurrentThread.ManagedThreadId);
          LazyInitializer.EnsureInitialized(ref _heavy, () => new HeavyObject(TimeSpan.FromMilliseconds(100)));
          Console.WriteLine("[ThreadId {0}] �l�����������J�n. end", Thread.CurrentThread.ManagedThreadId);

          return _heavy;
        }
      }
    }

    class HeavyObject
    {
      int _threadId;

      public HeavyObject(TimeSpan waitSpan)
      {
        Console.WriteLine(">>>>>> HeavyObject�̃R���X�g���N�^ start. [{0}]", Thread.CurrentThread.ManagedThreadId);
        Initialize(waitSpan);
        Console.WriteLine(">>>>>> HeavyObject�̃R���X�g���N�^ end.   [{0}]", Thread.CurrentThread.ManagedThreadId);
      }

      void Initialize(TimeSpan waitSpan)
      {
        Thread.Sleep(waitSpan);
        _threadId = Thread.CurrentThread.ManagedThreadId;
      }

      public int CreatedThreadId
      {
        get
        {
          return _threadId;
        }
      }
    }
  }
  #endregion
}
