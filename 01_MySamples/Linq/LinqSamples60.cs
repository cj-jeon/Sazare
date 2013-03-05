namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-60
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �v�f�ǉ��n���\�b�h�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples60 : IExecutable
  {
    public void Execute()
    {
      //
      // Add(object)
      //   ���O�̒ʂ�A���݂̗v�f�Ɏw�肳�ꂽ�v�f��ǉ�����.
      //   �ǉ������ʒu�́A���̗v�f�̖����ƂȂ�
      //
      var root = BuildSampleXml();
      var newElem1 = new XElement("NewElement", "hehe");
      root.Add(newElem1);

      Console.WriteLine(root);
      Console.WriteLine("=====================================");

      //
      // AddAfterSelf(object)
      //   ���݂̗v�f�̌��ɁA�w�肳�ꂽ�v�f��ǉ�����.
      //   �ǉ������ʒu�́A�������g�̒��ł͂Ȃ��O�ƂȂ鎖�ɒ���.
      //   ���A���[�g�v�f�ɑ΂��Ė{���\�b�h���Ăяo���Ɛe�����݂��Ȃ��̂�
      //   InvalidOperationException����������.
      //   (���������O��XmlException�ł͖������Ƃɒ���)
      //
      root = BuildSampleXml();
      var newElem4 = new XElement("AfterElement", "AfterSelf");

      try
      {
        // ���[�g�v�f�ɑ΂��āA���g�̌��ɗv�f��ǉ����悤�Ƃ���̂�
        // �G���[�ƂȂ�BXmlException�ł͖������Ƃɒ���.
        root.AddAfterSelf(newElem4);
        Console.WriteLine(root);
      }
      catch (InvalidOperationException invalidEx)
      {
        Console.WriteLine("[ERROR] {0}", invalidEx.Message);
      }
      finally
      {
        Console.WriteLine("=====================================");
      }

      root.Elements().First().AddAfterSelf(newElem4);

      Console.WriteLine(root);
      Console.WriteLine("=====================================");

      //
      // AddBeforeSelf(object)
      //   ���݂̗v�f�̑O�ɁA�w�肳�ꂽ�v�f��ǉ�����.
      //   �ǉ������ʒu�́A�������g�̒��ł͂Ȃ��O�ƂȂ鎖�ɒ���.
      //   ���A���[�g�v�f�ɑ΂��Ė{���\�b�h���Ăяo���Ɛe�����݂��Ȃ��̂�
      //   InvalidOperationException����������.
      //   (���������O��XmlException�ł͖������Ƃɒ���)
      //
      root = BuildSampleXml();
      var newElem5 = new XElement("BeforeElement", "BeforeSelf");

      try
      {
        // ���[�g�v�f�ɑ΂��āA���g�̑O�ɗv�f��ǉ����悤�Ƃ���̂�
        // �G���[�ƂȂ�BXmlException�ł͖������Ƃɒ���.
        root.AddBeforeSelf(newElem5);
        Console.WriteLine(root);
      }
      catch (InvalidOperationException invalidEx)
      {
        Console.WriteLine("[ERROR] {0}", invalidEx.Message);
      }
      finally
      {
        Console.WriteLine("=====================================");
      }

      root.Elements().First().AddBeforeSelf(newElem5);

      Console.WriteLine(root);
      Console.WriteLine("=====================================");

      //
      // AddFirst(object)
      //   ���ݗv�f�̐擪�q�v�f�Ƃ��āA�w�肳�ꂽ�v�f��ǉ�����.
      //   �ǉ������ʒu�́A�������g�̒��ƂȂ�B�i�擪�v�f�j
      //
      root = BuildSampleXml();
      var newElem6 = new XElement("FirstElement", "First");

      root.AddFirst(newElem6);

      Console.WriteLine(root);
      Console.WriteLine("=====================================");

      root = BuildSampleXml();
      root.Elements().First().AddFirst(newElem6);

      Console.WriteLine(root);
      Console.WriteLine("=====================================");
    }

    XElement BuildSampleXml()
    {
      return new XElement("Root",
                   new XElement("Child",
                     new XAttribute("Id", 100),
                     new XElement("Value", "hoge")
                   )
                 );
    }
  }
  #endregion
}
