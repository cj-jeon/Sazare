namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-74
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �i�r�Q�[�V����(FirstNode, LastNode�v���p�e�B)�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples74 : IExecutable
  {
    public void Execute()
    {
      //
      // FirstNode
      //   ���݂̗v�f�̍ŏ��̎q�v�f���擾����
      //
      var root = BuildSampleXml();
      var elem = root.Elements("Child").First();

      Console.WriteLine(root.FirstNode);
      Console.WriteLine(elem.FirstNode);

      //
      // LastNode
      //   ���݂̗v�f�̍Ō�̎q�v�f���擾����
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").First();

      Console.WriteLine(root.LastNode);
      Console.WriteLine(elem.LastNode);
    }

    XElement BuildSampleXml()
    {
      var root = new XElement("Root",
        new XElement("Child", "value1"),
        new XElement("Child", "value2"),
        new XElement("Child", "value3"),
        new XElement("Child", "value4")
      );

      return root;
    }
  }
  #endregion
}
