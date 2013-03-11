namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  #region ThreadLocalSamples-01
  /// <summary>
  /// ThreadLocal<T>�N���X�̃T���v���ł��B
  /// </summary>
  public class ThreadLocalSamples01 : IExecutable
  {
    #region Static Fields
    // ThreadStatic
    [ThreadStatic]
    static int count = 2;
    static ThreadLocal<int> count2 = new ThreadLocal<int>(() => 2);
    #endregion

    #region Fields
    [ThreadStatic]
    int count3 = 2;
    ThreadLocal<int> count4 = new ThreadLocal<int>(() => 4);
    #endregion

    public void Execute()
    {
      //
      // ThreadLocal<T>�́A.NET 4.0����ǉ����ꂽ�^�ł���B
      // ThreadStatic�����Ɠ��l�ɁA�X���b�h���[�J���X�g���[�W(TLS)��\�����邽�߂̌^�ł���B
      //
      // �]����葶�݂��Ă���ThreadStatic�����ɂ́A�ȉ��̓_���s���Ȃ������B
      //   �E�C���X�^���X�t�B�[���h�ɂ͑Ή����Ă��Ȃ��B�istatic�t�B�[���h�̂�)
      //    (�C���X�^���X�t�B�[���h�ɂ�������t�^���邱�Ƃ��o���邪�A�����Ɠ��삵�Ȃ��j
      //   �E�t�B�[���h�̒l�͏�ɁA���̌^�̃f�t�H���g�l�ŏ����������B�����l��ݒ肵�Ă����������B
      //
      // ThreadLocal<T>�́A��L�̓_���������Ă���B�܂�
      //   �E�C���X�^���X�t�B�[���h�ɑΉ����Ă���B
      //   �E�t�B�[���h�̒l�������l�ŏ������o����B
      //
      // ���p���@�́ASystem.Lazy�Ǝ��Ă���A�R���X�g���N�^�ɏ������̂��߂̃f���Q�[�g��n���B
      //

      //
      // static�t�B�[���h��ThreadState�����̊m�F
      // ThreadStatic�����ł́A�����l��錾���ɐݒ肵�Ă��Ă���������A�����I�Ƀf�t�H���g�l���K�p�����̂�
      // �o�͂����l�́A�S��0�ƂȂ�B
      //
      int numberOfParallels = 10;
      using (var countdown = new CountdownEvent(numberOfParallels))
      {
        for (var i = 0; i < numberOfParallels; i++)
        {
          int tmp = i;
          new Thread(() => { Console.WriteLine("ThreadStatic [count]>>> {0}", count++); countdown.Signal(); }).Start();
        }

        countdown.Wait();
      }

      //
      // static�t�B�[���h��ThreadLocal<T>�̊m�F
      // ThreadLocal<T>�́A�����l��ݒ�ł���̂ŁA�o�͂����l��2�ƂȂ�B
      //
      using (var countdown = new CountdownEvent(numberOfParallels))
      {
        for (var i = 0; i < numberOfParallels; i++)
        {
          new Thread(() => { Console.WriteLine("ThreadLocal<T> [count2]>>> {0}", count2.Value++); countdown.Signal(); }).Start();
        }

        countdown.Wait();
      }

      //
      // �C���X�^���X�t�B�[���h��ThreadStatic�����̊m�F
      // ThreadStatic�����́A�C���X�^���X�t�B�[���h�ɑ΂��Ă͌��ʂ������B
      // �Ȃ̂ŁA�o�͂����l��2,3,4,5,6...�ƃC���N�������g����Ă���.
      //
      using (var countdown = new CountdownEvent(numberOfParallels))
      {
        for (var i = 0; i < numberOfParallels; i++)
        {
          int tmp = i;
          new Thread(() => { Console.WriteLine("ThreadStatic [count3]>>> {0}", count3++); countdown.Signal(); }).Start();
        }

        countdown.Wait();
      }

      //
      // �C���X�^���X�t�B�[���h��ThreadLocal<T>�̊m�F
      // ThreadLocal<T>�́A�C���X�^���X�t�B�[���h�ɑ΂��Ă����Ȃ����p�ł���B
      // �Ȃ̂ŁA�o�͂����l��4�ƂȂ�B
      //
      using (var countdown = new CountdownEvent(numberOfParallels))
      {
        for (var i = 0; i < numberOfParallels; i++)
        {
          new Thread(() => { Console.WriteLine("ThreadLocal<T> [count4]>>> {0}", count4.Value++); countdown.Signal(); }).Start();
        }

        countdown.Wait();
      }

      count2.Dispose();
      count4.Dispose();
    }
  }
  #endregion
}
