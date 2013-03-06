namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  #region TaskSamples-01
  /// <summary>
  /// �^�X�N���񃉃C�u�����ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// �^�X�N���񃉃C�u�����́A4.0����ǉ�����Ă��郉�C�u�����ł��B
  /// </remarks>
  public class TaskSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // Task�́A�^�X�N���񃉃C�u�����̈ꕔ�Ƃ��Ē񋟂���Ă���
      // �����ʂ�^�X�N����񏈗����邽�߂ɗ��p�ł���B
      //
      // .NET 4.0�܂ŁA�񓯊��������s���ꍇThread�N���X��ThreadPool�N���X��
      // �p�ӂ���Ă������A���p����̂Ɏ኱�̐�含���K�v�ƂȂ���̂ł������B
      //
      // �^�X�N���񃉃C�u�����́A�o���邾���e�Ղɗ��p�ł���悤�f�U�C�����ꂽ
      // �V�������C�u�����ł���B
      //
      // ����Ƀ^�X�N���񃉃C�u�����ł́A�������s�̒��x������Œ������Ă���邱�Ƃɂ����
      // CPU�������I�ɗ��p����悤�ɂȂ��Ă���B
      //
      // �������A����ł��X���b�h�����Ɋւ����b�m���͓��R�K�v�ƂȂ�B
      // (���b�N�A�f�b�h���b�N�A������ԂȂǁj
      //
      // Task�N���X�́ASystem.Threading.Tasks���O��Ԃɑ��݂���B
      //
      // �^�X�N�𗘗p����̂Ɉ�ԊȒP�ȕ��@��TaskFactory��StartNew���\�b�h��
      // ���p���鎖�ł���B
      //
      // �^�X�N�͓����ŃX���b�h�v�[���𗘗p���Ă��邽�߁A�X���b�h�I�u�W�F�N�g��
      // ���ڍ쐬���ĊJ�n��������y�����ׂŎ��s�ł���B
      //
      // �^�X�N�ɂ̓L�����Z���@�\���f�t�H���g�ŗp�ӂ���Ă���B(CancellationToken)
      // �^�X�N�̃L�����Z���@�\�ɂ��ẮA�ʂ̋@��ŋL�q����B
      //
      // �^�X�N�ɂ͏�ԊǗ��@�\���f�t�H���g�ŗp�ӂ���Ă���B
      // �^�X�N�̏�ԊǗ��@�\�ɂ��ẮA�ʂ̋@��ŋL�q����B
      //

      // �ʃX���b�h�Ń^�X�N�����s����Ă��鎖���m�F����ׂɁA���C���X���b�h�̃X���b�hID��\��
      Console.WriteLine("Main Thread : {0}", Thread.CurrentThread.ManagedThreadId);

      //
      // Task��V�K�쐬���Ď��s.
      //   �����ɂ�Action�f���Q�[�g���w�肷��B
      //
      // Wait���\�b�h�̓^�X�N�̏I����҂��\�b�h�B
      //
      Task.Factory.StartNew(DoAction).Wait();


      //
      // Action�̕����Ƀ����_���w�肵����
      //
      Task.Factory.StartNew(() => Console.WriteLine("Lambda : {0}", Thread.CurrentThread.ManagedThreadId)).Wait();

      //
      // �����̃^�X�N���쐬���Ď��s.
      //   Task.WaitAll���\�b�h�͈����Ŏw�肳�ꂽ�^�X�N���S�ďI������܂őҋ@���郁�\�b�h
      //
      Task.WaitAll(
        Enumerable.Range(1, 20).Select(i => Task.Factory.StartNew(DoActionWithSleep)).ToArray()
      );
    }

    private void DoAction()
    {
      Console.WriteLine("DoAction: {0}", Thread.CurrentThread.ManagedThreadId);
    }

    private void DoActionWithSleep()
    {
      DoAction();
      Thread.Sleep(200);
    }
  }
  #endregion
}
