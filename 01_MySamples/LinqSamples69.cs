namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-69
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// ���O��� (XNamespace) �̃T���v���ł�.
  /// </remarks>
  public class LinqSamples69 : IExecutable
  {
    public void Execute()
    {
      //
      // ���O��ԂȂ�
      //   �ʏ킻�̂܂ܗv�f���쐬����Ɩ��O��Ԗ����ƂȂ�.
      //   ���O��Ԗ����̏ꍇ�AXNamespace.None���ݒ肳��Ă���.
      //   XName.Namespace�v���p�e�B��null�ɂȂ�Ȃ����Ƃ͕ۏ؂���Ă���.
      //     http://msdn.microsoft.com/ja-jp/library/system.xml.linq.xnamespace.aspx
      //
      var root = BuildSampleXml();
      var name = root.Name;

      Console.WriteLine("is XNamespace.None?? == {0}", root.Name.Namespace == XNamespace.None);
      Console.WriteLine("=====================================");

      //
      // �f�t�H���g���O��Ԃ���
      //   ����XML�Ƀf�t�H���g���O��Ԃ��ݒ肳��Ă���ꍇ
      //   �擾����XElement -> XName��薼�O��Ԃ��擾�ł���
      //
      //   �f�t�H���g���O��ԂȂ̂ŁA�v�f���擾����ۂɖ��O��Ԃ̕t�^��
      //   �K�v�Ȃ��B�i���̂܂܎擾�ł���)
      //
      root = BuildSampleXmlWithDefaultNamespace();
      name = root.Name;

      Console.WriteLine("XName.LocalName={0}", name.LocalName);
      Console.WriteLine("XName.Namespace={0}", name.Namespace);
      Console.WriteLine("XName.NamespaceName={0}", name.NamespaceName);
      Console.WriteLine("=====================================");

      //
      // �f�t�H���g���O��ԂƃJ�X�^�����O��Ԃ���
      //   �f�t�H���g���O��ԂɊւ��ẮA��L�̒ʂ�B
      //   �J�X�^�����O��Ԃ̏ꍇ�A�v�f���擾����ۂ�
      //     XNamespace + "�v�f��"
      //   �̂悤�ɁA���O��Ԃ�t�^���Ď擾����K�v������.
      //   �J�X�^�����O��ԓ��̗v�f�́AXNamespace��t�^���Ȃ���
      //   �擾�ł��Ȃ�.
      //
      root = BuildSampleXmlWithNamespace();
      name = root.Name;

      Console.WriteLine("XName.LocalName={0}", name.LocalName);
      Console.WriteLine("XName.Namespace={0}", name.Namespace);
      Console.WriteLine("XName.NamespaceName={0}", name.NamespaceName);

      if (root.Descendants("Value").Count() == 0)
      {
        Console.WriteLine("[Count=0] Namespace���Ⴄ�̂ŁA�v�f���擾�ł��Ȃ�.");
      }

      Console.WriteLine("=====================================");

      var ns = (XNamespace)"http://www.tmpurl.org/MyXml2";
      var elem = root.Descendants(ns + "Value").First();
      name = elem.Name;

      Console.WriteLine("XName.LocalName={0}", name.LocalName);
      Console.WriteLine("XName.Namespace={0}", name.Namespace);
      Console.WriteLine("XName.NamespaceName={0}", name.NamespaceName);
      Console.WriteLine("=====================================");

      //
      // ���O��ԕt���ŗv�f�쐬 (�v���t�B�b�N�X�Ȃ�)
      //   �v�f�쐬�̍ۂɁA���O��Ԃ�t�^����ɂ�
      //   �\��XNamespace���쐬���Ă����A�����
      //      XNamespace + "�v�f"
      //   �Ƃ������ɁA���������������悤�ȗv�̂ŗ��p����B
      //   XNamespace�́A�Öقŕ����񂩂琶���ł���.
      //
      var defaultNamespace = (XNamespace)"http://www.tmpurl.org/Default";
      var customNamespace = (XNamespace)"http://www.tmpurl.org/Custom";

      var newElement = new XElement(
                         defaultNamespace + "RootNode",
                         Enumerable.Range(1, 3).Select(x => new XElement(customNamespace + "ChildNode", x))
                       );

      Console.WriteLine(newElement);
      Console.WriteLine("=====================================");

      //
      // ���O��ԕt���ŗv�f�쐬 (�v���t�B�b�N�X����)
      //   <ns:Node>xxx</ns:Node>
      // �̂悤�ɁA�v�f�ɖ��O��ԃv���t�B�b�N�X��t�^����ɂ�
      // �܂��A�v���t�B�b�N�X��t�^����v�f�����e�v�f�ɂ�
      //   new XAttribute(XNamespace.Xmlns + "customs", "http://xxxxx/xxxx")
      // �̑�����t�^����B����ɂ��A�e�v�f�ɂ�
      //   <Root xmlns:customs="http://xxxxx/xxxx">
      // �Ƃ��������ɂȂ�B
      // ��́A�v���t�B�b�N�X��t�^����v�f�ɂĒʏ�ʂ�
      //   new XElement(customNamespace + "ChildNode", x)
      // �ƒ�`���邱�Ƃɂ��A�����I�ɍ��v����v���t�B�b�N�X���ݒ肳���B
      // 
      newElement = new XElement(
                     defaultNamespace + "RootNode",
                     new XAttribute(XNamespace.Xmlns + "customns", "http://www.tmpurl.org/Custom"),
                     from x in Enumerable.Range(1, 3)
                     select new XElement(customNamespace + "ChildNode", x),
                     new XElement(defaultNamespace + "ChildNode", 4)
                   );

      Console.WriteLine(newElement);
      Console.WriteLine("=====================================");

      //
      // �J�X�^�����O��Ԃɑ�����v�f��\��.
      //
      foreach (var e in newElement.Descendants(customNamespace + "ChildNode"))
      {
        Console.WriteLine(e);
      }

      Console.WriteLine("=====================================");

      //
      // �f�t�H���g���O��Ԃɑ�����v�f��\��.
      //
      foreach (var e in newElement.Descendants(defaultNamespace + "ChildNode"))
      {
        Console.WriteLine(e);
      }

      Console.WriteLine("=====================================");

      //
      // ���O��Ԗ����̗v�f��\��.
      //
      foreach (var e in newElement.Descendants("ChildNode"))
      {
        Console.WriteLine(e);
      }
    }

    XElement BuildSampleXml()
    {
      return XElement.Parse("<Root><Child Id=\"100\" Id2=\"200\"><Value Id=\"300\">hoge</Value></Child></Root>");
    }

    XElement BuildSampleXmlWithDefaultNamespace()
    {
      return XElement.Parse("<Root xmlns=\"http://www.tmpurl.org/MyXml\"><Child Id=\"100\" Id2=\"200\"><Value Id=\"300\">hoge</Value></Child></Root>");
    }

    XElement BuildSampleXmlWithNamespace()
    {
      return XElement.Parse("<Root xmlns=\"http://www.tmpurl.org/MyXml\" xmlns:x=\"http://www.tmpurl.org/MyXml2\"><Child Id=\"100\" Id2=\"200\"><x:Value Id=\"300\">hoge</x:Value></Child></Root>");
    }
  }
  #endregion
}
