namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-63
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �v�f�u���n���\�b�h�̃T���v���ł�.
  /// </remarks>
  public class LinqSamples63 : IExecutable
  {
    public void Execute()
    {
      //
      // ReplaceWith(object)
      //   ���݂̗v�f���w�肵���v�f�Œu��������.
      //   
      var root = BuildSampleXml();
      var elem = root.Descendants("Value").First();

      elem.ReplaceWith(new XElement("Value2", "replaced"));

      Console.WriteLine(root);
      Console.WriteLine("=====================================");

      //
      // ReplaceNodes(object)
      //   ���݂̗v�f�̎q�m�[�h���w�肳�ꂽ�v�f�Œu��������.
      //   ���̃��\�b�h�̓X�i�b�v�V���b�g�Z�}���e�B�N�X�Ƃ������@�Œu���������s���B
      //   �X�i�b�v�V���b�g�Z�}���e�B�N�X��p���Ă���ꍇ�A�u���O�Ɏ��O�ɒu����������e�̃R�s�[��
      //   �쐬���Ă���A�u���������s�����߁A���݂̗v�f�̏�Ԃ����ɒu���������������邱�Ƃ��ł���B
      //   (��F LINQ to XML�𗘗p���āA���݂̗v�f���e���N�G�����A���̌��ʂ�u����Ƃ��ė��p����B�j
      //
      //   ���A���̃��\�b�h�͑������폜���Ȃ�.
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").First();

      elem.Add
        (
          from x in Enumerable.Range(1, 5)
          select new XElement("Value", x)
        );

      elem.ReplaceNodes
        (
          from e in elem.Elements()
          where ToInt(e.Value) >= 3
          select e
        );

      Console.WriteLine(root);
      Console.WriteLine("=====================================");

      //
      // ReplaceAll(object)
      //   ���݂̗v�f�̎q�m�[�h�Ƒ������폜���A�w�肳�ꂽ�v�f�Œu��������.
      //   ���̃��\�b�h�́A�X�i�b�v�V���b�g�Z�}���e�B�N�X�Ƃ������@�Œu���������s���B
      //   �X�i�b�v�V���b�g�Z�}���e�B�N�X��p���Ă���ꍇ�A�u���O�Ɏ��O�ɒu����������e�̃R�s�[��
      //   �쐬���Ă���A�u���������s�����߁A���݂̗v�f�̏�Ԃ����ɒu���������������邱�Ƃ��ł���B
      //   (��F LINQ to XML�𗘗p���āA���݂̗v�f���e���N�G�����A���̌��ʂ�u����Ƃ��ė��p����B)
      //
      //   ���A���̃��\�b�h�͑������폜����̂ŗ��p���ɂ͒��ӂ��K�v�B
      //
      root = BuildSampleXml();
      elem = root.Elements("Child").First();

      elem.Add
        (
          from x in Enumerable.Range(1, 5)
          select new XElement("Value", x)
        );

      elem.ReplaceAll
        (
          from e in elem.Elements()
          where ToInt(e.Value) >= 3
          select e
        );

      Console.WriteLine(root);
      Console.WriteLine("=====================================");
    }

    int ToInt(string value)
    {
      int tmp;
      if (!int.TryParse(value, out tmp))
      {
        return -1;
      }

      return tmp;
    }

    XElement BuildSampleXml()
    {
      return XElement.Parse("<Root><Child Id=\"100\"><Value>hoge</Value></Child></Root>");
    }
  }
  #endregion
}
