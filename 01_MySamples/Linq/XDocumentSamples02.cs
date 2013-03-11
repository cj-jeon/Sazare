namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region XDocumentSamples-02
  /// <summary>
  /// XDocument�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  public class XDocumentSamples02 : IExecutable
  {
    public void Execute()
    {
      var xmlStrings =
            @"<Persons>
              <Person>
                <Name>gsf_zero1</Name>
                <Age>30</Age>
              </Person>
            </Persons>";

      //
      // Parse���\�b�h�𗘗p���鎖�ŁA�����񂩂璼��XDocument��
      // �\�z���邱�Ƃ��o����B
      //
      var doc = XDocument.Parse(xmlStrings, LoadOptions.None);

      //
      // �m�[�h��u��.
      //
      var name = (from element in doc.Descendants("Name") select element).First();

      name.ReplaceWith(new XElement("���O", name.Value));
      Console.WriteLine(doc);
    }
  }
  #endregion
}
