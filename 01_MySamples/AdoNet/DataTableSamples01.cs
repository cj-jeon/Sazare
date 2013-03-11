namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Linq;

  #region DataTableSamples-01
  /// <summary>
  /// DataTable�N���X�Ɋւ���T���v���ł��B
  /// </summary>
  public class DataTableSamples01 : IExecutable
  {
    public void Execute()
    {
      DataTable table = new DataTable();

      table.Columns.Add("Val", typeof(decimal));

      for (int i = 0; i < 10; i++)
      {
        table.LoadDataRow(new object[] { i * 0.1 }, true);
      }

      //
      // ���[]�t���ł������ł��\��Ȃ����A�t���Ă�������������.
      // 
      object result = table.Compute("SUM([Val])", "[Val] >= 0.5");
      Console.WriteLine("{0}:{1}", result, result.GetType().FullName);
    }
  }
  #endregion
}
