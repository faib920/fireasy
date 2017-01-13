// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Extensions;
using Fireasy.Web.Http.Assistants;
using Fireasy.Web.Http.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Fireasy.Web.Http.Definitions
{
    /// <summary>
    /// 基于反射的 HTTP 服务定义。
    /// </summary>
    public class ReflectionServiceDescriptor : ServiceDescriptor
    {
        /// <summary>
        /// 初始化 <see cref="ReflectionServiceDescriptor"/> 类的新实例。
        /// </summary>
        /// <param name="serviceName">服务名称。</param>
        /// <param name="serviceType">服务类型。</param>
        public ReflectionServiceDescriptor(string serviceName, Type serviceType)
            : base (serviceName, serviceType)
        {
        }

        /// <summary>
        /// 获取服务的过滤器特性列表。
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<FilterAttribute> GetFilters()
        {
            return ServiceType.GetCustomAttributes<FilterAttribute>(false).ToList();
        }

        /// <summary>
        /// 获取服务的自定义特性列表。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override IEnumerable<T> GetCustomAttributes<T>()
        {
            return ServiceType.GetCustomAttributes<T>();
        }

        /// <summary>
        /// 判断是否定义了自定义特性。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override bool IsDefined<T>()
        {
            return ServiceType.IsDefined<T>();
        }

        /// <summary>
        /// 初始化所有动作。
        /// </summary>
        /// <param name="map"></param>
        protected override void InitializeActions(IDictionary<string, ActionDescriptor> map)
        {
            foreach (var method in ServiceType.GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                if (method.DeclaringType != ServiceType)
                {
                    continue;
                }

                var name = method.Name;
                var nameAttr = method.GetCustomAttributes<FriendlyNameAttribute>().FirstOrDefault();
                if (nameAttr != null && !string.IsNullOrEmpty(nameAttr.Name))
                {
                    name = nameAttr.Name;
                }

                if (map.ContainsKey(name))
                {
                    throw new HttpServiceException(string.Format("服务 {0} 已经定义了名称为 {1} 的动作，请使用 ActionNameAttribute 指定另一个名称。", ServiceName, name));
                }

                var actionDescriptor = new ReflectionActionDescriptor(this, name, method);
                var contentTypeAttr = actionDescriptor.GetCustomAttributes<ContentTypeAttribute>().FirstOrDefault();
                if (contentTypeAttr != null)
                {
                    actionDescriptor.RequestContentType = contentTypeAttr.RequestContentType;
                    actionDescriptor.ResponseContentType = contentTypeAttr.ResponseContentType;
                }

                map.Add(name.ToLower(), actionDescriptor);
            }
        }
    }
}
