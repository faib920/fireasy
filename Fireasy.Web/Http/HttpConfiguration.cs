// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Extensions;
using Fireasy.Common.Serialization;
using Fireasy.Web.Http.Definitions;
using Fireasy.Web.Http.Filters;
using System;
using System.Collections.Generic;
using System.Web.Routing;

namespace Fireasy.Web.Http
{
    /// <summary>
    /// HTTP 基础配置类。
    /// </summary>
    public sealed class HttpConfiguration : ICloneable
    {
        private static Dictionary<string, HttpConfiguration> configurations = new Dictionary<string, HttpConfiguration>();

        /// <summary>
        /// 获取默认的 <see cref="HttpConfiguration"/> 实例。
        /// </summary>
        public static HttpConfiguration Default = new HttpConfiguration
            {
                ServiceFactory = new MEFServiceFactory(),
                ActionInvoker = new ReflectionActionInvoker(),
                ResultWriter = new DefaultResultWriter(),
                ResponseContentType = ContentType.Json,
                Filters = new FilterAttributeCollection { new ExceptionActionFilterAttribute() },
                Converters = new List<ITextConverter>(),
            };

        /// <summary>
        /// 获取或设置结果输出到客户端的内容类型。
        /// </summary>
        public ContentType ResponseContentType { get; set; }

        /// <summary>
        /// 获取动作过滤器列表。
        /// </summary>
        public FilterAttributeCollection Filters { get; private set; }

        /// <summary>
        /// 获取文本转换器列表。
        /// </summary>
        public List<ITextConverter> Converters { get; private set; }

        /// <summary>
        /// 获取或设置服务工厂实例。
        /// </summary>
        public IServiceFactory ServiceFactory { get; set; }

        /// <summary>
        /// 获取或设置动作执行器实例。
        /// </summary>
        public IActionInvoker ActionInvoker { get; set; }

        /// <summary>
        /// 获取或设置结果输出器实例。
        /// </summary>
        public IResultWriter ResultWriter { get; set; }

        /// <summary>
        /// 克隆一个副本。
        /// </summary>
        /// <returns></returns>
        public HttpConfiguration Clone()
        {
            var instance = new HttpConfiguration
                {
                    ActionInvoker = ActionInvoker,
                    ResultWriter = ResultWriter,
                    ServiceFactory = ServiceFactory,
                    ResponseContentType = ResponseContentType,
                    Converters = new List<ITextConverter>(),
                    Filters = new FilterAttributeCollection()
                }; 

            instance.Converters.AddRange(Converters);
            instance.Filters.AddRange(Filters);

            return instance;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// 映射路由地址。
        /// </summary>
        /// <param name="routeTemplate">路由模板。</param>
        /// <param name="configuration">指定此模板应用的 <see cref="HttpConfiguration"/>。</param>
        /// <param name="defaults">默认设置。</param>
        public static void MapHttpRoute(string routeTemplate, HttpConfiguration configuration = null, object defaults = null)
        {
            RouteTable.Routes.Add(new HttpRoute(routeTemplate, defaults));

            if (configuration != null)
            {
                configurations.TryAdd(routeTemplate, configuration);
            }
        }

        /// <summary>
        /// 映射路由地址。
        /// </summary>
        /// <param name="name">定义名称。</param>
        /// <param name="routeTemplate">路由模板。</param>
        /// <param name="configuration">指定此模板应用的 <see cref="HttpConfiguration"/>。</param>
        /// <param name="defaults">默认设置。</param>
        public static void MapHttpRoute(string name, string routeTemplate, HttpConfiguration configuration = null, object defaults = null)
        {
            RouteTable.Routes.Add(name, new HttpRoute(routeTemplate));

            if (configuration != null)
            {
                configurations.TryAdd(routeTemplate, configuration);
            }
        }

        /// <summary>
        /// 根据路由模板获取对应的 <see cref="HttpConfiguration"/> 实例。
        /// </summary>
        /// <param name="routeTemplate"></param>
        /// <returns></returns>
        public static HttpConfiguration GetConfiguration(string routeTemplate)
        {
            HttpConfiguration configuration;
            if (!configurations.TryGetValue(routeTemplate, out configuration))
            {
                configuration = Default;
            }

            return configuration;
        }
    }
}
