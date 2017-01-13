// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Data;
using System.Text;

namespace Fireasy.Data.Syntax
{
    /// <summary>
    /// Microsoft Access函数语法解析。
    /// </summary>
    public class MsAccessSyntax : ISyntaxProvider
    {   
        /// <summary>
        /// 获取字符串函数相关的语法。
        /// </summary>
        public virtual StringSyntax String
        {
            get { return new MsAccessStringSyntax(); }
        }

        /// <summary>
        /// 获取日期函数相关的语法。
        /// </summary>
        public virtual DateTimeSyntax DateTime
        {
            get { return new MsAccessDateTimeSyntax(); }
        }

        /// <summary>
        /// 获取数学函数相关的语法。
        /// </summary>
        public virtual MathSyntax Math
        {
            get { return new MsAccessMathSyntax(); }
        }

        /// <summary>
        /// 获取最近创建的自动编号的查询文本。
        /// </summary>
        public virtual string IdentitySelect
        {
            get { return ";SELECT @@IDENTITY"; }
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
        public virtual char ParameterPrefix
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
            get { return "\nGO\n"; }
        }

        /// <summary>
        /// 对命令文本进行分段处理，使之能够返回小范围内的数据。
        /// </summary>
        /// <param name="context">命令上下文对象。</param>
        /// <returns>处理后的分段命令文本。</returns>
        /// <exception cref="SegmentNotSupportedException">当前数据库或版本不支持分段时，引发该异常。</exception>
        public virtual string Segment(CommandContext context)
        {
            return Segment(context.Command.CommandText, context.Segment);
        }

        /// <summary>
        /// 对命令文本进行分段处理，使之能够返回小范围内的数据。
        /// </summary>
        /// <param name="commandText">命令文本。</param>
        /// <param name="segment">数据分段对象。</param>
        /// <returns>处理后的分段命令文本。</returns>
        /// <exception cref="SegmentNotSupportedException">当前数据库或版本不支持分段时，引发该异常。</exception>
        public virtual string Segment(string commandText, IDataSegment segment)
        {
            return commandText;
        }

        /// <summary>
        /// 转换源表达式的数据类型。
        /// </summary>
        /// <param name="sourceExp">要转换的源表达式。</param>
        /// <param name="dbType">要转换的类型。</param>
        /// <returns></returns>
        public virtual string Convert(object sourceExp, DbType dbType)
        {
            switch (dbType)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                case DbType.StringFixedLength:
                    return string.Format("CSTR({0})", sourceExp);
                case DbType.Binary:
                    return string.Format("CVAR({0})", sourceExp);
                case DbType.Boolean:
                    return string.Format("CBOOL({0})", sourceExp);
                case DbType.Byte:
                    return string.Format("CBYTE({0})", sourceExp);
                case DbType.Currency:
                    return string.Format("CCUR({0})", sourceExp);
                case DbType.Date:
                case DbType.DateTime:
                    return string.Format("CDATE({0})", sourceExp);
                case DbType.DateTime2:
                    ExceptionHelper.ThrowSyntaxConvertException(dbType);
                    break;
                case DbType.DateTimeOffset:
                    ExceptionHelper.ThrowSyntaxConvertException(dbType);
                    break;
                case DbType.Decimal:
                    return string.Format("CDEC({0})", sourceExp);
                case DbType.Double:
                    return string.Format("CDBL({0})", sourceExp);
                case DbType.Guid:
                    return string.Format("CSTR({0})", sourceExp);
                case DbType.Int16:
                case DbType.Int32:
                case DbType.UInt16:
                case DbType.UInt32:
                    return string.Format("CINT({0})", sourceExp);
                case DbType.Int64:
                case DbType.UInt64:
                    return string.Format("CLNG({0})", sourceExp);
                case DbType.SByte:
                    ExceptionHelper.ThrowSyntaxConvertException(dbType);
                    break;
                case DbType.Single:
                    return string.Format("CSNG({0})", sourceExp);
                case DbType.Time:
                case DbType.VarNumeric:
                case DbType.Xml:
                    break;
            }
            throw new SyntaxParseException("ConvertTo" + dbType);
        }

        /// <summary>
        /// 根据数据类型生成相应的列。
        /// </summary>
        /// <param name="dbType">数据类型。</param>
        /// <param name="length">数据长度。</param>
        /// <param name="precision">数值的精度。</param>
        /// <param name="scale">数值的小数位。</param>
        /// <returns></returns>
        public string Column(DbType dbType, int? length, int? precision, int? scale = new int?())
        {
            switch (dbType)
            {
                case DbType.AnsiString:
                    if (length == null)
                    {
                        return "VARCHAR(255)";
                    }
                    if (length > 8000)
                    {
                        return "NTEXT";
                    }
                    return string.Format("VARCHAR({0})", length);
                case DbType.AnsiStringFixedLength:
                    return length == null ? "CHAR(255)" : string.Format("CHAR({0})", length);
                case DbType.Binary:
                    if (length == null)
                    {
                        return "VARBINARY(8000)";
                    }
                    if (length > 8000)
                    {
                        return "IMAGE";
                    }
                    return string.Format("VARBINARY({0})", length);
                case DbType.Boolean:
                    return "BIT";
                case DbType.Byte:
                    return "TINYINT";
                case DbType.Currency:
                    return "MONEY";
                case DbType.Date:
                    return "DATETIME";
                case DbType.DateTime:
                    return "DATETIME";
                case DbType.DateTime2:
                    ExceptionHelper.ThrowSyntaxCreteException(dbType);
                    break;
                case DbType.DateTimeOffset:
                    ExceptionHelper.ThrowSyntaxCreteException(dbType);
                    break;
                case DbType.Decimal:
                    if (precision == null && scale == null)
                    {
                        return "DECIMAL(19, 5)";
                    }
                    if (precision == null)
                    {
                        return string.Format("DECIMAL(19, {0})", scale);
                    }
                    if (scale == null)
                    {
                        return string.Format("DECIMAL({0}, 5)", precision);
                    }
                    return string.Format("DECIMAL({0}, {1})", precision, scale);
                case DbType.Double:
                    return "DOUBLE PRECISION";
                case DbType.Guid:
                    return "UNIQUEIDENTIFIER";
                case DbType.Int16:
                    return "SMALLINT";
                case DbType.Int32:
                    return "INT";
                case DbType.Int64:
                    return "BIGINT";
                case DbType.SByte:
                    return "TINYINT";
                case DbType.Single:
                    return "REAL";
                case DbType.String:
                    if (length == null)
                    {
                        return "VARCHAR(255)";
                    }
                    if (length > 8000)
                    {
                        return "NTEXT";
                    }
                    return string.Format("VARCHAR({0})", length);
                case DbType.StringFixedLength:
                    if (length == null)
                    {
                        return "NCHAR(255)";
                    }
                    return string.Format("NCHAR({0})", length);
                case DbType.Time:
                    return "DATETIME";
                case DbType.UInt16:
                case DbType.UInt32:
                case DbType.UInt64:
                case DbType.VarNumeric:
                case DbType.Xml:
                    break;
            }
            throw new SyntaxParseException("Create" + dbType);
        }

        /// <summary>
        /// 如果源表达式为 null，则依次判断给定的一组参数，直至某参数非 null 时返回。
        /// </summary>
        /// <param name="sourceExp">要转换的源表达式。</param>
        /// <param name="argExps">参与判断的一组参数。</param>
        /// <returns></returns>
        public virtual string Coalesce(object sourceExp, params object[] argExps)
        {
            if (argExps == null || argExps.Length == 0)
            {
                return sourceExp.ToString();
            }
            var sb = new StringBuilder();
            sb.AppendFormat("IIF({0} <> NULL", sourceExp);
            for (var i = 0; i < argExps.Length - 1; i++)
            {
                sb.AppendFormat(", IIF({0} <> NULL", argExps[i]);
            }
            sb.AppendFormat(", {0}", argExps[argExps.Length - 1]);
            for (var i = 0; i < argExps.Length - 1; i++)
            {
                sb.Append(")");
            }
            sb.Append(")");
            return sb.ToString();
        }

        /// <summary>
        /// 格式化参数名称。
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public virtual string FormatParameter(string parameterName)
        {
            return ParameterPrefix + parameterName;
        }

        /// <summary>
        /// 获取判断表是否存在的语句。
        /// </summary>
        /// <param name="tableName">要判断的表的名称。</param>
        /// <returns></returns>
        public string ExistsTable(string tableName)
        {
            throw new System.NotImplementedException();
        }

    }
}
