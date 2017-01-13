// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Data.Entity.Validation;
using Fireasy.Web;
using Fireasy.Web.Http;
using Fireasy.Web.Http.Filters;
using System;
using System.Collections;
using System.Linq;

namespace Fireasy.Utilities.Web
{
    /// <summary>
    /// 当实体验证失败时对异常信息的处理。
    /// </summary>
    public class ValidationActionFilterAttribute : ExceptionActionFilterAttribute
    {
        /// <summary>
        /// 对抛出的异常信息进行处理。
        /// </summary>
        /// <param name="context">上下文对象。</param>
        /// <param name="exception">异常信息。</param>
        public override void OnExceptionThrow(ActionExecutedContext context, Exception exception)
        {
            var valexp = exception as EntityInvalidateException;
            if (valexp != null)
            {
                context.Result = GetValidResult(valexp);
                return;
            }

            base.OnExceptionThrow(context, exception);
        }

        /// <summary>
        /// 获取验证输出结果。
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        private object GetValidResult(EntityInvalidateException exception)
        {
            var result = new ArrayList();
            foreach (var k in exception.PropertyErrors)
            {
                result.Add(new { Key = k.Key.Name, Value = string.Join("; ", k.Value.ToArray()) });
            }

            return Result.Info("Invalid", result);
        }
    }
}