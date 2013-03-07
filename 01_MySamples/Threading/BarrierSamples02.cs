namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  #region BarrierSamples-02
  /// <summary>
  /// Barrier�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// Barrier�N���X�́A.NET 4.0����ǉ����ꂽ�N���X�ł��B
  /// </remarks>
  public class BarrierSamples02 : IExecutable
  {
    // �v�Z�l��ێ�����ϐ�
    long _count;
    // �L�����Z���g�[�N���\�[�X.
    CancellationTokenSource _tokenSource;
    // �L�����Z���g�[�N��.
    CancellationToken _token;

    public void Execute()
    {
      _tokenSource = new CancellationTokenSource();
      _token = _tokenSource.Token;

      //
      // 5�̏������A����̃t�F�[�Y���ɓ��������Ȃ�����s.
      // ����ɁA�t�F�[�Y�P�ʂœr�����ʂ��o�͂���悤�ɂ��邪
      // 5�b�o�߂������_�ŃL�����Z�����s���B
      //
      using (Barrier barrier = new Barrier(5, PostPhaseProc))
      {

        try
        {
          Parallel.Invoke(
            () => ParallelProc(barrier, 10, 123456, 2),
            () => ParallelProc(barrier, 20, 678910, 3),
            () => ParallelProc(barrier, 30, 749827, 5),
            () => ParallelProc(barrier, 40, 847202, 7),
            () => ParallelProc(barrier, 50, 503295, 777),
            () =>
            {
              //
              // 5�b�ԑҋ@������ɃL�����Z�����s��.
              //
              Thread.Sleep(TimeSpan.FromSeconds(5));
              Console.WriteLine("���������@�L�����Z���@��������");
              _tokenSource.Cancel();
            }
          );
        }
        catch (AggregateException aggEx)
        {
          aggEx.Handle(HandleAggregateException);
        }
      }

      _tokenSource.Dispose();

      Console.WriteLine("�ŏI�l�F{0}", _count);
    }

    //
    // �e���񏈗��p�̃A�N�V����.
    //
    void ParallelProc(Barrier barrier, int randomMaxValue, int randomSeed, int modValue)
    {
      //
      // ���t�F�[�Y.
      //
      Calculate(barrier, randomMaxValue, randomSeed, modValue, 100);

      //
      // ���t�F�[�Y.
      //
      Calculate(barrier, randomMaxValue, randomSeed, modValue, 5000);

      //
      // ��O�t�F�[�Y.
      //
      Calculate(barrier, randomMaxValue, randomSeed, modValue, 10000);
    }

    //
    // �v�Z����.
    //
    void Calculate(Barrier barrier, int randomMaxValue, int randomSeed, int modValue, int loopCountMaxValue)
    {
      Random rnd = new Random(randomSeed);
      Stopwatch watch = Stopwatch.StartNew();

      int loopCount = rnd.Next(loopCountMaxValue);
      Console.WriteLine("[Phase{0}] ���[�v�J�E���g�F{1}, TASK:{2}", barrier.CurrentPhaseNumber, loopCount, Task.CurrentId);

      for (int i = 0; i < loopCount; i++)
      {
        //
        // �L�����Z����Ԃ��`�F�b�N.
        // �ʂ̏ꏊ�ɂăL�����Z�����s���Ă���ꍇ��
        // OperationCanceledException����������.
        //
        _token.ThrowIfCancellationRequested();

        // �K�x�Ɏ��Ԃ�������悤�ɒ���.
        if (rnd.Next(10000) % modValue == 0)
        {
          Thread.Sleep(TimeSpan.FromMilliseconds(10));
        }

        Interlocked.Add(ref _count, (i + rnd.Next(randomMaxValue)));
      }

      watch.Stop();
      Console.WriteLine("[Phase{0}] SignalAndWait -- TASK:{1}, ELAPSED:{2}", barrier.CurrentPhaseNumber, Task.CurrentId, watch.Elapsed);

      try
      {
        //
        // �V�O�i���𔭍s���A���Ԃ̃X���b�h�������̂�҂�.
        //
        barrier.SignalAndWait(_token);
      }
      catch (BarrierPostPhaseException postPhaseEx)
      {
        //
        // Post Phase�A�N�V�����ɂăG���[�����������ꍇ�͂����ɗ���.
        // (�{���ł���΁A�L�����Z������Ȃǂ̃G���[�������K�v)
        //
        Console.WriteLine("*** {0} ***", postPhaseEx.Message);
        throw;
      }
      catch (OperationCanceledException cancelEx)
      {
        //
        // �ʂ̏ꏊ�ɂăL�����Z�����s��ꂽ.
        //
        // ���ɏ�������������SignalAndWait���ĂсA���Ԃ̃X���b�h��
        // �҂��Ă����ԂŃL�����Z�������������ꍇ��
        //    �u���삪��������܂����B�v�ƂȂ�B
        //
        // SignalAndWait���ĂԑO�ɁA���ɃL�����Z����ԂƂȂ��Ă����Ԃ�
        // SignalAndWait���ĂԂ�
        //    �u���삪�L�����Z������܂����B�v�ƂȂ�B
        //
        Console.WriteLine("�L�����Z������܂��� -- MESSAGE:{0}, TASK:{1}", cancelEx.Message, Task.CurrentId);
        throw;
      }
    }

    //
    // Barrier�ɂāA�e�t�F�[�Y�������������ۂɌĂ΂��R�[���o�b�N.
    // (Barrier�N���X�̃R���X�g���N�^�ɂĐݒ肷��)
    //
    void PostPhaseProc(Barrier barrier)
    {
      //
      // Post Phase�A�N�V�����́A�������s���Ă��鏈�����S��SignalAndWait��
      // �Ă΂Ȃ���Δ������Ȃ��B
      //
      // �܂�A���̏����������Ă���ԁA���̓������s�����͑S�ău���b�N����Ă����ԂƂȂ�B
      //
      long current = Interlocked.Read(ref _count);

      Console.WriteLine("���݂̃t�F�[�Y�F{0}, �Q���v�f���F{1}", barrier.CurrentPhaseNumber, barrier.ParticipantCount);
      Console.WriteLine("t���ݒl�F{0}", current);

      //
      // �ȉ��̃R�����g���O���ƁA����Post Phase�A�N�V�����ɂ�
      // �S�Ă�SignalAndWait���Ăяo���Ă���A�����ɂ�BarrierPostPhaseException��
      // ��������B
      //
      //throw new InvalidOperationException("dummy");
    }

    //
    // AggregateException.Handle���\�b�h�ɐݒ肳���R�[���o�b�N.
    //
    bool HandleAggregateException(Exception ex)
    {
      if (ex is OperationCanceledException)
      {
        OperationCanceledException cancelEx = ex as OperationCanceledException;
        if (_token == cancelEx.CancellationToken)
        {
          Console.WriteLine("������Barrier���̏������L�����Z�����ꂽ MESSAGE={0} ������", cancelEx.Message);
          return true;
        }
      }

      return false;
    }
  }
  #endregion
}
