namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  //
  // Alias�ݒ�.
  //
  using WinFormsApplication = System.Windows.Forms.Application;
  using WinFormsDockStyle = System.Windows.Forms.DockStyle;
  using WinFormsForm = System.Windows.Forms.Form;
  using WinFormsFormClosingEventArgs = System.Windows.Forms.FormClosingEventArgs;
  using WinFormsListBox = System.Windows.Forms.ListBox;

  #region System.Timers.Timer�̃T���v��
  /// <summary>
  /// System.Timers.Timer�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  public class ServerTimerSamples01 : WinFormsForm, IExecutable
  {
    System.Timers.Timer _timer;
    WinFormsListBox _listBox;

    public ServerTimerSamples01()
    {
      InitializeComponent();
      SetTimer();
    }

    void InitializeComponent()
    {
      SuspendLayout();

      Text = "Timer Sample.";
      FormClosing += OnFormClosing;

      _listBox = new WinFormsListBox();
      _listBox.Dock = WinFormsDockStyle.Fill;

      Controls.Add(_listBox);

      ResumeLayout();
    }

    void SetTimer()
    {
      _timer = new System.Timers.Timer();

      _timer.Elapsed += OnTimerElapsed;

      //
      // System.Timers.Timer�̓T�[�o�[�^�C�}�̈�
      // ThreadPool�ɂăC�x���g����������B
      //
      // Elapsed�C�x���g���ŁAUI�R���g���[���ɃA�N�Z�X����K�v������ꍇ
      // ���̂܂܂��ƁA�ʃX���b�h����R���g���[���ɑ΂��ăA�N�Z�X���Ă��܂��\��������̂�
      // �C�x���g���ɂāAControl.Invoke���邩�A�ȉ��̂悤��SynchronizingObject��
      // �ݒ肵�āA�C�x���g�̌Ăяo�����}�[�V�������O����悤�ɂ���B
      //
      _timer.SynchronizingObject = this;

      //
      // �J��Ԃ��̐ݒ�.
      //
      _timer.Interval = 1000;
      _timer.AutoReset = true;

      //
      // �^�C�}���J�n.
      //
      _timer.Enabled = true;
    }

    public void Execute()
    {
      WinFormsApplication.EnableVisualStyles();
      WinFormsApplication.Run(new ServerTimerSamples01());
    }

    void OnFormClosing(object sender, WinFormsFormClosingEventArgs e)
    {
      _timer.Enabled = false;
      _timer.Dispose();
    }

    void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      _listBox.Items.Add(String.Format("Time:{0}, ThreadID:{1}", e.SignalTime.ToString("HH:mm:ss"), Thread.CurrentThread.ManagedThreadId.ToString()));
    }
  }
  #endregion
}
