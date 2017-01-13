// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Extensions;
using Fireasy.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Fireasy.Windows.Designer
{
    internal class EntityAssemblyHelper
    {
        internal static void CheckAssembly(object instance, Action<Assembly> action)
        {
            var assembly = instance.GetType().Assembly;
            if (IsFireasyEntityAssembly(assembly))
            {
                action(assembly);
            }

            foreach (var assemblyName in assembly.GetReferencedAssemblies())
            {
                try
                {
                    var assembly1 = Assembly.Load(assemblyName.FullName);
                    if (IsFireasyEntityAssembly(assembly1))
                    {
                        action(assembly1);
                    }
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 获取指定程序集中的实体类集合。
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        internal static IEnumerable<Type> GetEntityTypes(Assembly assembly)
        {
            return assembly.GetExportedTypes().Where(s => s.IsPublic && !s.IsAbstract && typeof(EntityObject).IsAssignableFrom(s));
        }

        /// <summary>
        /// 判断程序集是否是 Fireasy Entity 实体程序集。
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private static bool IsFireasyEntityAssembly(Assembly assembly)
        {
            return assembly.IsDefined<EntityDiscoverAssemblyAttribute>();
        }
    }
}
