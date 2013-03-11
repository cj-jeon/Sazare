namespace Gsf.Samples
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;
  using System.Xml.XPath;

  #region LinqSamples-82
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// XPath(System.Xml.XPath.Extensions)�̃T���v���ł�.
  /// LINQ to XML��XPath�̔�r�ɂ��Ă�
  ///   http://msdn.microsoft.com/ja-jp/library/vstudio/bb675178.aspx
  /// �ɏڍׂɋL�ڂ���Ă���.
  /// </remarks>
  public class LinqSamples82 : IExecutable
  {
    public void Execute()
    {
      //
      // XPathSelectElements
      //   XPath����]�����āAXElement���擾����
      //
      // LINQ to XML�ɂ́AXPath�p�̊g�����\�b�h����`���ꂽ�N���X�����݂��邽��
      // ����𗘗p����B�ȉ��̃N���X�ł���.
      //   System.Xml.XPath.Extensions
      // ���A���p����ɂ�System.Xml.XPath��using���Ă����K�v������.
      //
      var root = BuildSampleXml();

      // XPath�w��
      foreach (var elem in root.XPathSelectElements("Book/Title"))
      {
        Console.WriteLine("Value:{0}, Type:{1}", elem, elem.GetType().Name);
      }

      // XPath�w��
      foreach (var elem in root.XPathSelectElements("//Title"))
      {
        Console.WriteLine("Value:{0}, Type:{1}", elem, elem.GetType().Name);
      }

      Console.WriteLine("=====================================");

      // LINQ to XML
      foreach (var elem in root.Elements("Book").Elements("Title"))
      {
        Console.WriteLine(elem);
      }

      // LINQ to XML
      foreach (var elem in root.Descendants("Title"))
      {
        Console.WriteLine(elem);
      }

      Console.WriteLine("=====================================");

      //
      // XPathEvaluate
      //   XPath����]�����āA���ʂ��擾����
      //
      // LINQ to XML�ɂ́AXPath�p�̊g�����\�b�h����`���ꂽ�N���X�����݂��邽��
      // ����𗘗p����B�ȉ��̃N���X�ł���.
      //   System.Xml.XPath.Extensions
      // ���A���p����ɂ�System.Xml.XPath��using���Ă����K�v������.
      //
      // XPathEvaluate���\�b�h�́A�߂�l��object�ɂȂ邱�Ƃɒ��ӁB
      //
      root = BuildSampleXml();

      // XPath�w��
      foreach (var elem in (IEnumerable)root.XPathEvaluate("Book[@id=\"bk102\"]/PublishDate"))
      {
        Console.WriteLine("Value:{0}, Type:{1}", elem, elem.GetType().Name);
      }

      Console.WriteLine("=====================================");

      // LINQ to XML
      var query = from book in root.Elements("Book")
                  where book.Attribute("id").Value == "bk102"
                  select book.Element("PublishDate");

      foreach (var elem in query)
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
