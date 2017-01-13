// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fireasy.Data.Provider;

namespace Fireasy.Data.Test
{
    /// <summary>
    /// DatabaseFactoryTests类。
    /// </summary>
    [TestClass()]
    public class DatabaseFactoryTests
    {
        /// <summary>
        /// 测试CreateDatabase方法。
        /// </summary>
        [TestMethod()]
        public void CreateDatabaseTest()
        {
            using (var database = DatabaseFactory.CreateDatabase())
            {
                Assert.IsNotNull(database);
                Console.WriteLine(database.ConnectionString);
            }
        }

        /// <summary>
        /// 使用实例名称测试CreateDatabase方法。
        /// </summary>
        [TestMethod()]
        public void CreateDatabaseUseInstanceNameTest()
        {
            using (var database = DatabaseFactory.CreateDatabase("mssql1"))
            {
                Assert.IsNotNull(database);
                Console.WriteLine(database.ConnectionString);
            }
        }

        /// <summary>
        /// 测试方法GetDatabaseFromScope。
        /// </summary>
        [TestMethod()]
        public void GetDatabaseFromScopeTest()
        {
            using (var database = DatabaseFactory.CreateDatabase())
            {
                GetDatabaseFromScope("mysql");
            }
        }

        /// <summary>
        /// 测试方法GetDatabaseFromScope，超出范围。
        /// </summary>
        [TestMethod()]
        public void GetDatabaseFromScopeOutTest()
        {
            using (var database = DatabaseFactory.CreateDatabase())
            {
                GetDatabaseFromScope("mysql");
            }

            //DatabaseScope.Current 已经不在了
            GetDatabaseFromScope();
        }

        [TestMethod()]
        public void GetDatabaseFromScopeNestedTest()
        {
            using (var database = DatabaseFactory.CreateDatabase("mssql"))
            {
                GetDatabaseFromScope("mssql");
                TestNested1();
            }

            //DatabaseScope.Current 已经不在了
            GetDatabaseFromScope();
        }

        [TestMethod]
        public void TestPool()
        {
            var cons = @"data source=(local);user id=sa;password=123;;AttachDBFileName=E:\Faib\组件\Fireasy\Fireasy.DevelopLibrary-2014\documents\db\Northwind.mdf;pooling=true;";
            var result = string.Empty;
            var startTicks1 = DateTime.Now;

            for (var i = 0; i < 100; i++)
            {
                using (var db = new Database(cons, MsSqlProvider.Instance))
                {
                    db.ExecuteScalar((SqlCommand)"select 1");
                }
            }

            var endTicks1 = DateTime.Now;
            var usedTicks1 = (endTicks1 - startTicks1).TotalMilliseconds;
            Console.WriteLine("Used time: " + usedTicks1);

            var startTicks2 = DateTime.Now;
            for (int i = 0; i < 100; i++)
            {
                using (var conn2 = new System.Data.SqlClient.SqlConnection(cons))
                {
                    conn2.Open();
                    var cmd = System.Data.SqlClient.SqlClientFactory.Instance.CreateCommand();
                    cmd.CommandText = "select 1";
                    cmd.Connection = conn2;
                    cmd.ExecuteScalar();

                    conn2.Close();
                }
            }
            var endTicks2 = DateTime.Now;
            var usedTicks2 = (endTicks2 - startTicks2).TotalMilliseconds;

            Console.WriteLine("Used time: " + usedTicks2);
        }

        private void TestNested1()
        {
            using (var database = DatabaseFactory.CreateDatabase("mysql"))
            {
                GetDatabaseFromScope("mysql");
                TestNested2();
            }
        }

        private void TestNested2()
        {
            using (var database = DatabaseFactory.CreateDatabase("sqlite"))
            {
                GetDatabaseFromScope("sqlite");
                TestNested3();
            }
        }

        private void TestNested3()
        {
            using (var database = DatabaseFactory.CreateDatabase("oracle"))
            {
                GetDatabaseFromScope("oracle");
            }
        }

        private void GetDatabaseFromScope(string instanceName = null)
        {
            try
            {
                var database = DatabaseFactory.GetDatabaseFromScope();
                if (database != null)
                {
                    Console.WriteLine("{0}:{1}", instanceName, database.ConnectionString);
                }
            }
            catch (UnableGetDatabaseScopeException ex)
            {
                Console.WriteLine("无法获取 IDatabase 实例，超出范围。");
            }
        }
    }
}
