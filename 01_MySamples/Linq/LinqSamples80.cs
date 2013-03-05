namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-80
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �i�r�Q�[�V����(NodesAfterSelf, NodesBeforeSelf)�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples80 : IExecutable
  {
    public void Execute()
    {
      //
      // NodesAfterSelf
      //   ���݂̗v�f�̌��ɂ���Z��m�[�h���擾
      //   ElementsAfterSelf�Ƃ̈Ⴂ�́AXElement�ł��邩XNode�ł��邩
      //
      var root = BuildSampleXml();
      var startingPoint = root.Descendants("Book").First();

      foreach (var node in startingPoint.NodesAfterSelf())
      {
        Console.WriteLine(node);
      }

      Console.WriteLine("=====================================");

      root = BuildSampleXml();
      startingPoint = root.Descendants("Title").Last();

      foreach (var node in startingPoint.NodesAfterSelf())
      {
        Console.WriteLine(node);
      }

      //
      // NodesBeforeSelf
      //   ���݂̗v�f�̑O�ɂ���Z��m�[�h���擾
      //   ElementsBeforeSelf�Ƃ̈Ⴂ�́AXElement�ł��邩XNode�ł��邩
      //
      root = BuildSampleXml();
      startingPoint = root.Descendants("PublishDate").Last();

      foreach (var node in startingPoint.NodesBeforeSelf())
      {
        Console.WriteLine(node);
      }
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
