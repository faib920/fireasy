// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;

namespace Fireasy.Data.Entity.Linq.Translators
{
    /// <summary>
    /// 提供方法调用的绑定特性。
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class MethodCallBindAttribute : Attribute
    {
        /// <summary>
        /// 初始化 <see cref="MethodCallBindAttribute"/> 类的新实例。
        /// </summary>
        /// <param name="binderType"></param>
        public MethodCallBindAttribute(Type binderType)
        {
            BinderType = binderType;
        }

        /// <summary>
        /// 获取或设置绑定类。
        /// </summary>
        public Type BinderType { get; set; }
    }
}
