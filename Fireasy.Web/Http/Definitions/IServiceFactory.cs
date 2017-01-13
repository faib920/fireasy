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
    /// HTTP 服务工厂。
    /// </summary>
    public interface IServiceFactory
    {
        /// <summary>
        /// 从路由请求对象中获取动作的名称。
        /// </summary>
        /// <param name="requestContext">路由请求对象。</param>
        /// <returns></returns>
        string GetActionName(RequestContext requestContext);

        /// <summary>
        /// 从路由请求对象中获取 HTTP 服务定义。
        /// </summary>
        /// <param name="requestContext">路由请求对象。</param>
        /// <returns></returns>
        ServiceDescriptor GetDescriptor(RequestContext requestContext);
        
        /// <summary>
        /// 创建服务实例。
        /// </summary>
        /// <param name="serviceDescriptor">服务定义对象。</param>
        /// <returns></returns>
        IHttpService CreateInstance(ServiceDescriptor serviceDescriptor);

        /// <summary>
        /// 从路由请求对象中获取会话状态枚举。
        /// </summary>
        /// <param name="requestContext">路由请求对象。</param>
        /// <returns></returns>
        SessionStateBehavior GetSessionStateBehavior(RequestContext requestContext);
    }
}
