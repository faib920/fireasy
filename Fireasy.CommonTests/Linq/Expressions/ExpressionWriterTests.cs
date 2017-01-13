// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Linq.Expressions.Test
{
    [TestClass()]
    public class ExpressionWriterTests
    {
        [TestMethod()]
        public void WriteTest()
        {
            Expression<Func<People, bool>> expression = (s) => s.Age == 12;

            using (var writer = new StringWriter(CultureInfo.InvariantCulture))
            {
                ExpressionWriter.Write(writer, expression);

                Console.WriteLine(writer.ToString());
            }
        }

        [TestMethod()]
        public void WriteToStringTest()
        {
            Expression<Func<People, bool>> expression = (s) => s.Age == 12;

            Console.WriteLine(ExpressionWriter.WriteToString(expression));
        }

        [TestMethod()]
        public void WiteToStringWithLengthTest()
        {
            Expression<Func<People, bool>> expression = (s) => s.Name.Length == 4;

            Console.WriteLine(ExpressionWriter.WriteToString(expression));
        }

        [TestMethod()]
        public void WiteToStringWithSubqueryTest()
        {
            Expression<Func<People, bool>> expression = (s) => s.Works.Count(t => t.Company == "aa") > 0;

            Console.WriteLine(ExpressionWriter.WriteToString(expression));
        }

        [TestMethod()]
        public void WiteToStringWithReferenceTest()
        {
            var p = new People { Name = "fireasy" };
            Expression<Func<Work, bool>> expression = (s) => s.People.Name == p.Name;

            Console.WriteLine(ExpressionWriter.WriteToString(expression));
        }

        [TestMethod()]
        public void WiteToStringWithConstantTest()
        {
            var str = "fireasy";
            var p = new People { Age = 34 };
            Expression<Func<People, bool>> expression = (s) => s.Name == str && s.Age == p.Age;

            Console.WriteLine(ExpressionWriter.WriteToString(expression));
        }

        private class People
        {
            public string Name { get; set; }

            public DateTime Birthday { get; set; }

            public int Age { get; set; }

            public List<Work> Works { get; set; }
        }

        private class Work
        {
            public string Company { get; set; }

            public People People { get; set; }
        }
    }
}
