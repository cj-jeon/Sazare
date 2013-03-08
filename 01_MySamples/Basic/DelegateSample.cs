namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Windows.Forms;

  #region �f���Q�[�g�̃T���v�� (.net framework 1.1)
  /// <summary>
  /// �f���Q�[�g�̃T���v���i.NET Framework 1.1�j
  /// </summary>
  class DelegateSample : IExecutable
  {
    /// <summary>
    /// ���������s���܂��B
    /// </summary>
    public void Execute()
    {
      MethodInvoker methodInvoker = new MethodInvoker(DelegateMethod);
      methodInvoker();
    }

    /// <summary>
    /// �f���Q�[�g���\�b�h.
    /// </summary>
    private void DelegateMethod()
    {
      Console.WriteLine("SAMPLE_DELEGATE_METHOD.");
    }
  }
  #endregion
}
