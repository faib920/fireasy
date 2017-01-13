using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Fireasy.Data.Syntax
{
    public class OleDbSyntax : ISyntaxProvider
    {
        private StringSyntax m_string;
        private DateTimeSyntax m_datetime;
        private MathSyntax m_math;

        /// <summary>
        /// 获取字符串函数相关的语法。
        /// </summary>
        public virtual StringSyntax String
        {
            get { return m_string ?? (m_string = new OleDbStringSyntax()); }
        }

        /// <summary>
        /// 获取日期函数相关的语法。
        /// </summary>
        public virtual DateTimeSyntax DateTime
        {
            get { return m_datetime ?? (m_datetime = new OleDbDateTimeSyntax()); }
        }

        /// <summary>
        /// 获取数学函数相关的语法。
        /// </summary>
        public virtual MathSyntax Math
        {
            get { return m_math ?? (m_math = new OleDbMathSyntax()); }
        }

        /// <summary>
        /// 获取最近创建的自动编号的查询文本。
        /// </summary>
        public string IdentitySelect
        {
            get { return "SELECT @@IDENTITY"; }
        }

        /// <summary>
        /// 获取自增长列的关键词。
        /// </summary>
        public string IdentityColumn
        {
            get { return "IDENTITY(1, 1)"; }
        }

        /// <summary>
        /// 获取存储参数的前缀。
        /// </summary>
        public char ParameterPrefix
        {
            get { return '@'; }
        }

        /// <summary>
        /// 获取列引号标识符。
        /// </summary>
        public char[] Quote
        {
            get { return new[] { '[', ']' }; }
        }

        /// <summary>
        /// 获取换行符。
        /// </summary>
        public string Linefeed
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// 对命令文本进行分段处理，使之能够返回小范围内的数据。
        /// </summary>
        /// <param name="commandText">命令文本。</param>
        /// <param name="segment">数据分段对象。</param>
        /// <returns>处理后的分段命令文本。</returns>
        /// <exception cref="SegmentNotSupportedException">当前数据库或版本不支持分段时，引发该异常。</exception>
        public string Segment(string commandText, IDataSegment segment)
        {
            throw new SegmentNotSupportedException();
        }

        /// <summary>
        /// 对命令文本进行分段处理，使之能够返回小范围内的数据。
        /// </summary>
        /// <param name="context">命令上下文对象。</param>
        /// <returns>处理后的分段命令文本。</returns>
        /// <exception cref="SegmentNotSupportedException">当前数据库或版本不支持分段时，引发该异常。</exception>
        public string Segment(CommandContext context)
        {
            throw new SegmentNotSupportedException();
        }

        /// <summary>
        /// 转换源表达式的数据类型。
        /// </summary>
        /// <param name="sourceExp">要转换的源表达式。</param>
        /// <param name="dbType">要转换的类型。</param>
        /// <returns></returns>
        public string Convert(object sourceExp, DbType dbType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据数据类型生成相应的列。
        /// </summary>
        /// <param name="dbType">数据类型。</param>
        /// <param name="length">数据长度。</param>
        /// <param name="precision">数值的精度。</param>
        /// <param name="scale">数值的小数位。</param>
        /// <returns></returns>
        public string Column(DbType dbType, int? length = new int?(), int? precision = new int?(), int? scale = new int?())
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 如果源表达式为 null，则依次判断给定的一组参数，直至某参数非 null 时返回。
        /// </summary>
        /// <param name="sourceExp">要转换的源表达式。</param>
        /// <param name="argExps">参与判断的一组参数。</param>
        /// <returns></returns>
        public string Coalesce(object sourceExp, params object[] argExps)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 格式化参数名称。
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public string FormatParameter(string parameterName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取判断表是否存在的语句。
        /// </summary>
        /// <param name="tableName">要判断的表的名称。</param>
        /// <returns></returns>
        public string ExistsTable(string tableName)
        {
            throw new NotImplementedException();
        }
    }
}
