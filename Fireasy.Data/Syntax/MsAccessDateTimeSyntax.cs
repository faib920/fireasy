// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Fireasy.Data.Syntax
{
    /// <summary>
    /// MsAccess日期函数语法解析。
    /// </summary>
    public class MsAccessDateTimeSyntax : DateTimeSyntax
    {
        /// <summary>
        /// 获取源表达式中的小时。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Hour(object sourceExp)
        {
            return string.Format("DATEPART('h', {0})", sourceExp);
        }

        /// <summary>
        /// 获取源表达式中的分。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Minute(object sourceExp)
        {
            return string.Format("DATEPART('n', {0})", sourceExp);
        }

        /// <summary>
        /// 获取源表达式中的秒。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Second(object sourceExp)
        {
            return string.Format("DATEPART('s', {0})", sourceExp);
        }

        /// <summary>
        /// 获取源表达式中的毫秒。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Millisecond(object sourceExp)
        {
            return string.Format("DATEPART('s', {0})", sourceExp);
        }

        /// <summary>
        /// 获取源表达式中的本周的第几天。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string DayOfWeek(object sourceExp)
        {
            return string.Format("DATEPART('w', {0}) - 1", sourceExp);
        }

        /// <summary>
        /// 获取源表达式中的本年的第几天。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string DayOfYear(object sourceExp)
        {
            return string.Format("DATEPART('y', {0})", sourceExp);
        }

        /// <summary>
        /// 获取源表达式中的本年的第几周。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string WeekOfYear(object sourceExp)
        {
            return string.Format("DATEPART('ww', {0}) - 1", sourceExp);
        }

        /// <summary>
        /// 源表达式增加年。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="yearExp">年份数，可为正可为负。</param>
        /// <returns></returns>
        public override string AddYears(object sourceExp, object yearExp)
        {
            return string.Format("DATEADD('yyyy', {1}, {0})", sourceExp, yearExp);
        }

        /// <summary>
        /// 源表达式增加月。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="monthExp">月份数，可为正可为负。</param>
        /// <returns></returns>
        public override string AddMonths(object sourceExp, object monthExp)
        {
            return string.Format("DATEADD('m', {1}, {0})", sourceExp, monthExp);
        }

        /// <summary>
        /// 源表达式增加天。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="dayExp">天数，可为正可为负。</param>
        /// <returns></returns>
        public override string AddDays(object sourceExp, object dayExp)
        {
            return string.Format("DATEADD('d', {1}, {0})", sourceExp, dayExp);
        }

        /// <summary>
        /// 计算两个表达式相差的天数。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="otherExp">结束日期。</param>
        /// <returns></returns>
        public override string DiffDays(object sourceExp, object otherExp)
        {
            return string.Format("DATEDIFF('d', {0}, {1})", sourceExp, otherExp);
        }

        /// <summary>
        /// 计算两个表达式相差的小时数。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="otherExp">结束日期。</param>
        /// <returns></returns>
        public override string DiffHours(object sourceExp, object otherExp)
        {
            return string.Format("DATEDIFF('h', {0}, {1})", sourceExp, otherExp);
        }

        /// <summary>
        /// 计算两个表达式相差的分钟数。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="otherExp">结束日期。</param>
        /// <returns></returns>
        public override string DiffMinutes(object sourceExp, object otherExp)
        {
            return string.Format("DATEDIFF('n', {0}, {1})", sourceExp, otherExp);
        }

        /// <summary>
        /// 计算两个表达式相差的秒数。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="otherExp">结束日期。</param>
        /// <returns></returns>
        public override string DiffSeconds(object sourceExp, object otherExp)
        {
            return string.Format("DATEDIFF('s', {0}, {1})", sourceExp, otherExp);
        }
    }
}
