namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-53
  /// <summary>
  /// LINQ to XML�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// XElement.Load�𗘗p�����ǂݍ��݂̃T���v���ł��B
  /// </remarks>
  public class LinqSamples53 : IExecutable
  {
    const string FILE_URI = @"LinqSamples53_Sample.xml";
    const string DOWNLOAD_URI = @"https://sites.google.com/site/gsfzero1/Home/Books.xml?attredirects=0&d=1";

    public void Execute()
    {
      //
      // XElement��XDocument��Parse���\�b�h�̑���
      // ���g���\�z���邽�߂�Load���\�b�h�������Ă���.
      //
      // Parse���\�b�h�́A���������͂��č\�z���鎞�ɗ��p��
      // Load���\�b�h�́A���ɑ��݂��Ă�����̂�ǂݍ��ލۂɗ��p����.
      //
      // Load���\�b�h�́A�����̃I�[�o�[���[�h������
      //   �EURI���w��
      //   �E�X�g���[�����w��
      // �ɑ�ʂ����.
      //
      // �{�T���v���ł́AURI�ɂ��ǂݍ��݂��L�q����.
      // URI���w�肷��Load���\�b�h�̃I�[�o�[���[�h�͈ȉ��̒ʂ�B
      //
      //   public XDocument Load(string)
      //   public XDocument Load(string, LoadOptions)
      //   public XElement  Load(string)
      //   public XElement  Load(string, LoadOptions)
      //
      CreateSampleXml();

      var rootElement = XElement.Load(FILE_URI);
      var query = from element in rootElement.Descendants("Person")
                  let name = element.Attribute("name").Value
                  where !name.StartsWith("b")
                  select new { name };

      foreach (var item in query)
      {
        Console.WriteLine(item);
      }

      //
      // URL����XML��ǂݍ���
      //   XML�t�@�C���͈ȉ��̃T���v���𗘗p�����Ă�����Ă���B
      //     http://msdn.microsoft.com/ja-jp/library/vstudio/bb387066.aspx
      //
      Console.WriteLine(XElement.Load(DOWNLOAD_URI));
    }

    void CreateSampleXml()
    {
      if (File.Exists(FILE_URI))
      {
        File.Delete(FILE_URI);
      }

      var doc = MakeDocument();
      doc.Save(FILE_URI);
    }

    XDocument MakeDocument()
    {
      var doc = new XDocument
                  (
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Persons", MakePersonElements())
                  );

      return doc;
    }

    IEnumerable<XElement> MakePersonElements()
    {
      var names = new[] { "foo", "bar", "baz" };
      var query = from name in names
                  select new XElement
                         (
                           "Person",
                           new XAttribute("name", name),
                           string.Format("VALUE-{0}", name)
                         );

      return query;
    }
  }
  #endregion
}
