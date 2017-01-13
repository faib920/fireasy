// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Emit.Test
{
    [TestClass()]
    public class DynamicAssemblyBuilderTests
    {
        [TestMethod()]
        public void DynamicAssemblyBuilderTest()
        {
            var assemblyBuilder = new DynamicAssemblyBuilder("dynamicAssembly1");

            Assert.IsNotNull(assemblyBuilder);
        }

        [TestMethod()]
        public void DefineTypeTest()
        {
            var assemblyBuilder = new DynamicAssemblyBuilder("dynamicAssembly1");

            assemblyBuilder.DefineType("class1");
        }

        [TestMethod()]
        public void DefineInterfaceTest()
        {
            var assemblyBuilder = new DynamicAssemblyBuilder("dynamicAssembly1");

            assemblyBuilder.DefineInterface("interface1");
        }

        [TestMethod()]
        public void DefineEnumTest()
        {
            var assemblyBuilder = new DynamicAssemblyBuilder("dynamicAssembly1");

            assemblyBuilder.DefineEnum("enum1");
        }

        [TestMethod()]
        public void SaveTest()
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dynamicAssembly1.dll");
            var assemblyBuilder = new DynamicAssemblyBuilder("dynamicAssembly1", fileName);

            assemblyBuilder.Save();

            Assert.IsTrue(File.Exists(fileName));
        }

        [TestMethod()]
        public void SaveAllTest()
        {
            var assemblyBuilder = new DynamicAssemblyBuilder("dynamicAssembly1");
            var type1 = assemblyBuilder.DefineType("class1");
            var type2 = assemblyBuilder.DefineType("class2");

            assemblyBuilder.Save();

            Assert.AreEqual(2, assemblyBuilder.AssemblyBuilder.GetTypes().Length);
        }
    }
}
