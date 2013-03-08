namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region TypeSamples-01
  public class TypeSamples01 : IExecutable
  {
    public void Execute()
    {
      List<int> theList = new List<int> { 1, 2, 3, 4, 5 };
      Dictionary<int, string> theDictionary = new Dictionary<int, string> { { 1, "hoge" }, { 2, "hehe" } };

      //
      // Generic�ȃI�u�W�F�N�g�̌^�����̌^���擾����ɂ́ASystem.Type�N���X�̈ȉ��̃��\�b�h�𗘗p����B
      //
      //   �EGetGenericArguments()
      //
      // GetGenericArguments���\�b�h�́ASystem.Type�̔z���Ԃ��̂ŁA����𗘗p���Č^�����̌^�𔻕ʂ���B
      //
      var genericArgTypes = theList.GetType().GetGenericArguments();
      Console.WriteLine("=============== List<int>�̏ꍇ =================");
      Console.WriteLine("�^�����̐�={0}, �^�����̌^=({1})", genericArgTypes.Count(), string.Join(",", genericArgTypes.Select(item => item.Name)));

      genericArgTypes = theDictionary.GetType().GetGenericArguments();
      Console.WriteLine("=============== Dictionary<int, string>�̏ꍇ =================");
      Console.WriteLine("�^�����̐�={0}, �^�����̌^=({1})", genericArgTypes.Count(), string.Join(",", genericArgTypes.Select(item => item.Name)));
    }
  }
  #endregion
}
