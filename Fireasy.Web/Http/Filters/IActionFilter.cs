// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;

namespace Fireasy.Web.Http.Filters
{
    public interface IActionFilter
    {
        /// <summary>
        /// 动作执行前，对参数进行处理。
        /// </summary>
        /// <param name="context">上下文对象。</param>
        void OnActionExecuting(ActionExecutingContext context);

        /// <summary>
        /// 动作执行后，可以对结果进行处理。
        /// </summary>
        /// <param name="context">上下文对象。</param>
        void OnActionExecuted(ActionExecutedContext context);

        /// <summary>
        /// 动作执行过程中，负责对异常的处理。
        /// </summary>
        /// <param name="context">上下文对象。</param>
        /// <param name="exception"></param>
        void OnExceptionThrow(ActionExecutedContext context, Exception exception);
    }
}
