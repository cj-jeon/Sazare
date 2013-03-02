namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Linq;

  #region DataTableSamples-03
  /// <summary>
  /// DataTable�N���X�Ɋւ���T���v���ł��B
  /// </summary>
  public class DataTableSamples03 : IExecutable
  {
    public void Execute()
    {
      DataTable tableA = new DataTable();

      tableA.Columns.Add("Val", typeof(int));

      for (int i = 0; i < 10; i++)
      {
        tableA.LoadDataRow(new object[] { i }, true);
      }

      Console.WriteLine("[TableA]ColumnCount = {0}", tableA.Columns.Count);
      Console.WriteLine("[TableA]RowCount = {0}", tableA.Rows.Count);

      //
      // tableA�̃X�L�[�}��tableB�ɃR�s�[.
      // (�f�[�^�̓R�s�[���Ȃ��B)
      //
      DataTable tableB = tableA.Clone();
      Console.WriteLine("[TableB]ColumnCount = {0}", tableB.Columns.Count);
      Console.WriteLine("[TableB]RowCount = {0}", tableB.Rows.Count);

      //
      // tableA�̃X�L�[�}�ƃf�[�^��tableC�ɃR�s�[.
      //
      DataTable tableC = tableA.Copy();
      Console.WriteLine("[TableC]ColumnCount = {0}", tableC.Columns.Count);
      Console.WriteLine("[TableC]RowCount = {0}", tableC.Rows.Count);
    }
  }
  #endregion
}
