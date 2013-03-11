namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region �����f���Q�[�g�̃T���v�� (.net framework 2.0)
  /// <summary>
  /// �����f���Q�[�g(anonymous delegete)�̃T���v���i.NET Framework 2.0�j
  /// </summary>
  class AnonymousDelegateSample : IExecutable
  {
    /// <summary>
    /// �{�T���v���ŗ��p����f���Q�[�g�̒�`
    /// </summary>
    delegate void SampleDelegate();

    /// <summary>
    /// ���������s���܂��B
    /// </summary>
    public void Execute()
    {
      //
      // �������\�b�h���\�z���Ď��s.
      //
      SampleDelegate d = delegate()
      {
        Console.WriteLine("SAMPLE_ANONYMOUS_DELEGATE.");
      };

      d.Invoke();
    }

  }
  #endregion
}
