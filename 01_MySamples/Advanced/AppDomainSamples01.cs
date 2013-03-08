namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region AppDomainSamples-01
  /// <summary>
  /// AppDomain�N���X�̃T���v���ł��B
  /// </summary>
  public class AppDomainSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // AppDomain�ɂ́A.NET 4.0���ȉ��̃C�x���g���ǉ�����Ă���B
      //   �EFirstChanceException�C�x���g
      // ���̃C�x���g�́A��O�����������ۂɕ����ʂ�ŏ��ɒʒm�����C�x���g�ł���B
      // ���̃C�x���g�ɒʒm�����^�C�~���O�́Acatch�߂ɂė�O���⑫����������ƂȂ�B
      // 
      // ���ӓ_�Ƃ���
      //   �E���̃C�x���g�́A�ʒm�݂̂ƂȂ�B���̃C�x���g���n���h����������Ƃ����ė�O�̔�����
      //    �����Ŏ~�܂�킯�ł͂Ȃ��B��O�͒ʏ�ʂ�v���O�����R�[�h���catch�ɓ����Ă���B
      //   �E���̃C�x���g�́A�A�v���P�[�V�����h���C�����ɒ�`�ł���B
      //   �EFirstChanceException�C�x���g���ł̗�O�́A��΂Ƀn���h�����ŃL���b�`���Ȃ��Ƃ����Ȃ��B
      //    �������Ȃ��ƁA�ċA�I��FirstChanceException����������B
      //   �E�C�x���g�����ł���FirstChanceExceptionEventArgs�N���X��
      //    System.Runtime.ExceptionServices���O��Ԃɑ��݂���B
      //

      // ����AppDomain�ɂāAFirstChanceException�C�x���g���n���h��.
      AppDomain.CurrentDomain.FirstChanceException += FirstChanceExHandler;

      try
      {
        // �킴�Ɨ�O����.
        throw new InvalidOperationException("test Ex messsage");
      }
      catch (InvalidOperationException ex)
      {
        // �{����catch����.
        Console.WriteLine("Catch clause: {0}", ex.Message);
      }

      // �C�x���g���A���o�C���h.
      AppDomain.CurrentDomain.FirstChanceException -= FirstChanceExHandler;
    }

    // �C�x���g�n���h��.
    void FirstChanceExHandler(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
    {
      Console.WriteLine("FirstChanceException: {0}", e.Exception.Message);
    }
  }
  #endregion
}
