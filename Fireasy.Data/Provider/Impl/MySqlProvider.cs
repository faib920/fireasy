﻿// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Fireasy.Data.Batcher;
using Fireasy.Data.Extensions;
using Fireasy.Data.Identity;
using Fireasy.Data.RecordWrapper;
using Fireasy.Data.Schema;
using Fireasy.Data.Syntax;

namespace Fireasy.Data.Provider
{
    /// <summary>
    /// MySql或MairaDB数据库提供者。无法继承此类。
    /// </summary>
    public sealed class MySqlProvider : AssemblyProvider
    {
        /// <summary>
        /// 提供 <see cref="MySqlProvider"/> 的静态实例。
        /// </summary>
        public readonly static MySqlProvider Instance = new MySqlProvider();

        /// <summary>
        /// 初始化 <see cref="MySqlProvider"/> 类的新实例。
        /// </summary>
        public MySqlProvider()
            : base("MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data", null)
        {
            this.RegisterService<IGeneratorProvider, BaseSequenceGenerator>();
            this.RegisterService<ISyntaxProvider, MySqlSyntax>();
            this.RegisterService<ISchemaProvider, MySqlSchema>();
            this.RegisterService<IBatcherProvider, MySqlBatcher>();
            this.RegisterService<IRecordWrapper, GeneralRecordWrapper>();
        }

        public override string DbName
        {
            get { return "mysql"; }
        }

        /// <summary>
        /// 获取当前连接的参数。
        /// </summary>
        /// <returns></returns>
        public override ConnectionParameter GetConnectionParameter(ConnectionString connectionString)
        {
            return new ConnectionParameter
            {
                Server = connectionString.Properties["data source"],
                Database = connectionString.Properties["database"],
                UserId = connectionString.Properties["user id"],
                Password = connectionString.Properties["password"],
            };
        }

        /// <summary>
        /// 使用参数更新指定的连接。
        /// </summary>
        /// <param name="connectionString">连接字符串对象。</param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override string UpdateConnectionString(ConnectionString connectionString, ConnectionParameter parameter)
        {
            connectionString.Properties.TrySetValue(parameter.Server, "data source")
                .TrySetValue(parameter.Database, "database")
                .TrySetValue(parameter.UserId, "user id")
                .TrySetValue(parameter.Password, "password");

            return connectionString.Update();
        }
    }
}
