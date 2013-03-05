namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Xml;
  using System.Xml.Linq;

  #region LinqSamples-54
  /// <summary>
  /// LINQ to XML�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// XElement.Load�𗘗p�����X�g���[���ǂݍ��݂̃T���v���ł�.
  /// </remarks>
  public class LinqSamples54 : IExecutable
  {
    public void Execute()
    {
      //
      // XElement.Load�ɂ́A�����񂩂烍�[�h���鑼��
      // �X�g���[�~���O���w�肵�ē��e�����[�h���邱�Ƃ��ł���B
      //
      // ���\�b�h�͕����̃I�[�o�[���[�h�������Ă���A�ȉ��̏����ƂȂ�.
      //   Load(Stream)
      //   Load(TextReader)
      //   Load(XmlReader)
      //   Load(Stream, LoadOptions)
      //   Load(TextReader, LoadOptions)
      //   Load(XmlReader, LoadOptions)
      // ��ʂ���ƁA�X�g���[���݂̂��w�肷����̂ƃI�v�V�������w��ł�����̂ɕ������.
      //

      //
      // Load(Stream)�̃T���v��.
      //   -- File.OpenRead�ŕԂ�̂�FileStream
      //      FileStream��Stream�̃T�u�N���X.
      //
      XElement element = null;
      using (var stream = File.OpenRead("xml/Books.xml"))
      {
        element = XElement.Load(stream);
      }

      Console.WriteLine(element);
      Console.WriteLine("=============================================");

      //
      // Load(TextReader)�̃T���v��
      //   -- StreamReader��TextReader�̃T�u�N���X.
      //
      element = null;
      using (var reader = new StreamReader("xml/Data.xml"))
      {
        element = XElement.Load(reader);
      }

      Console.WriteLine(element);
      Console.WriteLine("=============================================");

      //
      // Load(XmlReader)�̃T���v��.
      //
      element = null;
      using (var reader = XmlReader.Create("xml/PurchaseOrder.xml", new XmlReaderSettings { IgnoreWhitespace = true, IgnoreComments = true }))
      {
        element = XElement.Load(reader);
      }

      Console.WriteLine(element);
    }
  }
  #endregion
}
