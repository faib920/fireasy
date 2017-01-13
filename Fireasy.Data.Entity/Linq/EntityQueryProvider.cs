// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Fireasy.Common;
using Fireasy.Common.Configuration;
using Fireasy.Common.Extensions;
using Fireasy.Data.Entity.Extensions;
using Fireasy.Data.Entity.Linq.Translators;
using Fireasy.Data.Entity.Linq.Translators.Configuration;
using Fireasy.Data.Extensions;
using Fireasy.Data.Provider;
using Fireasy.Data.RecordWrapper;
using Fireasy.Data.Syntax;

namespace Fireasy.Data.Entity.Linq
{
    /// <summary>
    /// 为实体提供 LINQ 查询的支持。无法继承此类。
    /// </summary>
    public sealed class EntityQueryProvider : IEntityQueryProvider, 
        IEntityPersistentEnvironment,
        IEntityPersistentInstanceContainer
    {
        private string instanceName;
        private EntityPersistentEnvironment environment;
        private InternalContext context;

        /// <summary>
        /// 初始化 <see cref="EntityQueryProvider"/> 类的新实例。
        /// </summary>
        public EntityQueryProvider()
        {
        }

        /// <summary>
        /// 使用一个 <see cref="IDatabase"/> 对象初始化 <see cref="EntityQueryProvider"/> 类的新实例。
        /// </summary>
        /// <param name="context">一个 <see cref="InternalContext"/> 对象。</param>
        internal EntityQueryProvider(InternalContext context)
        {
            Guard.ArgumentNull(context, "context");

            this.context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        public EntityQueryProvider(IDatabase database)
            : this (new InternalContext(database))
        {
        }

        /// <summary>
        /// 获取或设置持久化环境。
        /// </summary>
        EntityPersistentEnvironment IEntityPersistentEnvironment.Environment
        {
            get { return environment; }
            set { environment = value; }
        }

        /// <summary>
        /// 获取或设置实例名称。
        /// </summary>
        string IEntityPersistentInstanceContainer.InstanceName
        {
            get { return instanceName; }
            set { instanceName = value; }
        }

        /// <summary>
        /// 执行 <see cref="Expression"/> 的查询，返回查询结果。
        /// </summary>
        /// <param name="expression">表示 LINQ 查询的表达式树。</param>
        /// <returns>单值对象。</returns>
        /// <exception cref="TranslateException">对 LINQ 表达式解析失败时抛出此异常。</exception>
        public object Execute(Expression expression)
        {
            var lambda = expression as LambdaExpression;
            var plan = GetExecutionPlan(expression);

            if (lambda != null)
            {
                // compile & return the execution plan so it can be used multiple times
                var fn = Expression.Lambda(lambda.Type, plan, lambda.Parameters);
                return fn.Compile();
            }
            else
            {
                // compile the execution plan and invoke it
                var efn = Expression.Lambda<Func<object>>(Expression.Convert(plan, typeof(object)));
                var fn = efn.Compile();
                return fn();
            }
        }

        public Expression GetExecutionPlan(Expression expression, TranslateOptions option = null)
        {
            try
            {
                LambdaExpression lambda = expression as LambdaExpression;
                if (lambda != null)
                {
                    expression = lambda.Body;
                }

                var section = ConfigurationUnity.GetSection<TranslatorConfigurationSection>();
                var package = GetTranslateProvider();
                var options = option ?? (section == null ? package.CreateOptions() : section.Options);

                using (var scope = new TranslateScope(context, package))
                {
                    var translation = package.Translate(expression, options);

                    var parameters = lambda != null ? lambda.Parameters : null;
                    var provider = Find(expression, parameters, typeof(QueryProvider));
                    if (provider == null)
                    {
                        var rootQueryable = Find(expression, parameters, typeof(IQueryable));
                        provider = Expression.Property(rootQueryable, typeof(IQueryable).GetProperty("Provider"));
                    }

                    return package.BuildExecutionPlan(translation, provider, options);
                }
            }
            catch (Exception ex)
            {
                throw new TranslateException(expression, ex);
            }
        }

        /// <summary>
        /// 执行表达式的翻译。
        /// </summary>
        /// <param name="expression">表示 LINQ 查询的表达式树。</param>
        /// <returns>一个 <see cref="TranslateResult"/>。</returns>
        /// <param name="option">指定解析的选项。</param>
        /// <exception cref="TranslateException">对 LINQ 表达式解析失败时抛出此异常。</exception>
        public TranslateResult Translate(Expression expression, TranslateOptions option = null)
        {
            try
            {
                LambdaExpression lambda = expression as LambdaExpression;
                if (lambda != null)
                {
                    expression = lambda.Body;
                }

                var section = ConfigurationUnity.GetSection<TranslatorConfigurationSection>();
                var package = GetTranslateProvider();
                var options = option ?? (section == null ? package.CreateOptions() : section.Options);

                using (var scope = new TranslateScope(context, package))
                {
                    var translation = package.Translate(expression, options);
                    var translator = package.CreateTranslator();
                    translator.InternalContext = context;
                    translator.Environment = environment;
                    translator.Options = options;

                    TranslateResult result;
                    var selects = SelectGatherer.Gather(translation).ToList();
                    if (selects.Count > 0)
                    {
                        result = translator.Translate(selects[0]);
                        if (selects.Count > 1)
                        {
                            var list = new List<TranslateResult>();
                            for (var i = 1; i < selects.Count; i++)
                            {
                                list.Add(translator.Translate((selects[i])));
                            }

                            result.NestedResults = list.AsReadOnly();
                        }
                    }
                    else
                    {
                        translator.Options.HideTableAliases = translator.Options.HideColumnAliases = true;
                        result = translator.Translate(expression);
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new TranslateException(expression, ex);
            }
        }

        private Expression Find(Expression expression, IList<ParameterExpression> parameters, Type type)
        {
            if (parameters != null)
            {
                Expression found = parameters.FirstOrDefault(p => type.IsAssignableFrom(p.Type));
                if (found != null)
                {
                    return found;
                }
            }

            return TypedSubtreeFinder.Find(expression, type);
        }

        private ITranslateProvider GetTranslateProvider()
        {
            var provider = context.Database.Provider;
            var package = provider.GetService<ITranslateProvider>();
            if (package != null)
            {
                return package;
            }

            switch (provider.GetType().Name)
            {
                case "MsSqlProvider":
                    provider.RegisterService<ITranslateProvider, MsSqlTranslateProvider>();
                    break;
                case "OracleProvider":
                case "OracleAccessProvider":
                    provider.RegisterService<ITranslateProvider, OracleTranslateProvider>();
                    break;
                case "MySqlProvider":
                    provider.RegisterService<ITranslateProvider, MySqlTranslateProvider>();
                    break;
                case "SQLiteProvider":
                    provider.RegisterService<ITranslateProvider, SQLiteTranslateProvider>();
                    break;
                case "OleDbProvider":
                    provider.RegisterService<ITranslateProvider, AccessTranslateProvider>("Access");
                    break;
                case "PostgreSqlProvider":
                    provider.RegisterService<ITranslateProvider, PostgreSqlTranslateProvider>();
                    break;
                case "FirebirdProvider":
                    provider.RegisterService<ITranslateProvider, FirebirdTranslateProvider>();
                    break;
                default:
                    throw new Exception(SR.GetString(SRKind.TranslatorNotSupported, provider.GetType().Name));
            }

            package = provider.GetService<ITranslateProvider>();
            return package;
        }

        private class TypedSubtreeFinder : Fireasy.Common.Linq.Expressions.ExpressionVisitor
        {
            Expression root;
            Type type;

            private TypedSubtreeFinder(Type type)
            {
                this.type = type;
            }

            public static Expression Find(Expression expression, Type type)
            {
                TypedSubtreeFinder finder = new TypedSubtreeFinder(type);
                finder.Visit(expression);
                return finder.root;
            }

            public override Expression Visit(Expression exp)
            {
                Expression result = base.Visit(exp);

                // remember the first sub-expression that produces an IQueryable
                if (this.root == null && result != null)
                {
                    if (this.type.IsAssignableFrom(result.Type))
                        this.root = result;
                }

                return result;
            }
        }
    }
}
