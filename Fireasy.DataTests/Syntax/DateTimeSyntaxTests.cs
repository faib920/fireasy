// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Data.Syntax.Test
{
    [TestClass()]
    public class DateTimeSyntaxTests : SyntaxTestBase
    {
        [TestMethod()]
        public void SystemTimeTest()
        {
            AreEqual(DateTime.Now.ToString(), syntax => syntax.DateTime.SystemTime());
        }

        [TestMethod()]
        public void YearTest()
        {
            AreEqual(2013, syntax => syntax.DateTime.Year(GetCurrentDateTime(syntax)));
        }

        [TestMethod()]
        public void MonthTest()
        {
            AreEqual(9, syntax => syntax.DateTime.Month(GetCurrentDateTime(syntax)));
        }

        [TestMethod()]
        public void DayTest()
        {
            AreEqual(4, syntax => syntax.DateTime.Day(GetCurrentDateTime(syntax)));
        }

        [TestMethod()]
        public void HourTest()
        {
            AreEqual(13, syntax => syntax.DateTime.Hour(GetCurrentDateTime(syntax)));
        }

        [TestMethod()]
        public void MinuteTest()
        {
            AreEqual(45, syntax => syntax.DateTime.Minute(GetCurrentDateTime(syntax)));
        }

        [TestMethod()]
        public void SecondTest()
        {
            AreEqual(32, syntax => syntax.DateTime.Second(GetCurrentDateTime(syntax)));
        }

        [TestMethod()]
        public void MillisecondTest()
        {
            AreEqual(0, syntax => syntax.DateTime.Millisecond(GetCurrentDateTime(syntax)));
        }

        [TestMethod()]
        public void DayOfWeekTest()
        {
            AreEqual(3, syntax => syntax.DateTime.DayOfWeek(GetCurrentDateTime(syntax)));
        }

        [TestMethod()]
        public void DayOfYearTest()
        {
            AreEqual(247, syntax => syntax.DateTime.DayOfYear(GetCurrentDateTime(syntax)));
        }

        [TestMethod()]
        public void WeekOfYearTest()
        {
            AreEqual(35, syntax => syntax.DateTime.WeekOfYear(GetCurrentDateTime(syntax)));
        }

        [TestMethod()]
        public void AddYearsTest()
        {
            AreEqual(DateTime.Parse("2014-09-04 13:45:32").ToString(), syntax => syntax.DateTime.AddYears(GetCurrentDateTime(syntax), 1));
        }

        [TestMethod()]
        public void AddMonthsTest()
        {
            AreEqual(DateTime.Parse("2013-10-04 13:45:32").ToString(), syntax => syntax.DateTime.AddMonths(GetCurrentDateTime(syntax), 1));
        }

        [TestMethod()]
        public void AddDaysTest()
        {
            AreEqual(DateTime.Parse("2013-09-05 13:45:32").ToString(), syntax => syntax.DateTime.AddDays(GetCurrentDateTime(syntax), 1));
        }

        [TestMethod()]
        public void AddHoursTest()
        {
            AreEqual(DateTime.Parse("2013-09-04 14:45:32").ToString(), syntax => syntax.DateTime.AddHours(GetCurrentDateTime(syntax), 1));
        }

        [TestMethod()]
        public void AddMinutesTest()
        {
            AreEqual(DateTime.Parse("2013-09-04 13:46:32").ToString(), syntax => syntax.DateTime.AddMinutes(GetCurrentDateTime(syntax), 1));
        }

        [TestMethod()]
        public void AddSecondsTest()
        {
            AreEqual(DateTime.Parse("2013-09-04 13:45:33").ToString(), syntax => syntax.DateTime.AddSeconds(GetCurrentDateTime(syntax), 1));
        }

        [TestMethod()]
        public void DiffDaysTest()
        {
            AreEqual(GetTimeSpanBetweenToDateTimes().TotalDays, syntax => syntax.DateTime.DiffDays(GetStartDateTime(syntax), GetCurrentDateTime(syntax)));
        }

        [TestMethod()]
        public void DiffHoursTest()
        {
            AreEqual(GetTimeSpanBetweenToDateTimes().TotalHours, syntax => syntax.DateTime.DiffHours(GetStartDateTime(syntax), GetCurrentDateTime(syntax)));
        }

        [TestMethod()]
        public void DiffMinutesTest()
        {
            AreEqual(GetTimeSpanBetweenToDateTimes().TotalMinutes, syntax => syntax.DateTime.DiffMinutes(GetStartDateTime(syntax), GetCurrentDateTime(syntax)));
        }

        [TestMethod()]
        public void DiffSecondsTest()
        {
            AreEqual(GetTimeSpanBetweenToDateTimes().TotalSeconds, syntax => syntax.DateTime.DiffSeconds(GetStartDateTime(syntax), GetCurrentDateTime(syntax)));
        }

        private string GetStartDateTime(ISyntaxProvider syntax)
        {
            return syntax.Convert("'2013-01-01 00:00:00'", DbType.DateTime);
        }

        private string GetCurrentDateTime(ISyntaxProvider syntax)
        {
            return syntax.Convert("'2013-09-04 13:45:32'", DbType.DateTime);
        }

        private TimeSpan GetTimeSpanBetweenToDateTimes()
        {
            var d1 = DateTime.Parse("2013-01-01 00:00:00");
            var d2 = DateTime.Parse("2013-09-04 13:45:32");

            return d2 - d1;
        }
    }
}
