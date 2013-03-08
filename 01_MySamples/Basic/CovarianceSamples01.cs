namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region CovarianceSamples-01
  /// <summary>
  /// ���ϐ��ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// ���ϐ���4.0����ǉ����ꂽ�@�\�ł��B
  /// </remarks>
  public class CovarianceSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // Covariance(���ϐ�)�́A�ȒP�Ɍ����ƁA�q�̃I�u�W�F�N�g��e�̌^�Ƃ��Ĉ������B
      //
      // ��F
      //   string str = "gsf_zero1";
      //   object obj = str;
      //
      // C# 4.0�ł́A���̊T�O���W�F�l���b�N�C���^�[�t�F�[�X�ɑ΂��ēK�p�ł���悤�ɂȂ����B
      // ���ϐ���\������ɂ́A�^�������`����ۂɁA�uout�v�L�[���[�h��ݒ肷��B
      //
      // .NET 4.0�ł́AIEnumerable<T>�͈ȉ��̂悤�ɒ�`����Ă���B
      //   public interface IEnumerable<out T> : IEnumerable { ... }
      //
      // �uout�v�L�[���[�h�́A���̌^�������u�o�͕����v�ɂ������p���Ȃ����Ƃ�\�����Ă���B
      // �܂�A�uout�v�L�[���[�h���t�^������T��߂�l�Ȃǂ̏o�͒l�ɂ������p�ł��Ȃ��Ȃ�B
      // (out���w�肵�Ă����ԂŁA���͕����A�܂胁�\�b�h�̈����Ȃǂ�T��ݒ肵�悤�Ƃ����
      //  �R���p�C���G���[����������B�j
      //
      // �o�͕����ɂ������p���Ȃ��̂ŁA�q�̌^�i�܂苷�`�̌^�j��e�̌^�i�܂�L�`�̌^�j��
      // �ݒ肵�Ă��A���Ȃ��B
      //  �u�����̌^��string�ł��邪�A���ۂɒl�����o���ۂɂ͐e�̌^�Ŏ󂯎��̂Ŗ��Ȃ��v
      //
      // Contravariance(���ϐ�)�́A���̋t���s�����̂ƂȂ�B
      //
      IEnumerable<string> strings = new[] { "gsf_zero1", "gsf_zero2" };
      IEnumerable<object> objects = strings;

      foreach (var obj in objects)
      {
        Console.WriteLine("VALUE={0}, TYPE={1}", obj, obj.GetType().Name);
      }
    }
  }
  #endregion
}
