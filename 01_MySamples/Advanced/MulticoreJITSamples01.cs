namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime;

  #region MulticoreJITSamples-01
  /// <summary>
  /// �}���`�R�AJIT�̃T���v���ł�.
  /// </summary>
  public class MulticoreJITSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // .NET 4.5���}���`�R�AJIT�����ڂ���Ă���.
      // �����ʂ�A�}���`�R�A�\���̊��ɂĕ����JIT���s���@�\�ł���B
      // ����ɂ��A�A�v���P�[�V�����̓����ɐ�s���āA�K�v�ƂȂ郁�\�b�h��JIT��
      // �s����\���������Ȃ�A���ʓI�ɃA�v���P�[�V�����̃p�t�H�[�}���X���オ��Ƃ̂��ƁB
      //
      // �}���`�R�AJIT�́AASP.NET 4.5��Silverlight5�ł�
      // ����ŗL���ƂȂ��Ă��邪�A�f�X�N�g�b�v�A�v���P�[�V�����ł�
      // �f�t�H���g�ŗL���ɂȂ��Ă��Ȃ��B
      //
      // �L���ɂȂ��Ă��Ȃ����R�́A���̋@�\�𗘗p���邽�߂ɂ�
      // �v���t�@�C�����O�������K�{�ł���A�v���t�@�C���f�[�^��ۑ�
      // ���邱�Ƃ������ł��邽�߁B�f�X�N�g�b�v�A�v���P�[�V�����ł�
      // �t���[�����[�N�����A�v���t�@�C���f�[�^���ǂ��ɕۑ�����ׂ��Ȃ̂���
      // ���f�ł��Ȃ����߁A�蓮�Ŏ��s����悤�ɂȂ��Ă���B
      //
      // �Q�lURL:
      //  http://blogs.msdn.com/b/dotnet/archive/2012/10/18/an-easy-solution-for-improving-app-launch-performance.aspx
      //  http://stackoverflow.com/questions/12965606/why-is-multicore-jit-not-on-by-default-in-net-4-5
      //  http://msdn.microsoft.com/ja-jp/magazine/hh882452.aspx
      //
      // �}���`�R�AJIT��L���ɂ���ɂ́ASystem.Runtime.ProfileOptimization�N���X��
      // �ȉ���static���\�b�h���Ăяo�������ł���B
      //   �ESetProfileRoot
      //   �EStartProfile
      // ��L���\�b�h�́A�A�v���P�[�V�����̃G���g���|�C���g�ŌĂяo�������悢�B
      //

      //
      // �}���`�R�AJIT��L���ɂ���.
      //  �v���t�@�C���f�[�^�i�[�ꏊ�́A�A�v�����s�t�H���_.
      //  �v���t�@�C���f�[�^�̃t�@�C�����́AApp.JIT.Profile�Ƃ���B
      //
      ProfileOptimization.SetProfileRoot(Environment.CurrentDirectory);
      ProfileOptimization.StartProfile("App.JIT.Profile");
    }
  }
  #endregion
}
