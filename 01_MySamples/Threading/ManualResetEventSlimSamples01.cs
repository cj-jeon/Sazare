namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  #region ManualResetEventSlimSamples-01
  /// <summary>
  /// ManualResetEventSlim�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// ManualResetEventSlim�N���X�́A.NET 4.0�Œǉ����ꂽ�N���X�ł��B
  /// ���X���݂��Ă���ManualResetEvent�N���X�����y�ʂȃN���X�ƂȂ��Ă��܂��B
  /// �������ẮA�ȉ��̓_���������܂��B
  ///   �EWait���\�b�h��CancellationToken���󂯕t����I�[�o�[���[�h�����݂���B
  ///   �E���ɒZ�����Ԃ̑ҋ@�̏ꍇ�A���̃N���X�͑ҋ@�n���h���ł͂Ȃ��r�W�[�X�s���𗘗p���đҋ@����B
  /// </remarks>
  public class ManualResetEventSlimSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // �ʏ�̎g����.
      //
      ManualResetEventSlim mres = new ManualResetEventSlim(false);

      ThreadPool.QueueUserWorkItem(DoProc, mres);

      Console.Write("���C���X���b�h�ҋ@���E�E�E");
      mres.Wait();
      Console.WriteLine("�I��");

      //
      // Wait���\�b�h��CancellationToken���󂯕t����I�[�o�[���[�h���g�p�B
      //
      mres.Reset();

      CancellationTokenSource tokenSource = new CancellationTokenSource();
      CancellationToken token = tokenSource.Token;

      Task task = Task.Factory.StartNew(DoProc, mres);

      //
      // �L�����Z����Ԃɐݒ�.
      //
      tokenSource.Cancel();

      Console.Write("���C���X���b�h�ҋ@���E�E�E");

      try
      {
        //
        // CancellationToken���w�肵�āAWait�Ăяo���B
        // ���̏ꍇ�́A�ȉ��̂ǂ��炩�̏����𖞂��������_��Wait�����������B
        //  �E�ʂ̏ꏊ�ɂāASet���Ă΂�ăV�O�i����ԂƂȂ�B
        //  �ECancellationToken���L�����Z�������B
        //
        // �g�[�N�����L�����Z�����ꂽ�ꍇ�AOperationCanceledException����������̂�
        // CancellationToken���w�肷��Wait���Ăяo���ꍇ�́Atry-catch���K�{�ƂȂ�B
        //
        // ����̗�̏ꍇ�́A�\��CancellationToken���L�����Z�����Ă���̂�
        // �^�X�N�����ŃV�O�i����Ԃɐݒ肳��������ɁA�L�����Z����Ԃɐݒ肳���B
        // �Ȃ̂ŁA���s���ʂɂ́A�u*** �V�O�i����Ԃɐݒ� ***�v�Ƃ��������͏o�͂���Ȃ��B
        //
        mres.Wait(token);
      }
      catch (OperationCanceledException cancelEx)
      {
        Console.Write("*** {0} *** ", cancelEx.Message);
      }

      Console.WriteLine("�I��");
    }

    void DoProc(object stateObj)
    {
      Thread.Sleep(TimeSpan.FromSeconds(1));
      Console.Write("*** �V�O�i����Ԃɐݒ� *** ");
      (stateObj as ManualResetEventSlim).Set();
    }
  }
  #endregion
}
