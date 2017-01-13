// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Fireasy.Web.Http.Filters
{
    /// <summary>
    /// 定义授权筛选器所需的方法。
    /// </summary>
    public interface IAuthorizationFilter
    {
        /// <summary>
        /// 在需要授权时调用。
        /// </summary>
        /// <param name="context">筛选器上下文对象。</param>
        void Authenticate(AuthorizationContext context);
    }
}
