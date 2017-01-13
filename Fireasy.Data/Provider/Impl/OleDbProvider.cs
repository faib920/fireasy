// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Fireasy.Common.Extensions;
using Fireasy.Data.Extensions;
using Fireasy.Data.Identity;
using Fireasy.Data.RecordWrapper;
using Fireasy.Data.Schema;
using Fireasy.Data.Syntax;

namespace Fireasy.Data.Provider
{
    /// <summary>
    /// OleDb数据库提供者。无法继承此类。
    /// </summary>
    public sealed class OleDbProvider : ProviderBase
    {
        /// <summary>
        /// 提供 <see cref="OleDbProvider"/> 的静态实例。
        /// </summary>
        public readonly static OleDbProvider Instance = new OleDbProvider();

        /// <summary>
        /// 初始化 <see cref="OleDbProvider"/> 类的新实例。
        /// </summary>
        public OleDbProvider()
            : base("System.Data.OleDb")
        {
            this.RegisterService<IGeneratorProvider, BaseSequenceGenerator>();
            this.RegisterService<ISchemaProvider, OleDbSchema>();
            this.RegisterService<IRecordWrapper, GeneralRecordWrapper>();
            this.RegisterService<ISyntaxProvider, AccessSyntax>("Access");
        }

        public override string DbName
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// 获取当前连接的参数。
        /// </summary>
        /// <returns></returns>
        public override ConnectionParameter GetConnectionParameter(ConnectionString connectionString)
        {
            var provider = connectionString.Properties["provider"];

            var parameter = new ConnectionParameter
            {
                Database = connectionString.Properties["data source"],
                UserId = connectionString.Properties["user id"],
                Password = connectionString.Properties["password"]
            };

            switch (provider.ToUpper())
            {
                case "SQLOLEDB":
                    parameter.Schema = "dbo";
                    break;
                case "MSDAORA":
                case "MSDAORA.1":
                    parameter.Schema = connectionString.Properties["user id"].ToUpper();
                    break;
            }

            return parameter;
        }

        /// <summary>
        /// 使用参数更新指定的连接。
        /// </summary>
        /// <param name="connectionString">连接字符串对象。</param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override string UpdateConnectionString(ConnectionString connectionString, ConnectionParameter parameter)
        {
            connectionString.Properties
                .TrySetValue(parameter.Database, "data source")
                .TrySetValue(parameter.UserId, "user id")
                .TrySetValue(parameter.Password, "password");

            return connectionString.Update();
        }

        /// <summary>
        /// 获取注册到数据库提供者的插件服务实例。
        /// </summary>
        /// <typeparam name="TProvider">插件服务的类型。</typeparam>
        /// <returns></returns>
        public override TProvider GetService<TProvider>()
        {
            var database = DatabaseFactory.GetDatabaseFromScope();
            if (database == null)
            {
                return base.GetService<TProvider>();
            }

            var parameter = GetConnectionParameter(database.ConnectionString);
            if (parameter == null || parameter.Database == null)
            {
                return base.GetService<TProvider>();
            }

            var fileName = parameter.Database.ToLower();

            if (fileName.EndsWith(".mdb") || fileName.EndsWith(".accdb"))
            {
                return ProviderExtension.GetService<TProvider>(this, "Access");
            }

            return base.GetService<TProvider>();
        }
    }
}
