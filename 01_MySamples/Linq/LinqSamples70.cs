namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-70
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// ���݊m�F�v���p�e�B (HasElements, HasAttributes) �̃T���v���ł�.
  /// </remarks>
  public class LinqSamples70 : IExecutable
  {
    public void Execute()
    {
      //
      // HasElements
      //   ���O�̒ʂ�A���݂̃m�[�h���T�u�m�[�h�������Ă��邩�ۂ����擾����.
      //
      var root = BuildSampleXml();
      var child = root.Elements("Child").First();
      var grandChild = child.Elements("Value").First();

      Console.WriteLine("root.HasElements: {0}", root.HasElements);
      Console.WriteLine("child.HasElements: {0}", child.HasElements);
      Console.WriteLine("grand-child.HasElements: {0}", grandChild.HasElements);

      Console.WriteLine("=====================================");

      //
      // HasAttributes
      //   ���O�̒ʂ�A���݂̃m�[�h�������������Ă��邩�ۂ����擾����.
      //
      root = BuildSampleXml();
      child = root.Elements("Child").First();
      grandChild = child.Elements("Value").First();

      Console.WriteLine("root.HasAttributes:{0}", root.HasAttributes);
      Console.WriteLine("child.HasAttributes:{0}", child.HasAttributes);
      Console.WriteLine("grand-child.HasAttributes:{0}", grandChild.HasAttributes);

      Console.WriteLine("=====================================");
    }

    XElement BuildSampleXml()
    {
      return XElement.Parse("<Root><Child Id=\"100\" Id2=\"200\"><Value Id=\"300\">hoge</Value></Child></Root>");
    }
  }
  #endregion
}
