﻿// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Fireasy.Common.Caching;
using Fireasy.Common.ComponentModel;
using Fireasy.Common.Extensions;
using Fireasy.Data.Extensions;
using System;
using System.Data;
using System.Text.RegularExpressions;

namespace Fireasy.Data
{
    /// <summary>
    /// 以记录总数作为评估依据，它需要计算出返回数据的总量，然后计算总页数。无法继承此类。
    /// </summary>
    public sealed class TotalRecordEvaluator : IDataPageEvaluator
    {
        /// <summary>
        /// 获取缓存记录数的时间间隔。默认为 null，不使用缓存。
        /// </summary>
        public TimeSpan? Expiration { get; set; }

        void IDataPageEvaluator.Evaluate(CommandContext context)
        {
            var dataPager = context.Segment as IPager;
            if (dataPager == null)
            {
                return;
            }

            dataPager.RecordCount = GetRecoredCount(context);

            CalculatePageCount(dataPager);
        }

        private int GetRecoredCount(CommandContext context)
        {
            ICacheManager cacheManager;
            if (Expiration != null && 
                (cacheManager = CacheManagerFactory.CreateManager()) != null)
            {
                var key = context.Command.Output();
                return cacheManager.Contains<int>(key) ?
                    cacheManager.Get<int>(key) :
                    cacheManager.Add(key, GetRecordCountFromDatabase(context), new RelativeTime((TimeSpan)Expiration));
            }

            return GetRecordCountFromDatabase(context);
        }

        private int GetRecordCountFromDatabase(CommandContext context)
        {
            var count = 0;
            var regx = new Regex(@"\border\s*by\b([^)]+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var sql = string.Format("SELECT COUNT(*) FROM ({0}) TEMP", regx.Replace(context.Command.CommandText, string.Empty));
            using (var connection = context.Database.CreateConnection())
            {
                connection.OpenClose(() =>
                    {
                        using (var command = context.Database.Provider.CreateCommand(connection, null, sql, parameters: context.Parameters))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    switch (reader.GetFieldType(0).GetDbType())
                                    {
                                        case DbType.Decimal:
                                            count = (int)reader.GetDecimal(0);
                                            break;
                                        case DbType.Int32:
                                            count = reader.GetInt32(0);
                                            break;
                                        case DbType.Int64:
                                            count = (int)reader.GetInt64(0);
                                            break;
                                    }
                                }
                            }
                        }
                    });
            }

            return count;
        }

        /// <summary>
        /// 计算总页数。
        /// </summary>
        /// <param name="dataPager">数据分页评估器。</param>
        private void CalculatePageCount(IPager dataPager)
        {
            var num = 0;
            if (dataPager.PageSize > 0)
            {
                num = dataPager.RecordCount / dataPager.PageSize;
                if ((num * dataPager.PageSize) < dataPager.RecordCount)
                {
                    num++;
                }
            }

            dataPager.PageCount = num;
        }
    }
}
