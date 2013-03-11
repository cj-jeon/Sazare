namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml;
  using System.Xml.Linq;

  #region LinqSamples-55
  /// <summary>
  /// LINQ to XML�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// LINQ to XML�ɂăG���[������XmlException���������邱�Ƃ��m�F����T���v���ł��B
  /// </remarks>
  public class LinqSamples55 : IExecutable
  {
    public void Execute()
    {
      try
      {
        //
        // LINQ to XML�͓�����XmlReader�𗘗p���Ă���.
        // �Ȃ̂ŁA�G���[�����������ꍇ�AXmlReader�̏ꍇ��
        // ���l��XmlException����������.
        //
        XElement.Parse(GetXmlStrings());
      }
      catch (XmlException xmlEx)
      {
        Console.WriteLine(xmlEx.ToString());
      }
    }

    string GetXmlStrings()
    {
      //
      // �킴�Ɖ�̓G���[�ɂȂ�XML��������쐬.
      //
      return @"<data>
                 <id>1</id>
                 <id>2</id>
               </dat>";
    }
  }
  #endregion
}
