namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  #region CountdownEventSamples-04
  /// <summary>
  /// CountdownEvent�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// CountdownEvent�N���X�́A.NET 4.0����ǉ����ꂽ�N���X�ł��B
  /// </remarks>
  public class CountdownEventSamples04 : IExecutable
  {
    public void Execute()
    {
      //
      // CountdownEvent�N���X�ɂ́A�ȉ��̃��\�b�h�����݂���B
      //   �EAddCount���\�b�h
      //   �EReset���\�b�h
      // AddCount���\�b�h�́ACountdownEvent�̓����J�E���g���C���N�������g����B
      // Reset���\�b�h�́A���݂̓����J�E���g�����Z�b�g����B
      //
      // �ǂ���̃��\�b�h���AInt32�������Ɏ��I�[�o�[���[�h���p�ӂ���Ă���
      // �w�肵������ݒ肷�邱�Ƃ��o����B
      //
      // ���AAddCount���\�b�h�𗘗p����ۂ̒��ӓ_�Ƃ���
      //   ���ɓ����J�E���g��0�̏�Ԃ�AddCount�����s����Ɨ�O����������B
      // �܂�A����IsSet��True�i�V�O�i����ԁj��AddCount����ƃG���[�ƂȂ�B
      //

      //
      // �����J�E���g��0�̏�ԂŁAAddCount���Ă݂�.
      //
      using (CountdownEvent cde = new CountdownEvent(0))
      {
        // �����̏�Ԃ�\��.
        PrintCurrentCountdownEvent(cde);

        try
        {
          //
          // ���ɃV�O�i����Ԃ̏ꍇ�ɁA�����AddCount���悤�Ƃ���Ɨ�O����������.
          //
          cde.AddCount();
        }
        catch (InvalidOperationException invalidEx)
        {
          Console.WriteLine("������ {0} ������", invalidEx.Message);
        }

        // ���݂̏�Ԃ�\��.
        PrintCurrentCountdownEvent(cde);
      }

      Console.WriteLine("");

      using (CountdownEvent cde = new CountdownEvent(1))
      {
        // �����̏�Ԃ�\��.
        PrintCurrentCountdownEvent(cde);

        //
        // 10�̕ʏ��������s����.
        // ���ꂼ��̓��������ɂă����_����SLEEP���āA�I���^�C�~���O���o���o���ɐݒ�.
        //
        Console.WriteLine("�ʏ����J�n�E�E�E");

        for (int i = 0; i < 10; i++)
        {
          Task.Factory.StartNew(TaskProc, cde);
        }

        do
        {
          // ���݂̏�Ԃ�\��.
          PrintCurrentCountdownEvent(cde, "t");

          Thread.Sleep(TimeSpan.FromSeconds(2));
        }
        while (cde.CurrentCount != 1);

        Console.WriteLine("�E�E�E�ʏ����I��");

        //
        // �ҋ@.
        //
        Console.WriteLine("���C���X���b�h�ɂčŌ�̃J�E���g���f�N�������g");
        cde.Signal();
        cde.Wait();

        // ���݂̏�Ԃ�\��.
        PrintCurrentCountdownEvent(cde);

        Console.WriteLine("");

        //
        // �����J�E���g�����Z�b�g.
        //
        Console.WriteLine("�����J�E���g�����Z�b�g");
        cde.Reset();

        // ���݂̏�Ԃ�\��.
        PrintCurrentCountdownEvent(cde);

        //
        // �ҋ@.
        //
        Console.WriteLine("���C���X���b�h�ɂčŌ�̃J�E���g���f�N�������g");
        cde.Signal();
        cde.Wait();

        // ���݂̏�Ԃ�\��.
        PrintCurrentCountdownEvent(cde);
      }
    }

    void PrintCurrentCountdownEvent(CountdownEvent cde, string prefix = "")
    {
      Console.WriteLine("{0}InitialCount={1}", prefix, cde.InitialCount);
      Console.WriteLine("{0}CurrentCount={1}", prefix, cde.CurrentCount);
      Console.WriteLine("{0}IsSet={1}", prefix, cde.IsSet);
    }

    void TaskProc(object data)
    {
      //
      // �����J�n�Ƌ��ɁACountdownEvent�̓����J�E���g���C���N�������g.
      //
      CountdownEvent cde = data as CountdownEvent;
      cde.AddCount();

      Thread.Sleep(TimeSpan.FromSeconds(new Random().Next(10)));

      //
      // �����J�E���g���f�N�������g.
      //
      cde.Signal();
    }
  }
  #endregion
}
