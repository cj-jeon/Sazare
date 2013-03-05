namespace Gsf.Samples
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  #region QueueSynchronizedSamples-01
  /// <summary>
  /// Queue�̓��������ɂ��ẴT���v���ł��B
  /// </summary>
  public class QueueSynchronizedSamples01 : IExecutable
  {
    Queue queue;
    public void Execute()
    {
      queue = Queue.Synchronized(new Queue());
      Console.WriteLine("Queue.IsSyncronized == {0}", queue.IsSynchronized);

      for (int i = 0; i < 1000; i++)
      {
        queue.Enqueue(i);
      }

      new Thread(EnumerateCollection).Start();
      new Thread(ModifyCollection).Start();

      Console.WriteLine("Press any key to exit...");
      Console.ReadLine();
    }

    void EnumerateCollection()
    {
      //
      // ���b�N�����ɗ񋓏������s���B
      //
      // Collection��Synchronized���\�b�h�ō쐬�����I�u�W�F�N�g��
      // �P�ꑀ��ɑ΂��ẮA�����ł��邪�����A�N�V�����̓K�[�h�ł��Ȃ��B
      // �i�C�e���[�V�����A�i�r�Q�[�V�����A�v�b�g�E�C�t�E�A�u�Z���g�Ȃǁj
      //
      // �ʂ̃X���b�h�ɂāA�R���N�V�����𑀍삵�Ă���ꍇ
      // ��O����������\��������B
      //
      /*
      foreach(int i in queue)
      {
        Console.WriteLine(i);
        Thread.Sleep(0);
      }
      */

      //
      // ���̕��@�F
      //
      // ���[�v���Ă���ԁA�R���N�V���������b�N����.
      // �L���ł��邪�A�񋓏������s���Ă���Ԃ����ƃ��b�N���ꂽ�܂܂ƂȂ�B
      // 
      /*
      lock(queue.SyncRoot)
      {
        foreach(int i in queue)
        {
          Console.WriteLine(i);
          Thread.Sleep(0);
        }
      }
      */

      //
      // ���̕��@�F
      //
      // ��U���b�N���l�����A�R���N�V�����̃N���[�����쐬����B
      // �N���[���쐬��A���b�N��������A���̌�N���[���ɑ΂��ė񋓏������s���B
      //
      // ������R���N�V�������̂��傫���ꍇ�͎��Ԃƕ��ׂ������邪�A����̓g���[�h�I�t�ƂȂ�B
      //
      Queue cloneQueue = null;
      lock (queue.SyncRoot)
      {

        Array array = Array.CreateInstance(typeof(int), queue.Count);
        queue.CopyTo(array, 0);

        cloneQueue = new Queue(array);
      }

      foreach (int i in cloneQueue)
      {
        Console.WriteLine(i);

        // �킴�ƃ^�C���X���C�X��؂�ւ�
        Thread.Sleep(0);
      }
    }

    void ModifyCollection()
    {

      for (; ; )
      {
        if (queue.Count == 0)
        {
          break;
        }

        Console.WriteLine("\t==> Dequeue");
        queue.Dequeue();

        // �킴�ƃ^�C���X���C�X��؂�ւ�
        Thread.Sleep(0);
      }

    }
  }
  #endregion
}
