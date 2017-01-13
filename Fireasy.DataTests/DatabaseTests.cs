// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using Fireasy.Data.Extensions;
using Fireasy.Data.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Fireasy.Data.Test
{
    /// <summary>
    /// DatabaseTests类。
    /// </summary>
    [TestClass()]
    public class DatabaseTests : DbTestBase
    {
        [TestMethod()]
        public void DatabaseTest()
        {
            UseDatabase(database => Assert.IsNotNull(database));
        }

        /// <summary>
        /// 测试BeginTransaction方法。
        /// </summary>
        [TestMethod()]
        public void BeginTransactionTest()
        {
            UseDatabase(database => Assert.IsTrue(database.BeginTransaction()));
        }

        /// <summary>
        /// 使用ReadCommitted隔离级别(不允许脏读)测试BeginTransaction方法。
        /// </summary>
        [TestMethod()]
        public void BeginTransactionForReadCommittedTest()
        {
            TestIsolationLevel(IsolationLevel.ReadCommitted);
        }

        /// <summary>
        /// 使用ReadUncommitted隔离级别(允许脏读)测试BeginTransaction方法。
        /// </summary>
        [TestMethod()]
        public void BeginTransactionForReadUncommittedTest()
        {
            TestIsolationLevel(IsolationLevel.ReadUncommitted);
        }

        private void TestIsolationLevel(IsolationLevel level)
        {
            UseDatabase(database =>
                {
                    database.BeginTransaction();
                    try
                    {
                        var parameters = new ParameterCollection();
                        parameters.Add("Name", "车轮");

                        //未改之前，去查沙发
                        AnthorRead(level, "沙发");

                        SqlCommand sql = "update products set \"ProductName\" = '沙发' where \"ProductName\" = @Name";
                        database.ExecuteNonQuery(sql, parameters);

                        //改了后，去查沙发
                        AnthorRead(level, "沙发");

                        database.RollbackTransaction();

                        //事务回滚后，去查沙发
                        AnthorRead(level, "沙发");
                    }
                    catch (Exception ex)
                    {
                        Assert.Fail();
                        database.RollbackTransaction();
                    }
                });
        }

        /// <summary>
        /// 模拟另一个用户读取数据。
        /// </summary>
        /// <param name="level">隔离级别。</param>
        /// <param name="name">新名称。</param>
        private void AnthorRead(IsolationLevel level, string name)
        {
            using (var database = DatabaseFactory.CreateDatabase(instanceName))
            {
                try
                {
                    database.BeginTransaction(level);

                    var parameters = new ParameterCollection();
                    parameters.Add("Name", name);
                    SqlCommand sql = "select count(1) from Products where ProductName = @Name";
                    var count = Convert.ToInt32(database.ExecuteScalar(sql, parameters));

                    Console.WriteLine("{0}的数量为{1}", name, count);
                    database.CommitTransaction();
                }
                catch (System.Exception ex)
                {
                    database.RollbackTransaction();
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// 测试CommitTransaction方法。
        /// </summary>
        [TestMethod()]
        public void CommitTransactionTest()
        {
            UseDatabase(database => Assert.IsFalse(database.CommitTransaction()));
        }

        /// <summary>
        /// 测试RollbackTransaction方法。
        /// </summary>
        [TestMethod()]
        public void RollbackTransactionTest()
        {
            UseDatabase(database => Assert.IsFalse(database.RollbackTransaction()));
        }

        /// <summary>
        /// 使用嵌套事务测试CommitTransaction方法。
        /// </summary>
        [TestMethod()]
        public void CommitTransactionNestedTest()
        {
            UseDatabase(database =>
                {
                    database.BeginTransaction();

                    TransactionNested();

                    Assert.IsTrue(database.CommitTransaction());
                });
        }

        /// <summary>
        /// 事务嵌套。
        /// </summary>
        private void TransactionNested()
        {
            var database = DatabaseFactory.GetDatabaseFromScope();

            try
            {
                Assert.IsFalse(database.BeginTransaction());

                Assert.IsFalse(database.CommitTransaction());
            }
            catch (Exception ex)
            {
                Assert.IsFalse(database.RollbackTransaction());
            }
        }

        /// <summary>
        /// 测试ExecuteDataTable方法。
        /// </summary>
        [TestMethod()]
        public void ExecuteDataTableTest()
        {
            UseDatabase(database =>
                {
                    var tb = database.ExecuteDataTable((SqlCommand)"select * from products");

                    Assert.IsNotNull(tb);
                });
        }

        /// <summary>
        /// 测试ExecuteEnumerable方法。
        /// </summary>
        [TestMethod()]
        public void ExecuteEnumerableTest()
        {
            UseDatabase(database =>
                {
                    var list = database.ExecuteEnumerable((SqlCommand)"select * from products").ToList();

                    Assert.IsNotNull(list.Count);
                    var pc = TypeDescriptor.GetProperties(list[0]);
                    Console.WriteLine(pc.Count);
                });
        }

        public interface IProduct
        {
            string ProductName { get; set; }
        }

        /// <summary>
        /// 使用分页测试ExecuteEnumerable方法。
        /// </summary>
        [TestMethod()]
        public void ExecuteEnumerableForDataPagerTest()
        {
            UseDatabase(database =>
                {
                    var pager = new DataPager(2, 1);
                    var list = database.ExecuteEnumerable((SqlCommand)"select * from products", pager).ToList();

                    Assert.IsNotNull(list);
                });
        }

        /// <summary>
        /// 使用返回单值测试ExecuteEnumerable方法。
        /// </summary>
        [TestMethod()]
        public void ExecuteEnumerableForValueTest()
        {
            UseDatabase(database =>
                {
                    var list = database.ExecuteEnumerable<string>((SqlCommand)"select productname from products").ToList();

                    Assert.IsNotNull(list);
                });
        }

        /// <summary>
        /// 使用返回实体测试ExecuteEnumerable方法。
        /// </summary>
        [TestMethod()]
        public void ExecuteEnumerableForEntityTest()
        {
            UseDatabase(database =>
                {
                    var list = database.ExecuteEnumerable<Product>((SqlCommand)"select * from products").ToList();

                    Assert.IsNotNull(list);
                });
        }
        
        /// <summary>
        /// 使用返回实体测试ExecuteEnumerable方法。
        /// </summary>
        [TestMethod()]
        public void ExecuteEnumerableForDynamicEntityTest()
        {
            using (var database = DatabaseFactory.CreateDatabase())
            {
                var list = database.ExecuteEnumerable((SqlCommand)"select * from products");
                foreach (var item in list)
                {
                    Console.WriteLine(item.ProductID);
                }
            }
        }

        /// <summary>
        /// 测试ExecuteNonQuery方法。
        /// </summary>
        [TestMethod()]
        public void ExecuteNonQueryTest()
        {
            UseDatabase(database =>
                {
                    SqlCommand sql = "update products set productname = @name where productid = @id";
                    var parameters = new ParameterCollection();
                    parameters.Add("id", 99);
                    parameters.Add("name", "");

                    var result = database.ExecuteNonQuery(sql, parameters);

                    Assert.AreEqual(1, result);
                });
        }

        /// <summary>
        /// 测试ExecuteReader方法。
        /// </summary>
        [TestMethod()]
        public void ExecuteReaderTest()
        {
            UseDatabase(database =>
                {
                    using (var reader = database.ExecuteReader((SqlCommand)"select * from products"))
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(1));
                        }
                    }
                });
        }

        /// <summary>
        /// 测试ExecuteScalar方法。
        /// </summary>
        [TestMethod()]
        public void ExecuteScalarTest()
        {
            UseDatabase(database =>
                {
                    var result = database.ExecuteScalar((SqlCommand)"select count(1) from products");

                    Assert.IsNotNull(result);
                });
        }

        /// <summary>
        /// 测试泛型ExecuteScalar方法。
        /// </summary>
        [TestMethod()]
        public void ExecuteScalarGenericTest()
        {
            UseDatabase(database =>
                {
                    var result = database.ExecuteScalar<int>((SqlCommand)"select max(productid) from products");

                    Assert.IsNotNull(result);
                });
        }

        /// <summary>
        /// 测试FillDataSet方法。
        /// </summary>
        [TestMethod()]
        public void FillDataSetTest()
        {
            UseDatabase(database =>
                {
                    var ds = new DataSet();

                    database.FillDataSet(ds, (SqlCommand)"select * from products");

                    Assert.AreEqual(ds.Tables.Count, 1);
                });
        }

        /// <summary>
        /// 使用返回多个表测试FillDataSet方法。
        /// </summary>
        [TestMethod()]
        public void FillDataSetForMultiTest()
        {
            UseDatabase(database =>
                {
                    var syntax = database.Provider.GetService<ISyntaxProvider>();
                    SqlCommand sql = string.Format("{0}{1}{2}",
                        "select * from products",
                        syntax.Linefeed,
                        "select * from orders");

                    var ds = new DataSet();

                    database.FillDataSet(ds, sql, "products,orders");

                    Assert.AreEqual(ds.Tables.Count, 2);
                });
        }

        /// <summary>
        /// 测试TryConnect方法。
        /// </summary>
        [TestMethod()]
        public void TryConnectTest()
        {
            UseDatabase(database =>
                Assert.AreEqual(string.Empty, database.TryConnect())
                );
        }

        /// <summary>
        /// 测试Update方法。
        /// </summary>
        [TestMethod()]
        public void UpdateTest()
        {
            UseDatabase(database =>
                {
                    var table = database.ExecuteDataTable((SqlCommand)"select * from products");
                    table.TableName = "products";

                    var row = table.NewRow();
                    row["productname"] = "轮胎";
                    row["discontinued"] = 1;

                    table.Rows.Add(row);

                    database.Update(table);
                });
        }
        
        /*
        [TestMethod()]
        public void ExecuteNonQueryAsyncTest()
        {
            UseDatabase(database =>
                {
                    SqlCommand sql = "update products set productname = @name where productid = @id";
                    var parameters = new ParameterCollection();
                    parameters.Add("id", 9119);
                    parameters.Add("name", "");

                    Console.WriteLine(11);
                    int result = await database.ExecuteNonQueryAsync(sql, parameters);
                    Console.WriteLine(result);
                    Console.WriteLine(22);

                });
        }

        [TestMethod]
        public void ExecuteEnumerableForEntityAsyncTest()
        {
            UseDatabase(database =>
                {
                    var result = database.ExecuteEnumerableAsync<Product>((SqlCommand)"select * from products");
                    if (result != null)
                    {
                        Console.WriteLine(result.Result.Count());
                    }
                });
        }
         */

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }

        private class Product
        {
            public int ProductID { get; set; }

            public DateTime? ProductName { get; set; }

            public int? SupplierID { get; set; }
        }
    }
}
