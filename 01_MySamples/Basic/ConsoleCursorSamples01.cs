namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  #region ConsoleCursorSamples-01
  /// <summary>
  /// Console�N���X�𗘗p���ăv���O�����̎��s�󋵂������T���v���ł��B
  /// </summary>
  /// <remarks>
  /// ���̃T���v����EmEditor�o�R�ł͓���ł��܂���B
  /// ���̃N���X�̃\�[�X�R�[�h��ʃt�@�C���ɕۑ����ăR�}���h���C���ɂ�
  /// ���s���Ă��������B
  ///</remarks>
  public class ConsoleCursorSamples01 : IExecutable
  {
    volatile bool _stop;

    public void Execute()
    {
      //
      // Console�N���X�ɂ́A�J�[�\���ʒu�𑀍삷�邽�߂�
      // �ȉ��̃��\�b�h�����p�ł���B
      //
      //   �ESetCursorPosition : �J�[�\���ʒu��ݒ�
      //   �ECursorLeft    : ���݂̃J�[�\���̍��ʒu(��)���擾
      //   �ECursorTop     : ���݂̃J�[�\���̏�ʒu(�s)���擾
      //
      // ��L�̃��\�b�h�𗘗p���鎖�ŁALinux�Ȃǂł悭��������
      // ��������Ԃ̃J�[�\����ݒ肷�邱�Ƃ��o����B
      //
      Console.WriteLine("�����J�n.......");

      ShowProgressMark();
      Thread.Sleep(TimeSpan.FromSeconds(5.0));

      _stop = true;

      Console.WriteLine(string.Empty);
      Console.WriteLine("�I��");
    }

    void ShowProgressMark()
    {
      //
      // ���݂̃J�[�\���ʒu��ێ�.
      //
      int left = Console.CursorLeft;
      int top = Console.CursorTop;

      //
      // �o�b�t�@�ɏ�������.
      //
      _stop = false;

      Task.Factory.StartNew(() =>
        {
          while (true)
          {
            if (_stop)
            {
              break;
            }

            Console.SetCursorPosition(left, top);
            Console.Write("|");
            Thread.Sleep(TimeSpan.FromMilliseconds(100.0));

            Console.SetCursorPosition(left, top);
            Console.Write("/");
            Thread.Sleep(TimeSpan.FromMilliseconds(100.0));

            Console.SetCursorPosition(left, top);
            Console.Write("-");
            Thread.Sleep(TimeSpan.FromMilliseconds(100.0));

            Console.SetCursorPosition(left, top);
            Console.Write("\\");
            Thread.Sleep(TimeSpan.FromMilliseconds(100.0));
          }
        }
      );
    }
  }
  #endregion
}
