namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-67
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �����폜�n���\�b�h�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples67 : IExecutable
  {
    public void Execute()
    {
      //
      // XAttribute.Remove
      //   ���݂̑������폜����.
      //
      var root = BuildSampleXml();
      var elem = root.Elements("Child").First();

      var attr = elem.Attribute("Id");
      attr.Remove();

      //
      // �폜��̑����ɒl��ݒ肵�Ă��A���f����Ȃ�.
      //
      attr.Value = "999";

      Console.WriteLine(root);
      Console.WriteLine("=====================================");

      //
      // SetAttributeValue
      //   �����̒l��ݒ肷�郁�\�b�h�ł��邪
      //   �l��null���w�肷�邱�ƂŁA�������폜���邱�Ƃ��ł���.
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").First();

      elem.SetAttributeValue("Id", null);

      Console.WriteLine(root);
      Console.WriteLine("=====================================");

      //
      // RemoveAttributes
      //   ���݂̗v�f�ɑ��݂��鑮����S�č폜����.
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").First();

      elem.RemoveAttributes();

      Console.WriteLine(root);
      Console.WriteLine("=====================================");
    }

    XElement BuildSampleXml()
    {
      return XElement.Parse("<Root><Child Id=\"100\" Id2=\"200\"><Value Id=\"300\">hoge</Value></Child></Root>");
    }
  }
  #endregion
}
