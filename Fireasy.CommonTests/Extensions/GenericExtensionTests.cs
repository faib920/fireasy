// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.Dynamic;
using Fireasy.Common.Dynamic;
using System.Collections;

namespace Fireasy.Common.Extensions.Test
{
    /// <summary>
    /// GenericExtensionTests类。
    /// </summary>
    [TestClass()]
    public class GenericExtensionTests
    {
        /// <summary>
        /// 测试IsNullOrEmpty方法。
        /// </summary>
        [TestMethod()]
        public void IsNullOrEmptyTest()
        {
            var list = new List<string>();
            object obj = null;
            int? i = null;

            Console.WriteLine(list.IsNullOrEmpty());
            Console.WriteLine(obj.IsNullOrEmpty());
            Assert.IsTrue(i.IsNullOrEmpty());
        }

        /// <summary>
        /// 使用可空类型的数据测试AssertNotNull方法。
        /// </summary>
        [TestMethod()]
        public void AssertNotNullForNullableTypeTest()
        {
            DateTime? date1 = null;
            DateTime? date2 = DateTime.Parse("2009-1-1");

            Assert.IsNull(date1.AssertNotNull(s => s.ToShortDateString()));
            Assert.AreEqual("2009-01-01", date2.AssertNotNull(s => s.ToString("yyyy-MM-dd")));
        }

        /// <summary>
        /// 使用可空类型的数据测试AssertNotNull方法。
        /// </summary>
        [TestMethod()]
        public void AssertNotNullTest()
        {
            object obj = null;
            Assert.IsNull(obj.AssertNotNull(s => s.ToString()));
        }

        /// <summary>
        /// 测试Action参数的AssertNotNull方法。
        /// </summary>
        [TestMethod()]
        public void AssertNotNullForActionTest()
        {
            DateTime? date2 = DateTime.Parse("2009-1-1");
            var text = string.Empty;

            date2.AssertNotNull(s => text = s.ToString("yyyy-MM-dd"));

            Assert.AreEqual("2009-01-01", text);
        }

        /// <summary>
        /// 测试TryDispose方法。
        /// </summary>
        [TestMethod()]
        public void TryDisposeTest()
        {
            var dispose = new DisposeTest();
            dispose.TryDispose();

            Assert.IsTrue(dispose.IsDisposed);
        }

        [TestMethod()]
        public void AsTest()
        {
            var obj = new GenericData { Name = "fireasy" };
            Assert.IsNotNull(obj.As<IName>());
            Assert.IsNull(obj.As<IDisposable>());
        }

        [TestMethod()]
        public void AsTestWithAction()
        {
            var name1 = string.Empty;
            var name2 = string.Empty;

            var obj = new GenericData { Name = "fireasy" };
            obj.As<IName>(s => name1 = s.Name, () => name1 = "none");
            obj.As<IName1>(s => name2 = s.Name, () => name2 = "none");

            Assert.AreEqual("fireasy", name1);
            Assert.AreEqual("none", name2);
        }

        [TestMethod()]
        public void IsTest()
        {
            var obj = new GenericData { Name = "fireasy" };

            Assert.IsTrue(obj.Is<IName>());
            Assert.IsFalse(obj.Is<IName1>());
        }

        [TestMethod()]
        public void ToStringSafelyTest()
        {
            GenericData data = null;

            //使用ToString()将抛出异常
            Assert.AreEqual(string.Empty, data.ToStringSafely());
        }

        [TestMethod()]
        public void IsBetweenTest()
        {
            Assert.IsTrue(88.IsBetween(78, 90, new ValueComparer<int>()));
        }

        [TestMethod()]
        public void IsBetweenWithLowerBoundTest()
        {
            Assert.IsTrue(78.IsBetween(78, 90, new ValueComparer<int>(), true));
            Assert.IsFalse(78.IsBetween(78, 90, new ValueComparer<int>()));
        }

        [TestMethod()]
        public void IsBetweenWithUpperBoundTest()
        {
            Assert.IsTrue(90.IsBetween(78, 90, new ValueComparer<int>(), includeUpperBound: true));
            Assert.IsFalse(90.IsBetween(78, 90, new ValueComparer<int>()));
        }

        [TestMethod()]
        public void ToTest()
        {
            Console.WriteLine(Uri.EscapeUriString("中在地:= %3cabcdefgaadfadsfafdadfadf"));
            Console.WriteLine(Uri.EscapeDataString("中在地:= %3cabcdefgaadfadsfafdadfadf"));
            //Assert.AreEqual(1, "1".To<int>());
            //Assert.AreEqual(null, "".To<int?>());
            //Assert.AreEqual(33.34m, "33.34".To<decimal>());
            //Assert.AreEqual(true, "1".To<bool>());
            //Assert.AreEqual(true, "true".To<bool>());
            //Assert.AreEqual(Enum1.B, "1".To<Enum1>());
            //Assert.AreEqual(null, "".To<Enum1?>());
            //Assert.AreEqual(null, "2014.05".To<DateTime?>());
        }

        [TestMethod()]
        public void ToExTest()
        {
            var d = new Class1 { Name = "aa", Items = new List<Class1_1> { new Class1_1 { Add = "aa" } } };
            var s = d.To<Class2>();
            Assert.AreEqual(1, s.Items.Count);
            Assert.AreEqual("Class2_1", s.Items[0].GetType().Name);
        }

        [TestMethod()]
        public void ToWithDefaultTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToTypeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExtendTest()
        {
            var s = (dynamic)new { name = "fireasy", sex = 0 }.Extend(new { address = "kunming" });
            Assert.AreEqual("kunming", s.address);
        }

        [TestMethod()]
        public void ExtendForValueTypeTest()
        {
            var s = (dynamic)5.Extend(new { address = "kunming" });
            Assert.AreEqual("kunming", s.address);
        }

        [TestMethod()]
        public void ExtendForExpandoObjectTest()
        {
            var d1 = (IDictionary<string, object>)new ExpandoObject();
            var d2 = (IDictionary<string, object>)new ExpandoObject();
            d1.Add("a1", 45);
            d2.Add("b1", 77);

            var s = (dynamic)d1.Extend(d2);
            var pds = TypeDescriptor.GetProperties(s);
            Console.WriteLine(pds.Count);
            Assert.AreEqual(45, s.a1);
        }

        [TestMethod()]
        public void ExtendAsTest()
        {
            var d = new Data1 { Name = "fireasy" };
            var d2 = d.ExtendAs<Data2>(new { Age = 12 });
            Console.WriteLine(d2.GetType().Name);
            Assert.AreEqual(12, d2.Age);
        }

        [TestMethod()]
        public void ToDynamicTest()
        {
            dynamic d = new { A = "dfadsf" }.ToDynamic();

            Console.WriteLine(d.A);

            foreach (PropertyDescriptor p in TypeDescriptor.GetProperties(d))
            {
                Console.WriteLine(p.GetValue(d));
            }
        }

        [TestMethod()]
        public void ToSubClassTest()
        {
            var d = new Data2 { Name = "huangxd" };
            Console.WriteLine(d.To<Data1>().Name);
        }

        [TestMethod()]
        public void ToOtherTypeTest()
        {
            var d = new Data1 { Name = "huangxd" };
            Console.WriteLine(d.To<Data2>().Name);
        }

        [TestMethod()]
        public void ToUseAbstractTest()
        {
            var d = new { Name = "huangxd" };
            Console.WriteLine(d.To<Data3>().Name);
        }

        [TestMethod()]
        public void ToUseInterfaceTest()
        {
            var d = new { Name = "huangxd" };
            Console.WriteLine(d.To<IName>().Name);
        }

        [TestMethod()]
        public void ToListTest()
        {
            var array = new List<object>();
            array.Add(new { Name = "huangxd" });
            array.Add(new { Name = "liming" });
            Console.WriteLine(array.To<List<IName>>().Count);
            Console.WriteLine(array.To<List<IName>>()[0].Name);
        }

        [TestMethod()]
        public void ToArrayTest()
        {
            var array = new ArrayList();
            array.Add(new { Name = "huangxd" });
            array.Add(new { Name = "liming" });
            Console.WriteLine(array.To<IName[]>().Length);
        }

        [TestMethod()]
        public void ToDictionaryTest()
        {
            var array = new ArrayList();
            array.Add(new { Key = "huangxd", Value = 2 });
            array.Add(new { Key = "liming", Value = 4 });
            Console.WriteLine(array.To<Dictionary<string, int>>().Count);
        }

        private struct A
        {
            public string Name { get; set; }
        }

        public interface IName
        {
            string Name { get; set; }
        }

        private interface IName1
        {
            string Name { get; set; }
        }

        private class GenericData : IName
        {
            public string Name { get; set; }
        }

        private class DisposeTest : IDisposable
        {
            public bool IsDisposed { get; set; }

            void IDisposable.Dispose()
            {
                IsDisposed = true;
            }
        }

        private class ValueComparer<T> : Comparer<T> where T : IComparable<T>
        {
            public override int Compare(T x, T y)
            {
                if (x == null)
                {
                    return -1;
                }

                if (y == null)
                {
                    return 1;
                }

                return x.CompareTo(y);
            }
        }

        private enum Enum1
        {
            A = 0,
            B = 1,
        }

        public class Data1
        {
            public string Name { get; set; }
        }

        public abstract class Data3
        {
            public string Name { get; set; }
        }

        public class Data2 : Data1
        {
            public int Age { get; set; }
        }

        public class Class1
        {
            public string Name { get; set; }

            public List<Class1_1> Items { get; set; }
        }

        public class Class1_1
        {
            public string Add { get; set; }
        }

        public class Class2
        {
            public string Name { get; set; }

            public List<Class2_1> Items { get; set; }
        }

        public class Class2_1
        {
            public string Add { get; set; }
        }
    }
}
