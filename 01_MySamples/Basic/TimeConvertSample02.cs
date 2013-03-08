namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region �����Ɋւ��鏈��(10�i���`������XX����XX���`���ɕϊ�)
  /// <summary>
  /// �����Ɋւ��鏈��(10�i���`������XX����XX���`���ɕϊ�)�ɂ��ẴT���v���ł��B
  /// </summary>
  public class TimeConvertSample02 : IExecutable
  {
    public void Execute()
    {
      // ���̒l. 7.67���ԂƂ���.
      decimal original = 111.12M;

      //
      // ���Ԃ̕����͊��Ɋm��ς݂Ȃ̂ŁA���̂܂ܗ��p.
      //
      int hour = decimal.ToInt32(original);

      //
      // ���ԕ����̕������Z�o.
      //
      int hourMinutes = (hour * 60);

      //
      // ���̒l�̕������Z�o.
      //
      decimal originalMinutes = (original * 60);

      //
      // ���߂����̒l�̕������l�̌ܓ�.
      //
      int roundedOriginalMinutes = decimal.ToInt32(Math.Round(originalMinutes, 0, MidpointRounding.AwayFromZero));

      //
      // ���̒l�̕������玞�ԕ����̕���������.
      // ���ꂪ���ʂ̕����ƂȂ�B
      //
      int minutes = (roundedOriginalMinutes - hourMinutes);

      //
      // ���ʂ��\�z.
      //
      decimal result = decimal.Parse(string.Format("{0}.{1}", hour, minutes));

      Console.WriteLine("����={0}, {1}����{2}��", result, hour, minutes);
    }
  }
  #endregion
}
