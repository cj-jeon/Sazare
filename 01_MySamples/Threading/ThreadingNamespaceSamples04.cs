namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  #region ThreadingNamespaceSamples-04
  public class ThreadingNamespaceSamples04 : IExecutable
  {
    public void Execute()
    {
      //
      // .NET 4.0���AThread�N���X�Ɉȉ��̃��\�b�h���ǉ����ꂽ�B
      //   �EYield���\�b�h
      //
      // Yield���\�b�h�́A�ʂ̃X���b�h�Ƀ^�C���X���C�X�������n���ׂ̃��\�b�h�B
      // ���܂ł́AThread.Sleep�𗘗p�����肵�āA�^�C���X���C�X��؂�ւ���悤
      // �ɂ��Ă������A����͂��̃��\�b�h�𗘗p���邱�Ƃ����������B
      //
      // �߂�l�́A�^�C���X���C�X�̈����n���������������ۂ����Ԃ��Ă���B
      //

      //
      // �e�X�g�p�ɃX���b�h���Q�N������.
      //
      Thread t1 = new Thread(ThreadProc);
      Thread t2 = new Thread(ThreadProc);

      t1.Start("T1");
      t2.Start("T2");

      t1.Join();
      t2.Join();
    }

    void ThreadProc(object stateObj)
    {
      string threadName = stateObj.ToString();
      Console.WriteLine("{0} Start", threadName);

      //
      // �^�C���X���C�X��؂�ւ�.
      //
      Console.WriteLine("{0} Yield Call", threadName);
      bool isSuccess = Thread.Yield();
      Console.WriteLine("{0} Yield={1}", threadName, isSuccess);

      Console.WriteLine("{0} End", threadName);
    }
  }
  #endregion
}
