namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.CompilerServices;

  #region RuntimeHelpersSamples-01
  /// <summary>
  /// RuntimeHelpers�N���X�̃T���v���ł��B
  /// </summary>
  public class RuntimeHelpersSamples01 : IExecutable
  {
    class SampleClass
    {
      public int Id { get; set; }

      public override int GetHashCode()
      {
        return Id.GetHashCode();
      }
    }

    public void Execute()
    {
      //
      // RuntimeHelpers�N���X��GetHashCode�́A���̃N���X��GetHashCode���\�b�h
      // �Ƌ����������Ⴄ�B�ȉ��AMSDN(http://msdn.microsoft.com/ja-jp/library/11tbk3h9.aspx)��
      // ����L�q�����p�B
      //
      // �EObject.GetHashCode �́A�I�u�W�F�N�g�l���l������V�i���I�ŕ֗��ł��B �������e�� 2 �̕�����́AObject.GetHashCode �œ����l��Ԃ��܂��B
      // �ERuntimeHelpers.GetHashCode �́A�I�u�W�F�N�g���ʎq���l������V�i���I�ŕ֗��ł��B �������e�� 2 �̕�����́A���e�������ł��قȂ镶����I�u�W�F�N�g�ł��邽�߁ARuntimeHelpers.GetHashCode �ňقȂ�l��Ԃ��܂��B
      //
      // �ȉ��ł́A�T���v���ƂȂ�I�u�W�F�N�g��2�쐬���A�n�b�V���R�[�h���o�͂���悤�ɂ��Ă���B
      // �T���v���N���X�ł́AGetHashCode���\�b�h���I�[�o�[���C�h���Ă���AId�v���p�e�B�̃n�b�V���R�[�h��
      // �Ԃ��悤�ɂ��Ă���B
      //   (����) ���̃N���X��GetHashCode���\�b�h�̎����́A�T���v���̂��߂Ɋȗ������Ă���܂��B
      //         ���ۂ̎����ŁA���̂悤�ȃn�b�V���R�[�h�̎Z�o�͂��Ă͂����܂���B
      //
      // �ȉ��̏ꍇ�AObject.GetHashCode���Ăяo���Ă���ꍇ�͓��R�Ȃ��瓯���n�b�V���R�[�h�ƂȂ邪
      // RuntimeHelpers.GetHashCode���Ăяo���Ă���ꍇ�A�Ⴄ�n�b�V���R�[�h�ƂȂ�.
      //
      SampleClass sampleObj1 = new SampleClass { Id = 100 };
      SampleClass sampleObj2 = new SampleClass { Id = 100 };

      Console.WriteLine("[Object.GetHashCode]        sampleObj1 = {0}, sampleObj2 = {1}", sampleObj1.GetHashCode(), sampleObj2.GetHashCode());
      Console.WriteLine("[RuntimeHelper.GetHashCode] sampleObj1 = {0}, sampleObj2 = {1}", RuntimeHelpers.GetHashCode(sampleObj1), RuntimeHelpers.GetHashCode(sampleObj2));

      //
      // ������f�[�^�Ō���.
      // �ȉ��́A������̃n�b�V���R�[�h���قȂ邩�ۂ�������.
      // �ϐ�s1, s2���쐬���Ă���A�A�����ĕ�����l���쐬���Ă��闝�R��
      // CLR�ɂ���āA�����ŕ����񂪃C���^�[��(Intern)����Ȃ��悤�ɂ��邽��.
      //
      // ������Intern����Ă��Ȃ��ꍇ�ARuntimeHelpers.GetHashCode���\�b�h��
      // �Ⴄ�l��Ԃ��BObject.GetHashCode�͓����n�b�V���R�[�h��Ԃ�.
      //
      string s1 = "hello ";
      string s2 = "world";
      string test1 = s1 + s2;
      string test2 = s1 + s2;

      Console.WriteLine("[Object.GetHashCode]        test1 = {0}, test2 = {1}", test1.GetHashCode(), test2.GetHashCode());
      Console.WriteLine("[RuntimeHelper.GetHashCode] test1 = {0}, test2 = {1}", RuntimeHelpers.GetHashCode(test1), RuntimeHelpers.GetHashCode(test2));

      //
      // ������f�[�^�Ō���
      // �ȉ��́ACLR�ɂ���ĕ����񂪃C���^�[�������l�ɑ΂��ăn�b�V���R�[�h���擾���Ă���.
      //
      // ���̏ꍇ�ARuntimeHelpers.GetHashCode�ł������n�b�V���R�[�h���Ԃ��Ă���.
      // ���ACLR�ɂ���Ēl���C���^�[�������̂̓��e���������ł���.
      // �A������ɂ���č쐬���ꂽ������̓C���^�[������Ȃ�.
      // ������C���^�[������ɂ́AString.Intern���\�b�h�𗘗p����.
      //
      string test3 = "hello world";
      string test4 = "hello world";

      Console.WriteLine("[Object.GetHashCode]        test3 = {0}, test4 = {1}", test3.GetHashCode(), test4.GetHashCode());
      Console.WriteLine("[RuntimeHelper.GetHashCode] test3 = {0}, test4 = {1}", RuntimeHelpers.GetHashCode(test3), RuntimeHelpers.GetHashCode(test4));
    }
  }
  #endregion
}
