// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Extensions.Test
{
    /// <summary>
    /// TypeExtensionTests类。
    /// </summary>
    [TestClass()]
    public class TypeExtensionTests
    {
        [TestMethod()]
        public void GetTypeTest()
        {
            var type = "Fireasy.Common.Test.UtilityTests, Fireasy.CommonTests".GetType();
            Assert.IsNotNull(type);
        }

        [TestMethod()]
        public void GetTypeOutTest()
        {
            var type = "System.Data.DataTable, System.Data".GetType();
            Assert.IsNotNull(type);
        }

        /// <summary>
        /// 测试New方法。
        /// </summary>
        [TestMethod()]
        public void NewTest()
        {
            Assert.IsNotNull(typeof(DateTime).New());
        }

        /// <summary>
        /// 带参数测试New方法。
        /// </summary>
        [TestMethod()]
        public void NewWithParametersTest()
        {
            Assert.AreEqual(new DateTime(2009, 2, 12), typeof(DateTime).New<DateTime>(2009, 2, 12));
        }

        /// <summary>
        /// 测试GetDefaultValue方法。
        /// </summary>
        [TestMethod()]
        public void GetDefaultValueTest()
        {
            Assert.AreEqual(0, typeof(int).GetDefaultValue());
            Assert.AreEqual(DateTime.Now, typeof(DateTime).GetDefaultValue());
        }

        /// <summary>
        /// 测试IsNullableType方法。
        /// </summary>
        [TestMethod()]
        public void IsNullableTypeTest()
        {
            Assert.IsTrue(typeof(int?).IsNullableType());
            Assert.IsFalse(typeof(int).IsNullableType());
        }

        /// <summary>
        /// 测试IsConcreteType方法。
        /// </summary>
        [TestMethod()]
        public void IsConcreteTypeTest()
        {
            Assert.IsTrue(typeof(ConcreteClass).IsConcreteType());
            Assert.IsFalse(typeof(AbstractClass).IsConcreteType());
        }

        /// <summary>
        /// 测试GetHierarchyTypes方法。
        /// </summary>
        [TestMethod()]
        public void GetHierarchyTypesTest()
        {
            foreach (var t in typeof(TList<string>).GetHierarchyTypes())
            {
                Console.WriteLine(t);
            }
        }

        /// <summary>
        /// 测试EachBaseTypes方法。
        /// </summary>
        [TestMethod()]
        public void EachBaseTypesTest()
        {
            foreach (var t in typeof(TList<string>).EachBaseTypes())
            {
                Console.WriteLine(t);
            }
        }

        /// <summary>
        /// 测试GetNonNullableType方法。
        /// </summary>
        [TestMethod()]
        public void GetNonNullableTypeTest()
        {
            Assert.AreEqual(typeof(int), typeof(int?).GetNonNullableType());
        }

        /// <summary>
        /// 测试GetNullableType方法。
        /// </summary>
        [TestMethod()]
        public void GetNullableTypeTest()
        {
            Assert.AreEqual(typeof(int?), typeof(int).GetNullableType());
        }

        /// <summary>
        /// 测试IsNumericType方法。
        /// </summary>
        [TestMethod()]
        public void IsNumericTypeTest()
        {
            Assert.IsTrue(typeof(int).IsNumericType());
            Assert.IsFalse(typeof(decimal?).IsNumericType());
            Assert.IsFalse(typeof(string).IsNumericType());
        }

        /// <summary>
        /// 测试GetImplementType方法。
        /// </summary>
        [TestMethod()]
        public void GetImplementTypeTest()
        {
            Assert.AreEqual(null, typeof(TList<string>).GetImplementType(typeof(ICustomListNoMember)));
            Assert.AreEqual(typeof(TList<string>), typeof(MList<string>).GetImplementType(typeof(ICustomListNoMember)));
        }

        /// <summary>
        /// 测试IsImplementInterface方法。
        /// </summary>
        [TestMethod()]
        public void IsImplementInterfaceTest()
        {
            Assert.IsTrue(typeof(TList<string>).IsImplementInterface(typeof(ICustomListNoMember)));
            Assert.IsTrue(typeof(TList<string>).IsImplementInterface(typeof(IEnumerable<string>)));
            Assert.IsFalse(typeof(List<string>).IsImplementInterface(typeof(ICustomListNoMember)));
        }

        /// <summary>
        /// 测试IsDirectImplementInterface方法。
        /// </summary>
        [TestMethod()]
        public void IsDirectImplementInterfaceTest()
        {
            Assert.IsTrue(typeof(List<string>).IsDirectImplementInterface(typeof(IList<string>)));
            Assert.IsFalse(typeof(TList<string>).IsDirectImplementInterface(typeof(IList<string>)));
        }

        /// <summary>
        /// 测试IsDirectImplementInterface方法。
        /// </summary>
        [TestMethod()]
        public void IsDirectImplementInterfaceWithoutMethodTest()
        {
            //如果接口没有成员，则此方法不能够获得正确的信息
            Assert.IsFalse(typeof(TList<string>).IsDirectImplementInterface(typeof(ICustomListNoMember)));
            Assert.IsTrue(typeof(TList<string>).IsDirectImplementInterface(typeof(ICustomList)));
        }

        /// <summary>
        /// 测试GetDirectImplementInterface方法。
        /// </summary>
        [TestMethod()]
        public void GetDirectImplementInterfaceTest()
        {
            Assert.AreEqual(typeof(ICustomListNoMember), typeof(MList<string>).GetDirectImplementInterface(typeof(ICustomListNoMember)));
        }

        /// <summary>
        /// 测试IsAnonymousType方法。
        /// </summary>
        [TestMethod()]
        public void IsAnonymousTypeTest()
        {
            var obj = new { Name = "" };
            Assert.IsTrue(obj.GetType().IsAnonymousType());
            Assert.IsFalse(typeof(int).IsAnonymousType());
        }

        /// <summary>
        /// 测试GetEnumerableElementType方法。
        /// </summary>
        [TestMethod()]
        public void GetEnumerableElementTypeTest()
        {
            Assert.AreEqual(typeof(string), typeof(MList<string>).GetEnumerableElementType());
            Assert.AreEqual(typeof(string), typeof(string[]).GetEnumerableElementType());
            Assert.AreEqual(null, typeof(string).GetEnumerableElementType());
            Assert.AreEqual(typeof(KeyValuePair<string, int>), typeof(Dictionary<string, int>).GetEnumerableElementType());
        }

        /// <summary>
        /// 测试GetEnumerableType方法。
        /// </summary>
        [TestMethod()]
        public void GetEnumerableTypeTest()
        {
            Assert.AreEqual(typeof(IEnumerable<KeyValuePair<string, int>>), typeof(Dictionary<string, int>).GetEnumerableType());
            Assert.AreEqual(typeof(IEnumerable<string>), typeof(MList<string>).GetEnumerableType());
            Assert.AreEqual(null, typeof(string).GetEnumerableType());
        }

        private abstract class AbstractClass
        {
        }

        private class ConcreteClass : AbstractClass
        {
        }

        private class TList<T> : List<T>, ICustomListNoMember, ICustomList
        {
            public void Test()
            {
            }
        }

        private class MList<T> : TList<T>
        {
        }

        private interface ICustomListNoMember
        {
        }

        private interface ICustomList
        {
            void Test();
        }
    }
}
