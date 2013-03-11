namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region ExpandoObject�N���X�̃T���v��-02
  /// <summary>
  /// ExpandoObject�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// .NET 4.0����ǉ����ꂽ�N���X�ł��B
  /// </remarks>
  public class ExpandoObjectSamples02 : IExecutable
  {
    public void Execute()
    {
      ///////////////////////////////////////////////
      //
      // ExpandoObject�ɃC�x���g��ǉ�.
      //
      dynamic obj = new System.Dynamic.ExpandoObject();

      //
      // �C�x���g��`
      //   ExpandoObject�ɑ΂��ăC�x���g���`����ɂ�
      //   �܂��A�C�x���g�t�B�[���h���`���āA�����null�ŏ�����
      //   ����K�v������B
      //
      obj.MyEvent = null;

      //
      // �C�x���g�n���h����ݒ�.
      //
      obj.MyEvent += new EventHandler((sender, e) =>
      {
        Console.WriteLine("sender={0}", sender);
      });

      // �C�x���g����.
      obj.MyEvent(obj, EventArgs.Empty);
    }
  }
  #endregion
}
