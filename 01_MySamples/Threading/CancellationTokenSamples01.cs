namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net;
  using System.Threading;
  using System.Threading.Tasks;

  #region CancellationTokenSamples-01
  /// <summary>
  /// CancellationToken��CancellationTokenSource�ɂ��ẴT���v���ł��B
  /// </summary>
  public class CancellationTokenSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // CancellationToken��CancellationTokenSource��
      // .NET Framework 4.0����ǉ����ꂽ�^�ł���B
      //
      // �񓯊�����܂��͒����Ԃ̓��������Ȃǂ̍ہA�ėp�I�ȃL�����Z���������������邽�߂ɗ��p�ł���B
      // �悭�^�X�N (System.Threading.Tasks.Task)�ƈꏏ�ɗ��p����Ă���
      // �Ⴊ�������A�ʂɃ^�X�N�łȂ��Ă����p�ł���B�i�ʏ��Thread��ManualResetEventSlim�Ȃ�)
      //
      // CancellationTokenSource��CancellationToken�͐e�q�̂悤�Ȋ֌W�ɂ���
      //   �ECancellationTokenSource�̓L�����Z����������B
      //   �ECancellationToken�́A�L�����Z�����ꂽ�������m����B
      // �ƂȂ��Ă���B
      //
      // CancellationToken�ɂāA�L�����Z�����ꂽ���ۂ������m����ɂ͈ȉ��̃v���p�e�B�܂��̓��\�b�h�𗘗p����.
      //   �EIsCancellationRequested
      //   �EThrowIfCancellationRequested
      // ��L�̓��AThrowIfCancellationRequested���\�b�h�̓L�����Z������Ă����ꍇ��
      // OperationCanceledException�𔭐�������B
      //
      // ���̂ق��ɂ��ACancellationToken�ɂ͈ȉ��̃v���p�e�B�ƃ��\�b�h�����݂���B
      //   �EWaitHandle
      //   �ERegister
      // WaitHandle�v���p�e�B�́A�Y���g�[�N�����L�����Z�����ꂽ�ۂɒʒm�����ҋ@�n���h���ł���B
      // ���̑ҋ@�n���h���𗘗p���邱�ƂŁA�g�[�N�����L�����Z�����ꂽ��Ɏ��s����鏈���Ȃǂ��L�q�o����B
      // Register���\�b�h�́A�g�[�N�����L�����Z�����ꂽ�ۂɊ֘A���ăL�����Z�������Ȃǂ��s�������I�u�W�F�N�g�����݂���
      // �ꍇ�Ȃǂɗ��p�ł���BCancellationToken�͑���̃L�����Z����\�����̂ł���A�I�u�W�F�N�g�̏�Ԃ��L�����Z��������
      // �ꍇ�ɂ��̃��\�b�h�𗘗p���ēo�^���Ă���.
      //
      // �܂��ACancellationTokenSource�ɂ́A�ȉ���static���\�b�h�����݂���B
      //   �ECreateLinkedTokenSource
      // CreateLinkedTokenSource���\�b�h�́A�����ɕ����̃g�[�N�����󂯎��
      // �����̃g�[�N����R�Â�����Ԃ̃g�[�N���\�[�X���쐬���Ă����B
      // ����𗘗p���邱�Ƃɂ��A�����̃g�[�N���S�Ă��L�����Z�����ꂽ�ۂɃL�����Z�������ɂȂ�
      // CancellationToken�𐶐����鎖���o����B
      // 
      // �֘A����S�Ẵg�[�N�����L�����Z����ԂƂȂ����ۂɍs���L�����Z���������L�q����ꍇ�Ȃǂɗ��p�ł���B
      //
      var cts = new CancellationTokenSource();

      ////////////////////////////////////////////////////////////////////
      //
      // Thread�𗘗p���ẴL�����Z������.
      //
      var t = new Thread(() => Work1(cts.Token));
      t.Start();

      Thread.Sleep(TimeSpan.FromSeconds(3));

      // �L�����Z�����s.
      cts.Cancel();

      ////////////////////////////////////////////////////////////////////
      //
      // ThreadPool�𗘗p���ẴL�����Z������.
      //
      // CancellationTokenSource�́A��x�L�����Z�������
      // �ė��p�ł��Ȃ��\���ƂȂ��Ă���B�i�܂�A�L�����Z����Ɏ擾����Token�𗘗p���Ă�
      // �ŏ�����L�����Z�����ꂽ���ɂȂ��Ă���B�j
      //
      cts = new CancellationTokenSource();
      ThreadPool.QueueUserWorkItem((obj) => Work2(cts.Token), null);

      Thread.Sleep(TimeSpan.FromSeconds(3));
      cts.Cancel();

      ////////////////////////////////////////////////////////////////////
      //
      // ManualResetEventSlim�𗘗p���ẴL�����Z������.
      //
      cts = new CancellationTokenSource();

      var waitHandle = new ManualResetEventSlim(false);
      Task.Factory.StartNew(() => Work3(cts.Token, waitHandle));

      Thread.Sleep(TimeSpan.FromSeconds(3));
      cts.Cancel();

      ////////////////////////////////////////////////////////////////////
      //
      // CancellationToken.WaitHandle�𗘗p���ẴL�����Z���҂�.
      //
      cts = new CancellationTokenSource();
      using (var countdown = new CountdownEvent(3))
      {
        var token = cts.Token;

        Parallel.Invoke
        (
          // 3�b��ɃL�����Z�����������s.
          () =>
          {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            cts.Cancel();
            countdown.Signal();
          },
          // �g�[�N����WaitHandle�𗘗p���ăL�����Z���҂�.
          () =>
          {
            Console.WriteLine(">>> �L�����Z���҂��E�E�E");
            token.WaitHandle.WaitOne();
            Console.WriteLine(">>> ���삪�L�����Z�����ꂽ�̂ŁAWaitHandle����ʒm����܂����B");
            countdown.Signal();
          },
          // �L�����Z�������܂Ŏ��s����鏈��.
          () =>
          {
            try
            {
              while (true)
              {
                token.ThrowIfCancellationRequested();
                Console.WriteLine(">>> wait...");
                Thread.Sleep(TimeSpan.FromMilliseconds(700));
              }
            }
            catch (OperationCanceledException ex)
            {
              Console.WriteLine(">>> {0}", ex.Message);
            }

            countdown.Signal();
          }
        );

        countdown.Wait();
      }

      ////////////////////////////////////////////////////////////////////
      //
      // CancellationToken.Register�𗘗p�����֘A�I�u�W�F�N�g�̃L�����Z������.
      // CancellationToken.Register���\�b�h�ɂ́A�L�����Z�����ꂽ�ۂɎ��s�����
      // �A�N�V������ݒ肷�邱�Ƃ��o����B����𗘗p���邱�ƂŁA�g�[�N���̃L�����Z������
      // �֘A���ăL�����Z��������L�����Z�����ɂ̂ݎ��s���鏈�����L�q���邱�Ƃ��o����B
      //
      // �ȉ��ł́AWebClient�𗘗p���Ĕ񓯊��������s���Ă���Œ��Ƀg�[�N�����L�����Z����
      // ����ɁAWebClient���L�����Z������悤�ɂ��Ă���B�i�኱���������E�E�E�Ew�j
      //
      cts = new CancellationTokenSource();

      var token2 = cts.Token;
      var client = new WebClient();

      client.DownloadStringCompleted += (s, e) =>
      {
        Console.WriteLine(">>> �L�����Z�����ꂽ�H == {0}", e.Cancelled);
      };

      token2.Register(() =>
        {
          Console.WriteLine(">>> ���삪�L�����Z�����ꂽ�̂ŁAWebClient�����L�����Z�����܂��B");
          client.CancelAsync();
        }
      );

      Console.WriteLine(">>> WebClient.DownloadStringAsync...");
      client.DownloadStringAsync(new Uri(@"http://d.hatena.ne.jp/gsf_zero1/"));

      Thread.Sleep(TimeSpan.FromMilliseconds(200));
      cts.Cancel();

      ////////////////////////////////////////////////////////////////////
      //
      // CancellationTokenSource�ɂ́A�����̃g�[�N���𓯊������邽�߂�
      // CreateLinkedTokenSource���\�b�h�����݂���B
      // ���̃��\�b�h�𗘗p���邱�Ƃɂ��A�����̃g�[�N���̃L�����Z�����������邱�Ƃ��o����B
      // 
      // ���ACreateLinkedTokenSource�ō쐬���������N�g�[�N���\�[�X��
      // Dispose���Ȃ��Ƃ����Ȃ����ɒ��ӁB
      //
      var cts2 = new CancellationTokenSource();
      var cts3 = new CancellationTokenSource();

      var cts2Token = cts2.Token;
      var cts3Token = cts3.Token;

      using (var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts2Token, cts3Token))
      {
        var linkedCtsToken = linkedCts.Token;

        using (var countdown = new CountdownEvent(2))
        {
          Parallel.Invoke
          (
            // 1�b���cts2���L�����Z��
            () =>
            {
              Thread.Sleep(TimeSpan.FromSeconds(1));
              Console.WriteLine(">>> cts2.Canel()");
              cts2.Cancel();

              countdown.Signal();
            },
            // 2�b���cts3���L�����Z��.
            () =>
            {
              Thread.Sleep(TimeSpan.FromSeconds(2));
              Console.WriteLine(">>> cts3.Canel()");
              cts3.Cancel();

              countdown.Signal();
            }
          );

          countdown.Wait();
        }

        // �e�g�[�N���̏�Ԃ��`�F�b�N.
        Console.WriteLine(">>>> cts2Token.IsCancellationRequested == {0}", cts2Token.IsCancellationRequested);
        Console.WriteLine(">>>> cts3Token.IsCancellationRequested == {0}", cts3Token.IsCancellationRequested);
        // �����N�g�[�N���Ȃ̂ŁA�R�Â��g�[�N���S�Ă��L�����Z���ɂȂ�Ǝ����I�ɃL�����Z����ԂƂȂ�B
        Console.WriteLine(">>>> linkedCtsToken.IsCancellationRequested == {0}", linkedCtsToken.IsCancellationRequested);
      }

      Thread.Sleep(TimeSpan.FromSeconds(1));
    }

    void Work1(CancellationToken cancelToken)
    {
      //
      // �L�����Z����������������ꍇ�Atry-catch��p�ӂ���
      // OperationCanceledException���󂯎��悤�ɂ��Ă���.
      //
      try
      {
        while (true)
        {
          //
          // �����A�O���ŃL�����Z������Ă����ꍇ
          // ���̃��\�b�h��OperationCanceledException�𔭐�������B
          //
          cancelToken.ThrowIfCancellationRequested();

          Console.WriteLine(">> wait...");
          Thread.Sleep(TimeSpan.FromSeconds(1));
        }
      }
      catch (OperationCanceledException ex)
      {
        //
        // �L�����Z�����ꂽ.
        //
        Console.WriteLine(">>> {0}", ex.Message);
      }
    }

    void Work2(CancellationToken cancelToken)
    {
      //
      // IsCancellationRequested�v���p�e�B�𗘗p����
      // �L�����Z�������m����.
      //
      while (true)
      {
        if (cancelToken.IsCancellationRequested)
        {
          // �L�����Z�����ꂽ.
          Console.WriteLine(">>> ����̓L�����Z������܂����B");
          break;
        }

        Console.WriteLine(">> wait...");
        Thread.Sleep(TimeSpan.FromSeconds(1));
      }
    }

    void Work3(CancellationToken cancelToken, ManualResetEventSlim waitHandle)
    {
      try
      {
        Console.WriteLine(">> waitHandle.Wait...");
        waitHandle.Wait(cancelToken);
        Console.WriteLine(">> awake!");
      }
      catch (OperationCanceledException ex)
      {
        // �L�����Z�����ꂽ.
        Console.WriteLine(">>> {0}", ex.Message);
      }
    }
  }
  #endregion
}
