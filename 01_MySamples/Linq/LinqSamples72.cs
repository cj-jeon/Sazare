namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-72
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// ��v�f�n�v���p�e�B�ƃ��\�b�h (IsEmpty, EmptySequence) �̃T���v���ł�.
  /// </remarks>
  public class LinqSamples72 : IExecutable
  {
    public void Execute()
    {
      //
      // EmptySequence
      //   ���IEnumerable<XElement>��Ԃ��ÓI���\�b�h.
      //
      var empty = XElement.EmptySequence;

      Console.WriteLine("Count={0}", empty.Count());

      //
      // IsEmpty
      //   ���݂̗v�f����v�f���ۂ��𔻒肷��.
      //   ��v�f�̏����́AMSDN�ɋL�ڂ�����ȉ��̒ʂ�ƂȂ�.
      //     �u�J�n�^�O�݂̂������A�I��������̗v�f�Ƃ��ĕ\�����v�f�������A��̗v�f�ƌ��Ȃ���܂��B�v
      //     (http://msdn.microsoft.com/ja-jp/library/system.xml.linq.xelement.isempty.aspx)
      //
      var root = BuildSampleXmlNoNode();
      Console.WriteLine("IsEmpty={0}", root.IsEmpty);

      root = BuildSampleXml();
      Console.WriteLine("IsEmpty={0}", root.IsEmpty);
    }

    XElement BuildSampleXmlNoNode()
    {
      return new XElement("Root");
    }

    XElement BuildSampleXml()
    {
      var root = new XElement("Root",
        new XElement("Child", "value1"),
        new XElement("Child", "value2"),
        new XElement("Child", "value3"),
        new XElement("Child", "value4")
      );

      return root;
    }
  }
  #endregion
}
