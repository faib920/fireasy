// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Fireasy.Common.Extensions;
using System;

namespace Fireasy.Common.Aop
{
    /// <summary>
    /// 面向方面的类型工厂。
    /// </summary>
    public static class AspectFactory
    {
        /// <summary>
        /// 创建一个代理，将定义的拦截器注入到属性或方法内。
        /// </summary>
        /// <typeparam name="T">用于创建代理类型的基类型。</typeparam>
        /// <param name="args">创建对象的一组参数。</param>
        /// <returns>类型 <typeparamref name="T"/> 的代理。</returns>
        public static T BuildProxy<T>(params object[] args) where T : class
        {
            return (T)BuildProxy(typeof(T), args);
        }

        /// <summary>
        /// 创建一个代理，将定义的拦截器注入到属性或方法内。
        /// </summary>
        /// <param name="objectType">用于创建代理类型的基类型。</param>
        /// <param name="args">创建对象的一组参数。</param>
        /// <returns></returns>
        public static object BuildProxy(Type objectType, params object[] args)
        {
            Guard.ArgumentNull(objectType, "objectType");

            if (objectType.IsSealed)
            {
                throw new AspectException(SR.GetString(SRKind.AopTypeMustNotSeald, objectType.FullName));
            }

            var proxyType = InterceptBuilder.BuildTypeCached(objectType);
            return proxyType.InternalNew(args);
        }
    }
}