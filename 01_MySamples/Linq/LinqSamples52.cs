namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-52
  /// <summary>
  /// LINQ to XML�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// XDocument�I�u�W�F�N�g���֐��^�\�z����T���v���ł��B
  /// </remarks>
  public class LinqSamples52 : IExecutable
  {
    public void Execute()
    {
      //
      // XDocument�͕����̃R���X�g���N�^�������Ă��邪
      // �ȉ��𗘗p����ƁA�֐��^�\�z���s����.
      // �֐��^�\�z�Ƃ́A�P��̃X�e�[�g�����g��XML�c���[���쐬���邽�߂̋@�\�ł���B
      // 
      // public XDocument(object[])
      // public XDocument(XDeclaration, object[])
      //
      // XDocument���N�_�Ƃ��Ċ֐��^�\�z���s���ꍇ
      // ���[�g�v�f�ƂȂ�XElement���쐬���A���̎q�v�f��
      // �l�X�ȗv�f��ݒ肷��.
      //
      // ��F
      // var doc = new XDocument
      //           (
      //             new XElement
      //             (
      //               "RootElement",
      //               new XElement("ChildElement", "ChildValue1"),
      //               new XElement("ChildElement", "ChildValue2"),
      //               new XElement("ChildElement", "ChildValue3")
      //             )
      //           );
      //
      // ��L��́A�ȉ���XML�c���[���\�z����.
      // <RootElement>
      //   <ChildElement>ChildValue1</ChildElement>
      //   <ChildElement>ChildValue2</ChildElement>
      //   <ChildElement>ChildValue3</ChildElement>
      // </RootElement>
      //
      var doc = MakeDocument();
      Console.WriteLine(doc);
    }

    XDocument MakeDocument()
    {
      var doc = new XDocument
                  (
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Persons", MakePersonElements())
                  );

      return doc;
    }

    IEnumerable<XElement> MakePersonElements()
    {
      var names = new[] { "foo", "bar", "baz" };
      var query = from name in names
                  select new XElement
                         (
                           "Person",
                           new XAttribute("name", name),
                           string.Format("VALUE-{0}", name)
                         );

      return query;
    }
  }
  #endregion
}
