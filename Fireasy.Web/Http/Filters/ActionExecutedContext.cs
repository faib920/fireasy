using Fireasy.Web.Http.Definitions;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Collections.Generic;
using System.Web;

namespace Fireasy.Web.Http.Filters
{
    /// <summary>
    /// 动作执行后的上下文对象。
    /// </summary>
    public sealed class ActionExecutedContext
    {
        internal ActionExecutedContext(ServiceContext serviceContext, ActionDescriptor actionDescriptor)
        {
            ServiceContext = serviceContext;
            ActionDescriptor = actionDescriptor;
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
        public IDictionary<string, object> Parameters { get; set; }

        /// <summary>
        /// 获取或设置执行结果。
        /// </summary>
        public object Result { get; set; }

    }
}
