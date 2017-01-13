// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;

namespace Fireasy.Web.Http.Filters
{
    /// <summary>
    /// 该特性用于标记在授权期间要跳过 <see cref="AuthorizeAttribute"/> 的筛选。
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class AllowAnonymousAttribute : Attribute
    {
    }
}
