namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.CompilerServices;
  using System.Runtime.ConstrainedExecution;

  #region RuntimeHelpersSamples-03
  /// <summary>
  /// RuntimeHelpers�N���X�̃T���v���ł��B
  /// </summary>
  public class RuntimeHelpersSamples03 : IExecutable
  {
    // �T���v���N���X
    static class SampleClass
    {
      static SampleClass()
      {
        Console.WriteLine("SampleClass static ctor()");
      }

      //
      // ���̃��\�b�h�ɑ΂��āACER���ŗ��p�ł���悤�M�����̃R���g���N�g��t�^.
      // ReliabilityContractAttribute�����Consistency��Cer��
      // System.Runtime.ConstrainedExecution���O��Ԃɑ��݂���.
      //
      [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
      internal static void Print()
      {
        Console.WriteLine("SampleClass.Print()");
      }
    }

    public void Execute()
    {
      //
      // ExecuteCodeWithGuaranteedCleanup���\�b�h��, PrepareConstrainedRegions���\�b�h��
      // ���l�ɁA�R�[�h��CER�i���񂳂ꂽ���s���j�Ŏ��s���郁�\�b�h�ł���B
      //
      // PrepareConstrainedRegions���\�b�h���Ăяo���ꂽ���\�b�h��catch, finally�u���b�N��
      // CER�Ƃ��ă}�[�N����̂ɑ΂��āAExecuteCodeWithGuaranteedCleanup���\�b�h��
      // �����I�Ɏ��s�R�[�h�����ƃN���[���A�b�v���� (�o�b�N�A�E�g�R�[�h)�������œn���d�l�ƂȂ��Ă���B
      //
      // ExecuteCodeWithGuaranteedCleanup���\�b�h��
      // TryCode�f���Q�[�g��CleanupCode�f���Q�[�g�A�y�сAuserData���󂯎��.
      //
      // public delegate void TryCode(object userData)
      // public delegate void CleanupCode(object userData, bool exceptionThrown)
      //
      // �O��̃T���v���Ɠ���������s��.
      RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup(Calc, Cleanup, null);
    }

    void Calc(object userData)
    {
      for (int i = 0; i < 10; i++)
      {
        Console.Write("{0} ", (i + 1));
      }

      Console.WriteLine("");
    }

    void Cleanup(object userData, bool exceptionThrown)
    {
      SampleClass.Print();
    }
  }
  #endregion
}
