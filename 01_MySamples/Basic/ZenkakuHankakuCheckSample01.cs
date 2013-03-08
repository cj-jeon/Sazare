namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  #region �S�p�`�F�b�N�Ɣ��p�`�F�b�N
  /// <summary>
  /// �S�p�`�F�b�N�Ɣ��p�`�F�b�N�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// �P���ȑS�p�`�F�b�N�Ɣ��p�`�F�b�N���`���Ă��܂��B
  /// </remarks>
  public class ZenkakuHankakuCheckSample01 : IExecutable
  {
    public void Execute()
    {
      string zenkakuOnlyStrings = "����������";
      string hankakuOnlyStrings = "�����";
      string zenkakuAndHankakuStrings = "���������������";

      Console.WriteLine("IsZenkaku:zenkakuOnly:{0}", IsZenkaku(zenkakuOnlyStrings));
      Console.WriteLine("IsZenkaku:hankakuOnlyStrings:{0}", IsZenkaku(hankakuOnlyStrings));
      Console.WriteLine("IsZenkaku:zenkakuAndHankakuStrings:{0}", IsZenkaku(zenkakuAndHankakuStrings));
      Console.WriteLine("IsHankaku:zenkakuOnly:{0}", IsHankaku(zenkakuOnlyStrings));
      Console.WriteLine("IsHankaku:hankakuOnlyStrings:{0}", IsHankaku(hankakuOnlyStrings));
      Console.WriteLine("IsHankaku:zenkakuAndHankakuStrings:{0}", IsHankaku(zenkakuAndHankakuStrings));
    }

    bool IsZenkaku(string value)
    {
      //
      // �w�肳�ꂽ�����񂪑S�đS�p�����ō\������Ă��邩�ۂ���
      // ���������USJIS�ɕϊ����擾�����o�C�g���ƌ�������̕��������Q��
      // ���藧���ۂ��Ō���ł���B
      //
      return (Encoding.GetEncoding("sjis").GetByteCount(value) == (value.Length * 2));
    }

    bool IsHankaku(string value)
    {
      //
      // �w�肳�ꂽ�����񂪑S�Ĕ��p�����ō\������Ă��邩�ۂ���
      // ���������USJIS�ɕϊ����擾�����o�C�g���ƌ�������̕�������
      // ���藧���ۂ��Ō���ł���B
      //
      return (Encoding.GetEncoding("sjis").GetByteCount(value) == value.Length);
    }
  }
  #endregion
}
