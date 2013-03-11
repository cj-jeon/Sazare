namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-79
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �i�r�Q�[�V����(ElementsAfterSelf, ElementsBeforeSelf)�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples79 : IExecutable
  {
    public void Execute()
    {
      //
      // ElementsAfterSelf(), ElementsAfterSelf(XName)
      //   ���݂̗v�f�̌��ɂ���Z��v�f���擾����.
      //   �������g�͊܂܂Ȃ�.
      //
      //   ���������ł̃��\�b�h�̕��́A�\�z�ʂ�̓��������邪
      //   XName���󂯎��I�[�o�[���[�h�̕��́AAncestorsAndSelf(XName)��
      //   �����ςȋ���������B (MSDN�ɏ���Ă���T���v���ł��A�Z��v�f���\������Ă��Ȃ�)
      //   ��,,,�B
      //
      var root = BuildSampleXml();
      var startingPoint = root.Descendants("Book").First();

      // �ŏ���Book�v�f�̌��ɂ���Z��v�f���\�������.
      foreach (var elem in startingPoint.ElementsAfterSelf())
      {
        Console.WriteLine(elem);
      }

      Console.WriteLine("=====================================");

      root = BuildSampleXml();
      startingPoint = root.Descendants("Title").Last();

      // Title�̌��ɂ���Z��v�f���\�������
      foreach (var elem in startingPoint.ElementsAfterSelf())
      {
        Console.WriteLine(elem);
      }


      Console.WriteLine("=====================================");

      root = BuildSampleXml();
      startingPoint = root.Descendants("Title").Last();

      // ���̂��A�����Ɏw�肵��Genre�����\������Ȃ��H�H
      // AncestorsAndSelf(XName)�Ƃ��Ɠ�������.
      foreach (var elem in startingPoint.ElementsAfterSelf("Genre"))
      {
        Console.WriteLine(elem);
      }

      Console.WriteLine("=====================================");

      //
      // ElementsBeforeSelf(), ElementsBeforeSelf(XName)
      //   ���݂̗v�f�̑O�ɂ���Z��v�f���擾����.
      //   �������g�͊܂܂Ȃ�.
      //
      //   ���������ł̃��\�b�h�̕��́A�\�z�ʂ�̓��������邪
      //   XName���󂯎��I�[�o�[���[�h�̕��́AAncestorsAndSelf(XName)��
      //   �����ςȋ���������B (MSDN�ɏ���Ă���T���v���ł��A�Z��v�f���\������Ă��Ȃ�)
      //   ��,,,�B
      //
      root = BuildSampleXml();
      startingPoint = root.Descendants("PublishDate").Last();

      foreach (var elem in startingPoint.ElementsBeforeSelf())
      {
        Console.WriteLine(elem);
      }

      Console.WriteLine("=====================================");

      root = BuildSampleXml();
      startingPoint = root.Descendants("Description").Last();

      // ���̂��A�����Ɏw�肵��PublishDate�����\������Ȃ��H�H
      // AncestorsAndSelf(XName)�Ƃ��Ɠ�������.
      foreach (var elem in startingPoint.ElementsBeforeSelf("PublishDate"))
      {
        Console.WriteLine(elem);
      }

      Console.WriteLine("=====================================");
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
