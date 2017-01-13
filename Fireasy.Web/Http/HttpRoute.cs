using System;
using System.Collections.Generic;
using System.ComponentModel;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using System.Web.UI;

namespace Fireasy.Web.Http
{
    /// <summary>
    /// HTTP 路由。
    /// </summary>
    public class HttpRoute : RouteBase, IRouteHandler
    {
        private Route innerRoute = null;
        private object defaults = null;

        /// <summary>
        /// 初始化 <see cref="HttpRoute"/> 类的新实例。
        /// </summary>
        /// <param name="routeTemplate"></param>
        /// <param name="defaults"></param>
        public HttpRoute(string routeTemplate, object defaults = null)
        {
            innerRoute = new Route(routeTemplate, new RouteValueDictionary(), this);
            this.defaults = defaults;
        }

         /// <summary>
        /// 返回有关路由的信息。
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var data = innerRoute.GetRouteData(httpContext);
            if (data == null)
            {
                return null;
            }

            CheckRouteData(data, "service");
            CheckRouteData(data, "action");

            return data;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }

        /// <summary>
        /// 获取提供处理请求的对象。
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns></returns>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var configuration = HttpConfiguration.GetConfiguration(innerRoute.Url);
            var sessionState = configuration.ServiceFactory.GetSessionStateBehavior(requestContext);
            requestContext.HttpContext.SetSessionStateBehavior(sessionState);
            return new HttpHandler(requestContext, configuration);
        }

        private void CheckRouteData(RouteData data, string key)
        {
            if (data.Values[key] == null)
            {
                data.Values[key] = GetValueFormDefaults(key);
            }
        }

        private object GetValueFormDefaults(string key)
        {
            if (defaults == null || string.IsNullOrEmpty(key))
            {
                return null;
            }

            var properties = TypeDescriptor.GetProperties(defaults);
            var property = properties.Find(key, true);
            if (property != null)
            {
                return property.GetValue(defaults);
            }

            return null;
        }
    }
}
