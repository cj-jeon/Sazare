namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  #region SemaphoreSlimSamples-02
  /// <summary>
  /// SemaphoreSlim�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// SemaphoreSlim�N���X�́A.NET 4.0����ǉ����ꂽ�N���X�ł��B
  /// �]�����瑶�݂��Ă���Semaphore�N���X�̌y�ʔłƂȂ�܂��B
  /// </remarks>
  public class SemaphoreSlimSamples02 : IExecutable
  {
    public void Execute()
    {
      //
      // SemaphoreSlim��Wait���\�b�h�ɂ̓L�����Z���g�[�N����
      // �󂯕t����I�[�o�[���[�h�����݂���B
      //
      // CountdownEvent��Barrier�̏ꍇ�Ɠ������AWait���\�b�h��
      // �L�����Z���g�[�N�����w�肵���ꍇ�A�ʂ̏ꏊ�ɂăL�����Z����
      // �s����ƁAOperationCanceledException����������B
      //
      const int timeout = 2000;

      CancellationTokenSource tokenSource = new CancellationTokenSource();
      CancellationToken token = tokenSource.Token;

      using (SemaphoreSlim semaphore = new SemaphoreSlim(2))
      {
        //
        // ���炩���߁A�Z�}�t�H�̏���܂�Wait���Ă���
        // ��̃X���b�h������Ȃ��悤�ɂ��Ă���.
        //
        semaphore.Wait();
        semaphore.Wait();

        //
        // �R�̃^�X�N���쐬����.
        //  �P�ڂ̃^�X�N�F�L�����Z���g�[�N�����w�肵�Ė������ҋ@.
        //  �Q�ڂ̃^�X�N�F�L�����Z���g�[�N���ƃ^�C���A�E�g�l���w�肵�đҋ@.
        //  �R�ڂ̃^�X�N�F���莞�ԑҋ@������A�L�����Z���������s��.
        //
        Parallel.Invoke
          (
            () => WaitProc1(semaphore, token),
            () => WaitProc2(semaphore, timeout, token),
            () => DoCancel(timeout, tokenSource)
          );

        semaphore.Release();
        semaphore.Release();
        Console.WriteLine("CurrentCount={0}", semaphore.CurrentCount);
      }
    }

    // �L�����Z���g�[�N�����w�肵�Ė������ҋ@.
    void WaitProc1(SemaphoreSlim semaphore, CancellationToken token)
    {
      try
      {
        Console.WriteLine("WaitProc1=�ҋ@�J�n");
        semaphore.Wait(token);
      }
      catch (OperationCanceledException cancelEx)
      {
        Console.WriteLine("WaitProc1={0}", cancelEx.Message);
      }
      finally
      {
        Console.WriteLine("WaitProc1_CurrentCount={0}", semaphore.CurrentCount);
      }
    }

    // �L�����Z���g�[�N���ƃ^�C���A�E�g�l���w�肵�đҋ@.
    void WaitProc2(SemaphoreSlim semaphore, int timeout, CancellationToken token)
    {
      try
      {
        bool isSuccess = semaphore.Wait(timeout, token);
        if (!isSuccess)
        {
          Console.WriteLine("WaitProc2={0}t�����^�C���A�E�g����", isSuccess);
        }
      }
      catch (OperationCanceledException cancelEx)
      {
        Console.WriteLine("WaitProc2={0}", cancelEx.Message);
      }
      finally
      {
        Console.WriteLine("WaitProc2_CurrentCount={0}", semaphore.CurrentCount);
      }
    }

    // ���莞�ԑҋ@������A�L�����Z���������s��.
    void DoCancel(int timeout, CancellationTokenSource tokenSource)
    {
      Console.WriteLine("�ҋ@�J�n�F{0}msec", timeout + 1000);
      Thread.Sleep(timeout + 1000);

      Console.WriteLine("�ҋ@�I��");
      Console.WriteLine("�����L�����Z�����s����");
      tokenSource.Cancel();
    }
  }
  #endregion
}
