// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Composition;
using Fireasy.Common.Extensions;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Routing;

namespace Fireasy.Web.Http.Definitions
{
    /// <summary>
    /// 使用 MEF 配置实现 Http 服务的工厂类。
    /// </summary>
    public class MEFServiceFactory : ReflectionServiceFactory
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

            //从MEF容器里查找实例
            try
            {
                var instance = GetInstance(requestContext.HttpContext.Request.RawUrl, serviceName);
                if (instance == null)
                {
                    throw new HttpServiceException(string.Format("找不到名称为 {0} 的服务。", serviceName));
                }

                return GetServiceDescriptor(serviceName, instance.GetType());
            }
            catch (Exception exp)
            {
                throw new HttpServiceException(string.Format("无法导出名称为 {0} 的服务类，请检查服务类是否已标注 ServiceAttribute 特性。或是服务类所属的程序集未配置在 MEF 容器中。", serviceName), exp);
            }
        }

        private IHttpService GetInstance(string url, string serviceName)
        {
            var instances = Imports.GetServices<IHttpService>(serviceName).ToList();
            if (instances.Count == 0)
            {
                return null;
            }

            if (instances.Count == 1)
            {
                return instances[0];
            }

            foreach (var instance in instances)
            {
                var attr = instance.GetType().GetCustomAttributes<ServiceAttribute>().FirstOrDefault();
                if (attr != null && !string.IsNullOrEmpty(attr.UriTemplate))
                {
                    var tmp = attr.UriTemplate.Replace("{service}", serviceName);
                    if (Regex.IsMatch(url, tmp, RegexOptions.IgnoreCase))
                    {
                        return instance;
                    }
                }
            }

            throw new HttpServiceException(string.Format("存在多个名称为 {0} 的服务类，请在 ServiceAttribute 中使用 UriMatch 标记。", serviceName));
        }
    }
}
