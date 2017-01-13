using Fireasy.Common.Caching;
using Fireasy.Common.Extensions;
using System;
using System.Linq;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Web.Routing;
using System.Web.SessionState;

namespace Fireasy.Web.Http.Definitions
{
    /// <summary>
    /// HTTP 服务工厂的抽象类。
    /// </summary>
    public abstract class ReflectionServiceFactory : IServiceFactory
    {
        /// <summary>
        /// 从路由请求对象中获取动作的名称。
        /// </summary>
        /// <param name="requestContext">路由请求对象。</param>
        /// <returns></returns>
        public string GetActionName(RequestContext requestContext)
        {
            return requestContext.RouteData.Values["action"].ToString();
        }

        /// <summary>
        /// 从路由请求对象中获取 HTTP 服务定义。
        /// </summary>
        /// <param name="requestContext">路由请求对象。</param>
        /// <returns></returns>
        public virtual ServiceDescriptor GetDescriptor(RequestContext requestContext)
        {
            return null;
        }

        /// <summary>
        /// 创建服务实例。
        /// </summary>
        /// <param name="serviceDescriptor">服务定义对象。</param>
        /// <returns></returns>
        public virtual IHttpService CreateInstance(ServiceDescriptor serviceDescriptor)
        {
            return serviceDescriptor.ServiceType.New<IHttpService>();
        }

        /// <summary>
        /// 从路由请求对象中获取会话状态枚举。
        /// </summary>
        /// <param name="requestContext">路由请求对象。</param>
        /// <returns></returns>
        public virtual SessionStateBehavior GetSessionStateBehavior(RequestContext requestContext)
        {
            var service = GetDescriptor(requestContext);
            if (service == null)
            {
                return SessionStateBehavior.Default;
            }

            var actionName = GetActionName(requestContext);
            var actionDescriptor = service.FindAction(actionName);
            if (actionDescriptor == null)
            {
                return SessionStateBehavior.Default;
            }

            var attr = actionDescriptor.GetCustomAttributes<SessionStateAttribute>().FirstOrDefault();
            if (attr != null)
            {
                return attr.Behavior;
            }

            var serviceType = actionDescriptor.ServiceDescriptor.ServiceType;
            attr = serviceType.GetCustomAttributes<SessionStateAttribute>().FirstOrDefault();
            return attr == null ? SessionStateBehavior.Default : attr.Behavior;
        }

        protected ServiceDescriptor GetServiceDescriptor(string serviceName, Type serviceType)
        {
            return DescriptorUtil.GetServiceDescriptor(serviceName, serviceType, (name, type) => new ReflectionServiceDescriptor(name, type));
        }
    }
}
