namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Linq;
  using System.Threading;

  using WinFormsApplication = System.Windows.Forms.Application;
  using WinFormsButton = System.Windows.Forms.Button;
  using WinFormsDockStyle = System.Windows.Forms.DockStyle;
  using WinFormsFlowLayoutPanel = System.Windows.Forms.FlowLayoutPanel;
  using WinFormsForm = System.Windows.Forms.Form;
  using WinFormsMessageBox = System.Windows.Forms.MessageBox;

  #region AsyncOperationSamples-01
  /// <summary>
  /// AsyncOperation�̃T���v��1�ł��B
  /// </summary>
  public class AsyncOperationSamples01 : IExecutable
  {

    class SampleForm : WinFormsForm
    {

      public SampleForm()
      {
        Thread.CurrentThread.Name = "Main Thread";
        InitializeComponent();
      }

      protected void InitializeComponent()
      {
        SuspendLayout();

        WinFormsButton b = new WinFormsButton
        {
          Name = "btn01",
          Text = "btn01"
        };
        b.Click += (s, e) =>
        {

          WinFormsMessageBox.Show("Click Handler Begin : " + string.Format("{0}-{1}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId));

          WinFormsButton btn = s as WinFormsButton;

          // ���̏ꏊ��AsyncOpration���쐬�����WindowsFormsSynchronizationContext�I�u�W�F�N�g�ɂȂ�B
          // (���݂̃X���b�h�̃R���e�L�X�g��Windows Forms�̂���)
          // (WindowsFormsSynchronizationContext.AutoInstall�̒l���f�t�H���g��true�ɂȂ��Ă���̂ŁA�ŏ��̃R���g���[����
          //  new���ꂽ���Ƀ��b�Z�[�W�X���b�h (�����ł�Main Thread)��WindowsFormsSynchronizationContext���ǂݍ��܂��)
          //
          // SynchonizationContext��System.Threading���O��Ԃɑ��݂��A�ȉ��̔h���N���X�����B
          //    ��System.Windows.Forms.WindowsFormsSynchronizationContext   (WindowsForms�p)
          //    ��System.Windows.Threading.DispatcherSynchronizationContext (WPF�p)
          // ���ꂻ��̔h���N���X�́A��{�@�\�ɉ����A�e���Ǝ��̓���ƃv���p�e�B�������Ă���B
          WinFormsMessageBox.Show("Click Handler Begin SyncContext : " + SynchronizationContext.Current.ToString());

          // AsyncOperationManager��CreateOperation���\�b�h���Ă΂ꂽ�ۂɌ��݂�SynchronizationContext���R�s�[����
          // AsyncOperation�̃R���X�g���N�^�ɓn���Ă���͗l�B�Ȃ̂ŁAAsyncOperation��Post,Send�����m�Ƀ��b�Z�[�W�X���b�h��
          // �����ł��邩�ǂ����́A����AsyncOperation�I�u�W�F�N�g���쐬�������_�ł̃X���b�h��SynchronizationContext�����邩�ǂ����ɂ��B
          // �i�V�K�ŃX���b�h���쐬�����ꍇ��SynchronizationContext��null�ƂȂ��Ă���B�j
          //
          // ���ASynchronizationContext�𒼐ڗp���āAPost, Send���s���Ă��悢�B
          // ���݂̃X���b�h��SynchronizationContext���擾����ɂ́ASynchronizationContext.Current�Ŏ擾�ł���B
          // ���݂��Ȃ��ꍇ�́A�ȉ��̂悤�ɂ��Đݒ�ł���B
          //
          // SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

          // ���̏ꏊ��AsyncOperation���쐬�����ꍇ�A���̃X���b�h(Main Thread)��ł͊���WindowsFormsSynchronizationContext���쐬����Ă���
          // �̂ŁA���ꂪAsyncOperation�ɓn��B
          // AsyncOperation�͎��g��Post, PostOperationCompleted���Ă΂ꂽ�ۂɓ����ŕێ����Ă���SynchronizationContext�ɏ������Ϗ����܂��B
          // �i�Ȃ̂ŁA����Ƀ��b�Z�[�W�X���b�h�ɂăf���Q�[�g����������鎖�ɂȂ�B�j
          AsyncOperation asyncOp = AsyncOperationManager.CreateOperation(btn);

          // �ʃX���b�h���ɂ�����SynchronizationContext�𗘗p������ꍇ�͈ȉ��̂悤�ɂ���
          // �R�s�[���쐬���A�ێ����Ă����A�Ώۂ̃X���b�h�ɐݒ肷��B
          //SynchronizationContext syncContext = SynchronizationContext.Current.CreateCopy();

          Thread t = new Thread(() =>
          {
            WinFormsMessageBox.Show("New Thread : " + string.Format("{0}-{1}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId));

            // �V�K�ŕʂ̃X���b�h���쐬�����ꍇ�͍ŏ�SynchronizationContext��null�ƂȂ��Ă���B
            // �V���Ɋ��蓖�Ă�ꍇ�͈ȉ��̂悤�ɂ���B
            //SynchronizationContext.SetSynchronizationContext(syncContext);

            // ���̏ꏊ��AsyncOpration���쐬�����SynchronizationContext�I�u�W�F�N�g�ɂȂ�B
            // (AsyncOperationManager�́A���݂̃X���b�h�ɂ�SynchronizationContext�����݂��Ȃ��ꍇ�͐V����SynchronizationContext��
            //  �������A�ݒ肵�Ă���AsyncOperation�𐶐�����B���XSynchronizationContext��AsyncOperation�𐶐�����ۂɑ��݂��Ă���ꍇ��
            //  �����AsyncOperation�ɓn���Đ�������B�j
            WinFormsMessageBox.Show("New Thread SyncContext Is Null?? (1) : " + (SynchronizationContext.Current == null).ToString());
            //AsyncOperation asyncOp = AsyncOperationManager.CreateOperation(btn);
            WinFormsMessageBox.Show("New Thread SyncContext Is Null?? (2) : " + (SynchronizationContext.Current == null).ToString());

            // �����ŕ\�������SynchronizationContext��, AsyncOperation���ǂ̃X���b�h�ō쐬���ꂽ���ɂ����
            // �o�͂����l���ς��B
            //
            // ���C�x���g�n���h������AsyncOperation���������ꂽ�ꍇ�FWindowsFormsSynchronizationContext
            // ���ʃX���b�h����AsyncOperation���������ꂽ�ꍇ�F    SynchronizationContext
            WinFormsMessageBox.Show(asyncOp.SynchronizationContext.ToString());

            // Post�y��PostOperationCompleted���\�b�h�̌Ăяo���́A���ۂɂ�AsyncOperation�������ŕێ����Ă���SynchronizationContext.Post��
            // �Ăяo���Ă���̂ŁA�ΏۂƂȂ�SynchronizationContext�ɂ���ē��������X���b�h���قȂ�B
            //
            // ���C�x���g�n���h������AsyncOperation���������ꂽ�ꍇ�F���b�Z�[�W�X���b�h���ɓ��� (Main Thread)
            // ���ʃX���b�h����AsyncOperation���������ꂽ�ꍇ�F    �V���ɃX���b�h���쐬���ꂻ�̒��ŏ��� (Thread Pool)
            asyncOp.Post((state) =>
            {
              Thread curThread = Thread.CurrentThread;
              WinFormsMessageBox.Show("AsyncOp.Post : " + string.Format("{0}-{1}-IsThreadPool:{2}", curThread.Name, curThread.ManagedThreadId, curThread.IsThreadPoolThread));
            }, asyncOp);

            asyncOp.PostOperationCompleted((state) =>
            {
              Thread curThread = Thread.CurrentThread;
              WinFormsMessageBox.Show("AsyncOp.PostOperationCompleted : " + string.Format("{0}-{1}-IsThreadPool:{2}", curThread.Name, curThread.ManagedThreadId, curThread.IsThreadPoolThread));
            }, asyncOp);
          });

          t.Name = "Sub Thread";
          t.IsBackground = true;
          t.Start();

        };

        WinFormsFlowLayoutPanel layout = new WinFormsFlowLayoutPanel();
        layout.Dock = WinFormsDockStyle.Fill;
        layout.Controls.Add(b);

        Controls.Add(layout);

        ResumeLayout();
      }
    }

    [STAThread]
    public void Execute()
    {
      // �ȉ��̃R�����g���O�����ŃR���g���[�����ŏ���new���ꂽ�ۂ�
      // WindowsFormsSynchronizationContext���ǂݍ��܂�Ȃ��悤�ɏo���܂��B
      // false�ɂ���ƁA�f�t�H���g��SynchronizationContext���ǂݍ��܂�܂��B
      //WindowsFormsSynchronizationContext.AutoInstall = false;

      WinFormsApplication.EnableVisualStyles();
      WinFormsApplication.Run(new SampleForm());
    }
  }
  #endregion
}
