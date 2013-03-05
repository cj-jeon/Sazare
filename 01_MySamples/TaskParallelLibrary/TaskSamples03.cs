namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  #region TaskSamples-03
  /// <summary>
  /// �^�X�N���񃉃C�u�����ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// �^�X�N���񃉃C�u�����́A.NET 4.0����ǉ����ꂽ���C�u�����ł��B
  /// </remarks>
  public class TaskSamples03 : IExecutable
  {
    public void Execute()
    {
      //
      // ����q�^�X�N�̍쐬
      //
      // �^�X�N�͓���q�ɂ��邱�Ƃ��\�B
      //
      // ����q�̃^�X�N�ɂ́A�ȉ���2��ނ����݂���B
      //   �E�P���ȓ���q�^�X�N�i�f�^�b�`���ꂽ����q�^�X�N�j
      //   �E�q�^�X�N�i�e�̃^�X�N�ɃA�^�b�`���ꂽ����q�^�X�N�j
      //
      // �ȉ��̃T���v���ł́A�P���ȓ���q�̃^�X�N���쐬�����s���Ă���B
      // �P���ȓ���q�̃^�X�N�Ƃ́A����q��Ԃō쐬���ꂽ�^�X�N��
      // �e�̃^�X�N�Ƃ̊֘A�������Ȃ���Ԃł��邱�Ƃ������B
      //
      // �܂�A�e�̃^�X�N�͎q�̃^�X�N�̏I����҂����ɁA���g�̏������I������B
      // ����q���̃^�X�N�ɂāA�m���ɐe�̃^�X�N�̏I���O�Ɏ����̌��ʂ𓾂�K�v������ꍇ��
      // Wait��Result��p���āA����������������K�v������B
      //
      // �e�Ƃ̊֘A�������Ȃ�����q�̃^�X�N�́A�u�f�^�b�`���ꂽ����q�̃^�X�N�v�ƌ����B
      //
      // �f�^�b�`���ꂽ����q�^�X�N�̍쐬�́A�P���ɐe�^�X�N�̒��ŐV���Ƀ^�X�N�𐶐����邾���ł���B
      //

      //
      // �P���ȓ���q�̃^�X�N���쐬.
      //
      Console.WriteLine("�O���̃^�X�N�J�n");
      Task t = new Task(ParentTaskProc);
      t.Start();
      t.Wait();
      Console.WriteLine("�O���̃^�X�N�I��");

    }

    void ParentTaskProc()
    {
      PrintTaskId();

      //
      // �����I�ɁATaskCreationOptions���w�肵�Ă��Ȃ��̂�
      // �ȉ��̓���q�^�X�N�́A�u�f�^�b�`���ꂽ����q�^�X�N�v
      // �Ƃ��Đ��������B
      //
      Task detachedTask = new Task(ChildTaskProc, TaskCreationOptions.None);
      detachedTask.Start();

      //
      // �ȉ���Wait���R�����g�A�E�g�����
      // �o�͂�
      //     �O���̃^�X�N�J�n
      //      Task Id: 1
      //     �����̃^�X�N�J�n
      //      Task Id: 2
      //     �O���̃^�X�N�I��
      //
      // �Əo�͂���A�u�����̃^�X�N�I���v�̏o�͂�����Ȃ��܂�
      // ���C���������I�������肷��B
      //
      // ����́A2�̃^�X�N���e�q�֌W�������Ă��Ȃ�����
      // �ʁX�ŏ������s���Ă��邩��ł���B
      //
      detachedTask.Wait();
    }

    void ChildTaskProc()
    {
      Console.WriteLine("�����̃^�X�N�J�n");
      PrintTaskId();
      Thread.Sleep(TimeSpan.FromSeconds(2.0));
      Console.WriteLine("�����̃^�X�N�I��");
    }

    void PrintTaskId()
    {
      //
      // ���ݎ��s���̃^�X�N��ID��\��.
      //
      Console.WriteLine("\tTask Id: {0}", Task.CurrentId);
    }
  }
  #endregion
}
