namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.Composition;
  using System.ComponentModel.Composition.Hosting;
  using System.Linq;

  #region MEFSamples-03
  /// <summary>
  /// MEF�ɂ��ẴT���v���ł��B
  /// </summary>
  public class MEFSamples03 : IExecutable
  {
    // Export�p�̃C���^�[�t�F�[�X
    public interface IExporter
    {
      string Name { get; }
    }

    // Exporter�p�̃��^�f�[�^�C���^�[�t�F�[�X
    public interface IExporterMetadata
    {
      string Symbol { get; }
    }

    [Export(typeof(IExporter))]
    [ExportMetadata("Symbol", "FIRST")]
    public class FirstExporter : IExporter
    {
      public string Name
      {
        get
        {
          return "���� FIRST EXPORTER ����";
        }
      }
    }

    [Export(typeof(IExporter))]
    [ExportMetadata("Symbol", "SECOND")]
    public class SecondExporter : IExporter
    {
      public string Name
      {
        get
        {
          return "���� SECOND EXPORTER ����";
        }
      }
    }

    [Export(typeof(IExporter))]
    [ExportMetadata("Symbol", "THIRD")]
    public class ThirdExporter : IExporter
    {
      public string Name
      {
        get
        {
          return "���� THIRD EXPORTER ����";
        }
      }
    }

    // Import�p�[�g (������Export���󂯕t���A���A���^�f�[�^�L��j
    //
    // �ʏ�A������Export���󂯕t����ꍇ�͈ȉ��̏����Ő錾����B
    //   IEnumerable<Lazy<T>>
    //
    // Lazy<T>�𗘗p���鎖�ɂ��A�x�����[�f�B���O���\�ƂȂ�B
    // (���p���Ȃ�Export�p�[�g���������ɑS�ăC���X�^���X�������̂�h���j
    //
    // �܂��A���^�f�[�^�𗘗p����ꍇ�͈ȉ��̂悤�ɂȂ�B
    //   IEnumerable<Lazy<T, TMetaData>>
    //
    // ���A�����I��null�������l�Ƃ��Ďw�肵�Ă���̂́A���̂܂܂��ƃR���p�C���ɂ���Čx����������邽��
    [ImportMany(typeof(IExporter))]
    IEnumerable<Lazy<IExporter, IExporterMetadata>> _exporters = null;

    // �R���e�i.
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
        foreach (Lazy<IExporter, IExporterMetadata> lazyObj in _exporters)
        {
          //
          // ���^�f�[�^�𒲂ׁA���v�������݂̂̂����s����.
          // Lazy<T, TMetadata>.Value���Ă΂Ȃ�����C���X�^���X�͍쐬����Ȃ��B
          //
          if (lazyObj.Metadata.Symbol == "SECOND")
          {
            Console.WriteLine(lazyObj.Value.Name);
          }
        }

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
