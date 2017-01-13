// -----------------------------------------------------------------------
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
    /// PostgreSql数据库提供者。无法继承此类。
    /// </summary>
    public sealed class PostgreSqlProvider : AssemblyProvider
    {
        /// <summary>
        /// 提供 <see cref="PostgreSqlProvider"/> 的静态实例。
        /// </summary>
        public readonly static PostgreSqlProvider Instance = new PostgreSqlProvider();

        /// <summary>
        /// 初始化 <see cref="PostgreSqlProvider"/> 类的新实例。
        /// </summary>
        public PostgreSqlProvider()
            : base("Npgsql.NpgsqlFactory, Npgsql", "Instance")
        {
            this.RegisterService<IGeneratorProvider, BaseSequenceGenerator>();
            this.RegisterService<ISyntaxProvider, PostgreSqlSyntax>();
            this.RegisterService<ISchemaProvider, PostgreSqlSchema>();
            this.RegisterService<IBatcherProvider, MySqlBatcher>();
            this.RegisterService<IRecordWrapper, GeneralRecordWrapper>();
        }

        public override string DbName
        {
            get { return "postgresql"; }
        }

        /// <summary>
        /// 获取当前连接的参数。
        /// </summary>
        /// <returns></returns>
        public override ConnectionParameter GetConnectionParameter(ConnectionString connectionString)
        {
            return new ConnectionParameter
            {
                Server = connectionString.Properties["server"],
                Database = connectionString.Properties["database"],
                UserId = connectionString.Properties["userid"],
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
            connectionString.Properties.TrySetValue(parameter.Server, "server")
                .TrySetValue(parameter.Database, "database")
                .TrySetValue(parameter.UserId, "userid")
                .TrySetValue(parameter.Password, "password");

            return connectionString.Update();
        }

    }
}
