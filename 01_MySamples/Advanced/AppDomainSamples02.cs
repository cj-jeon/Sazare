namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region AppDomainSamples-02
  /// <summary>
  /// AppDomain�N���X�̃T���v���ł��B
  /// </summary>
  public class AppDomainSamples02 : MarshalByRefObject, IExecutable
  {
    public void Execute()
    {
      AppDomain defaultDomain = AppDomain.CurrentDomain;
      AppDomain anotherDomain = AppDomain.CreateDomain("AnotherAppDomain");

      //
      // DomainUnload�C�x���g�̃n���h��.
      //
      // ����̃A�v���P�[�V�����h���C���ł́AUnload�͓o�^�ł��邪���s����邱�Ƃ�
      // �����̂ŁA�ݒ肷��Ӗ����Ȃ�.
      //defaultDomain.DomainUnload += AppDomain_Unload;
      anotherDomain.DomainUnload += AppDomain_Unload;

      //
      // ProcessExit�C�x���g�̃n���h��.
      //
      defaultDomain.ProcessExit += AppDomain_ProcessExit;
      anotherDomain.ProcessExit += AppDomain_ProcessExit;

      //
      // ����̃A�v���P�[�V�����h���C�����A�����[�h���悤�Ƃ���ƃG���[�ƂȂ�.
      // ** appdomain ���A�����[�h���ɃG���[���������܂����B (HRESULT ����̗�O: 0x80131015) **
      //AppDomain.Unload(defaultDomain);

      //
      // AppDomain.Unload���Ăяo���ƁADomainUnload�C�x���g����������.
      // AppDomain.Unload���Ăяo�����Ƀv���Z�X���I�������悤�Ƃ����
      // ProcessExit�C�x���g����������B�����̃C�x���g�������ɔ������邱�Ƃ͖���.
      //
      // �ȉ����R�����g�A�E�g����ƁAProcessExit�C�x���g����������.
      //
      //AppDomain.Unload(anotherDomain);
    }

    void AppDomain_Unload(object sender, EventArgs e)
    {
      AppDomain domain = sender as AppDomain;
      Console.WriteLine("AppDomain.Unload: {0}", domain.FriendlyName);
    }

    void AppDomain_ProcessExit(object sender, EventArgs e)
    {
      //
      // ProcessExit�C�x���g�ɂ́A�^�C���A�E�g�����݂���B�i�����2�b�j
      // �ȉ��AMSDN�̋L�q.
      // (http://msdn.microsoft.com/ja-jp/library/system.appdomain.processexit.aspx)
      //
      // �u�v���Z�X �V���b�g�_�E�����ɂ�����S�t�@�C�i���C�U�[�̍��v���s���Ԃ������Ă���悤�ɁAProcessExit ��
      // ���ׂẴC�x���g �n���h���[�ɑ΂��Ċ��蓖�Ă��鍇�v���s���Ԃ������Ă��܂��B ����l�� 2 �b�ł��B�v
      //
      // �ȉ��̃R�����g���O���Ď��s����ƁA�^�C���A�E�g���Ԃ��߂���̂�
      // �C�x���g���n���h�����Ă��Ă��A�㑱�̏����͎��s����Ȃ��B
      //
      // �킴�ƃ^�C���A�E�g���Ԃ��߂���悤�ɑҋ@.
      //Console.WriteLine("AppDomain.ProcessExit Thread.Sleep()");
      //Thread.Sleep(TimeSpan.FromSeconds(3));

      AppDomain domain = sender as AppDomain;
      Console.WriteLine("AppDomain.ProcessExit: {0}", domain.FriendlyName);
    }
  }
  #endregion
}
