namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-64
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �����擾�n���\�b�h�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples64 : IExecutable
  {
    public void Execute()
    {
      //
      // FirstAttribute
      //   ���݂̗v�f�̍ŏ��̑������擾����.
      //
      var root = BuildSampleXml();
      var elem = root.Elements("Child").First();

      var attr = elem.FirstAttribute;

      Console.WriteLine(attr);
      Console.WriteLine("{0}=\"{1}\"", attr.Name, attr.Value);
      Console.WriteLine("=====================================");

      //
      // LastAttribute
      //   ���݂̗v�f�̍Ō�̑������擾����.
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").First();

      attr = elem.LastAttribute;

      Console.WriteLine(attr);
      Console.WriteLine("=====================================");

      //
      // Attribute(XName)
      //   �w�肵�����̂����������擾����.
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").First();

      attr = elem.Attribute("Id2");

      Console.WriteLine(attr);
      Console.WriteLine(elem.Attribute("Id3") == null);
      Console.WriteLine("=====================================");

      //
      // Attributes()
      //   �v�f�������������ׂĎ擾����.
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").First();

      var attrs = elem.Attributes();

      Console.WriteLine("Count={0}", attrs.Count());
      foreach (var a in attrs)
      {
        Console.WriteLine("\t{0}", a);
      }

      Console.WriteLine("=====================================");

      //
      // Attributes(XName)
      //   �w�肵�����̂Ɉ�v���鑮�����擾����.
      //   ���XElement�̃V�[�P���X�ɑ΂��ė��p����.
      //
      root = BuildSampleXml();
      var elems = root.Descendants();

      attrs = elems.Attributes("Id");

      Console.WriteLine("Count={0}", attrs.Count());
      foreach (var a in attrs)
      {
        Console.WriteLine("\t{0}", a);
      }

      Console.WriteLine("=====================================");
    }

    XElement BuildSampleXml()
    {
      return XElement.Parse("<Root><Child Id=\"100\" Id2=\"200\"><Value Id=\"300\">hoge</Value></Child></Root>");
    }
  }
  #endregion
}
