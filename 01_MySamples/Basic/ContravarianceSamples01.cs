namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region ContravarianceSamples-01
  /// <summary>
  /// ���ϐ��ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// ���ϐ���4.0����ǉ����ꂽ�@�\�ł��B
  /// </remarks>
  public class ContravarianceSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // Contravariance(���ϐ�)�́A�ȒP�Ɍ����ƁA�e�̃I�u�W�F�N�g���q�̌^�Ƃ��Ĉ������B
      // (���ϐ��̋t�ł��B�j
      //
      // ��F
      //   class Parent     { ... }
      //   class Child : Parent { ... }
      //
      //   delegate Parent SampleDelegate();
      //
      //   Child SampleMethod() { ... }
      //
      //   // �����Ŕ��ϐ����������Ă���B
      //   SampleDelegate theDelegate = SampleMethod;
      //
      // C# 4.0�ł́A���̊T�O���W�F�l���b�N�C���^�[�t�F�[�X�ɑ΂��ēK�p�ł���悤�ɂȂ����B
      // ���ϐ���\������ɂ́A�^�������`����ۂɁA�uin�v�L�[���[�h��ݒ肷��B
      //
      // .NET 4.0�ł́AAction<T>�͈ȉ��̂悤�ɒ�`����Ă���B
      //   public delegate void Action<in T>(T obj)
      //
      // �uin�v�L�[���[�h�́A���̌^�������u���͕����v�ɂ������p���Ȃ����Ƃ�\�����Ă���B
      // �܂�A�uin�v�L�[���[�h���t�^������T�������Ȃǂ̓��͒l�ɂ������p�ł��Ȃ��Ȃ�B
      // (in���w�肵�Ă����ԂŁA�o�͕����A�܂胁�\�b�h�̖߂�l�Ȃǂ�T��ݒ肵�悤�Ƃ����
      //  �R���p�C���G���[����������B�j
      //
      // ���͕����ɂ������p���Ȃ��̂ŁA�e�̌^�i�܂�L�`�̌^�j���q�̌^�i�܂苷�`�̌^�j��
      // �ݒ肵�Ă��A���Ȃ��B
      //  �u�O���̌^��string�ł��邪�A���ۂɃf�[�^���n�����ہA�����̈����̌^��object�Ȃ̂Ŗ��Ȃ��v
      //
      // ��F
      //   Action<object> objAction = x => Console.WriteLine(x);
      //   Action<string> strAction = objAction;
      //
      //   strAction("gsf_zero1");
      //
      //   ��L�̗Ⴞ�ƁAobjAction��strAction�ɐݒ肵�Ă���B�܂�e�N���X�̌^�Œ�`����Ă���Action<object>��
      //   �q�̃N���X��Action<string>�ɐݒ肵�Ă���B
      //   ���̌�AstrAction("gsf_zero1")�Ƃ��Ă���̂ŁA�O������n���ꂽ�l��string�^�ł���B
      //   �������AobjAction�̈����̌^�́A�e�N���X�ł���object�^�Ȃ̂Ŗ��Ȃ����삷��B
      //   (�e�N���X�ɒ�`����Ă���U�镑���������p�ł��Ȃ����߁B�j
      //
      // Covariance(���ϐ�)�́A���̋t���s�����̂ƂȂ�B
      //
      Action<object> objAction = x => Console.WriteLine(x);
      Action<string> strAction = objAction;

      strAction("gsf_zero1");
    }
  }
  #endregion
}
