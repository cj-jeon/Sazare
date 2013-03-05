namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-77
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �i�r�Q�[�V����(DescendantsAndSelf, AncestorsAndSelf���\�b�h)�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples77 : IExecutable
  {
    public void Execute()
    {
      //
      // DescendantsAndSelf
      //   ���g�Ƃ��̎q�v�f���擾���邽�߂̃��\�b�h.
      //   �����������ł�XName���w�肷��ł����݂���B
      //   ���������ł́A�Ӑ}�����ʂ�̌��ʂ�Ԃ��Ă���邪
      //   XName���w�肷��ł̃��\�b�h�́A�q�v�f���܂߂Ă���Ȃ��E�E�E�B
      //   (�w��̎d�����Ԉ���Ă���̂��H �g�������Ԉ���Ă���̂��H)
      //
      //   ���炭�A�w��̎d�����Ԉ���Ă���̂��Ǝv�����A���i���p���Ȃ����\�b�h�Ȃ̂ŁA����ň�U�����Ƃ���.
      //
      var root = BuildSampleXml();
      var startingPoint = root.Descendants("Customer").First();
      var descendantsAndSelf = startingPoint.DescendantsAndSelf();

      //
      // AndSelf�t���̃��\�b�h�𗘗p���Ă���̂ŁACustomer���g�����ʂɊ܂܂��.
      //
      foreach (var elem in descendantsAndSelf)
      {
        Console.WriteLine(elem);
      }

      Console.WriteLine("=====================================");

      //
      // AndSelf��t���Ă��Ȃ��̂ŁACustomer���g�͊܂܂�Ȃ�.
      //
      foreach (var elem in startingPoint.Descendants())
      {
        Console.WriteLine(elem);
      }

      Console.WriteLine("=====================================");

      //
      // XName�t���̃I�[�o�[���[�h���Ăяo���ƁA�\�z�ƈႤ���ʂƂȂ�
      // Customer�v�f���܂܂�Ȃ�. (??)
      //
      // MSDN�̐����ɂ́A�u���̗v�f�Ƃ��̗v�f�̂��ׂĂ̎q�v�f�v�ƋL�ڂ����邪�E�E�E�B
      // (MSDN�̃��\�b�h�y�[�W�ɂ���T���v���v���O�����̌��ʂ��A�ȉ��̌��ʂƓ����ɂȂ��Ă���)
      //
      //   ���炭�A�w��̎d�����Ԉ���Ă���̂��Ǝv�����A���i���p���Ȃ����\�b�h�Ȃ̂ŁA����ň�U�����Ƃ���.
      //
      root = BuildSampleXml();
      startingPoint = root.Descendants("Customer").First();
      descendantsAndSelf = startingPoint.DescendantsAndSelf("FullAddress");

      foreach (var elem in descendantsAndSelf)
      {
        Console.WriteLine(elem);
      }

      Console.WriteLine("=====================================");

      //
      // AncestorsAndSelf
      //   ���g�Ƃ��̐�c���擾���邽�߂̃��\�b�h.
      //   �����������ł�XName���w�肷��ł����݂���B
      //   ���������ł́A�Ӑ}�����ʂ�̌��ʂ�Ԃ��Ă���邪
      //   XName���w�肷��ł̃��\�b�h�́A��c���܂߂Ă���Ȃ��E�E�E�B
      //   (�w��̎d�����Ԉ���Ă���̂��H �g�������Ԉ���Ă���̂��H)
      //
      root = BuildSampleXml2();
      startingPoint = root.Descendants("Price").First();

      var ancestorsAndSelf = startingPoint.AncestorsAndSelf();

      //
      // AndSelf�t���̃��\�b�h�𗘗p���Ă���̂ŁAPrice���g�����ʂɊ܂܂��.
      //
      foreach (var elem in ancestorsAndSelf)
      {
        Console.WriteLine(elem);
      }

      Console.WriteLine("=====================================");

      //
      // Price���g�͊܂܂�Ȃ�
      //
      foreach (var elem in startingPoint.Ancestors())
      {
        Console.WriteLine(elem);
      }

      Console.WriteLine("=====================================");

      //
      // XName�t���̃I�[�o�[���[�h���Ăяo���ƁA�\�z�ƈႤ���ʂƂȂ�
      // Price�v�f���܂܂�Ȃ�. (??)
      //
      // MSDN�̐����ɂ́A�u���̗v�f�Ƃ��̗v�f�̐�c�v�ƋL�ڂ����邪�E�E�E�B
      // (MSDN�̃��\�b�h�y�[�W�ɂ���T���v���v���O�����̌��ʂ��A�ȉ��̌��ʂƓ����ɂȂ��Ă���)
      //
      root = BuildSampleXml2();
      startingPoint = root.Descendants("Price").First();
      ancestorsAndSelf = startingPoint.AncestorsAndSelf("Book");

      foreach (var elem in ancestorsAndSelf)
      {
        Console.WriteLine(elem);
      }
    }

    XElement BuildSampleXml()
    {
      //
      // �T���v��XML�t�@�C��
      //  see: http://msdn.microsoft.com/ja-jp/library/vstudio/bb387025.aspx
      //
      return XElement.Load(@"xml/CustomersOrders.xml");
    }

    XElement BuildSampleXml2()
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
