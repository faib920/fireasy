using Fireasy.Web.Http.Filters;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Fireasy.Web.Http.Definitions
{
    /// <summary>
    /// 表示 HTTP 动作的定义。
    /// </summary>
    public class ActionDescriptor
    {
        /// <summary>
        /// 初始化 <see cref="ActionDescriptor"/> 类的新实例。
        /// </summary>
        /// <param name="serviceDescriptor">HTTP 服务定义。</param>
        /// <param name="actionName">动作的名称。</param>
        protected ActionDescriptor(ServiceDescriptor serviceDescriptor, string actionName)
        {
            ServiceDescriptor = serviceDescriptor;
            ActionName = actionName;
        }

        /// <summary>
        /// 获取动作的过滤器特性列表。
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<FilterAttribute> GetFilters()
        {
            return Enumerable.Empty<FilterAttribute>();
        }

        /// <summary>
        /// 获取动作的自定义特性列表。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IEnumerable<T> GetCustomAttributes<T>() where T : Attribute
        {
            return new T[0];
        }

        /// <summary>
        /// 判断是否定义了自定义特性。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual bool IsDefined<T>() where T : Attribute
        {
            return false;
        }

        /// <summary>
        /// 获取动作的名称。
        /// </summary>
        public string ActionName { get; private set; }

        /// <summary>
        /// 获取或设置请求的内容类型。
        /// </summary>
        public ContentType RequestContentType { get; set; }

        /// <summary>
        /// 获取或设置响应的内容类型。
        /// </summary>
        public ContentType ResponseContentType { get; set; }

        /// <summary>
        /// 获取返回类型。
        /// </summary>
        public virtual Type ReturnType { get; set; }

        /// <summary>
        /// 获取参数定义的集合。
        /// </summary>
        public virtual ReadOnlyCollection<ParameterDescriptor> Parameters { get; set; }

        /// <summary>
        /// 获取动作所属的 HTTP 服务定义 <see cref="ServiceDescriptor"/> 实例。
        /// </summary>
        public ServiceDescriptor ServiceDescriptor { get; private set; }

        /// <summary>
        /// 执行该动作。
        /// </summary>
        /// <param name="parameters">动作的参数字典。</param>
        /// <returns></returns>
        public virtual object Execute(IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
