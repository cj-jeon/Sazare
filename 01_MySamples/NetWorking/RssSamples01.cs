namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.ServiceModel.Syndication;
  using System.Text;
  using System.Xml;

  #region RssSamples-01
  public class RssSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // RSS���쐬�ɂ͈ȉ��̎菇�ō\�z����.
      //
      // (1) SyndicationItem���쐬���A���X�g�ɒǉ�
      // (2) SyndicationFeed���쐬���A(1)�ō쐬�������X�g��ǉ�
      // (3) XmlWriter���\�z���A�o��.
      //
      List<SyndicationItem> items = new List<SyndicationItem>();

      for (int i = 0; i < 10; i++)
      {
        var newItem = new SyndicationItem();

        newItem.Title = new TextSyndicationContent(string.Format("Test Title-{0}", i));
        newItem.Links.Add(new SyndicationLink(new Uri(@"http://www.google.co.jp/")));

        items.Add(newItem);
      }

      SyndicationFeed feed = new SyndicationFeed("Test Feed", "This is a test feed", new Uri(@"http://www.yahoo.co.jp/"), items);
      feed.LastUpdatedTime = DateTime.Now;

      StringBuilder sb = new StringBuilder();
      XmlWriterSettings settings = new XmlWriterSettings();
      settings.Indent = true;

      using (XmlWriter writer = XmlWriter.Create(sb, settings))
      {
        //feed.SaveAsAtom10(writer);
        feed.SaveAsRss20(writer);
        writer.Close();
      }

      Console.WriteLine(sb.ToString());
    }
  }
  #endregion
}
