namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  #region SemaphoreSlimSamples-01
  /// <summary>
  /// SemaphoreSlim�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// SemaphoreSlim�N���X�́A.NET 4.0����ǉ����ꂽ�N���X�ł��B
  /// �]�����瑶�݂��Ă���Semaphore�N���X�̌y�ʔłƂȂ�܂��B
  /// </remarks>
  public class SemaphoreSlimSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // SemaphoreSlim�N���X�́ASemaphore�N���X�̌y�ʔłƂ���
      // .NET 4.0����ǉ����ꂽ�N���X�ł���B
      //
      // Semaphore�́A���\�[�X�ɓ����ɃA�N�Z�X�o����X���b�h�̐��𐧌����邽�߂ɗ��p�����B
      //
      // �@�\�I�ɂ́ASemaphore�N���X�Ƒ卷�Ȃ����ȉ��̋@�\���ǉ�����Ă���B
      //   �L�����Z���g�[�N�����󂯕t����Wait���\�b�h�̃I�[�o�[���[�h�����݂���B
      // �L�����Z���g�[�N�����󂯕t����Wait���\�b�h�Ɋւ��ẮACountdownEvent�N���X��Barrier�N���X
      // �Ɨ��p���@�͓����ł���B
      //
      // ���A���X��Semaphore�N���X�ł́AWaitOne���\�b�h���������̂�
      // SemaphoreSlim�N���X�ł́AWait���\�b�h�Ƃ������O�ɕς���Ă���B
      //

      //
      // Wait���\�b�h�̗��p.
      // 
      // Wait���\�b�h�́A���邱�Ƃ��o�����ꍇ��True��Ԃ��B
      // ���ɏ���܂ŃX���b�h�������Ă���ꍇ��False���ԋp�����B
      // (�܂�u���b�N�����B)
      //
      // ����������Wait���\�b�h�́A���邱�Ƃ��o����܂Ńu���b�N����郁�\�b�h�ƂȂ�B
      // ���ʂ�bool�Ŏ󂯎��ꍇ�́AInt32�������ɂƂ�Wait���\�b�h�𗘗p����B
      // 0���w�肷��Ƒ����ʂ��Ԃ��Ă���B-1���w�肷��Ɩ������ɑ҂B
      // (����������Wait���\�b�h�Ɠ����B)
      //
      // SemaphoreSlim�ł́AAvailableWaitHandle�v���p�e�B���WaitHandle���擾���邱�Ƃ��o����B
      // �������A����WaitHandle�́ASemaphoreSlim�{�̂Ƃ͘A�g���Ă���킯�ł͖����B
      // �Ȃ̂ŁA����WaitHandle�o�R��WaitOne�����s���Ă��ASemaphoreSlim���̃J�E���g�͕ω����Ȃ��̂Œ��ӁB
      //
      using (SemaphoreSlim semaphore = new SemaphoreSlim(2))
      {
        // ����Semaphore�ɓ��邱�Ƃ��\�ȃX���b�h����\��
        Console.WriteLine("CurrentCount={0}", semaphore.CurrentCount);

        // 1��
        Console.WriteLine("1�ڂ�Wait={0}", semaphore.Wait(0));
        // 2��
        Console.WriteLine("2�ڂ�Wait={0}", semaphore.Wait(0));

        // ����Semaphore�ɓ��邱�Ƃ��\�ȃX���b�h����\��
        Console.WriteLine("CurrentCount={0}", semaphore.CurrentCount);

        // 3��
        // ����Release���Ă��鐔��0�Ȃ̂ŁA���邱�Ƃ��o���Ȃ��B
        // (False���ԋp�����)
        Console.WriteLine("3�ڂ�Wait={0}", semaphore.Wait(0));

        // �P�����[�X���āA�g���󂯂�.
        semaphore.Release();

        // ����Semaphore�ɓ��邱�Ƃ��\�ȃX���b�h����\��
        Console.WriteLine("CurrentCount={0}", semaphore.CurrentCount);

        // �ēx�A3��
        // ���x�́A�g���󂢂Ă���̂œ��邱�Ƃ��o����B
        Console.WriteLine("3�ڂ�Wait={0}", semaphore.Wait(0));

        // ����Semaphore�ɓ��邱�Ƃ��\�ȃX���b�h����\��
        Console.WriteLine("CurrentCount={0}", semaphore.CurrentCount);

        semaphore.Release();
        semaphore.Release();

        // ����Semaphore�ɓ��邱�Ƃ��\�ȃX���b�h����\��
        Console.WriteLine("CurrentCount={0}", semaphore.CurrentCount);
      }
    }
  }
  #endregion
}
