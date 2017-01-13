// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.IO;
using System.Web.Compilation;
using System.Web.Routing;
using System.Web.UI;
using Fireasy.Common.Extensions;

namespace Fireasy.Web.Http.Definitions
{
    /// <summary>
    /// 使用 AspPage 处理程序实现 Http 服务的工厂类。
    /// </summary>
    public class AspPageServiceFactory : ReflectionServiceFactory
    {
        /// <summary>
        /// 从路由请求对象中获取 HTTP 服务定义。
        /// </summary>
        /// <param name="requestContext">路由请求对象。</param>
        /// <returns></returns>
        public override ServiceDescriptor GetDescriptor(RequestContext requestContext)
        {
            if (requestContext.RouteData.Values["service"] == null)
            {
                throw new HttpServiceException("路由 URL 中未配置 {service} 参数。");
            }

            var serviceName = requestContext.RouteData.Values["service"].ToString();

            var virualPath = ResoleVirualPath(requestContext.HttpContext.Request.RawUrl);

            try
            {
                var instance = BuildManager.CreateInstanceFromVirtualPath(virualPath, typeof(Page)) as IHttpService;
                if (instance == null)
                {
                    throw new HttpServiceException(string.Format("找不到名称为 {0} 的服务。", serviceName));
                }

                return GetServiceDescriptor(serviceName, instance.GetType().BaseType);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private string ResoleVirualPath(string virualPath)
        {
            var dotIndex = virualPath.LastIndexOf('.');
            var speIndex = virualPath.LastIndexOf('/');
            if (speIndex < dotIndex)
            {
                throw new Exception("不符合路由规则。");
            }
            
            virualPath = virualPath.Substring(0, speIndex);
            var path = virualPath.Substring(0, dotIndex);
            return string.Concat(path, ".aspx");
        }
    }
}
