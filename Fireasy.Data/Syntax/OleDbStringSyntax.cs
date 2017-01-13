// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Fireasy.Data.Syntax
{
    public class OleDbStringSyntax : StringSyntax
    {
        /// <summary>
        /// 取源表达式的子串。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="startExp">子串的起始字符位置。</param>
        /// <param name="lenExp">子串中的字符数。</param>
        /// <returns></returns>
        public override string Substring(object sourceExp, object startExp, object lenExp = null)
        {
            if (lenExp == null)
            {
                lenExp = Length(sourceExp);
            }
            return string.Format("MID({0}, {1}, {2})", sourceExp, startExp, lenExp);
        }

        /// <summary>
        /// 计算源表达式的长度。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Length(object sourceExp)
        {
            return string.Format("LEN({0})", sourceExp);
        }

        /// <summary>
        /// 判断子串在源表达式中的位置。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="searchExp">要搜寻的字符串。</param>
        /// <param name="startExp">搜索起始位置。</param>
        /// <param name="countExp">要检查的字符位置数</param>
        /// <returns></returns>
        public override string IndexOf(object sourceExp, object searchExp, object startExp = null, object countExp = null)
        {
            return string.Format("INSTR({0}, {1})", sourceExp, searchExp);
        }

        /// <summary>
        /// 将源表达式转换为小写格式。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string ToLower(object sourceExp)
        {
            return string.Format("LCASE({0})", sourceExp);
        }

        /// <summary>
        /// 将源表达式转换为大写格式。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string ToUpper(object sourceExp)
        {
            return string.Format("UCASE({0})", sourceExp);
        }

        /// <summary>
        /// 截掉源表达式的两边所有空格。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Trim(object sourceExp)
        {
            return string.Format("TRIM({0})", sourceExp);
        }

        /// <summary>
        /// 将源表达式中的部份字符替换为新的字符。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="searchExp">要搜寻的字符串。</param>
        /// <param name="replaceExp">要替换的字符串。</param>
        /// <returns></returns>
        public override string Replace(object sourceExp, object searchExp, object replaceExp)
        {
            throw new SyntaxParseException("String.Replace");
        }

        /// <summary>
        /// 将一组字符串连接为新的字符串。
        /// </summary>
        /// <param name="strExps">要连接的字符串数组。</param>
        /// <returns></returns>
        public override string Concat(params object[] strExps)
        {
#if N35
            var str = new string[strExps.Length];
            for (var i = 0; i < strExps.Length; i++)
            {
                str[i] = strExps[i].ToString();
            }
            return string.Join(" + ", str);
#else
            return string.Join(" + ", strExps);
#endif
        }

        /// <summary>
        /// 反转源表达式。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <returns></returns>
        public override string Reverse(object sourceExp)
        {
            throw new SyntaxParseException("String.Reverse");
        }

        /// <summary>
        /// 删除字符串表达式中的字符。
        /// </summary>
        /// <param name="sourceExp">源表达式。</param>
        /// <param name="startExp">起始字符位置。</param>
        /// <param name="lenExp">要删除的长度。</param>
        /// <returns></returns>
        public override string Remove(object sourceExp, object startExp, object lenExp)
        {
            throw new SyntaxParseException("String.Remove");
        }
    }
}
