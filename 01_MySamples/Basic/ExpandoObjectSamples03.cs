namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region ExpandoObject�N���X�̃T���v��-03
  /// <summary>
  /// ExpandoObject�ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// .NET 4.0����ǉ����ꂽ�N���X�ł��B
  /// </remarks>
  public class ExpandoObjectSamples03 : IExecutable
  {
    public void Execute()
    {
      ///////////////////////////////////////////////////////////////////////
      //
      // ExpandoObject��Dictionary�Ƃ��Ĉ���. (�����o�[�̒ǉ�/�폜)
      //   ExpandoObject��IDictionary<string, object>���������Ă���̂�
      //   Dictionary�Ƃ��Ă����p�o����.
      //
      dynamic obj = new System.Dynamic.ExpandoObject();
      obj.Name = "gsf_zero1";
      obj.Age = 30;

      //
      // ��`����Ă��郁���o�[���.
      //
      IDictionary<string, object> map = obj as IDictionary<string, object>;
      foreach (var pair in map)
      {
        Console.WriteLine("{0}={1}", pair.Key, pair.Value);
      }

      //
      // Age�����o�[���폜.
      //
      map.Remove("Age");

      //
      // �m�F.
      //
      foreach (var pair in map)
      {
        Console.WriteLine("{0}={1}", pair.Key, pair.Value);
      }

      // �G���[�ƂȂ�.
      //Console.WriteLine(obj.Age);
    }
  }
  #endregion
}
