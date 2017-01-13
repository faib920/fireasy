// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Fireasy.Common.ComponentModel;
using Fireasy.Common.Extensions;
using Fireasy.Data.Extensions;
using Fireasy.Data.Syntax;

namespace Fireasy.Data
{
    /// <summary>
    /// 以尝试下一页作为评估依据，它并不计算数据的总量及总页数，始终只判断下一页是否有效，该评估器一般用于数据量非常大的环境中。无法继承此类。
    /// </summary>
    public sealed class TryNextEvaluator : IDataPageEvaluator
    {
        void IDataPageEvaluator.Evaluate(CommandContext context)
        {
            var dataPager = context.Segment as IPager;
            if (dataPager == null)
            {
                return;
            }

            var nextPage = new DataPager(dataPager.PageSize, dataPager.CurrentPageIndex + 1) as IDataSegment;
            var syntax = context.Database.Provider.GetService<ISyntaxProvider>();
            var sql = syntax.Segment(context.Command.CommandText, nextPage);
            using (var connection = context.Database.CreateConnection())
            {
                connection.OpenClose(() =>
                    {
                        using (var command = context.Database.Provider.CreateCommand(connection, null, sql, parameters: context.Parameters))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                dataPager.PageCount = reader.Read() ? dataPager.CurrentPageIndex + 2 : 0;
                            }
                        }
                    });
            }
        }
    }
}
