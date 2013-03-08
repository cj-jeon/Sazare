namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region �����Ɋւ��鏈��(XX����XX���`������10�i���`���ɕϊ�)
  /// <summary>
  /// �����Ɋւ��鏈��(XX����XX���`������10�i���`���ɕϊ�)�ɂ��ẴT���v���ł��B
  /// </summary>
  public class TimeConvertSample01 : IExecutable
  {
    public void Execute()
    {
      // ���̒l�B7����40���Ƃ���.
      decimal original = 111.07M;

      //
      // ���Ԃ̕����͊��Ɋm��ς݂Ȃ̂ŁA���̂܂ܗ��p.
      //
      int hour = decimal.ToInt32(original);

      //
      // ���̒l���A���Ԃ̕�������������.
      // ��L�̌��l�̏ꍇ�́A0.4�ƂȂ�B
      //
      decimal minutes = (original - hour);

      //
      // 0.4�ɑ΂��āA100���|���ĕ������m��.
      //
      minutes *= 100;

      //
      // �Ō��60�i�ꎞ�Ԃ̕����j�Ŋ���.
      //
      minutes /= 60;

      //
      // �v�Z���ʂɂ���ẮA�[����������̂Ŏl�̌ܓ�.
      // (�����_��3�ʎl�̌ܓ�)
      //
      minutes = Math.Round(minutes, 2, MidpointRounding.AwayFromZero);

      //
      // ���ʂ��\�z.
      //
      // ��L�̕������߂鎮�́A�ȉ��̂悤�ɂ��o����B
      // minutes = Math.Round(((original % 1) * 100 / 60), 2, MidpointRounding.AwayFromZero);
      //
      decimal result = ((decimal)hour + minutes);

      Console.WriteLine("{0}����", result);
    }
  }
  #endregion
}
