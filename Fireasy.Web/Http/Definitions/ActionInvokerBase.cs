// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Extensions;
using Fireasy.Web.Http.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Fireasy.Web.Http.Definitions
{
    public abstract class ActionInvokerBase : IActionInvoker
    {
        public virtual object Execute(ServiceContext serviceContext, string actionName)
        {
            var actionDescriptor = serviceContext.ServiceDescriptor.FindAction(actionName);
            if (actionDescriptor == null)
            {
                throw new HttpServiceException(string.Format("在服务 {0} 中找不到名称为 {1} 的方法。", serviceContext.ServiceDescriptor.ServiceName, actionName));
            }

            serviceContext.ActionDescriptor = actionDescriptor;

            var filters = GetFilters(serviceContext);
            OnAuthorize(serviceContext, filters);

            if (serviceContext.HttpContext.Response.StatusCode != (int)HttpStatusCode.OK)
            {
                return null;
            }

            var actionFilters = GetActionFilters(filters);

            var reqParams = GatherParameters(serviceContext.HttpContext.Request);

            var executingContext = new ActionExecutingContext(serviceContext, actionDescriptor, reqParams);
            var executedContext = new ActionExecutedContext(serviceContext, actionDescriptor);

            try
            {
                foreach (var filter in actionFilters)
                {
                    filter.OnActionExecuting(executingContext);
                    if (executingContext.IsFilter ||
                        serviceContext.HttpContext.Response.StatusCode != (int)HttpStatusCode.OK)
                    {
                        return executingContext.Result;
                    }
                }

                var extParams = executedContext.Parameters = GenerateMethodParameters(actionDescriptor, executingContext.Parameters);

                executedContext.Result = actionDescriptor.Execute(extParams);
            }
            catch (Exception exception)
            {
                actionFilters.ForEach(s => s.OnExceptionThrow(executedContext, exception));
            }
            finally
            {
                actionFilters.ForEach(s => s.OnActionExecuted(executedContext));
            }

            return executedContext.Result;
        }

        /// <summary>
        /// 从 <see cref="HttpRequestBase"/> 里收集前端可用的所有参数，包括 QueryString 和 Form 两个集合中的内容。
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual IDictionary<string, string> GatherParameters(HttpRequestBase request)
        {
            var dictionary = new Dictionary<string, string>();

            foreach (string key in request.QueryString.Keys)
            {
                dictionary.AddOrReplace(key, HttpUtility.UrlDecode(request.QueryString[key]));
            }

            foreach (string key in request.Form.Keys)
            {
                dictionary.AddOrReplace(key, request.Form[key]);
            }

            if (request.HttpMethod == "POST")
            {
                ReadStreamParameters(request, dictionary);
            }

            return dictionary;
        }

        /// <summary>
        /// 使用收集好的参数构造动作所需的参数对象组。
        /// </summary>
        /// <param name="actionDescriptor"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected abstract IDictionary<string, object> GenerateMethodParameters(ActionDescriptor actionDescriptor, IDictionary<string, string> parameters);

        protected virtual List<FilterAttribute> GetFilters(ServiceContext serviceContext)
        {
            var filters = serviceContext.Filters.AsEnumerable();
            filters = filters.Union(serviceContext.ActionDescriptor.ServiceDescriptor.GetFilters());
            filters = filters.Union(serviceContext.ActionDescriptor.GetFilters());
            return filters.ToList();
        }

        /// <summary>
        /// 获取动作筛选器。
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        protected virtual List<IActionFilter> GetActionFilters(IEnumerable<FilterAttribute> filters)
        {
            return filters.Where(s => s is IActionFilter).Cast<IActionFilter>().ToList();
        }

        /// <summary>
        /// 进行授权验证。
        /// </summary>
        /// <param name="serviceContext"></param>
        /// <param name="filters"></param>
        private void OnAuthorize(ServiceContext serviceContext, IEnumerable<FilterAttribute> filters)
        {
            var authorizeFilters = filters.Where(s => s is IAuthorizationFilter).Cast<IAuthorizationFilter>();
            var authorizeContext = new AuthorizationContext(serviceContext, serviceContext.ActionDescriptor);
            foreach (var filter in authorizeFilters)
            {
                filter.Authenticate(authorizeContext);
            }
        }

        /// <summary>
        /// 读取 <see cref="HttpRequestBase"/> 输入流数据，放入到参数字典中。
        /// </summary>
        /// <param name="request"></param>
        /// <param name="parameters"></param>
        protected virtual void ReadStreamParameters(HttpRequestBase request, IDictionary<string, string> parameters)
        {
            //从 InputStream 里读字节数组
            byte[] bytes = null;
            if (request.InputStream.Length == 0)
            {
                return;
            }

            using (var memory = new MemoryStream())
            {
                request.InputStream.WriteTo(memory);
                bytes = memory.ToArray();
            }

            //设置执行的参数
            if (bytes != null)
            {
                var content = request.ContentEncoding.GetString(bytes);
                foreach (var segment in content.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var equals = segment.IndexOf('=');
                    if (equals == -1)
                    {
                        continue;
                    }

                    var name = segment.Substring(0, equals);
                    var value = HttpUtility.UrlDecode(segment.Substring(equals + 1));

                    if (!parameters.ContainsKey(name))
                    {
                        parameters.Add(name, value);
                    }
                }
            }
        }
    }
}
