namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Drawing;
  using System.Globalization;
  using System.Linq;

  //
  // Alias�ݒ�.
  //
  using GDISize = System.Drawing.Size;
  using WinFormsApplication = System.Windows.Forms.Application;
  using WinFormsButton = System.Windows.Forms.Button;
  using WinFormsControl = System.Windows.Forms.Control;
  using WinFormsDockStyle = System.Windows.Forms.DockStyle;
  using WinFormsFlowDirection = System.Windows.Forms.FlowDirection;
  using WinFormsFlowLayoutPanel = System.Windows.Forms.FlowLayoutPanel;
  using WinFormsForm = System.Windows.Forms.Form;
  using WinFormsFormStartPosition = System.Windows.Forms.FormStartPosition;
  using WinFormsMessageBox = System.Windows.Forms.MessageBox;
  using WinFormsTextBox = System.Windows.Forms.TextBox;

  #region StringInfoSamples-001
  /// <summary>
  /// StringInfo�ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// �T���Q�[�g�y�A�ɂ��ċL�q���Ă��܂��B
  /// </remarks>
  public class StringInfoSamples001 : IExecutable
  {
    public class StringInfoSampleForm : WinFormsForm
    {
      public StringInfoSampleForm()
      {
        InitializeComponent();
      }

      void InitializeComponent()
      {
        SuspendLayout();

        Size = new GDISize(350, 100);
        StartPosition = WinFormsFormStartPosition.CenterScreen;
        Text = "�T���Q�[�g�y�A�̊m�F�T���v��";


        WinFormsTextBox t = new WinFormsTextBox();
        t.Text = "\uD867\uDE3D"; // ���ւ�ɉԂƂ��������B���̃z�b�P�̕������w��B

        WinFormsButton b = new WinFormsButton { Text = "Exec" };
        b.Click += (s, e) =>
        {

          string str = t.Text;
          WinFormsMessageBox.Show(string.Format("�����F{0}, �����F{1}", str, str.Length), "String�ł̕\��");

          //
          // �T���Q�[�g�y�A�̕�����
          //
          // �T���Q�[�g�y�A�̕�����͂P������
          // �S�o�C�g�ƂȂ��Ă���B
          //
          // �T���Q�[�g�y�A�̕�����ɑ΂���
          // String.Length�v���p�e�B�Œ������擾�����
          // �P�����Ȃ̂ɂQ�ƕԂ��Ă���B
          //
          // ������P�����Ƃ��ĔF������ɂ͈ȉ��̃N���X�𗘗p����B
          //
          // System.Globalization.StringInfo
          //
          // ���̃N���X�̈ȉ��̃v���p�e�B�𗘗p���邱�Ƃ�
          // �P�����ƔF�����邱�Ƃ��o����B
          //
          // LengthInTextElements�v���p�e�B
          //
          StringInfo si = new StringInfo(str);
          WinFormsMessageBox.Show(string.Format("�����F{0}, �����F{1}", si.String, si.LengthInTextElements), "StringInfo�ł̕\��");
        };

        WinFormsFlowLayoutPanel contentPane = new WinFormsFlowLayoutPanel { FlowDirection = WinFormsFlowDirection.TopDown, WrapContents = true };
        contentPane.Controls.AddRange(new WinFormsControl[] { t, b });
        contentPane.Dock = WinFormsDockStyle.Fill;

        Controls.Add(contentPane);

        ResumeLayout();
      }
    }

    [STAThread]
    public void Execute()
    {
      WinFormsApplication.EnableVisualStyles();
      WinFormsApplication.Run(new StringInfoSampleForm());
    }
  }
  #endregion
}
