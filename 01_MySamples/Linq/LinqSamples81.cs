namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-81
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �h�L�������g���ɕ��ёւ�(InDocumentOrder)�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples81 : IExecutable
  {
    public void Execute()
    {
      //
      // InDocumentOrder<T> where T : XNode (�g�����\�b�h)
      //   ���̃V�[�P���X���h�L�������g���̏����ɏ]���悤���ёւ���.
      //
      var root = BuildSampleXml();
      var reversed = root.Elements().Reverse();

      // Reverse���Ă���̂ŋt���ŕ\�������
      foreach (var elem in reversed)
      {
        Console.WriteLine(elem);
      }

      Console.WriteLine("=====================================");

      // InDocumentOrder���s�����Ƃɂ��A�v�f�������������ɕ��ёւ�����
      foreach (var elem in reversed.InDocumentOrder())
      {
        Console.WriteLine(elem);
      }

      Console.WriteLine("=====================================");

      // ����̗v�f���s�b�N�A�b�v���āA�V�[�P���X�쐬�B�킴�Ə�����ς��Ă���.
      XElement[] elemList = { root.Descendants("Title").Last(), root.Descendants("Title").First() };

      // ���̂܂ܕ\������Ɠ��R�����͕ς�����܂�
      foreach (var elem in elemList)
      {
        Console.WriteLine(elem);
      }

      Console.WriteLine("=====================================");

      // InDocumentOrder��t���邱�Ƃɂ��A�h�L�������g���̐����������ɕ��ёւ�����
      foreach (var elem in elemList.InDocumentOrder())
      {
        Console.WriteLine(elem);
      }
    }

    XElement BuildSampleXml()
    {
      //
      // �T���v��XML�t�@�C��
      //  see: http://msdn.microsoft.com/ja-jp/library/vstudio/ms256479(v=vs.90).aspx
      //
      return XElement.Load(@"xml/Books.xml");
    }
  }
  #endregion
}
