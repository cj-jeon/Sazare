namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  using WinFormsApplication = System.Windows.Forms.Application;
  using WinFormsForm = System.Windows.Forms.Form;

  #region WindowsFormsSynchronizationContextSamples-01
  /// <summary>
  /// WindowsFormsSynchronizationContext�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  /// <!-- <remarks>
  /// WindowsFormsSynchronizationContext�́ASynchronizationContext�N���X�̔h���N���X�ł��B
  /// �f�t�H���g�ł́AWindows Forms�ɂāA�ŏ��̃t�H�[�����쐬���ꂽ�ۂɎ����I�ɐݒ肳��܂��B
  /// (AutoInstall�ÓI�v���p�e�B�ɂāA�����ύX�\�B�j
  /// </remakrs>
  public class WindowsFormsSynchronizationContextSamples01 : IExecutable
  {
    class SampleForm : WinFormsForm
    {
      public string ContextTypeName { get; set; }

      public SampleForm()
      {
        Load += (s, e) =>
        {
          //
          // UI�X���b�h�̃X���b�hID��\��.
          //
          PrintMessageAndThreadId("UI Thread");

          //
          // ���݂̓����R���e�L�X�g���擾.
          //   Windows Forms�̏ꍇ�́AWinFormsSynchronizationContext�ƂȂ�B
          //
          SynchronizationContext context = SynchronizationContext.Current;
          ContextTypeName = context.ToString();

          //
          // Send�́A�����R���e�L�X�g�ɑ΂��ē������b�Z�[�W�𑗂�B
          // Post�́A�����R���e�L�X�g�ɑ΂��Ĕ񓯊����b�Z�[�W�𑗂�B
          //
          // �܂�ASendMessage��PostMessage�Ɠ���.
          //
          context.Send((obj) => { PrintMessageAndThreadId("Send"); }, null);
          context.Post((obj) => { PrintMessageAndThreadId("Post"); }, null);

          //
          // UI�X���b�h�Ɗ֌W�Ȃ��ʂ̃X���b�h.
          //
          Task.Factory.StartNew(() => { PrintMessageAndThreadId("Task.Factory"); });

          PrintMessageAndThreadId("Form.Load");
          Close();
        };

        FormClosing += (s, e) =>
        {
          //
          // Send��Post���Ăяo���A�ǂ̃^�C�~���O�ŏo�͂���邩�m�F.
          //
          SynchronizationContext context = SynchronizationContext.Current;
          context.Send((obj) => { PrintMessageAndThreadId("Send--2"); }, null);
          context.Post((obj) => { PrintMessageAndThreadId("Post--2"); }, null);

          //
          // UI�X���b�h�Ɗ֌W�Ȃ��ʂ̃X���b�h.
          //
          Task.Factory.StartNew(() => { PrintMessageAndThreadId("Task.Factory"); });

          PrintMessageAndThreadId("Form.FormClosing");
        };

        FormClosed += (s, e) =>
        {
          //
          // Send��Post���Ăяo���A�ǂ̃^�C�~���O�ŏo�͂���邩�m�F.
          //
          SynchronizationContext context = SynchronizationContext.Current;
          context.Send((obj) => { PrintMessageAndThreadId("Send--3"); }, null);
          context.Post((obj) => { PrintMessageAndThreadId("Post--3"); }, null);

          //
          // UI�X���b�h�Ɗ֌W�Ȃ��ʂ̃X���b�h.
          //
          Task.Factory.StartNew(() => { PrintMessageAndThreadId("Task.Factory"); });

          PrintMessageAndThreadId("Form.FormClosed");
        };
      }

      private void PrintMessageAndThreadId(string message)
      {
        Console.WriteLine("{0,-17}, �X���b�hID: {1}", message, Thread.CurrentThread.ManagedThreadId);
      }
    }

    [STAThread]
    public void Execute()
    {
      //
      // SynchronizationContext�́A�����R���e�L�X�g��l�X�ȓ������f���ɔ��f�����邽�߂�
      // ������񋟂���N���X�ł���B
      //
      // �h���N���X�Ƃ��Ĉȉ��̃N���X�����݂���B
      //   �EWindowsFormsSynchronizationContext   (WinForms�p)
      //   �EDispatcherSynchronizationContext   (WPF�p)
      //
      // ��{�I�ɁAWinForms��������WPF�𗘗p���Ă����Ԃ�
      // UI�X���b�h�Ƃ͕ʂ̃X���b�h����AUI���X�V����ۂɗ��ŗ��p����Ă���N���X�ł���B
      // (BackgroundWorker���A���̃N���X�𗘗p����UI�X���b�h�ɍX�V�������Ă���B�j
      //
      // ���݂̃X���b�h��SynchronizationContext���擾����ɂ́ACurrent�ÓI�v���p�e�B�𗘗p����B
      // �����SynchronizationContext�������I�ɐݒ肷��ɂ́ASetSynchronizationContext���\�b�h�𗘗p����B
      //
      // �f�t�H���g�ł́A�Ǝ��ɍ쐬�����X���b�h�̏ꍇ
      // SynchronizationContext.Current�̖߂�l��null�ƂȂ�B
      //
      Console.WriteLine(
        "���݂̃X���b�h�ł�SynchronizationContext�̏�ԁF{0}",
        SynchronizationContext.Current == null
          ? "NULL"
          : SynchronizationContext.Current.ToString()
      );

      //
      // �t�H�[�����N�����A�l���m�F.
      //
      WinFormsApplication.EnableVisualStyles();

      SampleForm aForm = new SampleForm();
      WinFormsApplication.Run(aForm);

      Console.WriteLine("WinForms�ł�SynchronizationContext�̌^���F{0}", aForm.ContextTypeName);
    }
  }
  #endregion
}
