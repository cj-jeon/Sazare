using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Sazare.Common;

// ReSharper disable once CheckNamespace
namespace Sazare.Samples
{
    #region MEFSamples-01

    /// <summary>
    ///     MEFについてのサンプルです。
    /// </summary>
    [Sample]
    // ReSharper disable once InconsistentNaming
    public class MEFSamples01 : IExecutable
    {
        // コンテナ
        private CompositionContainer _container;

        // Importパート
        // 尚、明示的にnullを初期値として指定しているのは、そのままだとコンパイラによって警告扱いされるため
        [Import(typeof(IExporter))] private IExporter _exporter;

        public void Execute()
        {
            //
            // カタログ構築.
            //  AggregateCatalogは、複数のCatalogを一つにまとめる役割を持つ。
            //
            var catalog = new AggregateCatalog();
            // AssemblyCatalogを利用して、自分自身のアセンブリをカタログに追加.
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MEFSamples01).Assembly));

            //
            // コンテナを構築.
            //
            _container = new CompositionContainer(catalog);
            try
            {
                // 合成実行.
                _container.ComposeParts(this);

                // 実行.
                Output.WriteLine(_exporter.Name);
            }
            catch (CompositionException ex)
            {
                // 合成に失敗した場合.
                Output.WriteLine(ex.ToString());
            }

            if (_container != null)
            {
                _container.Dispose();
            }
        }

        // Export用のインターフェース
        public interface IExporter
        {
            string Name { get; }
        }

        // Exportパート
        [Export(typeof(IExporter))]
        public class Exporter : IExporter
        {
            public string Name
            {
                get { return "☆☆☆☆☆☆☆ Exporter ☆☆☆☆☆☆☆"; }
            }
        }
    }

    #endregion
}