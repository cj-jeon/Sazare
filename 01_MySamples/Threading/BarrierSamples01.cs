namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  #region BarrierSamples-01
  /// <summary>
  /// Barrier�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// Barrier�N���X�́A.NET 4.0����ǉ����ꂽ�N���X�ł��B
  /// </remarks>
  public class BarrierSamples01 : IExecutable
  {
    // �v�Z�l��ێ�����ϐ�
    long _count;

    public void Execute()
    {
      //
      // Barrier�N���X�́A���s�����𕡐��̃t�F�[�Y���ɋ������삳����ꍇ�ɗ��p����.
      // �܂�A�������s����𓯊�����ۂɗ��p�o����B
      //
      // �Ⴆ�΁A�_���I��3�t�F�[�Y���݂��鏈�����������Ƃ��āA���s���ē��삷�鏈����2����Ƃ���B
      // �e���s�����ɑ΂��āA�t�F�[�Y���Ɉ�U���ʂ����W���A�܂����s���ď������s�����Ƃ���B
      // ���̂悤�ȏꍇ�ɁABarrier�N���X�����ɗ��B
      //
      // Barrier�N���X���C���X�^���X������ۂɁA�ΏۂƂȂ���s�����̐����R���X�g���N�^�Ɏw�肷��B
      // �R���X�g���N�^�ɂ́A�t�F�[�Y���Ɏ��s�����R�[���o�b�N��ݒ肷�邱�Ƃ��o����B
      //
      // ��́ABarrier.SignalAndWait���A�e���s�������Ăяo���Ηǂ��B
      // �R���X�g���N�^�Ɏw�肵�������ASignalAndWait���Ăяo���ꂽ���_��1�t�F�[�Y�I���ƂȂ�
      // �ݒ肵���R�[���o�b�N�����s�����B
      //
      // �e���s�����́ASignalAndWait���Ăяo������ABarrier�ɂĎw�肵������������SignalAndWait��
      // �Ăяo�����܂ŁA�u���b�N�����B
      //
      // �ΏۂƂ�����s�������́A�ȉ��̃��\�b�h�𗘗p���邱�Ƃɂ�葝�������邱�Ƃ��o����B
      //   �EAddParticipants
      //   �ERemoveParticipants
      //
      // CountdownEvent, ManualResetEventSlim�Ɠ������A���̃N���X��SignalAndWait���\�b�h��
      // CancellationToken���󂯕t����I�[�o�[���[�h�����݂���B
      //
      // CountdownEvent�Ɠ������A���̃N���X��IDisposable���������Ă���̂�using�\�B
      //

      //
      // 5�̏������A����̃t�F�[�Y���ɓ��������Ȃ�����s.
      // ����ɁA�t�F�[�Y�P�ʂœr�����ʂ��o�͂���悤�ɂ���.
      //
      using (Barrier barrier = new Barrier(5, PostPhaseProc))
      {
        Parallel.Invoke(
          () => ParallelProc(barrier, 10, 123456, 2),
          () => ParallelProc(barrier, 20, 678910, 3),
          () => ParallelProc(barrier, 30, 749827, 5),
          () => ParallelProc(barrier, 40, 847202, 7),
          () => ParallelProc(barrier, 50, 503295, 777)
        );
      }

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
        barrier.SignalAndWait();
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
  }
  #endregion
}
