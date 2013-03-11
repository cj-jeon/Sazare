namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-57
  /// <summary>
  /// LINQ to XML�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// LINQ to XML�ɂăN�G�����g�p���đΏۂ̗v�f���擾����T���v���ł��B
  /// </remarks>
  public class LinqSamples57 : IExecutable
  {
    public void Execute()
    {
      //
      // LINQ to XML�ł́A�N�G���𗘗p���ē���̗v�f�⑮���Ȃǂ��擾����B
      // �擾���@�͂��낢�날�邪�A�����Elements���\�b�h��Element���\�b�h��p���ėv�f�̎擾���s���Ă���.
      //
      //
      // Books.xml�́A���[�g�v�f��Cataglog�œ����ɕ�����Book�v�f�������Ă���.
      // �eBook�v�f�́A���Author�v�f�������Ă���.
      //
      // Elements���\�b�h�́A�����Ɏw�肳�ꂽ�v�f���ɍ��v����v�f�̏W����Ԃ�.
      // Element���\�b�h�́A�����Ɏw�肳�ꂽ�v�f���ɍ��v����ŏ��̗v�f��Ԃ�.
      //
      var root = XElement.Load(@"xml/Books.xml");
      var query = from book in root.Elements("Book")
                  select book.Element("Author");

      foreach (var author in query)
      {
        Console.WriteLine(author);
      }
    }
  }
  #endregion
}
