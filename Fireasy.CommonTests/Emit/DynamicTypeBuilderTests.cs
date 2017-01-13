// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Reflection;
using Fireasy.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Emit.Test
{
    [TestClass()]
    public class DynamicTypeBuilderTests
    {
        private DynamicTypeBuilder CreateBuilder()
        {
            var assemblyBuilder = new DynamicAssemblyBuilder("assemblyTests");
            return assemblyBuilder.DefineType("testClass");
        }

        /// <summary>
        /// 测试CreateType方法。
        /// </summary>
        [TestMethod()]
        public void CreateTypeTest()
        {
            var typeBuilder = CreateBuilder();
            var type = typeBuilder.CreateType();

            Assert.IsNotNull(type);
        }

        /// <summary>
        /// 测试BaseType属性。
        /// </summary>
        [TestMethod()]
        public void BaseTypeTest()
        {
            var typeBuilder = CreateBuilder();
            typeBuilder.BaseType = typeof(DynamicBuilderBase);
            var type = typeBuilder.CreateType();

            Assert.AreEqual(typeof(DynamicBuilderBase), type.BaseType);
        }

        /// <summary>
        /// 测试ImplementInterface方法。
        /// </summary>
        [TestMethod()]
        public void ImplementInterfaceTest()
        {
            var typeBuilder = CreateBuilder();
            typeBuilder.ImplementInterface(typeof(IDynamicInterface));
            var type = typeBuilder.CreateType();

            Assert.IsTrue(typeof(IDynamicInterface).IsAssignableFrom(type));
        }

        /// <summary>
        /// 使用接口成员测试ImplementInterface方法。
        /// </summary>
        [TestMethod()]
        public void ImplementInterfaceWithMemberTest()
        {
            var typeBuilder = CreateBuilder();
            typeBuilder.ImplementInterface(typeof(IDynamicPropertyInterface));
            typeBuilder.DefineProperty("Name", typeof(string)).DefineGetSetMethods();

            var type = typeBuilder.CreateType();

            Assert.IsTrue(typeof(IDynamicPropertyInterface).IsAssignableFrom(type));
            Assert.IsNotNull(type.GetProperty("Name"));
        }

        /// <summary>
        /// 测试DefineProperty方法。
        /// </summary>
        [TestMethod()]
        public void DefinePropertyTest()
        {
            var typeBuilder = CreateBuilder();

            typeBuilder.DefineProperty("Name", typeof(string)).DefineGetSetMethods();
            var type = typeBuilder.CreateType();

            Assert.IsNotNull(type.GetProperty("Name"));
        }

        /// <summary>
        /// 测试DefineMethod方法。
        /// </summary>
        [TestMethod()]
        public void DefineMethodTest()
        {
            var typeBuilder = CreateBuilder();

            typeBuilder.DefineMethod("HelloWorld");
            var type = typeBuilder.CreateType();

            Assert.IsNotNull(type.GetMethod("HelloWorld"));
        }

        /// <summary>
        /// 使用泛型参数测试DefineMethod方法。
        /// </summary>
        [TestMethod()]
        public void DefineGenericMethodTest()
        {
            var typeBuilder = CreateBuilder();

            // Helo<T1, T2>(string name, T1 any1, T2 any2)
            var methodBuilder = typeBuilder.DefineMethod("Hello", parameterTypes: new Type[] { typeof(string), null, null });
            methodBuilder.GenericArguments = new string[] { string.Empty, "T1", "T2" };
            methodBuilder.DefineParameter("name");
            methodBuilder.DefineParameter("any1");
            methodBuilder.DefineParameter("any2");

            var type = typeBuilder.CreateType();

            var method = type.GetMethod("Hello");
            Assert.IsNotNull(method);
            Assert.IsTrue(method.IsGenericMethod);
        }

        /// <summary>
        /// 使用重写抽象类方法测试DefineMethod方法。
        /// </summary>
        [TestMethod()]
        public void DefineOverrideMethodTest()
        {
            var typeBuilder = CreateBuilder();
            typeBuilder.BaseType = typeof(DynamicBuilderBase);

            typeBuilder.DefineMethod("Hello", parameterTypes: new Type[] { typeof(string) }, ilCoding: (context) =>
                {
                    context.Emitter
                        .ldarg_0
                        .ldarg_1
                        .call(typeBuilder.BaseType.GetMethod("Hello"))
                        .ret();
                });
            var type = typeBuilder.CreateType();

            var method = type.GetMethod("Hello");
            Assert.IsNotNull(method);
            method.Invoke(type.New(), new object[] { "fireasy" });
        }

        /// <summary>
        /// 测试DefineConstructor方法。
        /// </summary>
        [TestMethod()]
        public void DefineConstructorTest()
        {
            var typeBuilder = CreateBuilder();

            typeBuilder.DefineConstructor(new Type[] { typeof(string), typeof(int) }).AppendCode(e => e.ret());
            var type = typeBuilder.CreateType();

            var constructor = type.GetConstructors()[0];
            Assert.IsNotNull(constructor);
            Assert.AreEqual(2, constructor.GetParameters().Length);
        }

        /// <summary>
        /// 测试DefineField方法。
        /// </summary>
        [TestMethod()]
        public void DefineFieldTest()
        {
            var typeBuilder = CreateBuilder();

            typeBuilder.DefineField("Name", typeof(string));
            var type = typeBuilder.CreateType();

            Assert.IsNotNull(type.GetField("Name", BindingFlags.NonPublic | BindingFlags.Instance));
        }

        /// <summary>
        /// 使用公有特性测试DefineField方法。
        /// </summary>
        [TestMethod()]
        public void DefineFieldWithPublicTest()
        {
            var typeBuilder = CreateBuilder();

            typeBuilder.DefineField("Name", typeof(string), VisualDecoration.Public);
            var type = typeBuilder.CreateType();

            Assert.IsNotNull(type.GetField("Name"));
        }

        /// <summary>
        /// 测试DefineNestedType方法。
        /// </summary>
        [TestMethod()]
        public void DefineNestedTypeTest()
        {
            var typeBuilder = CreateBuilder();

            var nestedType = typeBuilder.DefineNestedType("nestedClass");
            var type = typeBuilder.CreateType();

            Assert.IsNotNull(type.GetNestedType("nestedClass", BindingFlags.NonPublic));
        }

        public interface IDynamicInterface
        {
        }

        public interface IDynamicPropertyInterface
        {
            string Name { get; set; }
        }

        public class DynamicBuilderBase
        {
            public virtual void Hello(string name)
            {
                Console.WriteLine("Hello " + name);
            }
        }
    }
}
