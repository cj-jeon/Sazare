namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-73
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �i�r�Q�[�V����(PreviousNode, NextNode�v���p�e�B)�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples73 : IExecutable
  {
    public void Execute()
    {
      //
      // PreviousNode
      //   ���݂̗v�f�̈�O�̌Z��v�f���擾����
      //   ��O�̗v�f�����݂��Ȃ��ꍇ�́Anull�ƂȂ�B
      //
      var root = BuildSampleXml();
      var elem = root.Elements("Child").Where(x => x.Value == "value2").First();

      Console.WriteLine("Prev node = {0}", elem.PreviousNode);

      elem = root.Elements("Child").First();
      Console.WriteLine("Prev node = {0}", elem.PreviousNode == null);

      //
      // NextNode
      //   ���݂̗v�f�̈��̌Z��v�f���擾����
      //   ���̗v�f�����݂��Ȃ��ꍇ�́Anull�ƂȂ�
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").Where(x => x.Value == "value3").First();

      Console.WriteLine("Next node = {0}", elem.NextNode);

      elem = root.Elements("Child").Last();
      Console.WriteLine("Next node = {0}", elem.NextNode == null);
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
