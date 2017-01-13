using Fireasy.Web.Http.Definitions;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web;

namespace Fireasy.Web.Http.Filters
{
    /// <summary>
    /// 动作执行中的上下文对象。
    /// </summary>
    public sealed class ActionExecutingContext
    {
        private object result = null;

        internal ActionExecutingContext(ServiceContext serviceContext, ActionDescriptor actionDescriptor, IDictionary<string, string> parameters)
        {
            ServiceContext = serviceContext;
            ActionDescriptor = actionDescriptor;
            Parameters = parameters;
        }

        /// <summary>
        /// 获取 <see cref="ServiceContext"/> 实例。
        /// </summary>
        public ServiceContext ServiceContext { get; private set; }

        /// <summary>
        /// 获取被执行的动作的定义。
        /// </summary>
        public ActionDescriptor ActionDescriptor { get; private set; }

        /// <summary>
        /// 获取或设置执行方法所需的参数字典。
        /// </summary>
        public IDictionary<string, string> Parameters { get; set; }

        /// <summary>
        /// 获取或设置执行结果。如果指定该值，那么动作将被忽略，直接返回该值。
        /// </summary>
        public object Result
        {
            get { return result; }
            set
            {
                IsFilter = true;
                result = value;
            }
        }

        /// <summary>
        /// 获取是否过滤动作的执行。
        /// </summary>
        internal bool IsFilter { get; private set; }
    }
}
