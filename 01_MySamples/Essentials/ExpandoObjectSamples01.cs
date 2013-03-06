namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region ExpandoObject�N���X�̃T���v��-01
  /// <summary>
  /// ExpandoObject�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// .NET 4.0����ǉ����ꂽ�N���X�ł��B
  /// </remarks>
  public class ExpandoObjectSamples01 : IExecutable
  {
    public void Execute()
    {
      //////////////////////////////////////////////////////////////////////
      //
      // ���I�I�u�W�F�N�g���쐬.
      //
      // System.Dynamic���O��Ԃ́A�uSystem.Core.dll�v���ɑ��݂���B
      // ���I�I�u�W�F�N�g�𗘗p����ɂ́A��L��DLL�̑��Ɉȉ���DLL���Q�Ɛݒ�
      // ����K�v������B
      //
      // �EMicrosoft.CSharp.dll
      //
      dynamic obj = new System.Dynamic.ExpandoObject();

      //
      // �����o�[���`.
      //
      // �v���p�e�B.
      obj.Value = 10;

      // ���\�b�h.
      var action = new Action<string>((line) =>
      {
        Console.WriteLine(line);
      });

      obj.WriteLine = action;

      //
      // �Ăяo���Ă݂�.
      //
      obj.WriteLine(obj.Value.ToString());

      obj.Value = 100;
      obj.WriteLine(obj.Value.ToString());

      obj.Value = "hoge";
      obj.WriteLine(obj.Value.ToString());
    }
  }
  #endregion
}
