namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region StringFormatSamples-01
  /// <sumamry>
  /// ������̏����ݒ�Ɋւ��ẴT���v���ł��B
  /// </summary>
  class StringFormatSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // �����ݒ�́A�ȉ��̂悤�ɂ��Đݒ肷��.
      //   {0,-20:C}
      // �ŏ���0�̓C���f�b�N�X��\���B�K�{���ځB
      //
      // �������w�肷��ꍇ�́A�J���}��t�^���������w�肷��B
      // �����̒l�����̒l�̏ꍇ�́A���񂹁B
      // �����̒l�����̒l�̏ꍇ�́A�E�񂹂ƂȂ�B
      // �����̎w��̓I�v�V�����B
      //
      // �t�H�[�}�b�g���w�肷��ꍇ�́A�R������t�^���t�H�[�}�b�g�̃^�C�v���w�肷��B
      // C�͒ʉ݂�\���B
      // �t�H�[�}�b�g�̎w��̓I�v�V�����B
      //
      // �t�H�[�}�b�g�̎�ނȂǂɂ��Ă�
      // http://msdn.microsoft.com/ja-jp/library/txafckwd(v=VS.100).aspx
      // ���Q�ƁB
      //
      string format = "'{0,20:C}'";
      Console.WriteLine(format, 25000);
    }
  }
  #endregion
}
