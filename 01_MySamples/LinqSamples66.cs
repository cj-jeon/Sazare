namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-66
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �����X�V�n���\�b�h�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples66 : IExecutable
  {
    public void Execute()
    {
      //
      // XAttribute.Value
      //   XElement.Attribute(XName)�𗘗p�����
      //   XAttribute�I�u�W�F�N�g���擾�ł���.
      //   XAttribute.Value�v���p�e�B�ɒl��ݒ肷�邱�Ƃ�
      //   �����̒l���X�V�ł���.
      //
      //   ���AValue�v���p�e�B��string�^�݂̂��󂯕t����d�l��
      //   �Ȃ��Ă���̂Œ��ӁB
      //
      var root = BuildSampleXml();
      var elem = root.Elements("Child").First();

      var attr = elem.Attribute("Id");
      attr.Value = 500.ToString();

      Console.WriteLine(root);
      Console.WriteLine("=====================================");

      //
      // XAttribute.SetValue
      //   XAttribute.Value�ƈႢ�A�������object�^���󂯕t���郁�\�b�h�B
      //   �����ŕϊ����s��ꂽ��A�l���ݒ肳���.
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").First();

      attr = elem.Attribute("Id");
      attr.SetValue(500);

      Console.WriteLine(root);
      Console.WriteLine("=====================================");

      //
      // SetAttributeValue
      //   ���łɑ��݂���v�f���w�肵�āA�{���\�b�h�����s�����
      //   �����̒l���X�V�����.
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").First();

      elem.SetAttributeValue("Id", 500);

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
