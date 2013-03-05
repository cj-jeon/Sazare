namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-61
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �v�f�X�V�n���\�b�h�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples61 : IExecutable
  {
    public void Execute()
    {
      //
      // Value { get; set; } �v���p�e�B
      //   �Ώۂ̗v�f�̒l���擾�E�ݒ肷��.
      //   �^��string�ƂȂ��Ă���̂ŁA������ɕϊ����Đݒ肷��K�v������B
      //   null���w�肷��Ɨ�O����������B(ArgumentNullException)
      //
      var root = BuildSampleXml();
      var elem = root.Descendants("Value").First();

      Console.WriteLine("[before] {0}", elem.Value);
      elem.Value = "updated";
      Console.WriteLine("[after] {0}", elem.Value);
      Console.WriteLine(root);

      try
      {
        elem.Value = null;
      }
      catch (ArgumentNullException argNullEx)
      {
        Console.WriteLine(argNullEx.Message);
      }

      // Value�v���p�e�B��string���󂯕t����̂ŁAbool�Ȃǂ̏ꍇ��
      // �����I�ɕ�����ɂ��Đݒ肷��K�v������.
      elem.Value = bool.TrueString.ToLower();
      Console.WriteLine(root);

      Console.WriteLine("=====================================");

      //
      // SetValue(object)
      //   �v�f�̒l��ݒ肷��B
      //   �^��object�ƂȂ��Ă���̂ŁA������ȊO�̏ꍇ�ł����̂܂ܐݒ�\�B
      //   �����ŕϊ������.
      //   null���w�肷��Ɨ�O����������B(ArgumentNullException)
      //
      root = BuildSampleXml();
      elem = root.Descendants("Value").First();

      Console.WriteLine("[before] {0}", elem.Value);
      elem.SetValue("updated");
      Console.WriteLine("[after] {0}", elem.Value);
      Console.WriteLine(root);

      try
      {
        elem.SetValue(null);
      }
      catch (ArgumentNullException argNullEx)
      {
        Console.WriteLine(argNullEx.Message);
      }

      // SetValue���\�b�h�́Aobject�^���󂯕t����̂�
      // bool�^�Ȃǂ̏ꍇ�ł����̂܂ܐݒ�ł���B�����ŕϊ������.
      elem.SetValue(true);
      Console.WriteLine(root);

      Console.WriteLine("=====================================");

      //
      // SetElementValue(XName, object)
      //   �q�v�f�̒l��ݒ肷��B
      //     �v�f�����݂��Ȃ��ꍇ�F �V�K�ǉ�
      //     �v�f�����݂���ꍇ�F �X�V
      //     null��ݒ肵���ꍇ�F �폜
      //   �ƂȂ�B�������g�̒l��ݒ肷��킯�ł͖������Ƃɒ��ӁB
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").First();

      // �v�f�����݂���ꍇ: �X�V
      elem.SetElementValue("Value", "updated");
      Console.WriteLine(root);

      // null���w�肵���ꍇ�F �폜
      root = BuildSampleXml();
      elem = root.Elements("Child").First();
      elem.SetElementValue("Value", null);
      Console.WriteLine(root);

      // �v�f�����݂��Ȃ��ꍇ: �V�K�ǉ�
      root = BuildSampleXml();
      elem = root.Elements("Child").First();
      elem.SetElementValue("Value2", "inserted");
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
