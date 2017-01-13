// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.SessionState;
using Fireasy.Common.Extensions;
using System.Collections.Generic;
using System.Net;
using Fireasy.Web.Http.Filters;
using Fireasy.Web.Http.Definitions;

namespace Fireasy.Web.Http
{
    /// <summary>
    /// HTTP 服务的请求处理器。
    /// </summary>
    public class HttpHandler : IHttpHandler, IReadOnlySessionState
    {
        private RequestContext requestContext;
        private HttpConfiguration configuration;

        /// <summary>
        /// 初始化 <see cref="HttpHandler"/> 类的新实例。
        /// </summary>
        /// <param name="context"></param>
        public HttpHandler(RequestContext context, HttpConfiguration configuration)
        {
            requestContext = context;
            this.configuration = configuration;
        }

        bool IHttpHandler.IsReusable
        {
            get { return false; }
        }

        /// <summary>
        /// 处理 HTTP WEB 的请求。
        /// </summary>
        /// <param name="context"></param>
        public virtual void ProcessRequest(HttpContext context)
        {
            var serviceDescriptor = configuration.ServiceFactory.GetDescriptor(requestContext);
            if (serviceDescriptor == null)
            {
                return;
            }

            using (var serviceContext = new ServiceContext(configuration, requestContext, serviceDescriptor))
            {
                var actionName = configuration.ServiceFactory.GetActionName(requestContext);
                if (string.IsNullOrEmpty(actionName))
                {
                    return;
                }

                var filters = GetFilters(configuration.Filters, serviceDescriptor);
                OnServiceCreating(serviceContext, filters);

                serviceContext.HttpService = configuration.ServiceFactory.CreateInstance(serviceDescriptor);
                var invoker = serviceContext.ActionInvoker ?? configuration.ActionInvoker;
                var value = invoker.Execute(serviceContext, actionName);
                var writer = serviceContext.ResultWriter ?? configuration.ResultWriter;
                writer.Write(serviceContext, value);
            };
        }

        private List<FilterAttribute> GetFilters(IList<FilterAttribute> baseFilters, ServiceDescriptor serviceDescriptor)
        {
            var filters = serviceDescriptor.GetFilters();
            return filters.Union(baseFilters).ToList();
        }

        private void OnServiceCreating(ServiceContext serviceContext, IEnumerable<FilterAttribute> filters)
        {
            filters.ForEach(s => s.OnServiceCreating(serviceContext));
        }
    }
}
