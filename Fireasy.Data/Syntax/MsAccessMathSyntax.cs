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
    /// MsAccess数学函数语法解析。
    /// </summary>
    public class MsAccessMathSyntax : MathSyntax
    {
        /// <summary>
        /// 两个表达式进行与运算。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="otherExp">参与运算的表达式。</param>
        /// <returns></returns>
        public override string And(object sourceExp, object otherExp)
        {
            return string.Format("({0} AND {1})", sourceExp, otherExp);
        }

        /// <summary>
        /// 两个表达式进行或运算。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="otherExp">参与运算的表达式。</param>
        /// <returns></returns>
        public override string Or(object sourceExp, object otherExp)
        {
            return string.Format("({0} OR {1})", sourceExp, otherExp);
        }

        /// <summary>
        /// 对源表达式进行求余运算。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="otherExp">参与运算的表达式。</param>
        /// <returns></returns>
        public override string Modulo(object sourceExp, object otherExp)
        {
            return string.Format("({0} MOD {1})", sourceExp, otherExp);
        }

        /// <summary>
        /// 返回源表达式的最小整数值。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Ceiling(object sourceExp)
        {
            return string.Format("FIX({0})", sourceExp);
        }

        /// <summary>
        /// 返回源表达式的最大整数值。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Floor(object sourceExp)
        {
            return string.Format("FIX({0})", sourceExp);
        }

        /// <summary>
        /// 返回以e为底的对数值。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Log(object sourceExp)
        {
            throw new SyntaxParseException("Math.Log");
        }

        /// <summary>
        /// 返回以10为底的对数值。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Log10(object sourceExp)
        {
            return string.Format("LOG({0})", sourceExp);
        }

        /// <summary>
        /// 返回源表达式的反值。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Negate(object sourceExp)
        {
            return string.Format("(0 - {0})", sourceExp);
        }

        /// <summary>
        /// 返回源表达式的指定冪。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="powerExp">冪。</param>
        /// <returns></returns>
        public override string Power(object sourceExp, object powerExp)
        {
            throw new SyntaxParseException("Math.Power");
        }

        /// <summary>
        /// 返回源表达式的二次开方值。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Sqrt(object sourceExp)
        {
            return string.Format("SQR({0})", sourceExp);
        }

        /// <summary>
        /// 返回源表达式的反正弦值。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Asin(object sourceExp)
        {
            return string.Format("ATN({0} / SQR({1} * {0} + 1))", sourceExp, Negate(sourceExp));
        }

        /// <summary>
        /// 返回源表达式的反余弦值。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Acos(object sourceExp)
        {
            return string.Format("ATN({1} / SQR({1} * {0} + 1)) + 2 * ATN(1)", sourceExp, Negate(sourceExp));
        }

        /// <summary>
        /// 返回源表达式的反正切值。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Atan(object sourceExp)
        {
            return string.Format("ATN({0})", sourceExp);
        }

        /// <summary>
        /// 返回源表达式左移后的值。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="shiftExp">位数。</param>
        /// <returns></returns>
        public override string LeftShift(object sourceExp, object shiftExp)
        {
            throw new SyntaxParseException("Math.LeftShift");
        }

        /// <summary>
        /// 返回源表达式右移后的值。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="shiftExp">位数。</param>
        /// <returns></returns>
        public override string RightShift(object sourceExp, object shiftExp)
        {
            throw new SyntaxParseException("Math.RightShift");
        }
    }
}
