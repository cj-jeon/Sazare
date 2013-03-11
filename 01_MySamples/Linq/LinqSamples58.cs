namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-58
  /// <summary>
  /// LINQ to XML�̃T���v���ł�.
  /// </summary>
  /// <remarks>
  /// �v�f�̃N���[���ƃA�^�b�`�ɂ��ẴT���v���ł�.
  /// </remarks>
  public class LinqSamples58 : IExecutable
  {
    public void Execute()
    {
      //
      // �e�v�f�������Ȃ��v�f���쐬���A�����XML�c���[�̒��ɑg�ݍ���. (�A�^�b�`)
      //
      var noParent = new XElement("NoParent", true);
      var tree1 = new XElement("Parent", noParent);

      var noParent2 = tree1.Element("NoParent");
      Console.WriteLine("�Q�Ƃ������H = {0}", noParent == noParent2);
      Console.WriteLine(tree1);

      // �l��ύX���Ċm�F.
      noParent.SetValue(false);
      Console.WriteLine(noParent.Value);
      Console.WriteLine(tree1.Element("NoParent").Value);

      Console.WriteLine("==========================================");

      //
      // �e�v�f�����v�f���쐬���A�����XML�c���[�̒��ɑg�ݍ���. (�N���[��)
      //
      var origTree = new XElement("Parent", new XElement("WithParent", true));
      var tree2 = new XElement("Parent", origTree.Element("WithParent"));

      Console.WriteLine("�Q�Ƃ������H = {0}", origTree.Element("WithParent") == tree2.Element("WithParent"));
      Console.WriteLine(tree2);

      // �l��ύX���Ċm�F
      origTree.Element("WithParent").SetValue(false);
      Console.WriteLine(origTree.Element("WithParent").Value);
      Console.WriteLine(tree2.Element("WithParent").Value);
    }
  }
  #endregion
}
