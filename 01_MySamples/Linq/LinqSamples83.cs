namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-83
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// XElement��XAttribute�̒l�擾�ɂ��Ă�Tip�ł��B
  /// </remarks>
  public class LinqSamples83 : IExecutable
  {
    public void Execute()
    {
      //
      // XElement��XAttribute�̒l�̓L���X�g������擾�ł���
      //   http://msdn.microsoft.com/ja-jp/library/vstudio/bb387049.aspx
      //
      // �Ή����Ă���̂́A�ȉ��̌^�̏ꍇ.
      // string
      // bool,bool?
      // int,int?
      // uint,uint?
      // long,long?
      // ulong,ulong?
      // float,float?
      // double,double?
      // decimal,decimal?
      // DateTime,DateTime?
      // TimeSpan,TimeSpan?
      // GUID,GUID?
      //
      var root = BuildSampleXml();

      var title = (string)root.Descendants("Title").FirstOrDefault() ?? "Nothing";
      var attr = (string)root.Elements("Book").First().Attribute("id") ?? "Nothing";
      var noElem = (string)root.Descendants("NoElem").FirstOrDefault() ?? "Nothing";

      Console.WriteLine(title);
      Console.WriteLine(attr);
      Console.WriteLine(noElem);
    }

    XElement BuildSampleXml()
    {
      //
      // �T���v��XML�t�@�C��
      //  see: http://msdn.microsoft.com/ja-jp/library/vstudio/ms256479(v=vs.90).aspx
      //
      return XElement.Load(@"xml/Books.xml");
    }
  }
  #endregion
}
