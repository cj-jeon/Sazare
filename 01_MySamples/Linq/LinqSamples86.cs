namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-86
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// LINQ to XML�̃A�m�e�[�V�����@�\�ɂ��ẴT���v���ł��B
  /// </remarks>
  public class LinqSamples86 : IExecutable
  {
    public void Execute()
    {
      // LINQ to XML�ł́A���ꂼ��̃f�[�^�ɑ΂���
      // �A�m�e�[�V������t�^���邱�Ƃ��o����B
      //
      //  XObject.AddAnnotation
      //  XObject.Annotation(Type)
      //         .Annotation<T>()
      //         .Annotations(Type)
      //         .Annotations<T>()
      //  XObject.RemoveAnnotations(Type)
      //         .RemoveAnnotations<T>()
      //
      // �A�m�e�[�V�����́ALINQ to XML�ŏ������Ă���Ԃ̂ݗL���ȃf�[�^.
      // �i�������ꂸ�AToString�ɂ��\������Ȃ�
      // Tag�v���p�e�B�̂悤�Ȏg�������o����.
      //
      // �R���N�V����������Annotations���\�b�h�̃R�[�h�͊���
      //
      var root = BuildSampleXml();
      var elem = root.Descendants("Price").Last();

      //
      // �A�m�e�[�V������ǉ�.
      //
      elem.AddAnnotation(new Tag("Tag Value"));

      //
      // �A�m�e�[�V�������t���Ă���v�f��񋓂��Ă݂�.
      //
      foreach (var item in QueryHasAnnotation(root))
      {
        Console.WriteLine(item);
        Console.WriteLine(item.Annotation<Tag>().Value);
      }

      //
      // �A�m�e�[�V�������폜
      //
      elem.RemoveAnnotations<Tag>();

      Console.WriteLine(QueryHasAnnotation(root).Count());

      //
      // �A�m�e�[�V������t�^������Ԃ�ToString���Ă݂�
      //
      elem.AddAnnotation(new Tag("Tag Value"));
      Console.WriteLine(root);
    }

    IEnumerable<XElement> QueryHasAnnotation(XElement root)
    {
      var query = from el in root.Descendants()
                  let an = el.Annotation<Tag>()
                  where an != null
                  select el;

      return query;
    }

    XElement BuildSampleXml()
    {
      //
      // �T���v��XML�t�@�C��
      //  see: http://msdn.microsoft.com/ja-jp/library/vstudio/ms256479(v=vs.90).aspx
      //
      return XElement.Load(@"xml/Books.xml");
    }

    class Tag
    {
      public Tag(string value)
      {
        Value = value;
      }

      public string Value { get; private set; }
    }
  }
  #endregion
}
