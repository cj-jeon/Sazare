namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;
  using System.Windows;
  using System.Windows.Controls;

  #region ProgressSamples-01
  /// <summary>
  /// System.Progress<T>�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// ���̃N���X�́A.NET Framework 4.5����ǉ����ꂽ�^�ł��B
  /// </remarks>
  public class ProgressSamples01 : IExecutable
  {
    /// <summary>
    /// �T���v���p�E�B���h�E
    /// </summary>
    /// <remarks>
    /// ���̃E�B���h�E�ɂ́AProgressBar��������z�u����Ă��܂��B
    /// </remarks>
    class SampleWindow : Window
    {
      const double MIN = 0.0;
      const double MAX = 100.0;

      ProgressBar _bar;

      public SampleWindow()
      {
        InitializeControl();
        InitializeEvent();
      }

      void InitializeControl()
      {
        Width = 400;
        Height = 80;

        _bar = new ProgressBar
               {
                 Minimum = MIN
                 ,
                 Maximum = MAX
                 ,
                 Value = MIN
                 ,
                 SmallChange = MIN
               };

        Content = _bar;
      }

      void InitializeEvent()
      {
        //
        // ���[�h�C�x���g.
        //   ����Ă邱�Ƃ́A�P���Ƀv���O���X�o�[�̐i����L�΂��Ă�������.
        //   �i����L�΂������ɁAProgress<T>�𗘗p���Ă���.
        //
        //   ������await���g�p���Ă���̂Ń����_��async���w��.
        //
        Loaded += async (s, e) =>
        {
          //
          // .NET Framework 4.5���ACancellationTokenSource�̃R���X�g���N�^��
          // �L�����Z����ԂɂȂ�܂ł̃^�C���A�E�g�l��ݒ�ł���悤�ɂȂ����B
          // ���L�̏ꍇ���ƁA5�b��Ɏ����I�ɃL�����Z�������ɂȂ�.
          //
          var tokenSource = new CancellationTokenSource(5000);

          //
          // �v���O���X�o�[�̐i����L�΂����߂�Progress<T>���\�z.
          // �R���X�g���N�^��Action��n���Ă��AProgressChanged�C�x���g�Ƀn���h����ݒ肵�Ă��ǂ���ł��ǂ��B
          //
          // Progress<T>�́A�C���X�^���X�������Ɍ��݂�SynchronizationContext���L���v�`������B
          // �Ȃ̂ŁAUI�����ޏ������s���ꍇ�́A�K��UI�X���b�h��ŃC���X�^���X�𐶐�����K�v������B
          //
          var progress = new Progress<int>(SetProgress);
          // �킴�ƁAUI�X���b�h�ł͂Ȃ��ꏊ�ŃC���X�^���X�𐶐����Ă���.
          // ���������PerformStep���\�b�h�ɓn���ƁASetProgress���\�b�h�ɓ����Ă������_��
          // Control.InvokeRequired��true�ƂȂ�B�܂�AUI�X���b�h�ȊO����SetProgress��
          // �Ă΂�Ă���̂ŁAInvoke���Ȃ��Ƃ����Ȃ���ԂƂȂ�B
          //var progress2 = Task.Run(() => new Progress<int>(SetProgress)).Result;

          //
          // �����J�n.
          //   await���w�肵�Ă���̂ŁA������UI�X���b�h�Ɛ؂藣����Ď��s����
          //   �v���O���X�o�[�̐i���ݒ�̎��̂�UI�X���b�h�Ŏ��s�����. (IProgress<T>.Report�����SetProgress�Ăяo��)
          //   await��̃^�C�g���ݒ�́APerformStep���\�b�h���I��������s�����B
          //
          // �������ɓn���Ă���progress���Aprogress2�ɕύX���Ď��s�����
          // ��ʏ�̃v���O���X�o�[�̐i������ؐi�܂Ȃ��Ȃ�B
          // ����́Aprogress2�̕����AUI�X���b�h�ł͂Ȃ��ꏊ�Ő������ꂽ����
          // �L���v�`�����ꂽSynchronizationContext��DispatcherSynchronizationContext�ł͖������߂ł���B
          //
          await PerformStep(tokenSource.Token, progress);
          Title = "DONE.";
        };
      }

      async Task PerformStep(CancellationToken token, IProgress<int> progress)
      {
        for (; ; )
        {
          foreach (var value in Enumerable.Range(0, 100))
          {
            if (token.IsCancellationRequested)
            {
              return;
            }

            await Task.Delay(10);

            //
            // Report���\�b�h���Ăяo���ɂ�
            // IProgress<T>�ɃL���X�g���ė��p����K�v������B
            // (Progress<T>�ɂāA�����I�C���^�[�t�F�[�X��������Ă��邽�߁j
            //
            progress.Report(value);
          }
        }
      }

      void SetProgress(int newValue)
      {
        //
        // UI�X���b�h�Ŏ��s����Ă��Ȃ��ꍇ�����o�I�Ɍ������̂�
        // UI�X���b�h�Ŏ��s����Ă��Ȃ��ꍇ�͂킴�Ɖ������Ȃ�.
        //
        if (!_bar.Dispatcher.CheckAccess())
        {
          return;
        }

        _bar.Value = newValue;
      }
    }

    [STAThread]
    public void Execute()
    {
      //
      // Progress<T>�́A.NET Framework 4.5�Œǉ����ꂽ�^�ł���B
      // Progress<T>�́AIProgress<T>�C���^�[�t�F�[�X���������Ă���
      // �����ʂ�A�i���󋵂��������邽�߂ɑ��݂���B
      //
      // ���p����ꍇ�A�R���X�g���N�^��Action<T>���w�肷�邩
      // ProgressChanged�C�x���g���n���h�����邩�ŏ����ł���B
      //
      // ���AProgress<T>�̓C���X�^���X���쐬�����ۂ�
      // ���݂�SynchronizationContext���L���v�`����
      // ProgressChanged�C�x���g���L���v�`������SynchronizationContext���
      // ���s���Ă���邽�߁A�C�x���g�n���h�����ŃR���g���[���𑀍삵�Ă���薳���B
      // (�C���X�^���X�̍쐬���̂��C�x���g�X���b�h�ȊO�ōs���Ă���ꍇ�͕ʁj
      //
      // �R���\�[���A�v���̂悤��SynchronizationContext���R�Â��Ȃ�
      // �R���e�L�X�g�̏ꍇ�́AThreadPool��Ŏ��s�����B
      //
      var app = new Application();
      app.Run(new SampleWindow());
    }
  }
  #endregion
}
