namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region WhereArrayIteratorSamples-01
  /// <summary>
  /// WhereArrayIterator�Ɋւ���T���v���ł��B
  /// </summary>
  public class WhereArrayIteratorSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // where���܂�linq���쐬�����, WhereArrayIterator�ƂȂ�B
      //
      var subset = from i in new[] { 1, 2, 3, 5, 6, 7 }
                   where i < 7
                   select i;

      Console.WriteLine("{0}", subset.GetType().Name);
      Console.WriteLine("{0}", subset.GetType().Namespace);

      //
      // where���܂܂Ȃ�linq���쐬����ƁAWhereSelectArrayIterator�ƂȂ�B
      //
      var subset2 = from i in new[] { 1, 2, 3, 5, 6, 7 }
                    select i;

      Console.WriteLine("{0}", subset2.GetType().Name);
      Console.WriteLine("{0}", subset2.GetType().Namespace);
    }
  }
  #endregion
}
