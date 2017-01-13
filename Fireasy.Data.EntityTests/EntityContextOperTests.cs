using Fireasy.Data.Entity.Test.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Fireasy.Data.Entity.Tests
{
    [TestClass]
    public class EntityContextOperTests
    {
        private static MyDbContext db;
        private string par = "London";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            db = new MyDbContext();
            var d = from s in db.Categories
                    orderby s.CategoryID descending
                    select new { };
            //db.Products.Delete(s => s.ProductName.StartsWith("XXXX"));
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            db.Dispose();
        }

        [TestMethod]
        public void TestGet()
        {
            var c = db.Customers.Get("ALFKI");
            Console.WriteLine(c.CustomerID);
        }

        [TestMethod]
        public void TestInsert()
        {
            var p = new Products { ProductName = "XXXX1", Discontinued = true, ReorderLevel = RecorderLevel.A };
            var ret = db.Products.Insert(p);
            Console.WriteLine(p.ProductID);
            Assert.AreEqual(1, ret);
        }

        [TestMethod]
        public void TestUpdate1()
        {
            var ret = db.Orders.Get(10259);
            ret.CustomerID = "7tt7";
            db.Orders.Update(ret);
        }

        [TestMethod]
        public void TestBatchInsert()
        {
            var products = Enumerable.Range(0, 5).Select(i => new Products
            {
                ProductName = "XXXX" + i,
                Discontinued = false
            }).ToList();

            db.Products.Batch(products, (s, u) => s.Insert(u));
        }

        [TestMethod]
        public void TestBatchInsert1()
        {
            var products = Enumerable.Range(0, 5).Select(i => new Customers
            {
                Fax = "dd",
                CompanyName = "aa + " + i
            }).ToList();

            db.Customers.Batch(products, (s, u) => s.Insert(u));
        }

        [TestMethod]
        public void TestBatchInsert2()
        {
            var products = Enumerable.Range(0, 5).Select(i => new Customers
            {
                Fax = "dd",
                CompanyName = "aa + " + i
            }).ToList();

            db.Customers.Batch(products, (s, u) => s.Insert(u));
        }

        [TestMethod]
        public void TestBatchUpdate()
        {
            var products = Enumerable.Range(0, 20).Select(i => new Products
            {
                ProductID = i + 929,
                ProductName = "XXXX--d" + i,
                Discontinued = true
            });

            db.Products.Batch(products, (s, u) => s.Update(u));
        }

        [TestMethod]
        public void TestBatchUpdatePredicate()
        {
            var products = Enumerable.Range(0, 100).Select(i => new Products
            {
                ProductID = i,
                ProductName = "XXXX" + i
            });

            db.Products.Batch(products, (s, u) => s.Update(u, t => t.ProductID == u.ProductID));
        }

        [TestMethod]
        public void TestBatchDelete()
        {
            var details = Enumerable.Range(100000, 100).Select(i => new OrderDetails
            {
                OrderID = i,
            });

            db.OrderDetails.Batch(details, (s, u) => s.Delete(u, true));
        }

        [TestMethod]
        public void TestBatchDeletePredicate()
        {
            var details = Enumerable.Range(100000, 100).Select(i => new OrderDetails
            {
                OrderID = i,
            });

            db.OrderDetails.Batch(details, (s, u) => s.Delete(t => t.OrderID == u.OrderID, true));
        }

        [TestMethod]
        public void TestUpdate()
        {
            db.OrderDetails.Update(new OrderDetails { Discount = 9 }, s => s.OrderID == 10248);
        }

        [TestMethod]
        public void TestDelete()
        {
            db.OrderDetails.Delete(s => s.Discount == 100000);
        }

        [TestMethod]
        public void TestNoProxy()
        {
            var d = new Orders();
            d.CustomerID = "dfafd";

            db.Orders.Update(d, s => s.CustomerID.StartsWith("xxxx"));

            var d1 = db.Orders.Select(s => s.Customers.CustomerID).FirstOrDefault();
            Console.WriteLine(d1);

            db.Orders.Delete(new object[] { 3999999 });
        }

        [TestMethod]
        public void TestInsertRelated()
        {
            var order = new Orders { CustomerID = "ALFKI", OrderID = 10248 };
            //Console.WriteLine(order.OrderDetailses);
            order.OrderDetailses.AllowBatchInsert = false;
            order.OrderDetailses.Add(new OrderDetails { ProductID = 1 });
            order.OrderDetailses.Add(new OrderDetails { ProductID = 2 });
            order.OrderDetailses.Add(new OrderDetails { ProductID = 4 });
            order.OrderDetailses.Add(new OrderDetails { ProductID = 5 });

            db.Orders.Insert(order);

            var o1 = Orders.New();
            o1.OrderID = 10248;
            o1.OrderDate = DateTime.Now;

            db.Orders.Update(o1);

            var o2 = db.Orders.Get(1);
            o2.OrderDate = DateTime.Now;
            //db.Orders.Update(o2);
        }

        [TestMethod]
        public void TestInsertRelated1()
        {
            var order = new Orders { CustomerID = "ALFKI" };
            //Console.WriteLine(order.OrderDetailses);
            order.OrderDetailses = new EntitySet<OrderDetails>(
                new OrderDetails { ProductID = 1, UnitPrice = 2, Quantity = 2, Discount = 1 },
                new OrderDetails { ProductID = 2, UnitPrice = 2, Quantity = 2, Discount = 1 },
                new OrderDetails { ProductID = 4, UnitPrice = 2, Quantity = 2, Discount = 1 },
                new OrderDetails { ProductID = 5, UnitPrice = 2, Quantity = 2, Discount = 1 });

            db.Orders.Insert(order);
            Console.WriteLine(order.OrderDetailses[0].OrderID);
        }

        [TestMethod]
        public void TestUpdateRelation()
        {
            var detail = db.OrderDetails.FirstOrDefault();
            detail.Discount = 11;
            detail.Orders.OrderDate = DateTime.Now;
            detail.Orders.Customers.City = "kunming";

            db.OrderDetails.Update(detail);
        }

        [TestMethod]
        public void TestUpdateRelation1()
        {
            var order = db.Orders.FirstOrDefault();
            order.OrderDetailses[0].Discount = new Random().Next(100);
            order.OrderDetailses[0].Orders.OrderDate = DateTime.Now;
            order.OrderDetailses[0].Orders.Customers.City = new Random().Next(100).ToString();

            order.OrderDetailses.RemoveAt(1);

            db.Orders.Update(order);
        }

        [TestMethod]
        public void TestUpdateRelation2()
        {
            var order = db.Orders.FirstOrDefault();
            order.OrderDetailses.AllowBatchUpdate = true;
            foreach (var p in order.OrderDetailses)
            {
                p.Discount = new Random().Next(100);
            }

            db.Orders.Update(order);
        }

        [TestMethod]
        public void TestConcurrencyLocking()
        {
            var p = db.Products.FirstOrDefault();
            p.ProductName = "dfasdfsaf";

            db.Products.Update(p);
        }
    }
}
