using Fireasy.Data.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Fireasy.Data.Test
{
    [TestClass()]
    public class SQLiteFunctionTests : DbTestBase
    {
        [TestMethod()]
        public void Test()
        {
            UseDatabase(db =>
                {
                    new SQLiteFunctionBuilder().RegisterRegexFunction();
                    Console.WriteLine(db.ExecuteScalar((SqlCommand)@"select count(*) from products where regexp(productname, '\w+')"));
                });
        }
    }
}
