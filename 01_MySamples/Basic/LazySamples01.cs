namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  #region LazySamples-01
  /// <summary>
  /// Lazy<T>, LazyInitializer�N���X�̃T���v���ł��B
  /// </summary>
  public class LazySamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // Lazy<T>�N���X�́A�x�������� (Lazy Initialize)�@�\��t�^����N���X�ł���B
      //
      // ���p����ۂ́ALazy�N���X�̃R���X�g���N�^��Func<T>���w�肷�邱�Ƃɂ��
      // �������������w�肷��B�i���Ƃ��΁A�R�X�g�̂�����I�u�W�F�N�g�̍\�z�Ȃǂ�Func�f���Q�[�g���ɂď����Ȃǁj
      //
      // �܂��A�R���X�g���N�^�ɂ�Func<T>�̑��ɂ��A�������Ƃ��ăX���b�h�Z�[�t���[�h���w��o����B
      // (System.Threading.LazyThreadSafetyMode)
      //
      // �X���b�h�Z�[�t���[�h�́ALazy�N���X���x���������������s���ۂɂǂ̃��x���̃X���b�h�Z�[�t������K�p���邩���w�肷����́B
      // �X���b�h�Z�[�t���[�h�̎w��́ALazy�N���X�̃R���X�g���N�^�ɂ�LazyThreadSafetyMode��bool�Ŏw�肷��B
      //   �ENone:                    �X���b�h�Z�[�t�����B���x���K�v�ȏꍇ�A�܂��́A�Ăь��ɂăX���b�h�Z�[�t���ۏ؏o����ꍇ�ɗ��p
      //   �EPublicationOnly:         �����̃X���b�h�������ɒl�̏��������s�����������邪�A�ŏ��ɏ������ɐ��������X���b�h��
      //                             Lazy�C���X�^���X�̒l��ݒ肷�郂�[�h�B�irace-to initialize)
      //   �EExecutionAndPublication: ���S�X���b�h�Z�[�t���[�h�B��̃X���b�h�݂̂����������s���郂�[�h�B
      //                             (double-checked locking)
      //
      // Lazy�N���X�̃R���X�g���N�^�ɂāA�X���b�h�Z�[�t���[�h��bool�^�Ŏw�肷��ꍇ�A�ȉ���LazyThreadSafetyMode�̒l���w�肳�ꂽ���Ɠ����ɂȂ�B
      //    �Etrue : LazyThreadSafetyMode.ExecutionAndPublication�Ɠ����B
      //    �Efalse: LazyThreadSafetyMode.None�Ɠ����B
      //
      // Lazy�N���X�́A��O�̃L���b�V���@�\�������Ă���B����́ALazy.Value���Ăяo�����ۂɃR���X�g���N�^�Ŏw�肵��
      // �������������ŗ�O�����������������m����ۂɗ��p����BLazy�N���X�̃R���X�g���N�^�ɂāA����R���X�g���N�^���g�p����^�C�v��
      // �ݒ���s���Ă���ꍇ�A��O�̃L���b�V���͗L���ɂȂ�Ȃ��B
      //
      // �܂��ALazyThreadSafetyMode.PublicationOnly���w�肵���ꍇ���A��O�̃L���b�V���͗L���ƂȂ�Ȃ��B
      //
      // �r�����[�h�ŏ��������������s
      var lazy1 = new Lazy<HeavyObject>(() => new HeavyObject(TimeSpan.FromMilliseconds(100)), LazyThreadSafetyMode.ExecutionAndPublication);
      // ���A��͈ȉ��̂悤�ɑ�������true�Ŏw�肵���ꍇ�Ɠ������B
      // var lazy1 = new Lazy(() => new HeavyObject(TimeSpan.FromSeconds(1)), true);

      // �l���������ς݂ł��邩�ǂ����́AIsValueCreated�Ŋm�F�o����B
      Console.WriteLine("�l�\�z�ς݁H == {0}", lazy1.IsValueCreated);

      //
      // �����̃X���b�h���瓯���ɏ����������݂Ă݂�B (ExecutionAndPublication)
      //
      Parallel.Invoke
      (
        () =>
        {
          Console.WriteLine("[lambda1] �������������s start.");

          if (lazy1.IsValueCreated)
          {
            Console.WriteLine("[lambda1] ���ɒl���쐬����Ă���B(IsValueCreated=true)");
          }
          else
          {
            Console.WriteLine("[lambda1] ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
            var obj = lazy1.Value;
          }

          Console.WriteLine("[lambda1] �������������s end.");
        },
        () =>
        {
          Console.WriteLine("[lambda2] �������������s start.");

          if (lazy1.IsValueCreated)
          {
            Console.WriteLine("[lambda2] ���ɒl���쐬����Ă���B(IsValueCreated=true)");
          }
          else
          {
            Console.WriteLine("[lambda2] ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
            var obj = lazy1.Value;
          }

          Console.WriteLine("[lambda2] �������������s end.");
        }
      );

      Console.WriteLine("==========================================");

      //
      // �����̃X���b�h�ɂē����ɏ����������̎��s�������邪�A�ŏ��ɏ����������l���ݒ肳��郂�[�h�B
      // (PublicationOnly)
      //
      var lazy2 = new Lazy<HeavyObject>(() => new HeavyObject(TimeSpan.FromMilliseconds(100)), LazyThreadSafetyMode.PublicationOnly);

      Parallel.Invoke
      (
        () =>
        {
          Console.WriteLine("[lambda1] �������������s start.");

          if (lazy2.IsValueCreated)
          {
            Console.WriteLine("[lambda1] ���ɒl���쐬����Ă���B(IsValueCreated=true)");
          }
          else
          {
            Console.WriteLine("[lambda1] ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
            var obj = lazy2.Value;
          }

          Console.WriteLine("[lambda1] �������������s end.");
        },
        () =>
        {
          Console.WriteLine("[lambda2] �������������s start.");

          if (lazy2.IsValueCreated)
          {
            Console.WriteLine("[lambda2] ���ɒl���쐬����Ă���B(IsValueCreated=true)");
          }
          else
          {
            Console.WriteLine("[lambda2] ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
            var obj = lazy2.Value;
          }

          Console.WriteLine("[lambda2] �������������s end.");
        }
      );

      Console.WriteLine("�l�\�z�ς݁H == {0}", lazy1.IsValueCreated);
      Console.WriteLine("�l�\�z�ς݁H == {0}", lazy2.IsValueCreated);

      Console.WriteLine("lazy1�̃X���b�hID: {0}", lazy1.Value.CreatedThreadId);
      Console.WriteLine("lazy2�̃X���b�hID: {0}", lazy2.Value.CreatedThreadId);
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
