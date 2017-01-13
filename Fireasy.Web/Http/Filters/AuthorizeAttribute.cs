using Fireasy.Common;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Linq;
using System.Net;

namespace Fireasy.Web.Http.Filters
{
    /// <summary>
    /// 授权验证筛选器。
    /// </summary>
    public class AuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// 返回是否验证成功。
        /// </summary>
        /// <param name="context">授权验证上下文对象。</param>
        /// <returns></returns>
        protected virtual bool IsAuthorized(AuthorizationContext context)
        {
            Guard.ArgumentNull(context.ServiceContext, "serviceContext");
            Guard.ArgumentNull(context.ServiceContext.HttpContext, "httpContext");

            var principal = context.ServiceContext.HttpContext.User;
            if (((principal == null) || (principal.Identity == null)) || !principal.Identity.IsAuthenticated)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 在需要授权时调用。
        /// </summary>
        /// <param name="context">授权验证上下文对象。</param>
        public virtual void Authenticate(AuthorizationContext context)
        {
            Guard.ArgumentNull(context.ServiceContext, "serviceContext");

            if (!SkipAuthorization(context) && !IsAuthorized(context))
            {
                HandleUnauthorizedRequest(context);
            }
        }

        /// <summary>
        /// 判断是否标记了 <see cref="AllowAnonymousAttribute"/> 而跳过验证。
        /// </summary>
        /// <param name="context">授权验证上下文对象。</param>
        /// <returns></returns>
        protected virtual bool SkipAuthorization(AuthorizationContext context)
        {
            var skip = false;
            if (context.ActionDescriptor != null)
            {
                skip = context.ActionDescriptor.IsDefined<AllowAnonymousAttribute>();
            }

            if (!skip)
            {
                skip = context.ServiceContext.ServiceDescriptor.IsDefined<AllowAnonymousAttribute>();
            }

            return skip;
        }

        /// <summary>
        /// 处理未能授权的 HTTP 请求。
        /// </summary>
        protected virtual void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            context.ServiceContext.SetStatus(HttpStatusCode.Unauthorized);
        }
    }
}
