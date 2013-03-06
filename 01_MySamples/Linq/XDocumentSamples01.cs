namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region XDocumentSamples-01
  /// <summary>
  /// XDocument�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  public class XDocumentSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // XElement���\�z����ہAparam�����ɂ́A����XElement��ݒ肵�Ă��AList<XElement>���w�肵�Ă����Ȃ��B
      //
      var doc = new XDocument(new XElement("RootElement",
                        new XElement("Title", "gsf_zero1"),
                        new List<XElement> { new XElement("Age", 30), new XElement("Address", "kyoto, Kyoto, Japan") }));

      Console.WriteLine(doc);
    }
  }
  #endregion
}
