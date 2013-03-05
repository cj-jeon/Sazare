namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Text;
  using System.Xml;
  using System.Xml.Linq;

  #region LinqSamples-56
  /// <summary>
  /// LINQ to XML�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// LINQ to XML�ɂ�XML�t�@�C����V�K�쐬����T���v���ł�.
  /// </remarks>
  public class LinqSamples56 : IExecutable
  {
    public void Execute()
    {
      //
      // LINQ to XML�ɂ�XML��V�K�쐬����ɂ�
      // �ȉ��̂ǂ��炩�̃C���X�^���X���쐬����K�v������.
      //   �EXDocument
      //   �EXElement
      // �ʏ�A�悭���p�����̂�XElement�̕��ƂȂ�.
      // �ۑ����s���ɂ́ASave���\�b�h�𗘗p����.
      // Save���\�b�h�ɂ́A�ȉ��̃I�[�o�[���[�h�����݂���. (XElement)
      //   Save(Stream)
      //   Save(String)
      //   Save(TextWriter)
      //   Save(XmlWriter)
      //   Save(Stream, SaveOptions)
      //   Save(String, SaveOptions)
      //   Save(TextWriter, SaveOptions)
      //
      var element = new XElement("RootNode",
                          from i in Enumerable.Range(1, 10)
                          select new XElement("Child", i)
                    );

      //
      // Save(Stream)
      //
      using (var stream = new MemoryStream())
      {
        element.Save(stream);

        stream.Position = 0;
        using (var reader = new StreamReader(stream))
        {
          Console.WriteLine(reader.ReadToEnd());
        }
      }

      Console.WriteLine("===================================");

      //
      // Save(String)
      //
      var tmpFile = Path.GetRandomFileName();
      element.Save(tmpFile);
      Console.WriteLine(File.ReadAllText(tmpFile));
      File.Delete(tmpFile);

      Console.WriteLine("===================================");

      //
      // Save(TextWriter)
      //
      using (var writer = new UTF8StringWriter())
      {
        element.Save(writer);
        Console.WriteLine(writer);
      }

      Console.WriteLine("===================================");

      //
      // Save(XmlWriter)
      //
      using (var backingStore = new UTF8StringWriter())
      {
        using (var xmlWriter = XmlWriter.Create(backingStore, new XmlWriterSettings { Indent = true }))
        {
          element.Save(xmlWriter);
        }

        Console.WriteLine(backingStore);
      }

      Console.WriteLine("===================================");

      //
      // SaveOptions�t���ŏ�������.
      //   DisableFormatting���w�肷��ƁA�o�͂����XML�ɏ������ݒ肳��Ȃ��Ȃ�.
      //
      using (var writer = new UTF8StringWriter())
      {
        element.Save(writer, SaveOptions.DisableFormatting);
        Console.WriteLine(writer);
      }
    }

    class UTF8StringWriter : StringWriter
    {
      public override Encoding Encoding { get { return Encoding.UTF8; } }
    }
  }
  #endregion
}
