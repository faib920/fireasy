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
using Fireasy.Web.Mvc;
using System;
using System.Collections;
using System.Linq;
using System.Web.Mvc;

namespace Fireasy.Utilities.Web.Mvc
{
    /// <summary>
    /// 当实体验证失败时对异常信息的处理。
    /// </summary>
    public class ValidationActionFilterAttribute : Fireasy.Web.Mvc.HandleErrorAttribute
    {
        protected override void HandleExceptionForJson(ExceptionContext filterContext)
        {
            var valexp = filterContext.Exception as EntityInvalidateException;
            if (valexp != null)
            {
                filterContext.Result = GetValidResult(valexp);
                filterContext.ExceptionHandled = true;
                return;
            }

            base.HandleExceptionForJson(filterContext);
        }

        /// <summary>
        /// 获取验证输出结果。
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        private ActionResult GetValidResult(EntityInvalidateException exception)
        {
            var result = new ArrayList();
            foreach (var k in exception.PropertyErrors)
            {
                result.Add(new { Key = k.Key.Name, Value = string.Join("; ", k.Value.ToArray()) });
            }

            return new JsonResultWrapper(new JsonResult { Data = Result.Info("Invalid", result) });
        }
    }
}