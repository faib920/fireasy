// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Data.Provider.Test
{
    [TestClass()]
    public class ProviderHelperTests
    {
        [TestMethod()]
        public void GetDefinedProviderInstanceTest()
        {
            Assert.IsNotNull(ProviderHelper.GetDefinedProviderInstance("MsSql"));
        }

        [TestMethod()]
        public void GetSupportedProvidersTest()
        {
            foreach (var name in ProviderHelper.GetSupportedProviders())
            {
                Console.WriteLine(name);
                var provider = ProviderHelper.GetDefinedProviderInstance(name);
                Assert.IsNotNull(provider);
            }
        }

        [TestMethod()]
        public void GetSupportedProvidersForParallelTest()
        {
            Parallel.For(1, 100, i =>
                {
                    Console.WriteLine(ProviderHelper.GetSupportedProviders().Length);
                });
        }
    }
}
