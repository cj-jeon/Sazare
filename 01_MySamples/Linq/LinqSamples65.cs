namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-65
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �����ǉ��n���\�b�h�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples65 : IExecutable
  {
    public void Execute()
    {
      //
      // Add(object)
      //   Add���\�b�h�́A�v�f�̐ݒ�ɂ������̐ݒ�ɂ����p�ł���.
      //   ���ӓ_�Ƃ��āA���̃��\�b�h�͏d�������������w�肵���ꍇ��
      //   InvalidOperationException�𔭐�������B
      //
      var root = BuildSampleXml();
      var elem = root.Elements("Child").First();

      elem.Add(new XAttribute("Id3", 400));
      Console.WriteLine(root);

      try
      {
        //
        // ���łɑ��݂��鑮����Add���悤�Ƃ����
        // InvalidOperationException����������.
        //
        elem.Add(new XAttribute("Id2", 500));
        Console.WriteLine(root);
      }
      catch (InvalidOperationException invalidOpEx)
      {
        Console.WriteLine("[ERROR] {0}", invalidOpEx.Message);
      }

      Console.WriteLine("=====================================");

      //
      // SetAttributeValue(XName, object)
      //   ����I�ɂ́A�v�f�̒l�ݒ�ɗ��p����
      //   SetElementValue���\�b�h�Ɠ����ƂȂ�B
      //     - ���݂��Ȃ��������̂��w�肷��ƒǉ������
      //     - ���݂��鑮�����̂��w�肷��ƍX�V�����
      //     - �l��null���w�肷��Ƒ������폜�����
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").First();

      elem.SetAttributeValue("Id3", 400);
      Console.WriteLine(elem);

      elem.SetAttributeValue("Id3", 500);
      Console.WriteLine(elem);

      elem.SetAttributeValue("Id3", null);
      Console.WriteLine(elem);

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
