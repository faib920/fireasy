// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Extensions.Test
{
    /// <summary>
    /// DateTimeExtensionTests类。
    /// </summary>
    [TestClass()]
    public class DateTimeExtensionTests
    {
        [TestMethod()]
        public void StartOfDayTest()
        {
            var date = DateTime.Parse("2009-7-8 8:45:30");

            Assert.AreEqual(DateTime.Parse("2009-7-8 0:00:00"), date.StartOfDay());
        }

        [TestMethod()]
        public void EndOfDayTest()
        {
            var date = DateTime.Parse("2009-7-8 8:45:30");

            Assert.AreEqual(DateTime.Parse("2009-7-8 23:59:59"), date.EndOfDay());
        }

        [TestMethod()]
        public void StartOfMonthTest()
        {
            var date = DateTime.Parse("2009-7-8");

            Assert.AreEqual(DateTime.Parse("2009-7-1"), date.StartOfMonth());
        }

        [TestMethod()]
        public void EndOfMonthTest()
        {
            var date = DateTime.Parse("2009-7-8");

            Assert.AreEqual(DateTime.Parse("2009-7-31"), date.EndOfMonth());
        }

        [TestMethod()]
        public void StartOfWeekTest()
        {
            // 7  1  2  3  4  5  6
            //-----------------------
            //          1  2  3  4
            // 5  6  7  8  9  10 11
            // 12 13 14 15 16 17 18
            // 19 20 21 22 23 24 25
            // 26 27 28 29 30 31

            var date = DateTime.Parse("2009-7-8");

            Assert.AreEqual(DateTime.Parse("2009-7-6"), date.StartOfWeek());
        }

        [TestMethod()]
        public void EndOfWeekTest()
        {
            // 7  1  2  3  4  5  6
            //-----------------------
            //          1  2  3  4
            // 5  6  7  8  9  10 11
            // 12 13 14 15 16 17 18
            // 19 20 21 22 23 24 25
            // 26 27 28 29 30 31

            var date = DateTime.Parse("2009-7-8");

            Assert.AreEqual(DateTime.Parse("2009-7-12"), date.EndOfWeek());
        }

        [TestMethod()]
        public void IsLeapYearTest()
        {
            Assert.IsFalse(DateTime.Parse("2009-7-8").IsLeapYear());
            Assert.IsTrue(DateTime.Parse("2012-7-8").IsLeapYear());
        }

        [TestMethod()]
        public void SetYearTest()
        {
            var date = DateTime.Parse("2009-7-8");

            Assert.AreEqual(DateTime.Parse("2010-7-8"), date.SetYear(2010));
        }

        [TestMethod()]
        public void SetMonthTest()
        {
            var date = DateTime.Parse("2009-7-8");

            Assert.AreEqual(DateTime.Parse("2009-12-8"), date.SetMonth(12));
        }

        [TestMethod()]
        public void SetDayTest()
        {
            var date = DateTime.Parse("2009-7-8");

            Assert.AreEqual(DateTime.Parse("2009-7-22"), date.SetDay(22));
        }

        [TestMethod()]
        public void IsWeekendTest()
        {
            // 7  1  2  3  4  5  6
            //-----------------------
            //          1  2  3  4
            // 5  6  7  8  9  10 11
            // 12 13 14 15 16 17 18
            // 19 20 21 22 23 24 25
            // 26 27 28 29 30 31

            Assert.IsTrue(DateTime.Parse("2009-7-12").IsWeekend());
            Assert.IsFalse(DateTime.Parse("2009-7-8").IsWeekend());
        }

        [TestMethod()]
        public void FirstWeekTest()
        {
            // 7  1  2  3  4  5  6
            //-----------------------
            //          1  2  3  4
            // 5  6  7  8  9  10 11
            // 12 13 14 15 16 17 18
            // 19 20 21 22 23 24 25
            // 26 27 28 29 30 31

            var date = DateTime.Parse("2009-7-8");

            Assert.AreEqual(DateTime.Parse("2009-7-6"), date.FirstWeek(DayOfWeek.Monday));
            Assert.AreEqual(DateTime.Parse("2009-7-1"), date.FirstWeek(DayOfWeek.Wednesday));
        }

        [TestMethod()]
        public void WeekTest()
        {
            // 7  1  2  3  4  5  6
            //-----------------------
            //          1  2  3  4
            // 5  6  7  8  9  10 11
            // 12 13 14 15 16 17 18
            // 19 20 21 22 23 24 25
            // 26 27 28 29 30 31

            var date = DateTime.Parse("2009-7-8");

            Assert.AreEqual(DateTime.Parse("2009-6-29"), date.FirstWeek());
            Assert.AreEqual(DateTime.Parse("2014-6-2"), new DateTime(2014, 6, 1).FirstWeek());
            Assert.AreEqual(DateTime.Parse("2014-7-28"), new DateTime(2014, 8, 1).FirstWeek());
            Assert.AreEqual(DateTime.Parse("2014-9-1"), new DateTime(2014, 9, 1).FirstWeek());
            Assert.AreEqual(DateTime.Parse("2014-9-29"), new DateTime(2014, 10, 1).FirstWeek());
            Assert.AreEqual(DateTime.Parse("2014-10-27"), new DateTime(2014, 11, 1).FirstWeek());
            Assert.AreEqual(DateTime.Parse("2014-12-1"), new DateTime(2014, 12, 1).FirstWeek());
        }

        [TestMethod()]
        public void LastWeekTest()
        {
            // 7  1  2  3  4  5  6
            //-----------------------
            //          1  2  3  4
            // 5  6  7  8  9  10 11
            // 12 13 14 15 16 17 18
            // 19 20 21 22 23 24 25
            // 26 27 28 29 30 31

            var date = DateTime.Parse("2009-7-8");

            Assert.AreEqual(DateTime.Parse("2009-7-27"), date.LastWeek(DayOfWeek.Monday));
            Assert.AreEqual(DateTime.Parse("2009-7-25"), date.LastWeek(DayOfWeek.Saturday));
        }

        [TestMethod()]
        public void NextWeekTest()
        {
            // 7  1  2  3  4  5  6
            //-----------------------
            //          1  2  3  4
            // 5  6  7  8  9  10 11
            // 12 13 14 15 16 17 18
            // 19 20 21 22 23 24 25
            // 26 27 28 29 30 31

            var date = DateTime.Parse("2009-7-8");
            Assert.AreEqual(DateTime.Parse("2009-7-13"), date.NextWeek(DayOfWeek.Monday));
            Assert.AreEqual(DateTime.Parse("2009-7-9"), date.NextWeek(DayOfWeek.Thursday));
            Assert.AreEqual(DateTime.Parse("2009-7-20"), date.NextWeek(DayOfWeek.Monday, 2));
            Assert.AreEqual(DateTime.Parse("2009-7-16"), date.NextWeek(DayOfWeek.Thursday, 2));
        }

        [TestMethod()]
        public void PreviousWeekTest()
        {
            // 7  1  2  3  4  5  6
            //-----------------------
            //          1  2  3  4
            // 5  6  7  8  9  10 11
            // 12 13 14 15 16 17 18
            // 19 20 21 22 23 24 25
            // 26 27 28 29 30 31

            var date = DateTime.Parse("2009-7-15");
            Assert.AreEqual(DateTime.Parse("2009-7-13"), date.PreviousWeek(DayOfWeek.Monday));
            Assert.AreEqual(DateTime.Parse("2009-7-9"), date.PreviousWeek(DayOfWeek.Thursday));
            Assert.AreEqual(DateTime.Parse("2009-7-6"), date.PreviousWeek(DayOfWeek.Monday, 2));
            Assert.AreEqual(DateTime.Parse("2009-7-2"), date.PreviousWeek(DayOfWeek.Thursday, 2));
        }

        [TestMethod()]
        public void ToStringExTest()
        {
            var time = TimeSpan.FromMinutes(304455);
            Console.WriteLine("{0}: {1}", time, time.ToStringEx());

            time = TimeSpan.FromSeconds(43455);
            Console.WriteLine("{0}: {1}", time, time.ToStringEx());
        }

        [TestMethod]
        public void ToTimeStampTest()
        {
            var d = new DateTime(2009, 12, 22, 13, 22, 34);
            Assert.AreEqual(1261459354, d.ToTimeStamp());
        }

        [TestMethod]
        public void ToDateTimeTest()
        {
            long t = 1261459354;
            var d = t.ToDateTime();
            Assert.AreEqual(new DateTime(2009, 12, 22, 13, 22, 34), d);
        }
    }
}
