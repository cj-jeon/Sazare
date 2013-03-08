namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Linq;

  #region ExpandoObject�N���X�̃T���v��-04
  /// <summary>
  /// ExpandoObject�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// .NET 4.0��ǉ����ꂽ�N���X�ł��B
  /// </remarks>
  public class ExpandoObjectSamples04 : IExecutable
  {
    public void Execute()
    {
      ///////////////////////////////////////////////////////////////////////
      //
      // ExpandoObject��INotifyPropertyChanged�Ƃ��Ĉ���. (�v���p�e�B�̕ύX���n���h��)
      //
      dynamic obj = new System.Dynamic.ExpandoObject();

      //
      // �C�x���g�n���h���ݒ�.
      //
      (obj as INotifyPropertyChanged).PropertyChanged += (sender, e) =>
      {
        Console.WriteLine("Property Changed:{0}", e.PropertyName);
      };

      //
      // �����o�[��`.
      //
      obj.Name = "gsf_zero1";
      obj.Age = 30;

      //
      // �����o�[�폜.
      //
      (obj as IDictionary<string, object>).Remove("Age");

      //
      // �l�ύX.
      //
      obj.Name = "gsf_zero2";

      //
      // ���s���ʁF
      //     Property Changed:Name
      //     Property Changed:Age
      //     Property Changed:Age
      //     Property Changed:Name
      //
    }
  }
  #endregion
}
