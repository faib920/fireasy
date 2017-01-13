// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common;
using Fireasy.Common.Extensions;
using Fireasy.Common.Serialization;
using Fireasy.Web.Http.Definitions;
using Fireasy.Web.Http.Filters;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Routing;

namespace Fireasy.Web.Http
{
    /// <summary>
    /// HTTP 服务的上下文对象。
    /// </summary>
    public sealed class ServiceContext : Scope<ServiceContext>
    {
        /// <summary>
        /// 初始化 <see cref="ServiceContext"/> 类的新实例。
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="requestContext"></param>
        /// <param name="serviceDescriptor"></param>
        internal ServiceContext(HttpConfiguration configuration, RequestContext requestContext, ServiceDescriptor serviceDescriptor)
        {
            Configuration = configuration;
            RequestContext = requestContext;
            HttpContext = requestContext.HttpContext;
            ServiceDescriptor = serviceDescriptor;
            Converters = new List<ITextConverter>();
            Filters = new List<FilterAttribute>();
            Converters.AddRange(configuration.Converters);
            Filters.AddRange(configuration.Filters);
        }

        /// <summary>
        /// 获取 <see cref="RequestContext"/> 对象。
        /// </summary>
        public RequestContext RequestContext { get; private set; }

        /// <summary>
        /// 获取 <see cref="HttpContextBase"/> 对象。
        /// </summary>
        public HttpContextBase HttpContext { get; private set; }

        /// <summary>
        /// 获取 HTTP 服务的定义。
        /// </summary>
        public ServiceDescriptor ServiceDescriptor { get; private set; }

        /// <summary>
        /// 获取正在执行动作的定义。
        /// </summary>
        public ActionDescriptor ActionDescriptor { get; internal set; }

        /// <summary>
        /// 获取 HTTP 服务实例。
        /// </summary>
        public IHttpService HttpService { get; internal set; }

        /// <summary>
        /// 获取用于转换输出结果的 <see cref="ITextConverter"/> 转换器集合。
        /// </summary>
        public List<ITextConverter> Converters { get; private set; }

        /// <summary>
        /// 获取或设置动作执行器实例。
        /// </summary>
        public IActionInvoker ActionInvoker { get; set; }

        /// <summary>
        /// 获取或设置结果输出器实例。
        /// </summary>
        public IResultWriter ResultWriter { get; set; }

        /// <summary>
        /// 获取当前的筛选器列表。
        /// </summary>
        public List<FilterAttribute> Filters { get; internal set; }

        /// <summary>
        /// 获取当前的 <see cref="HttpConfiguration"/> 实例。
        /// </summary>
        public HttpConfiguration Configuration { get; private set; }

        /// <summary>
        /// 设置 HTTP 响应的状态码及描述。
        /// </summary>
        /// <param name="statusCode">HTTP 状态码。</param>
        /// <param name="statusDescription">对状态的描述。</param>
        public void SetStatus(HttpStatusCode statusCode, string statusDescription = null)
        {
            if (string.IsNullOrEmpty(statusDescription))
            {
                statusDescription = statusCode.ToString();
            }

            if (HttpContext != null)
            {
                HttpContext.Response.StatusCode = (int)statusCode;
                HttpContext.Response.StatusDescription = statusDescription;
            }
        }

        protected override void Dispose(bool disposing)
        {
            HttpService.TryDispose();
            base.Dispose(disposing);
        }
    }
}
