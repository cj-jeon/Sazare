namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.Composition;
  using System.ComponentModel.Composition.Hosting;
  using System.Linq;

  #region MEFSamples-01
  /// <summary>
  /// MEF�ɂ��ẴT���v���ł��B
  /// </summary>
  public class MEFSamples01 : IExecutable
  {
    // Export�p�̃C���^�[�t�F�[�X
    public interface IExporter
    {
      string Name { get; }
    }

    // Export�p�[�g
    [Export(typeof(IExporter))]
    public class Exporter : IExporter
    {
      public string Name
      {
        get
        {
          return "�������������� Exporter ��������������";
        }
      }
    }

    // Import�p�[�g
    // ���A�����I��null�������l�Ƃ��Ďw�肵�Ă���̂́A���̂܂܂��ƃR���p�C���ɂ���Čx����������邽��
    [Import(typeof(IExporter))]
    IExporter _exporter = null;

    // �R���e�i
    CompositionContainer _container;

    public void Execute()
    {
      //
      // �J�^���O�\�z.
      //  AggregateCatalog�́A������Catalog����ɂ܂Ƃ߂���������B
      //
      var catalog = new AggregateCatalog();
      // AssemblyCatalog�𗘗p���āA�������g�̃A�Z���u�����J�^���O�ɒǉ�.
      catalog.Catalogs.Add(new AssemblyCatalog(typeof(MEFSamples01).Assembly));

      //
      // �R���e�i���\�z.
      //
      _container = new CompositionContainer(catalog);
      try
      {
        // �������s.
        _container.ComposeParts(this);

        // ���s.
        Console.WriteLine(_exporter.Name);
      }
      catch (CompositionException ex)
      {
        // �����Ɏ��s�����ꍇ.
        Console.WriteLine(ex.ToString());
      }

      if (_container != null)
      {
        _container.Dispose();
      }
    }
  }
  #endregion
}
