namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  #region ThreadingNamespaceSamples-05
  public class ThreadingNamespaceSamples05 : IExecutable
  {
    public void Execute()
    {
      //
      // ���ʂɃX���b�h�^�C�}�[���쐬���A�R�[���o�b�N�̌Ăяo���Ԋu�𖳌���
      // ������ԂŃ^�C�}�[���J�n������.
      //
      var timer = new System.Threading.Timer(TimerCallback);
      timer.Change(0, Timeout.Infinite);

      Thread.Sleep(10000);
    }

    void TimerCallback(object state)
    {
      Console.WriteLine("Timer Callback!!");

      var rnd = new Random();

      // ���Ԃ̂����鏈�����V�~�����[�g
      Thread.Sleep(rnd.Next(1000));
      Console.WriteLine("\tsleep done.");

      //
      // �ēxChange���\�b�h���Ăяo���āA���̃R�[���o�b�N��ݒ�.
      //
      var timer = state as System.Threading.Timer;
      timer.Change(rnd.Next(700), Timeout.Infinite);
    }
  }
  #endregion
}
