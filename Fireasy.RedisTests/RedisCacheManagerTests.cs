using Fireasy.Common.Caching;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Fireasy.Redis
{
    [TestClass]
    public class RedisCacheManagerTests
    {
        [TestMethod]
        public void TestGet()
        {
            var cache = CacheManagerFactory.CreateManager();
            Console.WriteLine(cache.Get<string>("test"));
        }

        [TestMethod]
        public void TestAdd()
        {
            var cache = CacheManagerFactory.CreateManager();
            cache.Add<Student>("s7", new Student { Name = "fireasy", Address = "aa" });
            var student = cache.Get<Student>("s7");
            Assert.IsNotNull(student);
            Assert.AreEqual("fireasy", student.Name);
            Assert.AreEqual(true, cache.Contains<Student1>("s7"));
        }

        [TestMethod]
        public void TestTryAdd()
        {
            var cache = CacheManagerFactory.CreateManager();
            var student = cache.TryGet<Student>("s0", () => new Student { Name = "fireasy", Address = "aa" });
            Assert.IsNotNull(student);
            Assert.AreEqual("fireasy", student.Name);
        }

        [TestMethod]
        public void TestAddList()
        {
            var cache = CacheManagerFactory.CreateManager();
            var students = new List<Student>();
            for (var i = 0; i < 10000; i++ )
            {
                students.Add(new Student { Name = "fireasy" + i, Address = "aa", Birthday = DateTime.Now });
            }
            cache.Add<List<Student>>("s2", students);
            students = cache.Get<List<Student>>("s2");
            Assert.AreEqual(10000, students.Count);
            Assert.AreEqual("fireasy0", students[0].Name);
        }

        [Serializable]
        public class Student
        {
            public string Name { get; set; }

            public string Address { get; set; }

            public DateTime Birthday { get; set; }
        }

        public class Student1
        {

        }
    }
}
