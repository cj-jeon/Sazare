namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.CompilerServices;
  using System.Runtime.ConstrainedExecution;

  #region RuntimeHelpersSamples-02
  /// <summary>
  /// RuntimeHelpers�N���X�̃T���v���ł��B
  /// </summary>
  public class RuntimeHelpersSamples02 : IExecutable
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
      // RuntimeHelpers.PrepareConstrainedRegions���\�b�h�ɂ�
      // ���s�ł���̂́AConsistency.WillNotCorruptState�����MayCorruptInstance�̏ꍇ�̂�.
      //
      // ���A���̑����̓��\�b�h�����ł͂Ȃ��A�N���X��C���^�[�t�F�[�X�ɂ��t�^�ł���B
      // ���̏ꍇ�A�N���X�S�̂ɑ΂��ĐM�����̃R���g���N�g��t�^�������ƂɂȂ�B
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
      // RuntimeHelpers.PrepareConstrainedRegions���Ăяo���ƁA�R���p�C����
      // ���̃��\�b�h����catch, finally�u���b�N��CER�i���񂳂ꂽ���s�̈�j�Ƃ��ă}�[�N����B
      //
      // CER�Ƃ��ă}�[�N���ꂽ�̈悩��A�R�[�h���Ăяo���ꍇ�A���̃R�[�h�ɂ͐M�����̃R���g���N�g���K�v�ƂȂ�B
      // �R�[�h�ɑ΂��āA�M�����̃R���g���N�g��t�^����ɂ́A�ȉ��̑����𗘗p����B
      //  [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
      //
      // CER�Ń}�[�N���ꂽ�̈�ɂāA�R�[�h�ɐM�����̃R���g���N�g���t�^����Ă���ꍇ�ACLR��
      // try���̖{���������s�����O�ɁAcatch, finally�u���b�N�̃R�[�h�����O�R���p�C������B
      //
      // �Ȃ̂ŁA�Ⴆ��finally�u���b�N���ɂĐÓI�R���X�g���N�^�����N���X�̃��\�b�h���Ăт����Ă�����
      // ����ƁAtry���̖{�����������finally�u���b�N���̐ÓI�R���X�g���N�^���Ă΂�鎖�ɂȂ�B
      // (���O�R���p�C�����s����ƁA�A�Z���u���̃��[�h�A�ÓI�R���X�g���N�^�̎��s�Ȃǂ��������邽��)
      //
      RuntimeHelpers.PrepareConstrainedRegions();

      try
      {
        // ���O��RuntimeHelpers.PrepareConstrainedRegions()���Ăяo���Ă���ꍇ
        // �ȉ��̃��\�b�h���Ăяo�����O�ɁAcatch, finally�u���b�N�����O�R���p�C�������.
        Calc();
      }
      finally
      {
        SampleClass.Print();
      }
    }

    void Calc()
    {
      for (int i = 0; i < 10; i++)
      {
        Console.Write("{0} ", (i + 1));
      }

      Console.WriteLine("");
    }
  }
  #endregion
}
