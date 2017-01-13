// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;

namespace Fireasy.Web.Http
{
    /// <summary>
    /// 指定提供基于 MEF 的 HTTP 服务标识。
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ServiceAttribute : ExportAttribute
    {
        /// <summary>
        /// 初始化 <see cref="ServiceAttribute"/> 类的新实例。
        /// </summary>
        /// <param name="serviceName">服务的名称。</param>
        public ServiceAttribute(string serviceName)
            : base(serviceName, typeof(IHttpService))
        {
        }

        /// <summary>
        /// 获取或设置匹配的路径。
        /// </summary>
        public string UriTemplate { get; set; }
    }
}
