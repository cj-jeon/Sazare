namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  #region TaskSamples-02
  /// <summary>
  /// �^�X�N���񃉃C�u�����ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// �^�X�N���񃉃C�u������4.0����ǉ����ꂽ���C�u�����ł��B
  /// </remarks>
  public class TaskSamples02 : IExecutable
  {
    public void Execute()
    {
      //
      // �^�X�N�𒼐�New���Ď��s.
      // 
      // �^�X�N�͒���New���Ď��s���邱�Ƃ��o����B
      // �R���X�g���N�^�Ɏ��s����Action�f���Q�[�g���w�肵
      // Start���ĂԂƋN�������B
      //

      // �ʃX���b�h�Ń^�X�N�����s����Ă��鎖���m�F����ׂɁA���C���X���b�h�̃X���b�hID��\��
      Console.WriteLine("Main Thread : {0}", Thread.CurrentThread.ManagedThreadId);

      //
      // Action�f���Q�[�g�𖾎��I�Ɏw��.
      //
      Task t = new Task(DoAction);
      t.Start();
      t.Wait();

      //
      // �����_���w��.
      //
      Task t2 = new Task(() => DoAction());
      t2.Start();
      t2.Wait();

      //
      // �����̃^�X�N���쐬���Ď��s.
      //
      List<Task> tasks = Enumerable.Range(1, 20).Select(i => new Task(DoActionWithSleep)).ToList();

      tasks.ForEach(task => task.Start());

      Task.WaitAll(
        tasks.ToArray()
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
