// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Fireasy.Common.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Fireasy.Common.Extensions.Test
{
    [TestClass()]
    public class ReflectionExtensionTests
    {
        [TestMethod()]
        public void GetMemberTypeTest()
        {
            var d = new ReflectionData { Name = "fireasy", TypeName = "type" };
            var type = typeof(ReflectionData).GetType();

            Console.WriteLine(type.GetMember("Name")[0].GetMemberType());
            Console.WriteLine(type.GetMember("TypeName")[0].GetMemberType());
            Console.WriteLine(type.GetMember("Change")[0].GetMemberType());
            Console.WriteLine(type.GetMember("GetAge")[0].GetMemberType());
        }

        [TestMethod]
        public void GetMemberValueTest()
        {
            var d = new ReflectionData { Name = "fireasy", TypeName = "type" };
            var type = d.GetType();
            Console.WriteLine(type.GetMember("Name")[0].GetMemberValue(d));
            Console.WriteLine(type.GetMember("TypeName")[0].GetMemberValue(d));
        }

        [TestMethod()]
        public void GetCustomAttributesTest()
        {
            Attribute[] attrs = typeof(ReflectionData).GetCustomAttributes<SerializableAttribute>().ToArray();
            Assert.AreEqual(1, attrs.Length);

            attrs = typeof(ReflectionData).GetCustomAttributes<AttributeUsageAttribute>().ToArray();
            Assert.AreEqual(0, attrs.Length);
            Console.WriteLine(MethodBase.GetCurrentMethod().GetCustomAttributes<TestMethodAttribute>().ToArray().Length);
        }

        [TestMethod()]
        public void IsDefinedTest()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().IsDefined<TestMethodAttribute>());
        }

        [TestMethod()]
        public void CloneToTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CompareTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FastSetPropertyValueTest()
        {
            var p = typeof(ReflectionData).GetProperty("Name");

            var t = TimeWatcher.Watch(() =>
                {
                    var s = new ReflectionData();
                    for (var i = 0; i < 10000000; i++)
                    {
                        p.SetValue(s, "A");
                    }
                });

            Console.WriteLine("反射:" + t);

            var ps = Reflection.ReflectionCache.GetAccessor(p);
            t = TimeWatcher.Watch(() =>
                {
                    var s = new ReflectionData();
                    for (var i = 0; i < 10000000; i++)
                    {
                        ps.SetValue(s, "A");
                    }
                });

            Console.WriteLine("缓存:" + t);
            t = TimeWatcher.Watch(() =>
                {
                    var s = new ReflectionData();
                    for (var i = 0; i < 10000000; i++)
                    {
                        s.Name = "A";
                    }
                });

            Console.WriteLine("直接:" + t);
        }

        [TestMethod]
        public void ParallelTest()
        {
            var p = typeof(ReflectionData).GetProperty("Name");
            System.Threading.Tasks.Parallel.For(0, 100, (i) =>
                {
                    var ps = Reflection.ReflectionCache.GetAccessor(p);
                    Console.WriteLine(i.ToString() + " " + ps.ToString());
                });
        }

        [Serializable]
        private class ReflectionData
        {
            public string TypeName;

            public event EventHandler Change;

            [TextSerializeElement("name")]
            public string Name { get; set; }

            public int GetAge()
            {
                return 0;
            }
        }
    }
}
