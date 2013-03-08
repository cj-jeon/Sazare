namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.InteropServices;
  using System.Security;

  #region SecureStringSamples-001
  /// <summary>
  /// SecureString�ɂ��ẴT���v���ł��B
  /// </summary>
  public class SecureStringSamples001 : IExecutable
  {
    public void Execute()
    {
      //
      // SecureString�̃T���v��.
      //
      // System.Security.SecureString�N���X�́A�ʏ�̕�����Ƃ�
      // �Ⴂ�A�p�X���[�h�Ȃǂ̋@�������������肷��ۂɗ��p�����B
      //
      // �悭���p�����Process�N���X��Start���\�b�h�ł̓p�X���[�h��n���ۂ�
      // SecureString��n���K�v������B
      //
      // ���̃N���X�̃C���X�^���X�ɐݒ肳�ꂽ���e�͎����I�ɈÍ�������
      // MakeReadOnly���\�b�h�𗘗p���āA�ǂݎ���p�Ƃ���ƕύX�ł��Ȃ��Ȃ�B
      //
      // SecureString�Ƀf�[�^��ݒ肷��ۂ́AAppendChar���\�b�h�𗘗p����
      // 1�������f�[�^��ݒ肵�Ă����K�v������B
      //
      // SecureString�ɂ́A�l���r�܂��͕ϊ�����ׂ̃��\�b�h�����݂��Ȃ��B
      // ������s���ׂɂ́ASystem.Runtime.InteropServices.Marshal��CoTaskMemUnicode���\�b�h��
      // Copy���\�b�h�𗘗p����char[]�ɕϊ�����K�v������B
      //

      //
      // SecureString���\�z.
      //
      // ���ۂ̓��[�U����̃p�X���[�h���͂�����SecureString���\�z�����肷��.
      //
      SecureString secureStr = MakeSecureString();

      //
      // ToString()���\�b�h���Ăяo���Ă�SecureString�̒��g��
      // ���邱�Ƃ͂ł��Ȃ��B
      //
      Console.WriteLine(secureStr);

      //
      // IsReadOnly���\�b�h�Ō��ݓǂݎ���p�Ƃ��ă}�[�N����Ă��邩�ۂ���
      // ���ʂł���B�ǂݎ���p�łȂ��ꍇ�A�ύX�͉\�B
      //
      // �ǂݎ���p�ɂ���ɂ�MakeReadOnly���\�b�h���g�p����B
      //
      Console.WriteLine("IsReadOnly:{0}", secureStr.IsReadOnly());
      secureStr.MakeReadOnly();
      Console.WriteLine("IsReadOnly:{0}", secureStr.IsReadOnly());

      //
      // SecureString�̒��g�𕜌�����ɂ́A�ȉ��̃��\�b�h�𗘗p����B
      //
      // ��Marshal.SecureStringToCoTaskMemUnicode���\�b�h
      // ��Marshal.Copy���\�b�h
      // ��Marshal.ZeroFreeCoTaskMemUnicode���\�b�h
      //
      RestoreSecureString(secureStr);
    }

    SecureString MakeSecureString()
    {
      SecureString secureStr = new SecureString();

      foreach (char ch in "hello world")
      {
        secureStr.AppendChar(ch);
      }

      return secureStr;
    }

    void RestoreSecureString(SecureString secureStr)
    {

      IntPtr pointer = IntPtr.Zero;
      try
      {
        //
        // �R�s�[��̃o�b�t�@���쐬.
        //
        char[] buffer = new char[secureStr.Length];

        //
        // ��������.
        //
        pointer = Marshal.SecureStringToCoTaskMemUnicode(secureStr);
        Marshal.Copy(pointer, buffer, 0, buffer.Length);

        Console.WriteLine(new string(buffer));
      }
      finally
      {
        if (pointer != IntPtr.Zero)
        {
          //
          // ���.
          //
          Marshal.ZeroFreeCoTaskMemUnicode(pointer);
        }
      }
    }
  }
  #endregion
}
