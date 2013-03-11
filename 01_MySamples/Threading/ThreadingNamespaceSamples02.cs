namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  #region ThreadingNamespaceSamples-02
  /// <summary>
  /// System.Threading���O��Ԃɑ��݂���N���X�̃T���v���ł��B
  /// </summary>
  public class ThreadingNamespaceSamples02 : IExecutable
  {

    public void Execute()
    {
      ////////////////////////////////////////////////////////////
      //
      // �����f�[�^�X���b�g.
      //    �f�[�^�X���b�g�͂ǂꂩ�̃X���b�h�ōŏ��ɍ쐬������
      //    �S�ẴX���b�h�ɑ΂��ăX���b�g�����蓖�Ă���B
      //
      LocalDataStoreSlot slot = Thread.AllocateDataSlot();

      List<Thread> threads = new List<Thread>();
      for (int i = 0; i < 10; i++)
      {
        Thread thread = new Thread(DoAnonymousDataSlotProcess);
        thread.Name = string.Format("Thread-{0}", i);
        thread.IsBackground = true;

        threads.Add(thread);

        thread.Start(slot);
      }

      threads.ForEach(thread =>
      {
        thread.Join();
      });

      Console.WriteLine(string.Empty);

      ////////////////////////////////////////////////////////////
      //
      // ���O�t���f�[�^�X���b�g.
      //    ���O�������鎖�ȊO�́A�����̃X���b�g�Ɠ����ł��B
      //    ���O�t���f�[�^�X���b�g�́A�ŏ��ɂ��̖��O���Ă΂ꂽ
      //    �ۂɍ쐬����܂��B
      //    FreeNamedDataSlot���\�b�h���ĂԂƌ��݂̃X���b�g�ݒ�
      //    ���������܂��B
      //
      threads.Clear();
      for (int i = 0; i < 10; i++)
      {
        Thread thread = new Thread(DoNamedDataSlotProcess);
        thread.Name = string.Format("Thread-{0}", i);
        thread.IsBackground = true;

        threads.Add(thread);

        thread.Start(slot);
      }

      threads.ForEach(thread =>
      {
        thread.Join();
      });

      //
      // ���p�����f�[�^�X���b�g�����.
      //
      Thread.FreeNamedDataSlot("SampleSlot");

    }

    void DoAnonymousDataSlotProcess(object stateObj)
    {
      LocalDataStoreSlot slot = stateObj as LocalDataStoreSlot;

      //
      // �X���b�g�Ƀf�[�^��ݒ�
      //
      Thread.SetData(slot, string.Format("ManagedThreadId={0}", Thread.CurrentThread.ManagedThreadId));

      //
      // �ݒ肵�����e���m�F.
      //
      Console.WriteLine("[BEFORE] Thread:{0}   DataSlot:{1}", Thread.CurrentThread.Name, Thread.GetData(slot));

      //
      // �ʂ̃X���b�h�ɏ������s���ĖႤ�ׂɈ�USleep����B
      //
      Thread.Sleep(TimeSpan.FromSeconds(1));

      //
      // �ēx�m�F.
      //
      Console.WriteLine("[AFTER ] Thread:{0}   DataSlot:{1}", Thread.CurrentThread.Name, Thread.GetData(slot));
    }

    void DoNamedDataSlotProcess(object stateObj)
    {
      //
      // �X���b�g�Ƀf�[�^��ݒ�
      //
      Thread.SetData(Thread.GetNamedDataSlot("SampleSlot"), string.Format("ManagedThreadId={0}", Thread.CurrentThread.ManagedThreadId));

      //
      // �ݒ肵�����e���m�F.
      //
      Console.WriteLine("[BEFORE] Thread:{0}   DataSlot:{1}", Thread.CurrentThread.Name, Thread.GetData(Thread.GetNamedDataSlot("SampleSlot")));

      //
      // �ʂ̃X���b�h�ɏ������s���ĖႤ�ׂɈ�USleep����B
      //
      Thread.Sleep(TimeSpan.FromSeconds(1));

      //
      // �ēx�m�F.
      //
      Console.WriteLine("[AFTER ] Thread:{0}   DataSlot:{1}", Thread.CurrentThread.Name, Thread.GetData(Thread.GetNamedDataSlot("SampleSlot")));
    }
  }
  #endregion
}
