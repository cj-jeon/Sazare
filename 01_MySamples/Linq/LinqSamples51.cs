namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  #region LinqSamples-51
  /// <summary>
  /// LINQ to XML�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// �����񂩂�XDocument�I�u�W�F�N�g���\�z����T���v���ł��B
  /// </remarks>
  public class LinqSamples51 : IExecutable
  {
    public void Execute()
    {
      //
      // LINQ to XML�́ALINQ�𗘗p����XML���������߂�API�ł���B
      // �C��������XML�m�[�h�̊Ǘ��y�уN�G�����s���\�B
      //
      // LINQ to XML�ł́A�܂��ŏ���XDocument�I�u�W�F�N�g�܂���XElement���\�z����.
      // XDocument�I�u�W�F�N�g�̍\�z�ɂ�
      //   �E�t�@�C������ǂݍ���
      //   �E�����񂩂�\�z
      //   �E�֐��^�\�z
      //   �E�V�K�쐬
      // �̕��@������B
      //
      // �{�T���v���ł́A�����񂩂�XDocument�I�u�W�F�N�g���擾���Ă���.
      //

      //
      // �����񂩂�XDocument���\�z����ɂ́AParse���\�b�h�𗘗p����.
      // LoadOption�ɂ́A�ȉ��̒l���ݒ�o����.
      //   None              : �Ӗ��̖����󔒂̍폜�A�y�сA�x�[�XURI�ƍs���̓ǂݍ��ݖ���
      //   PreserveWhitespace: �Ӗ��̖����󔒕ێ�
      //   SetBaseUri        : �x�[�XURI�̕ێ�
      //   SetLineInfo       : �s���̕ێ�
      //
      var doc = XDocument.Parse(MakeSampleXml(), LoadOptions.None);

      //
      // ����̗v�f�̕\��.
      //
      var query = from elem in doc.Descendants("Person")
                  let name = elem.Attribute("name").Value
                  where name.StartsWith("b")
                  select new { name };

      foreach (var item in query)
      {
        Console.WriteLine(item);
      }
    }

    string MakeSampleXml()
    {
      var xmlStrings =
            @"<?xml version='1.0' encoding='UTF-8' standalone='yes'?>
              <Persons>
                <Person name='foo'/>
                <Person name='bar'/>
                <Person name='baz'/>
              </Persons>";

      return xmlStrings;
    }
  }
  #endregion
}
