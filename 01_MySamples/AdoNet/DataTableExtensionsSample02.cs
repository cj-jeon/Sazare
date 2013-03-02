namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Linq;

  #region DataTableExtensionsSample-02
  /// <summary>
  /// System.Data.Extensions�̃T���v��2�ł��B
  /// </summary>
  public class DataTableExtensionsSample02 : IExecutable
  {

    public void Execute()
    {
      DataTable table = BuildSampleTable();

      //
      // 1��ڂ̏���int�^�Ŏ擾.
      // 2��ڂ̏���string�^�Ŏ擾.
      //
      int val1 = table.Rows[0].Field<int>("COL-1");
      string val2 = table.Rows[0].Field<string>("COL-2");
      PrintTable("Before:", table);

      //
      // 1��ڂ̏���ύX.
      //
      table.Rows[0].SetField<int>("COL-1", 100);
      PrintTable("After:", table);

    }

    DataTable BuildSampleTable()
    {
      DataTable table = new DataTable();

      table.BeginInit();
      table.Columns.Add("COL-1", typeof(int));
      table.Columns.Add("COL-2");
      table.EndInit();

      table.BeginLoadData();
      for (int i = 0; i < 5; i++)
      {
        table.LoadDataRow(new object[] { i, (i + 1).ToString() }, true);
      }
      table.EndLoadData();

      return table;
    }

    void PrintTable(string title, DataTable table)
    {
      Console.WriteLine(title);

      foreach (DataRow row in table.Rows)
      {
        Console.WriteLine("\t{0}, {1}", row[0], row[1]);
      }

      Console.WriteLine();
    }
  }
  #endregion
}
