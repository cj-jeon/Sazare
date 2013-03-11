namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-76
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �i�r�Q�[�V����(Descendants, Ancestors���\�b�h)�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples76 : IExecutable
  {
    public void Execute()
    {
      //
      // Descendants(XName)
      //   ���݂̗v�f���N�_�Ƃ��Ďq���v�f���擾����.
      //   �q���͈̔͂́A���������łȂ��A�l�X�g�����q���K�w�̃f�[�^��
      //   �擾�ł���. Linq To XML�ł悭���p���郁�\�b�h�̈��.
      //
      var root = BuildSampleXml();
      var elem = root.Descendants();

      Console.WriteLine("Count={0}", elem.Count());
      Console.WriteLine("=====================================");

      // "Customer"�Ƃ������O�̎q���v�f���擾
      elem = root.Descendants("Customer");
      Console.WriteLine("Count={0}", elem.Count());
      Console.WriteLine("First item:");
      Console.WriteLine(elem.First());
      Console.WriteLine("=====================================");

      // �����t���ōi�荞��
      elem = root.Descendants("Customer").Where(x => x.Attribute("CustomerID").Value == "HUNGC");
      Console.WriteLine("Count={0}", elem.Count());
      Console.WriteLine("First item:");
      Console.WriteLine(elem.First());
      Console.WriteLine("=====================================");

      // �N�G�����ŗ��p
      elem = from node in root.Descendants("Customer")
             let attr = node.Attribute("CustomerID").Value
             where attr.StartsWith("L")
             from child in node.Descendants("Region")
             where child.Value == "CA"
             select node;

      Console.WriteLine("Count={0}", elem.Count());
      Console.WriteLine("First item:");
      Console.WriteLine(elem.First());
      Console.WriteLine("=====================================");

      // ����2�K�w���̗v�f�����w��
      elem = from node in root.Descendants("Region")
             where node.Value == "CA"
             select node;

      Console.WriteLine("Count={0}", elem.Count());
      Console.WriteLine("First item:");
      Console.WriteLine(elem.First());
      Console.WriteLine("=====================================");

      //
      // Ancestors(XName)      
      //   ���݂̗v�f�̐�c�v�f���擾����.
      //   �Z��v�f�͎擾�ł��Ȃ��i������0���ƂȂ�)
      //   �����܂Ŏ����̐�c�ƂȂ�v�f���w�肷��.
      //
      root = BuildSampleXml();
      var startingPoint = root.Descendants("Region").Where(x => x.Value == "CA").First();

      var ancestors = startingPoint.Ancestors();

      Console.WriteLine("Count={0}", ancestors.Count());
      Console.WriteLine("First item:");
      Console.WriteLine(ancestors.First());
      Console.WriteLine("=====================================");

      // ContactName�́A���݂̗v�f(Region)�̐�c(FullAddress)�ł͂Ȃ����ߎw�肵�Ă��擾�ł��Ȃ�
      ancestors = startingPoint.Ancestors("ContactName");

      Console.WriteLine("Count={0}", ancestors.Count());
      if (ancestors.Any())
      {
        Console.WriteLine("First item:");
        Console.WriteLine(ancestors.First());
      }

      Console.WriteLine("=====================================");

      // FullAddress�v�f�̌Z��v�f�ƂȂ�ContactName�͎擾�ł��Ȃ�
      startingPoint = root.Descendants("FullAddress").First();
      ancestors = startingPoint.Ancestors("ContactName");

      Console.WriteLine("Count={0}", ancestors.Count());
      if (ancestors.Any())
      {
        Console.WriteLine("First item:");
        Console.WriteLine(ancestors.First());
      }

      Console.WriteLine("=====================================");

      // FullAddress�v�f�̐�c�ł���Customer�v�f�͎擾�ł���.
      startingPoint = root.Descendants("FullAddress").First();
      ancestors = startingPoint.Ancestors("Customer");

      Console.WriteLine("Count={0}", ancestors.Count());
      if (ancestors.Any())
      {
        Console.WriteLine("First item:");
        Console.WriteLine(ancestors.First());
      }

      Console.WriteLine("=====================================");
    }

    XElement BuildSampleXml()
    {
      //
      // �T���v��XML�t�@�C��
      //  see: http://msdn.microsoft.com/ja-jp/library/vstudio/bb387025.aspx
      //
      return XElement.Load(@"xml/CustomersOrders.xml");
    }
  }
  #endregion
}
