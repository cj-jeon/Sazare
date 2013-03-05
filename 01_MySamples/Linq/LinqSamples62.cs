namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-62
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �v�f�폜�n���\�b�h�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples62 : IExecutable
  {
    public void Execute()
    {
      //
      // Remove()
      //   ���݂̗v�f��XML�c���[���폜����.
      //
      var root = BuildSampleXml();
      var elem = root.Descendants("Value").First();

      elem.Remove();

      Console.WriteLine(root);
      Console.WriteLine("=====================================");

      //
      // RemoveAll()
      //   ���݂̗v�f����q�m�[�h�y�ё������폜����.
      //   �����܂ō폜�����_�ɒ��ӁB
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").First();

      elem.RemoveAll();

      Console.WriteLine(root);
      Console.WriteLine("=====================================");

      //
      // RemoveNodes()
      //   ���݂̗v�f����q�m�[�h���폜����
      //   RemoveAll���\�b�h�ƈႢ�A�����͍폜����Ȃ�
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").First();

      elem.RemoveNodes();

      Console.WriteLine(root);
      Console.WriteLine("=====================================");

      //
      // SetElementValue(XName, object)
      //   �{���́A�q�v�f�̒l��ݒ肷�邽�߂̃��\�b�h�ł��邪
      //   �v�f�̒l��null��ݒ肷�邱�Ƃō폜���邱�Ƃ��o����
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").First();

      elem.SetElementValue("Value", null);

      Console.WriteLine(root);
      Console.WriteLine("=====================================");
    }

    XElement BuildSampleXml()
    {
      return XElement.Parse("<Root><Child Id=\"100\"><Value>hoge</Value></Child></Root>");
    }
  }
  #endregion
}
