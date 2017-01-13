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
using System.Collections;
using System.Linq;

namespace Fireasy.Web.Http.Filters
{
    /// <summary>
    /// 对动作执行中发生的异常进行处理。
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ExceptionActionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 动作执行过程中，负责对异常的处理。
        /// </summary>
        /// <param name="context">上下文对象。</param>
        /// <param name="exception"></param>
        public override void OnExceptionThrow(ActionExecutedContext context, Exception exception)
        {
            if (exception is ClientNotificationException)
            {
                context.Result = Result.Fail(exception.Message);
                return;
            }

            var logger = LoggerFactory.CreateLogger();
            if (logger != null)
            {
                context.Result = ProcessReturnWhenException(context, exception);

                logger.Error(string.Format("执行服务 {0} 的 {1} 方法时发生错误。",
                    context.ActionDescriptor.ServiceDescriptor.ServiceName,
                    context.ActionDescriptor.ActionName), exception);
            }
        }

        /// <summary>
        /// 处理发生异常时的返回值。
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        protected virtual object ProcessReturnWhenException(ActionExecutedContext context, Exception exception)
        {
            var attr = context.ActionDescriptor.GetCustomAttributes<ExceptionBehaviorAttribute>().FirstOrDefault();
            if (attr != null)
            {
                if (attr.EmptyArray)
                {
                    return new string[0];
                }
                else
                {
                    return Result.Fail(attr.Message);
                }
            }
            else
            {
                return Result.Fail(GetErrorMessage(exception));
            }
        }

        /// <summary>
        /// 根据异常对象获取错误提示信息。
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        protected virtual string GetErrorMessage(Exception exception)
        {
            return "发生错误，请查阅相关日志或联系管理员。";
        }
    }
}
