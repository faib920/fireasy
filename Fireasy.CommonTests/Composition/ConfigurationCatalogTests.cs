using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fireasy.Common.Composition;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition;
namespace Fireasy.Common.Composition.Tests
{
    [TestClass()]
    public class ConfigurationCatalogTests
    {
        [TestMethod()]
        public void LoadedFilesTest()
        {
            var catalog = new ConfigurationCatalog();
            foreach (var assembly in catalog.LoadedFiles)
            {
                Console.WriteLine(assembly);
            }
        }

        [TestMethod()]
        public void ExportDefinitionsTest()
        {
            var catalog = new ConfigurationCatalog();
            foreach (var part in catalog.Parts)
            {
                foreach (var dif in part.ExportDefinitions)
                {
                    Console.WriteLine(dif.ContractName);
                }
            }
        }

        public interface IComposition
        {

        }

        [Export("Test", typeof(IComposition))]
        public class CompositionClass : IComposition
        {

        }
    }
}
