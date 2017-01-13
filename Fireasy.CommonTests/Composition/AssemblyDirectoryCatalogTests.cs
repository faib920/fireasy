using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fireasy.Common.Composition;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
namespace Fireasy.Common.Composition.Tests
{
    [TestClass()]
    public class AssemblyDirectoryCatalogTests
    {
        [TestMethod()]
        public void LoadedFilesTest()
        {
            var catalog = new AssemblyDirectoryCatalog();
            foreach (var assembly in catalog.LoadedFiles)
            {
                Console.WriteLine(assembly);
            }
        }

        [TestMethod()]
        public void ExportDefinitionsTest()
        {
            var catalog = new AssemblyDirectoryCatalog();
            foreach (var part in catalog.Parts)
            {
                foreach (var dif in part.ExportDefinitions)
                {
                    Console.WriteLine(dif.ContractName);
                }
            }
        }

        [TestMethod()]
        public void GetExportTest()
        {
            var catalog = new AssemblyDirectoryCatalog();
            using (var container = new CompositionContainer(catalog))
            {
                var instance = container.GetExport<IComposition>("Test");
                Assert.IsNotNull(instance.Value);

                try
                {
                    instance = container.GetExport<IComposition>("Test2");
                    Assert.IsNull(instance.Value);
                }
                catch
                {
                }
            }
        }

        [TestMethod()]
        public void GetExportsTest()
        {
            var catalog = new AssemblyDirectoryCatalog();
            using (var container = new CompositionContainer(catalog))
            {
                var instances = container.GetExports<IComposition>();
                foreach (var ins in instances)
                {
                    Console.WriteLine(ins.Value);
                }
            }
        }

        public interface IComposition
        {

        }

        public interface IComposition1
        {

        }

        [Export("Test", typeof(IComposition))]
        public class CompositionClass : IComposition
        {

        }

        [Export("Test1", typeof(IComposition))]
        public class CompositionClass1 : IComposition
        {

        }
    }
}
