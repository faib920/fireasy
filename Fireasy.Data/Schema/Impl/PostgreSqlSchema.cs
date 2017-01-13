// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;

namespace Fireasy.Data.Schema
{
    /// <summary>
    /// PostgreSql相关数据库架构信息的获取方法。
    /// </summary>
    public class PostgreSqlSchema : SchemaBase
    {
        public PostgreSqlSchema()
        {
            AddRestrictionIndex<Table>(s => s.Catalog, s => s.Schema, s => s.Name, s => s.Type);
            AddRestrictionIndex<Column>(s => s.Catalog, s => s.Schema, s => s.TableName, s => s.Name);
            AddRestrictionIndex<User>(s => s.Name);
        }

        /// <summary>
        /// 获取架构的名称。
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        protected override string GetSchemaCategoryName(SchemaCategory category)
        {
            switch (category)
            {
                case SchemaCategory.Column:
                    return "Columns";
                case SchemaCategory.DataType:
                    return "DataTypes";
                case SchemaCategory.MetadataCollection:
                    return "MetaDataCollections";
                case SchemaCategory.ReservedWord:
                    return "ReservedWords";
                case SchemaCategory.Restriction:
                    return "Restrictions";
                case SchemaCategory.Table:
                    return "Tables";
                case SchemaCategory.User:
                    return "Users";
                case SchemaCategory.View:
                    return "Views";
                default:
                    return base.GetSchemaCategoryName(category);
            }
        }


        /// <summary>
        /// 获取 <see cref="Column"/> 元数据序列。
        /// </summary>
        /// <param name="table">架构信息的表。</param>
        /// <param name="action">用于填充元数据的方法。</param>
        /// <returns></returns>
        protected override IEnumerable<Column> GetColumns(DataTable table, Action<Column, DataRow> action)
        {
            return base.GetColumns(table, (t, r) =>
                {
                    t.IsNullable = r["IS_NULLABLE"].ToString() == "YES";
                });
        }
    }
}
