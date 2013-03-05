namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-78
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �i�r�Q�[�V����(DescendantNodes, DescendantNodesAndSelf)�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples78 : IExecutable
  {
    public void Execute()
    {
      //
      // DescendantNodes
      //   �q����XNode�Ŏ擾����.
      //   �����̓m�[�h�ł͂Ȃ����߁A�܂܂�Ȃ�.
      //
      //   �擾�ł���f�[�^��XElement�ł͂Ȃ��AXNode�ł��邱�Ƃɒ���.
      //
      var root = BuildSampleXml();
      var startingPoint = root.Descendants("Book").First();

      // AndSelf�����Ȃ̂ŁABook���g�͊܂܂�Ȃ�.
      foreach (var node in startingPoint.DescendantNodes())
      {
        Console.WriteLine(node);
      }

      Console.WriteLine("=====================================");

      //
      // DescendantNodesAndSelf
      //   ��{�I�ȓ����DescendantNodes�Ɠ����B
      //   AndSelf�Ȃ̂ŁA�������g�����Ă���.
      //
      //   �擾�ł���f�[�^��XElement�ł͂Ȃ��AXNode�ł��邱�Ƃɒ���.
      //
      root = BuildSampleXml();
      startingPoint = root.Descendants("Book").First();

      // AndSelf����Ȃ̂ŁABook���g���܂܂��
      foreach (var node in startingPoint.DescendantNodesAndSelf())
      {
        Console.WriteLine(node);
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
