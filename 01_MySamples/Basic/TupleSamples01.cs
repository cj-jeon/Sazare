namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region TupleSamples-01
  /// <summary>
  /// Tuple�N���X�ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// Tuple�N���X��4.0����ǉ����ꂽ�N���X�ł��B
  /// </remarks>
  public class TupleSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // Tuple�N���X�́A.NET 4.0����ǉ����ꂽ�N���X�ł���B
      // �����̒l����g�̃f�[�^�Ƃ��āA�ێ����邱�Ƃ��ł���B
      // 
      // �悭���p�����̂́A�߂�l�ɂĕ����̒l��Ԃ��K�v���L��ꍇ�Ȃǂł���B
      // (object�̔z���Ԃ��Ƃ���������邪�A���̏ꍇBoxing���������Ă��܂��̂Ńp�t�H�[�}���X��
      //  �������v��������ʂł́A���p���Â炢�B���̓_�ATuple�̓W�F�l���b�N�N���X�ƂȂ��Ă���̂�
      //  Boxing���������鎖���Ȃ��B)
      //
      // Tuple�N���X�́A�s�ς̃I�u�W�F�N�g�ƂȂ��Ă���B�܂�A�R���X�g���N�g���ɒl��ݒ肵�����
      // ���̒l��ύX���邱�Ƃ��o���Ȃ��B�i�Q�Ƃ̐�ɑ��݂��Ă��郁���o�͕ύX�\�B�j
      // �e�f�[�^�́A�uItem1�v�uItem2�v�E�E�E�Ƃ����`�Ŏ擾���Ă����B
      //
      // �ȉ��̂悤�ȃN���X��`���s���Ă���A�f�[�^�̐��ɂ���ăC���X�^���X��������̂��ς��B
      //   Tuple<T1>
      //   Tuple<T1, T2>
      //   Tuple<T1, T2, T3>
      //   Tuple<T1, T2, T3, T4>
      //   Tuple<T1, T2, T3, T4, T5>
      //   Tuple<T1, T2, T3, T4, T5, T6>
      //   Tuple<T1, T2, T3, T4, T5, T6, T7>
      //   Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>
      //
      // �f�[�^�����V�ȏ�̏ꍇ�́A�c��̕�����TRest�Ƃ��Đݒ肷��B
      //
      // Tuple���쐬����ۂ́ATuple.Create���\�b�h�𗘗p���ăC���X�^���X���擾����̂��y�ł���B
      // �܂��A���̍ۂ͌^���_�𗘗p����ƕ֗��B
      //
      // Tuple�N���X�ł́AToString���\�b�h���I�[�o�[���C�h����Ă���A�ȉ��̂悤�ɕ\�������B
      //   Tuple<int, int>   ==> (xxx, yyy)
      //
      Tuple<int, string> t1 = Tuple.Create(100, "gsf_zero1");
      var t2 = Tuple.Create(200, "gsf_zero2", 30);  // Tuple<int, string, int>�ƂȂ�B

      Console.WriteLine(t1.Item1);
      Console.WriteLine(t1.Item2);

      Console.WriteLine(t2.Item1);
      Console.WriteLine(t2.Item2);
      Console.WriteLine(t2.Item3);

      var t3 = TestMethod(10, 20);
      Console.WriteLine(t3);     // (100, 400)

      // �ȉ��̓G���[�ƂȂ�.
      // t3.Item1 = 1000;
    }

    private Tuple<int, int> TestMethod(int x, int y)
    {
      return Tuple.Create(x * x, y * y);
    }
  }
  #endregion
}
