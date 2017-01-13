// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using Fireasy.Data.Batcher;
using Fireasy.Data.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Dynamic;

namespace Fireasy.Data.Test
{
    /// <summary>
    /// SchemaProviderTests类。
    /// </summary>
    [TestClass()]
    public class BatcherProviderTests : DbTestBase
    {
        /// <summary>
        /// 使用DataTable测试Insert方法。
        /// </summary>
        [TestMethod()]
        public void InsertForDataTableTest()
        {
            var table = new DataTable("BATCHERS");
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("NAME");
            table.Columns.Add("BIRTHDAY", typeof(DateTime));

            for (var i = 0; i < 100001; i++)
            {
                table.Rows.Add(i, Guid.NewGuid().ToString(), DateTime.Now);
            }

            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<IBatcherProvider>();

                    provider.Insert(database, table);
                });
        }
        
        /// <summary>
        /// 使用小数据量的DataTable测试Insert方法。
        /// </summary>
        [TestMethod()]
        public void InsertForLittleDataTableTest()
        {
            var table = new DataTable("BATCHERS");
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("NAME");
            table.Columns.Add("BIRTHDAY", typeof(DateTime));

            for (var i = 0; i < 1000000; i++)
            {
                table.Rows.Add(i, Guid.NewGuid().ToString(), DateTime.Now);
            }

            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<IBatcherProvider>();

                    provider.Insert(database, table);
                });
        }

        /// <summary>
        /// 使用List测试Insert方法。
        /// </summary>
        [TestMethod()]
        public void InsertForListTest()
        {
            var list = new List<BatcherData>();

            for (var i = 0; i < 100000; i++)
            {
                list.Add(new BatcherData { ID = i, NAME = new Size(12, 20), BIRTHDAY = DateTime.Now });
            }

            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<IBatcherProvider>();

                    provider.Insert(database, list, "BATCHERS");
                });
        }
        
        /// <summary>
        /// 使用小数据量的List测试Insert方法。
        /// </summary>
        [TestMethod()]
        public void InsertForLittleListTest()
        {
            var list = new List<BatcherData>();

            for (var i = 0; i < 1000; i++)
            {
                list.Add(new BatcherData { ID = i, NAME = new Size(12, 20), BIRTHDAY = DateTime.Now });
            }

            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<IBatcherProvider>();

                    provider.Insert(database, list, "BATCHERS");
                });
        }
                
        /// <summary>
        /// 使用小数据量的List测试Insert方法。
        /// </summary>
        [TestMethod()]
        public void InsertForDynamicTest()
        {
            var list = new List<object>();

            for (var i = 0; i < 1000; i++)
            {
                dynamic d = new ExpandoObject();
                d.ID = i;
                d.NAME = "test";
                d.BIRTHDAY = DateTime.Now;
                list.Add(d);
            }

            UseDatabase(database =>
                {
                    var provider = database.Provider.GetService<IBatcherProvider>();

                    provider.Insert(database, list, "BATCHERS");
                });
        }

        private class BatcherData
        {
            public int ID { get; set; }

            public Size NAME { get; set; }

            public DateTime BIRTHDAY { get; set; }
        }
    }
}
