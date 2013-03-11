namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-68
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �����u���n���\�b�h�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples68 : IExecutable
  {
    public void Execute()
    {
      // 
      // ReplaceAttributes
      //   ���݂̗v�f�ɕt�����Ă��鑮�����ꊇ�Œu������B
      //   �m�[�h�̒u���ɗ��p����ReplaceNodes���\�b�h�Ɠ����v�̂�
      //   ���p�ł���B�i�N�G���𗘗p���Ȃ���A�u���p�̃V�[�P���X���쐬����)
      //   
      var root = BuildSampleXml();
      var elem = root.Elements("Child").First();

      elem.ReplaceAttributes
        (
          from attr in elem.Attributes()
          where attr.Name.ToString().EndsWith("d")
          select new XAttribute(string.Format("{0}-Update", attr.Name), attr.Value)
        );

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
