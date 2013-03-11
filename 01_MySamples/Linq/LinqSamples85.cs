namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Xml;
  using System.Xml.Linq;

  #region LinqSamples-85
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// XStreamingElement�̃T���v���ł��B
  /// </remarks>
  public class LinqSamples85 : IExecutable
  {
    public void Execute()
    {
      //
      // XStreamingElement
      //   XStreamingElement�́A�x���]�����s���N���X�B
      //   ��ɁA�����XML�f�[�^��ϊ�����ۂɗ��p�ł���.
      //
      //   �Q�lURL:
      //     http://msdn.microsoft.com/ja-jp/library/system.xml.linq.xstreamingelement.aspx
      //     http://melma.com/backnumber_120830_4496326/
      //     http://msdn.microsoft.com/ja-jp/library/system.xml.linq.xnode.readfrom.aspx
      //     http://msdn.microsoft.com/ja-jp/library/system.xml.xmlreader.movetocontent.aspx
      //
      //   ���ۂɗ��p����ۂ́A�قƂ�ǂ̏ꍇ��XmlReader��yield�̎d�g�݂����O�ɍ���Ă����Ȃ��Ƃ����Ȃ��B
      //   XmlReader�ŋ���t�@�C���𒀎��ǂݍ��݂��A�����XStreamingElement�ŕϊ���������B
      //
      // �ȉ��̏����ł́A�ǂ̒��x������������Ă���̂����m�F���邽�߂�
      // GC.GetTotalMemory�ŏ���ʂ�\�����Ă���.
      Console.WriteLine("1:{0}", GC.GetTotalMemory(true));

      //
      // ����XML�t�@�C�����쐬.
      //
      var root = BuildSampleXml(CreateSampleXmlFile());

      Console.WriteLine("2:{0}", GC.GetTotalMemory(true));

      //
      // ���ʂ�XElement�𗘗p���ĕϊ�����.
      //
      var result = ConvertXml(root);

      Console.WriteLine("3:{0}", GC.GetTotalMemory(true));

      //
      // XStreamingElement�𗘗p���ĕϊ�����.
      //
      var result2 = ConvertXml2(root);

      Console.WriteLine("4:{0}", GC.GetTotalMemory(true));

      //
      // XStreamingElement�ŕϊ������f�[�^���o��.
      //
      result2.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "converted2.xml"));

      Console.WriteLine("5:{0}", GC.GetTotalMemory(true));

      //
      // �t�@�C���̓ǂݍ��݂ɁAXmlReader+yield�𗘗p����XStreamingElement�ŕϊ�����.
      //
      var result3 = ConvertXml3();

      Console.WriteLine("6:{0}", GC.GetTotalMemory(true));

      //
      // XStreamingElement�ŕϊ������f�[�^���o��.
      //
      result3.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "converted3.xml"));

      Console.WriteLine("7:{0}", GC.GetTotalMemory(true));
    }

    string CreateSampleXmlFile()
    {
      //
      // �����XML�t�@�C�����f�X�N�g�b�v�ɍ쐬.
      //
      var dirPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      var filePath = Path.Combine(dirPath, "toobig.xml");

      if (File.Exists(filePath))
      {
        File.Delete(filePath);
      }

      //
      // <root>
      //   <data>
      //     <code>...</code>
      //     <name>...</name>
      //   </data>
      //   .
      //   .
      //   .
      // </root>
      //
      // �̍\��������XML�t�@�C�����쐬.
      //
      var doc = new XDocument
                (
                  new XElement
                  (
                    "root",
                    from i in Enumerable.Range(1, 100000)
                    select new XElement
                           (
                             "data",
                             new XElement("code", string.Format("{0:D5}", i)),
                             new XElement("name", string.Format("name-{0:D5}", i))
                           )
                  )
                );

      doc.Save(filePath);

      return filePath;
    }

    XElement BuildSampleXml(string filePath)
    {
      return XElement.Load(filePath);
    }

    XElement ConvertXml(XElement original)
    {
      var result = new XElement
                   (
                     "newroot",
                     from elem in original.Elements()
                     select new XElement
                     (
                       "newdata",
                       new XAttribute("code", elem.Element("code").Value),
                       new XAttribute("name", elem.Element("name").Value)
                     )
                   );

      return result;
    }

    XStreamingElement ConvertXml2(XElement original)
    {
      var result = new XStreamingElement
                   (
                     "newroot",
                     from elem in original.Elements()
                     select new XElement
                     (
                       "newdata",
                       new XAttribute("code", elem.Element("code").Value),
                       new XAttribute("name", elem.Element("name").Value)
                     )
                   );

      return result;
    }

    XStreamingElement ConvertXml3()
    {
      var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "toobig.xml");

      var result = new XStreamingElement
                   (
                     "newroot",
                     from elem in StreamTooBigXml(filePath)
                     select new XElement
                     (
                       "newdata",
                       new XAttribute("code", elem.Element("code").Value),
                       new XAttribute("name", elem.Element("name").Value)
                     )
                   );

      return result;
    }

    IEnumerable<XElement> StreamTooBigXml(string filePath)
    {
      using (var reader = XmlReader.Create(filePath))
      {
        reader.MoveToContent();

        while (reader.Read())
        {
          if (reader.NodeType != XmlNodeType.Element)
          {
            continue;
          }

          if (reader.Name != "data")
          {
            continue;
          }

          //
          // XElement.ReadFrom�𗘗p����ƊȒP��XElement���擾�o����.
          //
          var elem = XElement.ReadFrom(reader) as XElement;
          if (elem != null)
          {
            yield return elem;
          }
        }
      }
    }
  }
  #endregion
}
