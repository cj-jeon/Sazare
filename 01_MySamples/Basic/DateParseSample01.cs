namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.Linq;

  #region DateParseSamples-01
  public class DateParseSample01 : IExecutable
  {
    public void Execute()
    {
      //
      // ParseExact���\�b�h�̏ꍇ�́A�l��2011, �t�H�[�}�b�g��yyyy
      // �̏ꍇ�ł����t�ϊ��o����B
      //
      try
      {
        var d = DateTime.ParseExact("2011", "yyyy", null);
        Console.WriteLine(d);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }

      //
      // TryParse���\�b�h�̏ꍇ�́A�ȉ��̂ǂ����False�ƂȂ�B
      // ���炭�AIFormatProvider��ݒ肵�Ȃ��Ɠ����Ȃ��Ǝv����B
      //
      DateTime d2;
      Console.WriteLine(DateTime.TryParse("2011", out d2));
      Console.WriteLine(DateTime.TryParse("2011", null, DateTimeStyles.None, out d2));

      //
      // TryParseExact���\�b�h�̏ꍇ�́A�l��2011�A�t�H�[�}�b�g��yyyy
      // �̏ꍇ�ł����t�ϊ��o����B
      //
      DateTime d3;
      Console.WriteLine(DateTime.TryParseExact("2011", "yyyy", null, DateTimeStyles.None, out d3));

      Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssfff"));

      var d98 = DateTime.Now;
      var d99 = DateTime.ParseExact(d98.ToString("yyyyMMddHHmmssfff"), "yyyyMMddHHmmssfff", null);
      Console.WriteLine(d98 == d99);
      Console.WriteLine(d98.Ticks);
      Console.WriteLine(d98 == new DateTime(d98.Ticks));

      // �����b���w�肵�Ă��Ȃ��ꍇ�́A00:00:00�ƂȂ�
      var d100 = new DateTime(2011, 11, 12);
      Console.WriteLine("{0}, {1}, {2}", d100.Hour, d100.Minute, d100.Second);
    }
  }
  #endregion
}
