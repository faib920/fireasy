using Fireasy.Data.Entity.Test.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Fireasy.Data.Entity.Test
{
    [TestClass]
    public class EntityTreePersisterTests
    {
        private static MyDbContext db;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            db = new MyDbContext();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            db.Dispose();
        }

        [TestMethod]
        public void RecurrenceParentTest()
        {
            var dept = db.Depts.FirstOrDefault(s => s.Code == "000100010001");
            var persister = db.CreateTreePersister<Dept>();
            foreach (var item in persister.RecurrenceParent(dept).Select(s => s.Code))
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod]
        public void RecurrenceParentTest1()
        {
            var dept = db.Depts.FirstOrDefault(s => s.Code == "0100101");
            var persister = db.CreateTreePersister<Dept>();
            foreach (var item in persister.RecurrenceParent(dept).Select(s => s.Code))
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod]
        public void HasChildrenTest()
        {
            var dept = db.Depts.FirstOrDefault(s => s.Code == "000100010001");
            var persister = db.CreateTreePersister<Dept>();
            Console.WriteLine(persister.HasChildren(dept));
        }

        [TestMethod]
        public void HasChildrenTest1()
        {
            var dept = db.Depts.FirstOrDefault(s => s.Code == "01001");
            var persister = db.CreateTreePersister<Dept>();
            Console.WriteLine(persister.HasChildren(dept));
        }

        [TestMethod]
        public void QueryChildrenTest()
        {
            var dept = db.Depts.FirstOrDefault(s => s.Code == "0001");
            var persister = db.CreateTreePersister<Dept>();
            foreach (var item in persister.QueryChildren(dept).Select(s => s.Code))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(persister.QueryChildren(dept).FirstOrDefault().Code);
        }

        [TestMethod]
        public void QueryChildrenTest1()
        {
            var dept = db.Depts.FirstOrDefault(s => s.Code == "01");
            var persister = db.CreateTreePersister<Dept>();
            foreach (var item in persister.QueryChildren(dept).Select(s => s.Code))
            {
                Console.WriteLine(item);
            }

           // Console.WriteLine(persister.QueryChildren(dept).FirstOrDefault().Code);
        }
    }
}
