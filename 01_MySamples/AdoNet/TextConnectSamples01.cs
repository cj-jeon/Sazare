namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Data.Common;
  using System.Linq;

  #region TextConnectSamples-01
  /// <summary>
  /// ADO.NET�𗘗p���ăe�L�X�g�t�@�C���ɐڑ�����T���v���ł��B
  /// </summary>
  /// <remarks>
  /// CSV�t�@�C���ɐڑ����A�e�N�G�����𔭍s���܂��B
  /// </remarks>
  public class TextConnectSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // OleDb�v���o�C�_�𗘗p���ăe�L�X�g�t�@�C��(CSV)�ɐڑ�����.
      //
      DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
      using (DbConnection conn = factory.CreateConnection())
      {
        //
        // �e�L�X�g�t�@�C���ɐڑ�����ׂ̐ڑ���������\�z.
        //
        // ��{�I��Excel�ɐڑ�����ꍇ�Ƃقړ����v�̂ƂȂ�B
        // Extended Properties����ISAM�h���C�o��Excel 12.0����text�ɂȂ�B
        // �܂��A�t�H�[�}�b�g�������w�肷��K�v������B
        //
        // Data Source�Ɏw�肷��̂́A�Y���t�@�C�������݂���f�B���N�g�����w�肷��B
        // ���A�Y���t�@�C���̍\���ɂ��Ă͕ʓrschema.ini�t�@�C���𓯂��f�B���N�g����
        // �p�ӂ���K�v������B
        //
        DbConnectionStringBuilder builder = factory.CreateConnectionStringBuilder();

        builder["Provider"] = "Microsoft.ACE.OLEDB.12.0";
        builder["Data Source"] = @".";
        builder["Extended Properties"] = "text;HDR=YES;FMT=Delimited";

        conn.ConnectionString = builder.ToString();
        conn.Open();

        //
        // SELECT.
        // FROM��̒��ɓǂݍ��ޑΏۂ̃t�@�C�������w�肷��B
        // �f�[�^���擾�����ۂ�schema.ini�t�@�C�����Q�Ƃ���A���`���s����B
        //
        using (DbCommand command = conn.CreateCommand())
        {
          command.CommandText = "SELECT * FROM [Persons.txt]";

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
        // INSERT.
        // Access�̏ꍇ�Ɠ������e�L�X�g�t�@�C���͒ǉ��E�Q�Ƃ����o���Ȃ��B
        // �i�܂�A�X�V�E�폜�͏o���Ȃ��j
        //
        using (DbCommand command = conn.CreateCommand())
        {
          string query = string.Empty;

          query += " INSERT INTO [Persons.txt] ";
          query += "   (ID, NAME, AGE) ";
          query += "   VALUES ";
          query += "   (7, 'gsf_zero7', 37) ";

          command.CommandText = query;
          command.ExecuteNonQuery();

          using (DbCommand command2 = conn.CreateCommand())
          {
            command2.CommandText = "SELECT * FROM [Persons.txt]";

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
        // ���� ISAM �ł́A�����N �e�[�u�����̃f�[�^���X�V���邱�Ƃ͂ł��܂���B
        //

        //
        // DELETE.
        // ���� ISAM �ł́A�����N �e�[�u�����̃f�[�^���폜���邱�Ƃ͂ł��܂���B
        //
      }
    }
  }
  #endregion
}
