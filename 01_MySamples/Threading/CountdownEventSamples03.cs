namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  #region CountdownEventSamples-03
  /// <summary>
  /// CountdownEvent�N���X�ɂ��ẴT���v���ł��B(3)
  /// </summary>
  /// <remarks>
  /// CountdownEvent�N���X�́A.NET 4.0����ǉ����ꂽ�N���X�ł��B
  /// Java��CountDownLatch�N���X�Ɠ����@�\�������Ă��܂��B
  /// </remarks>
  public class CountdownEventSamples03 : IExecutable
  {
    public void Execute()
    {
      //
      // CountdownEvent�ɂ́ACancellationToken���󂯕t����Wait���\�b�h�����݂���.
      // �g�����́AManualResetEventSlim�N���X�̏ꍇ�Ɠ����B
      // 
      // �Q�l���\�[�X:
      //   .NET �N���X���C�u�����T�K-042 (System.Threading.ManualResetEventSlim)
      //   http://d.hatena.ne.jp/gsf_zero1/20110323/p1
      //
      CancellationTokenSource tokenSource = new CancellationTokenSource();
      CancellationToken token = tokenSource.Token;

      using (CountdownEvent cde = new CountdownEvent(1))
      {
        // �����̏�Ԃ�\��.
        Console.WriteLine("InitialCount={0}", cde.InitialCount);
        Console.WriteLine("CurrentCount={0}", cde.CurrentCount);
        Console.WriteLine("IsSet={0}", cde.IsSet);

        Task t = Task.Factory.StartNew(() =>
        {
          Thread.Sleep(TimeSpan.FromSeconds(2));

          token.ThrowIfCancellationRequested();
          cde.Signal();
        }, token);

        //
        // �������L�����Z��.
        //
        tokenSource.Cancel();

        try
        {
          cde.Wait(token);
        }
        catch (OperationCanceledException cancelEx)
        {
          if (token == cancelEx.CancellationToken)
          {
            Console.WriteLine("������CountdownEvent.Wait()���L�����Z������܂���������");
          }
        }

        try
        {
          t.Wait();
        }
        catch (AggregateException aggEx)
        {
          aggEx.Handle(ex =>
          {
            if (ex is OperationCanceledException)
            {
              OperationCanceledException cancelEx = ex as OperationCanceledException;

              if (token == cancelEx.CancellationToken)
              {
                Console.WriteLine("�������^�X�N���L�����Z������܂���������");
                return true;
              }
            }

            return false;
          });
        }

        // ���݂̏�Ԃ�\��.
        Console.WriteLine("InitialCount={0}", cde.InitialCount);
        Console.WriteLine("CurrentCount={0}", cde.CurrentCount);
        Console.WriteLine("IsSet={0}", cde.IsSet);
      }
    }
  }
  #endregion
}
