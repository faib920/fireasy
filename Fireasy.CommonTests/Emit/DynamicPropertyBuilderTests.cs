using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fireasy.Common.Emit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Fireasy.Common.Emit.Test
{
    [TestClass()]
    public class DynamicPropertyBuilderTests
    {
        private DynamicTypeBuilder CreateBuilder()
        {
            var assemblyBuilder = new DynamicAssemblyBuilder("assemblyTests");
            return assemblyBuilder.DefineType("testClass");
        }

        [TestMethod()]
        public void DefineGetSetMethodsTest()
        {
            var typeBuilder = CreateBuilder();
            var propertyBuilder = typeBuilder.DefineProperty("Name", typeof(string));
            propertyBuilder.DefineGetSetMethods();

            Assert.IsTrue(propertyBuilder.PropertyBuilder.CanRead);
            Assert.IsTrue(propertyBuilder.PropertyBuilder.CanWrite);
        }

        [TestMethod()]
        public void DefineGetMethodTest()
        {
            var typeBuilder = CreateBuilder();
            var propertyBuilder = typeBuilder.DefineProperty("Name", typeof(string));
            propertyBuilder.DefineGetMethod();

            Assert.IsTrue(propertyBuilder.PropertyBuilder.CanRead);
            Assert.IsFalse(propertyBuilder.PropertyBuilder.CanWrite);
        }

        [TestMethod()]
        public void DefineGetMethodByFieldTest()
        {
            var typeBuilder = CreateBuilder();
            var propertyBuilder = typeBuilder.DefineProperty("Name", typeof(string));

            propertyBuilder.DefineGetMethodByField();

            Assert.IsTrue(propertyBuilder.PropertyBuilder.CanRead);
            Assert.IsFalse(propertyBuilder.PropertyBuilder.CanWrite);
        }

        [TestMethod()]
        public void DefineSetMethodTest()
        {
            var typeBuilder = CreateBuilder();
            var propertyBuilder = typeBuilder.DefineProperty("Name", typeof(string));
            propertyBuilder.DefineSetMethod();

            Assert.IsFalse(propertyBuilder.PropertyBuilder.CanRead);
            Assert.IsTrue(propertyBuilder.PropertyBuilder.CanWrite);
        }

        [TestMethod()]
        public void DefineSetMethodByFieldTest()
        {
            var typeBuilder = CreateBuilder();
            var propertyBuilder = typeBuilder.DefineProperty("Name", typeof(string));

            propertyBuilder.DefineSetMethodByField();

            Assert.IsFalse(propertyBuilder.PropertyBuilder.CanRead);
            Assert.IsTrue(propertyBuilder.PropertyBuilder.CanWrite);
        }
    }
}
