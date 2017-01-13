// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Extensions;
using Fireasy.Common.Reflection;
using Fireasy.Web.Http.Filters;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Fireasy.Web.Http.Definitions
{
    /// <summary>
    /// 表示基于反射的 HTTP 动作的定义。
    /// </summary>
    public class ReflectionActionDescriptor : ActionDescriptor
    {
        private MethodInvoker methodCall;
        private List<ParameterDescriptor> parameters;

        /// <summary>
        /// 初始化 <see cref="ReflectionActionDescriptor"/> 类的新实例。
        /// </summary>
        /// <param name="serviceDescriptor">HTTP 服务定义。</param>
        /// <param name="actionName">动作的名称。</param>
        /// <param name="method">对应的方法。</param>
        public ReflectionActionDescriptor(ServiceDescriptor serviceDescriptor, string actionName, MethodInfo method)
            : base (serviceDescriptor, actionName)
        {
            ReflectionMethod = method;
            ReturnType = ReflectionMethod.ReturnType;
            methodCall = ReflectionCache.GetInvoker(ReflectionMethod);

            parameters = new List<ParameterDescriptor>();
            foreach (var par in method.GetParameters())
            {
                parameters.Add(new ReflectionParameterDescriptor
                    {
                        ParameterName = par.Name,
                        ParameterType = par.ParameterType,
                        ReflectionParameter = par,
                        DefaultValue = par.DefaultValue
                    });
            }
        }

        /// <summary>
        /// 获取动作对应的 <see cref="ReflectionMethod"/> 对象。
        /// </summary>
        public MethodInfo ReflectionMethod { get; private set; }

        /// <summary>
        /// 获取参数定义的集合。
        /// </summary>
        public override ReadOnlyCollection<ParameterDescriptor> Parameters
        {
            get { return parameters.AsReadOnly(); }
        }

        /// <summary>
        /// 获取动作的过滤器特性列表。
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<FilterAttribute> GetFilters()
        {
            return ReflectionMethod.GetCustomAttributes<FilterAttribute>(false);
        }

        /// <summary>
        /// 判断是否定义了自定义特性。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override bool IsDefined<T>()
        {
            return ReflectionMethod.IsDefined<T>();
        }

        /// <summary>
        /// 获取动作的自定义特性列表。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override IEnumerable<T> GetCustomAttributes<T>()
        {
            return ReflectionMethod.GetCustomAttributes<T>();
        }

        /// <summary>
        /// 执行该动作。
        /// </summary>
        /// <param name="parameters">动作的参数字典。</param>
        /// <returns></returns>
        public override object Execute(IDictionary<string, object> parameters)
        {
            var serviceContext = ServiceContext.Current;
            return methodCall.Invoke(serviceContext.HttpService, parameters.Values.ToArray());
        }
    }
}
