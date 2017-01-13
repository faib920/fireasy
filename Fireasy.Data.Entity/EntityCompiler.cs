// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Aop;
using Fireasy.Common.Emit;
using Fireasy.Common.Extensions;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Fireasy.Data.Entity
{
    /// <summary>
    /// 实体代理编译器。
    /// </summary>
    public class EntityCompiler
    {
        private static ConcurrentDictionary<Type, Type> proxyTypes = new ConcurrentDictionary<Type, Type>();
        private static object locker = new object();

        /// <summary>
        /// 初始化 <see cref="EntityContext"/> 对象中的所有实体类型的代理。
        /// </summary>
        /// <param name="contextType"></param>
        /// <param name="entityTypes"></param>
        public static void CompileContextTypes(Type contextType, Type[] entityTypes)
        {
            //查找未实现的AOP类型
            entityTypes = entityTypes.Where(s => s.IsNotImplAOPType()).ToArray();
            if (entityTypes.Length == 0)
            {
                return;
            }

            lock(locker)
            {
                var assemblyBuilder = new DynamicAssemblyBuilder(contextType.FullName + "_Proxy");
                var option = new InterceptBuildOption { AssemblyBuilder = assemblyBuilder, TypeNameFormatter = "{0}_Proxy" };
                foreach (var type in entityTypes)
                {
                    proxyTypes.TryAdd(type, InterceptBuilder.BuildType(type, option));
                }
            }
        }

        /// <summary>
        /// 获取类型的代理类型。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetProxyType(Type type)
        {
            var lazy = new Lazy<Type>(() => 
                {
                    var option = new InterceptBuildOption { TypeNameFormatter = "{0}_Proxy" };

                    if (!typeof(IAopSupport).IsAssignableFrom(type))
                    {
                        option.TypeInitializer = b =>
                            {
                                b.SetCustomAttribute<InterceptAttribute>(typeof(LighEntityInterceptor));
                            };
                    }

                    return InterceptBuilder.BuildType(type, option);
                });

            return proxyTypes.GetOrAdd(type, t => lazy.Value);
        }

        /// <summary>
        /// 创建一个代理对象。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object NewProxy(Type type)
        {
            return GetProxyType(type).New();
        }
    }
}
