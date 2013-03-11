namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Data.Common;
  using System.Linq;

  #region ExcelConnectSamples-01
  /// <summary>
  /// ADO.NET��p����Excel�ɐڑ�����T���v���ł��B
  /// </summary>
  public class ExcelConnectSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // Excel�ɐڑ�����ɂ́AOLEDB�𗘗p����B
      // �v���o�C�_�[���́A�uSystem.Data.OleDb�v�ƂȂ�B
      //
      DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
      using (DbConnection conn = factory.CreateConnection())
      {
        //
        // Excel�p�̐ڑ���������\�z.
        //
        // Provider�́AMicrosoft.ACE.OLEDB.12.0���g�p���鎖�B
        // �iJET�h���C�o�𗘗p�����xlsx��ǂݍ��ގ����o���Ȃ��B�j
        //
        // Extended Properties�ɂ́AISAM�̃o�[�W����(Excel 12.0)��HDR���w�肷��B
        // �i2003�܂ł�xls�̏ꍇ��Excel 8.0��ISAM�o�[�W�������w�肷��B�j
        // HDR�͐擪�s���w�b�_���Ƃ��Ă݂Ȃ����ۂ����w�肷��B
        // �擪�s���w�b�_���Ƃ��Ă݂Ȃ��ꍇ��YES���A�����łȂ��ꍇ��NO��ݒ�B
        //
        // HDR=NO�Ǝw�肵���ꍇ�A�J�������̓V�X�e�����Ŏ����I�Ɋ���U����B
        // (F1, F2, F3.....�ƂȂ�)
        //
        DbConnectionStringBuilder builder = factory.CreateConnectionStringBuilder();

        builder["Provider"] = "Microsoft.ACE.OLEDB.12.0";
        builder["Data Source"] = @"C:\Users\gsf\Tmp\Sample.xlsx";
        builder["Extended Properties"] = "Excel 12.0;HDR=YES";

        conn.ConnectionString = builder.ToString();
        conn.Open();

        //
        // SELECT.
        //
        // �ʏ��SQL�̂悤�ɔ��s�ł���B���̍ۃV�[�g�w���
        // [Sheet1$]�̂悤�ɍs���B�͈͂��w�肷�邱�Ƃ��o����B
        //
        using (DbCommand command = conn.CreateCommand())
        {
          command.CommandText = "SELECT * FROM [Sheet1$]";

          DataTable table = new DataTable();
          using (DbDataReader reader = command.ExecuteReader())
          {
            table.Load(reader);
          }

          foreach (DataRow row in table.Rows)
          {
            Console.WriteLine("{0},{1},{2}", row["ID"], row["NAME"], row["AGE"]);
          }
        }

        using (DbCommand command = conn.CreateCommand())
        {
          command.CommandText = "SELECT * FROM [Sheet1$A1:C7]";

          DataTable table = new DataTable();
          using (DbDataReader reader = command.ExecuteReader())
          {
            table.Load(reader);
          }

          foreach (DataRow row in table.Rows)
          {
            Console.WriteLine("{0},{1},{2}", row["ID"], row["NAME"], row["AGE"]);
          }
        }

        //
        // INSERT
        //
        // ����������ʂ�SQL�Ɠ����悤�ɔ��s�ł���B
        // ���A�g�����U�N�V�����͐ݒ�ł��邪���ʂ͖����B
        // �i���[���o�b�N���s���Ă��f�[�^�͖߂�Ȃ��B�j
        //
        // �܂��AINSERT,UPDATE�̓G�N�Z�����J������Ԃł�
        // �s�������ł���B
        //
        // �f�[�^�̍폜�͍s�������ł��Ȃ��B�i�����j
        //
        using (DbCommand command = conn.CreateCommand())
        {
          string query = string.Empty;

          query += " INSERT INTO [Sheet1$] ";
          query += "   (ID, NAME, AGE) ";
          query += "   VALUES ";
          query += "   (7, 'gsf_zero7', 37) ";

          command.CommandText = query;
          command.ExecuteNonQuery();

          using (DbCommand command2 = conn.CreateCommand())
          {
            command2.CommandText = "SELECT * FROM [Sheet1$]";

            DataTable table = new DataTable();
            using (DbDataReader reader = command2.ExecuteReader())
            {
              table.Load(reader);
            }

            foreach (DataRow row in table.Rows)
            {
              Console.WriteLine("{0},{1},{2}", row["ID"], row["NAME"], row["AGE"]);
            }
          }
        }

        //
        // UPDATE
        //
        using (DbCommand command = conn.CreateCommand())
        {
          string query = string.Empty;

          query += " UPDATE [Sheet1$] ";
          query += " SET ";
          query += "    NAME = 'updated' ";
          query += "   ,AGE  = 99 ";
          query += " WHERE ";
          query += "   ID = 7 ";

          command.CommandText = query;
          command.ExecuteNonQuery();

          using (DbCommand command2 = conn.CreateCommand())
          {
            command2.CommandText = "SELECT * FROM [Sheet1$]";

            DataTable table = new DataTable();
            using (DbDataReader reader = command2.ExecuteReader())
            {
              table.Load(reader);
            }

            foreach (DataRow row in table.Rows)
            {
              Console.WriteLine("{0},{1},{2}", row["ID"], row["NAME"], row["AGE"]);
            }
          }
        }

        //
        // DELETE.
        // �폜�͍s���Ȃ��B
        //
      }
    }
  }
  #endregion
}
