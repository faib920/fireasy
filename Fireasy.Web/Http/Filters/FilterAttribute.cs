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
    /// 筛选器特性。
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple=false)]
    public class FilterAttribute : Attribute
    {
        /// <summary>
        /// 服务正在创建时进行处理。
        /// </summary>
        /// <param name="context"></param>
        public virtual void OnServiceCreating(ServiceContext context)
        {
        }
    }
}
