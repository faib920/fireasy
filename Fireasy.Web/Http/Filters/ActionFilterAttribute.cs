// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common;
using Fireasy.Common.Logging;
using System;
using System.Linq;

namespace Fireasy.Web.Http.Filters
{
    /// <summary>
    /// 动作的筛选器。
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public abstract class ActionFilterAttribute : FilterAttribute, IActionFilter
    {
        /// <summary>
        /// 动作执行前，对参数进行处理。
        /// </summary>
        /// <param name="context">上下文对象。</param>
        public virtual void OnActionExecuting(ActionExecutingContext context)
        {
        }

        /// <summary>
        /// 动作执行后，可以对结果进行处理。
        /// </summary>
        /// <param name="context">上下文对象。</param>
        public virtual void OnActionExecuted(ActionExecutedContext context)
        {
        }

        /// <summary>
        /// 动作执行过程中，负责对异常的处理。
        /// </summary>
        /// <param name="context">上下文对象。</param>
        /// <param name="exception"></param>
        public virtual void OnExceptionThrow(ActionExecutedContext context, Exception exception)
        {
        }
    }
}
