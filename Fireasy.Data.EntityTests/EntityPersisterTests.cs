// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Serialization;
using Fireasy.Data.Entity.Linq;
using Fireasy.Data.Entity.Test.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Fireasy.Data.Entity.Test
{
    [TestClass()]
    public class EntityPersisterTests : DbTestBase
    {
        [TestMethod()]
        public void EntityPersisterTest()
        {
            using (var per = new EntityPersister<Products>())
            {
                Assert.IsNotNull(per);
            }
        }

        [TestMethod()]
        public void EntityPersisterWithInstanceTest()
        {
            using (var per = new EntityPersister<Products>("sqlite"))
            {
                Assert.IsNotNull(per);
            }
        }

        [TestMethod()]
        public void GetEntityTypeTest()
        {
            using (var per = new EntityPersister<Products>(instanceName))
            {
                Assert.AreEqual(typeof(Products), per.GetEntityType());
            }
        }

        [TestMethod()]
        public void CreateTest()
        {
            using (var per = new EntityPersister<Categories>(instanceName))
            {
                var product = new Categories { CategoryID = 1, CategoryName = "dd", Description = "aa" };
                per.Create(product);
            }
        }

        [TestMethod()]
        public void BatchCreateTest()
        {
            using (var scope = new EntityTransactionScope())
            using (var per = new EntityPersister<Categories>(instanceName))
            {
                var products = new List<Categories>();
                for (var i = 0; i < 1000; i++)
                {
                    products.Add(new Categories { CategoryID = i + 1, CategoryName = "测试" + i, Description = "aa" });
                }

                per.BatchCreate(products);

                scope.Complete();
            }
        }

        /// <summary>
        /// 使用手动设置ID测试Create方法
        /// </summary>
        [TestMethod()]
        public void CreateWithManualIdTest()
        {
            using (var per = new EntityPersister<Customers>(instanceName))
            {
                var customer = new Customers { CustomerID = Guid.NewGuid().ToString(), CompanyName = "fireasy" };
                per.Create(customer);
            }
        }

        /// <summary>
        /// 根据Identity测试Create方法。
        /// </summary>
        [TestMethod()]
        public void CreateForIdentityTest()
        {
            using (var per = new EntityPersister<Identitys>(instanceName))
            {
                //Id1 为自增长类型
                //Id2 使用生成器生成
                //Id3 Guid
                var identity = new Identitys();
                per.Create(identity);

                Console.WriteLine(identity.Id1);
                Console.WriteLine(identity.Id2);
                Console.WriteLine(identity.Id3);
            }
        }

        [TestMethod()]
        public void CloneTest()
        {
            using (var per = new EntityPersister<Products>(instanceName))
            {
                var product = per.Query().FirstOrDefault();
                var newProduct = product.Clone();
            }
        }

        [TestMethod()]
        public void SaveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveTest2()
        {
            Assert.Fail();
        }

        /// <summary>
        /// 测试Query方法。
        /// </summary>
        [TestMethod()]
        public void QueryTest()
        {
            using (var per = new EntityPersister<Products>(instanceName))
            {
                foreach (var p in per.Query(s => true))
                {
                    Console.WriteLine(p.ProductName);
                }
            }
        }

        /// <summary>
        /// 测试Query方法。
        /// </summary>
        [TestMethod()]
        public void QueryFirstTest()
        {
            using (var per = new EntityPersister<Products>(instanceName))
            {
                var p = per.Query().FirstOrDefault();
                Assert.IsNotNull(p);
            }
        }

        /// <summary>
        /// 测试序列化方法。
        /// </summary>
        [TestMethod()]
        public void QuerySerializeTest()
        {
            using (var per = new EntityPersister<Products>(instanceName))
            {
                //TypeDescriptor.RemoveProvider(new EntityTypeDescriptionProvider(), typeof(EntityObject));
                var p = per.Query().FirstOrDefault();
                var json = new JsonSerializer();
                Console.WriteLine(json.Serialize(p));
            }
        }

        /// <summary>
        /// 使用条件测试Query方法。
        /// </summary>
        [TestMethod()]
        public void QueryForWhereTest()
        {
            using (var per = new EntityPersister<Products>(instanceName))
            {
                foreach (var p in per.Query(s => true).Where(s => (string)s.ProductName == "11"))
                {
                    Console.WriteLine(p.ProductName);
                }
            }
        }

        /// <summary>
        /// 使用排序测试Query方法。
        /// </summary>
        [TestMethod()]
        public void QueryForOrderTest()
        {
            using (var per = new EntityPersister<Products>(instanceName))
            {
                foreach (var p in per.Query(s => true).OrderBy(s => s.ProductName))
                {
                    Console.WriteLine(p.ProductName);
                }
            }
        }

        /// <summary>
        /// 使用复合排序测试Query方法。
        /// </summary>
        [TestMethod()]
        public void QueryForMutilOrderTest()
        {
            using (var per = new EntityPersister<Products>(instanceName))
            {
                foreach (var p in per.Query(s => true).OrderBy(s => new { Productid = s.ProductID, Productname = s.ProductName } ))
                {
                    Console.WriteLine(p.ProductName);
                }
            }
        }

        /// <summary>
        /// 使用返回匿名类型测试Query方法。
        /// </summary>
        [TestMethod()]
        public void QueryForAnonymousTest()
        {
            using (var per = new EntityPersister<Products>(instanceName))
            {
                foreach (var p in per.Query(s => true).OrderBy(s => s.ProductName).Select(s => new { Productname = s.ProductName } ))
                {
                    Console.WriteLine(p.Productname);
                }
            }
        }

        /// <summary>
        /// 使用返回匿名类型测试Query方法。
        /// </summary>
        [TestMethod()]
        public void QueryForAnonymousTest1()
        {
            using (var per = new EntityPersister<Orders>(instanceName))
            {
                foreach (var p in per.Query(s => true).Select(s => new { Orderdate = s.OrderDate, Country = s.Customers.Country }))
                {
                    Console.WriteLine(p.Country);
                }
            }
        }

        [TestMethod()]
        public void QueryJoinTest()
        {
            using (var per = new EntityPersister<Customers>(instanceName))
            {
                var list = from c in per.Query()
                           join o in per.Query<Orders>().DefaultIfEmpty() on c.CustomerID equals o.CustomerID
                           select new { Contactname = c.ContactName, Orderid = o.OrderID };

                foreach (var s in list)
                {
                    Console.WriteLine(s.Orderid);
                }
            }
        }

        [TestMethod()]
        public void QueryToDataTableTest()
        {
            using (var per = new EntityPersister<Products>(instanceName))
            {
                foreach (DataRow row in per.Query("productid <> 0", null, null).Cast<IEntity>().ToDataTable().Rows)
                {
                    Console.WriteLine(row.ItemArray.Length);
                }
            }
        }

        /// <summary>
        /// 使用分页参数测试Query方法。
        /// </summary>
        [TestMethod()]
        public void QueryForPagerTest()
        {
            using (var per = new EntityPersister<Products>(instanceName))
            {
                var pager = new DataPager(2) { CurrentPageIndex = 1 };
                foreach (var p in per.Query(s => true).Segment(pager))
                {
                    Console.WriteLine(p.ProductName);
                }
            }
        }

        /// <summary>
        /// 使用条件文本测试Query方法。
        /// </summary>
        [TestMethod()]
        public void QueryForConditionTest()
        {
            using (var per = new EntityPersister<Products>(instanceName))
            {
                foreach (var p in per.Query("productname <> '测试'", "productname desc"))
                {
                    Console.WriteLine(p.ProductName);
                }
            }
        }

        /// <summary>
        /// 使用查询参数测试Query方法。
        /// </summary>
        [TestMethod()]
        public void QueryForConditionParameterTest()
        {
            using (var per = new EntityPersister<Products>(instanceName))
            {
                var parameters = new ParameterCollection();
                parameters.Add("name", "测试");
                foreach (var p in per.Query("productname = @name", string.Empty, null, parameters))
                {
                    Console.WriteLine(p.ProductName);
                }
            }
        }

        /// <summary>
        /// 使用sql返回动态类型测试Query方法。
        /// </summary>
        [TestMethod()]
        public void QueryForSqlTest()
        {
            using (var per = new EntityPersister<Products>(instanceName))
            {
                foreach (object p in per.Query((SqlCommand)"select productname from products"))
                {
                    var f = p.GetType().GetProperty("productname");
                    var v = f.GetValue(p, null);
                    Console.WriteLine(v);
                }
            }
        }

        [TestMethod()]
        public void FirstTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WrapTest()
        {
            var d1 = new { Name = "dfadfsaf" };
            var d = Orders.Wrap(() => new Orders { CustomerID = Getdd(d1.Name), OrderDate = DateTime.Now });
            Console.WriteLine(d.CustomerID);
        }

        private string Getdd(string s)
        {
            return "kk" + s;
        }
    }
}
