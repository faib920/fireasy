// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fireasy.Common.Extensions.Test
{
    /// <summary>
    /// StringExtensionTests类。
    /// </summary>
    [TestClass()]
    public class StringExtensionTests
    {
        [TestMethod()]
        public void LeftTest()
        {
            Console.WriteLine("放开那女孩".Left(2));
            Console.WriteLine("放开那女孩".Right(2));
        }

        [TestMethod()]
        public void RightTest()
        {
            Assert.AreEqual("放开那女孩".Right(2), "女孩");
        }

        [TestMethod()]
        public void GetAnsiLengthTest()
        {
            Console.WriteLine("放开那女孩".GetAnsiLength());
            Console.WriteLine("放开那女孩".Length);
        }

        [TestMethod()]
        public void ToSBCTest()
        {
            Console.WriteLine("abc".ToSBC());
            Console.WriteLine("ａｂｃ".ToDBC());
        }

        [TestMethod()]
        public void ToDBCTest()
        {
            Assert.AreEqual("ａｂｃ".ToDBC(), "abc");
        }

        [TestMethod()]
        public void IsNumericTest()
        {
            Assert.IsTrue("3423.33".IsNumeric());
            Assert.IsFalse("3423.33d".IsNumeric());
        }

        [TestMethod()]
        public void IsIntegerTest()
        {
            Assert.IsTrue("3423".IsInteger());
            Assert.IsFalse("3423.33".IsInteger());
        }

        [TestMethod()]
        public void DeUnicodeTest()
        {
            Assert.AreEqual(@"<", "\u003c".DeUnicode());
        }

        [TestMethod()]
        public void IsMatchTest()
        {
            Assert.IsTrue("age56".IsMatch(@"age\d+$"));
        }

        [TestMethod()]
        public void ToSimplifiedTest()
        {
            Console.WriteLine("中国".ToTraditional());
            Console.WriteLine("中國".ToSimplified());
        }

        [TestMethod()]
        public void ToTraditionalTest()
        {
            Console.WriteLine("中国".ToTraditional());
        }

        [TestMethod()]
        public void ToPinyinTest()
        {
            Assert.AreEqual("ZG", "中国".ToPinyin());
        }

        [TestMethod()]
        public void ToPinyinRareTest()
        {
            Console.WriteLine("亖一濷".ToPinyin(true));
            Console.WriteLine("亖一鶑".ToPinyin());
        }

        [TestMethod()]
        public void GetLinesTest()
        {
            Console.WriteLine(
            @"中国
人".GetLines());
        }

        [TestMethod()]
        public void ToPluralTest()
        {
            Console.WriteLine("body".ToPlural());
            Console.WriteLine("people".ToPlural());
            Console.WriteLine("girl".ToPlural());

            Console.WriteLine("bodies".ToSingular());
            Console.WriteLine("people".ToSingular());
            Console.WriteLine("girls".ToSingular());
        }

        [TestMethod()]
        public void ToSingularTest()
        {
            Console.WriteLine("bodies".ToSingular());
            Console.WriteLine("people".ToSingular());
            Console.WriteLine("girls".ToSingular());


            var ss = new List<string>();
            ss.Add("dfsadfasf");
            ss.Add("233");
            ss.Add("233");
            ss.Add("fdffdsdf");
            Console.WriteLine(ss.Distinct().ToArray().Length);
        }
    }
}
