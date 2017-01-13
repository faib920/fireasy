// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Web.Http.Definitions;
namespace Fireasy.Web.Http.Filters
{
    /// <summary>
    /// 权限验证的上下文对象。
    /// </summary>
    public sealed class AuthorizationContext
    {
        internal AuthorizationContext(ServiceContext serviceContext, ActionDescriptor actionDescriptor)
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

    }
}
