using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fireasy.Data.Extensions;

namespace Fireasy.Data.Test
{
    [TestClass()]
    public class ExtensionsTests
    {
        [TestMethod]
        public void ToDataTableTest1()
        {
            var list = new List<object> { new { Name = "dd", Age = 12 }, new { Name = "gg", Age = 33 } };
            var table = list.ToDataTable();
            Console.WriteLine(table.Columns.Count);
        }

        [TestMethod]
        public void ToDataTableTest2()
        {
            var d = new { Name = "dd", Age = 12 };
            var table = d.ToDataTable();
            Console.WriteLine(table.Columns.Count);
        }
    }
}
