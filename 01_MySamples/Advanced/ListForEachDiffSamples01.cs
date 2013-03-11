namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;

  #region ListForEachDiffSamples-01
  /// <summary>
  /// List��foreach�Ń��[�v����ꍇ�ƁAList.ForEach����ꍇ�̑��x�����e�X�g
  /// </summary>
  public class ListForEachDiffSamples01 : IExecutable
  {
    public void Execute()
    {
      Prepare();

      //
      // List��foreach�ŏ������邩�AList.ForEach�ŏ������邩��
      // �ǂ���̕��������̂����v���B
      //
      // IL���x���Ō����
      //   foreach�̏ꍇ�F call��2��
      //   List.ForEach�̏ꍇ�F callvirt��1��
      // �ƂȂ�B
      //
      foreach (var elementCount in new[] { 1000, 3000, 5000, 10000, 50000, 100000, 150000, 500000, 700000, 1000000 })
      {
        Console.WriteLine("===== [Count:{0}] =====", elementCount);

        var theList = new List<int>(Enumerable.Range(1, elementCount));

        var watch = Stopwatch.StartNew();
        Sum_foreach(theList);
        watch.Stop();
        Console.WriteLine("foreach:      {0}", watch.Elapsed);

        watch = Stopwatch.StartNew();
        Sum_List_ForEach(theList);
        watch.Stop();
        Console.WriteLine("List.ForEach: {0}", watch.Elapsed);
      }
    }

    void Prepare()
    {
      int result = 0;
      foreach (var x in new List<int>(Enumerable.Range(1, 1000)))
      {
        result += x;
      }

      result = 0;
      new List<int>(Enumerable.Range(1, 1000)).ForEach(x => result += x);
    }

    int Sum_foreach(List<int> theList)
    {
      int result = 0;
      foreach (var x in theList)
      {
        result += x;
      }
      return result;
    }

    int Sum_List_ForEach(List<int> theList)
    {
      int result = 0;
      theList.ForEach(x => result += x);
      return result;
    }
  }
  #endregion
}
