namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-84
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// Changing, Changed�C�x���g�ɂ��ẴT���v���ł��B
  /// </remarks>
  public class LinqSamples84 : IExecutable
  {
    public void Execute()
    {
      //
      // Changing, Changed�C�x���g�́A�ǂ����XObject�ɑ�����C�x���g�ł���.
      //

      //
      // Changing�C�x���g
      //   ���̃C�x���g�́AXML�c���[�̕ύX�ɂ���Ă̂ݔ�������B
      //   XML�c���[�̍쐬�ł͔������Ȃ����Ƃɒ��ӁB
      // �C�x���g�����Ƃ��āAXObjectChangeEventArgs���󂯎��.
      // XObjectChangeEventArgs�́AObjectChange�Ƃ����v���p�e�B������.      
      //
      var root = BuildSampleXml();

      root.Changing += OnNodeChanging;

      var book = root.Elements("Book").First();
      var title = book.Elements("Title").First();

      // �����l��ύX
      //   Changing�C�x���g�Ȃ̂ŁA�C�x���g�n���h�����ɂČ�����sender�̒l��*�X�V�O*�̒l�ƂȂ�B (Change)
      book.Attribute("id").Value = "updated";
      // �v�f�̒l��ύX
      //   Title�v�f�͓�����XText�������Ă���̂ŁA�܂����ꂪ�폜����� (Remove)
      //   ���̌�A�X�V��̒l������XText���ݒ肳���. (Add)
      title.Value = "updated";
      title.Remove();
      // �v�f��ǉ�
      //   �v�f���ǉ������ (Add)
      book.Add(new XElement("newelem", "hogehoge"));

      Console.WriteLine("=====================================");

      //
      // Changed
      //   ���̃C�x���g�́AXML�c���[�̕ύX�ɂ���Ă̂ݔ�������B
      //   XML�c���[�̍쐬�ł͔������Ȃ����Ƃɒ��ӁB
      // �C�x���g�����Ƃ��āAXObjectChangeEventArgs���󂯎��.
      // XObjectChangeEventArgs�́AObjectChange�Ƃ����v���p�e�B������.
      //
      root = BuildSampleXml();

      root.Changed += OnNodeChanged;

      book = root.Elements("Book").First();
      title = book.Elements("Title").First();

      // �����l��ύX
      //   Changed�C�x���g�Ȃ̂ŁA�C�x���g�n���h�����ɂČ�����sender�̒l��*�X�V��*�̒l�ƂȂ�B (Change)
      book.Attribute("id").Value = "updated";
      title.Value = "updated";
      title.Remove();
      book.Add(new XElement("newelem", "hogehoge"));

      Console.WriteLine("=====================================");
    }

    // Changing�C�x���g�n���h��
    void OnNodeChanging(object sender, XObjectChangeEventArgs e)
    {
      Console.WriteLine("Changing: sender--{0}:{1}, ObjectChange--{2}", sender.GetType().Name, sender, e.ObjectChange);
    }

    // Changed�C�x���g�n���h��
    void OnNodeChanged(object sender, XObjectChangeEventArgs e)
    {
      Console.WriteLine("Changed: sender--{0}:{1}, ObjectChange--{2}", sender.GetType().Name, sender, e.ObjectChange);
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
