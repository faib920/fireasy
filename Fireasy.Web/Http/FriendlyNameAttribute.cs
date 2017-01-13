// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;

namespace Fireasy.Web.Http
{
    /// <summary>
    /// 指定动作的名称。动作名称默认为方法的名称，但也可以通过此特性指定名称。
    /// </summary>
    public sealed class FriendlyNameAttribute : Attribute
    {
        /// <summary>
        /// 使用动作名称初始化 <see cref="FriendlyNameAttribute"/> 类的新实例。
        /// </summary>
        /// <param name="name">动作名称。</param>
        public FriendlyNameAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 获取或设置动作名称。
        /// </summary>
        public string Name { get; set; }
    }
}
