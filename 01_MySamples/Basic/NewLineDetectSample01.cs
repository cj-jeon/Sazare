namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region NewLineDetectSample-01
  /// <summary>
  /// �����񒆂̉��s�R�[�h�̐����Z�o����T���v���ł��B
  /// </summary>
  public class NewLineDetectSample01 : IExecutable
  {
    public void Execute()
    {
      string testStrings = string.Format("��t{0}��t{0}��{0}��t{0}��{0}", Environment.NewLine);

      Console.WriteLine("=== �������� start ===");
      Console.WriteLine(testStrings);
      Console.WriteLine("=== �������� end  ===");

      //
      // ���s�R�[�h�𔻒肷�邽�߂́A��r�������z����\�z.
      //
      char[] newLineChars = Environment.NewLine.ToCharArray();

      //
      // ���s�R�[�h�̃J�E���g���Z�o.
      //
      int count = 0;
      char prevChar = char.MaxValue;
      foreach (Char ch in testStrings)
      {
        //
        // �v���b�g�t�H�[���ɂ���ẮA���s�R�[�h���Q�����̍\�� (CRLF)�ƂȂ邽��
        // �O��̕����̃p�^�[����������v����ꍇ�ɉ��s�R�[�h�ł���Ƃ݂Ȃ��B
        //
        if (newLineChars.Contains(prevChar) && newLineChars.Contains(ch))
        {
          count++;
        }

        prevChar = ch;
      }

      Console.WriteLine("���s�R�[�h�̐�: {0}", count);
    }
  }
  #endregion
}
