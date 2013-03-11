namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  #region CountDownEventSamples-01
  /// <summary>
  /// CountdownEvent�N���X�ɂ��ẴT���v���ł��B(1)
  /// </summary>
  /// <remarks>
  /// CountdownEvent�N���X�́A.NET 4.0����ǉ����ꂽ�N���X�ł��B
  /// Java��CountDownLatch�N���X�Ɠ����@�\�������Ă��܂��B
  /// </remarks>
  public class CountdownEventSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // �����J�E���g��1��CountdownEvent�I�u�W�F�N�g���쐬.
      //
      // ���̏ꍇ�A�ǂ����̏����ɂăJ�E���g������炷�K�v������B
      // �J�E���g���c���Ă����Ԃ�Wait�����Ă���ƁA���܂ł����Ă�Wait��
      // �����邱�Ƃ��o���Ȃ��B
      //
      using (CountdownEvent cde = new CountdownEvent(1))
      {
        // �����̏�Ԃ�\��.
        Console.WriteLine("InitialCount={0}", cde.InitialCount);
        Console.WriteLine("CurrentCount={0}", cde.CurrentCount);
        Console.WriteLine("IsSet={0}", cde.IsSet);

        Task t = Task.Factory.StartNew(() =>
        {
          Thread.Sleep(TimeSpan.FromSeconds(1));

          //
          // �J�E���g���f�N�������g.
          //
          // Signal���\�b�h�������Ȃ��ŌĂԂƁA�P�J�E���g�����炷���Ƃ��o����B
          // (�w�肵�������A�J�E���g���f�N�������g����I�[�o�[���[�h�����݂���B)
          //
          // CountdownEvent.CurrentCount��0�̏�ԂŁA�����Signal���\�b�h���Ăяo����
          // InvalidOperationException (�C�x���g�̃J�E���g�� 0 ��菬�����l�Ƀf�N�������g���悤�Ƃ��܂����B)��
          // ��������B
          //
          cde.Signal();
          cde.Signal(); // ���̃^�C�~���O�ŗ�O����������.
        });

        try
        {
          t.Wait();
        }
        catch (AggregateException aggEx)
        {
          foreach (Exception innerEx in aggEx.Flatten().InnerExceptions)
          {
            Console.WriteLine("ERROR={0}", innerEx.Message);
          }
        }

        //
        // �J�E���g��0�ɂȂ�܂őҋ@.
        //
        cde.Wait();

        // ���݂̏�Ԃ�\��.
        Console.WriteLine("InitialCount={0}", cde.InitialCount);
        Console.WriteLine("CurrentCount={0}", cde.CurrentCount);
        Console.WriteLine("IsSet={0}", cde.IsSet);
      }
    }
  }
  #endregion
}
