namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  #region ByteArraySamples-07
  /// <summary>
  /// �o�C�g�z��ɂ��ẴT���v���ł��B
  /// </summary>
  public class ByteArraySamples07 : IExecutable
  {
    public void Execute()
    {
      //
      // �o�C�g��𕶎����.
      //
      string s = "gsf_zero1";
      byte[] buf = Encoding.ASCII.GetBytes(s);

      Console.WriteLine(Encoding.ASCII.GetString(buf));
    }
  }
  #endregion
}
