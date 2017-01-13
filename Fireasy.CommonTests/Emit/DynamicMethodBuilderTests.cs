// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Emit.Test
{
    [TestClass()]
    public class DynamicMethodBuilderTests
    {
        private DynamicTypeBuilder CreateBuilder()
        {
            var assemblyBuilder = new DynamicAssemblyBuilder("assemblyTests");
            return assemblyBuilder.DefineType("testClass");
        }

        [TestMethod()]
        public void DefineParameterTest()
        {
            // Hello(string name);
            var typeBuilder = CreateBuilder();
            var methodBuilder = typeBuilder.DefineMethod("Hello", parameterTypes: new Type[] { typeof(string) });

            methodBuilder.DefineParameter("name");
            typeBuilder.CreateType();

            Assert.AreEqual("name", methodBuilder.MethodBuilder.GetParameters()[0].Name);
        }

        [TestMethod()]
        public void DefineParameterRefTest()
        {
            // Hello(ref string name);
            var typeBuilder = CreateBuilder();
            var methodBuilder = typeBuilder.DefineMethod("Hello", parameterTypes: new Type[] { typeof(string) });

            methodBuilder.DefineParameter("name", true);
            typeBuilder.CreateType();

            Assert.IsTrue(methodBuilder.MethodBuilder.GetParameters()[0].IsOut);
        }

        [TestMethod()]
        public void DefineParameterOptionalTest()
        {
            // Hello(string name = "fireasy");
            var typeBuilder = CreateBuilder();
            var methodBuilder = typeBuilder.DefineMethod("Hello", parameterTypes: new Type[] { typeof(string) });

            methodBuilder.DefineParameter("name", defaultValue: "fireasy");
            typeBuilder.CreateType();

            Assert.AreEqual("fireasy", methodBuilder.MethodBuilder.GetParameters()[0].DefaultValue);
        }

        [TestMethod()]
        public void AppendCodeTest()
        {
            var typeBuilder = CreateBuilder();
            var writeLineMethod = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) });
            var methodBuilder = typeBuilder.DefineMethod("Hello", calling: CallingDecoration.Static, ilCoding: context => { });

            methodBuilder.AppendCode(e => e.ldstr("Hello fireasy!").call(writeLineMethod));
            methodBuilder.AppendCode(e => e.ldstr("Hello world!").call(writeLineMethod).ret());

            var type = typeBuilder.CreateType();

            type.GetMethod("Hello").Invoke(null, null);
        }

        [TestMethod()]
        public void OverwriteCodeTest()
        {
            var typeBuilder = CreateBuilder();
            var writeLineMethod = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) });
            var methodBuilder = typeBuilder.DefineMethod("Hello", calling: CallingDecoration.Static, ilCoding: context =>
                context.Emitter.ldstr("Hello fireasy").call(writeLineMethod).ret());

            methodBuilder.OverwriteCode(e => e.ldstr("Hello world!").call(writeLineMethod).ret());

            var type = typeBuilder.CreateType();

            type.GetMethod("Hello").Invoke(null, null);
        }
    }
}
