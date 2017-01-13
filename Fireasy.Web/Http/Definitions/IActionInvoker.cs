// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Web.Routing;

namespace Fireasy.Web.Http.Definitions
{
    /// <summary>
    /// 定义对动作的执行。
    /// </summary>
    public interface IActionInvoker
    {
        /// <summary>
        /// 执行指定名称的动作，返回结果。
        /// </summary>
        /// <param name="serviceContext">上下文对象。</param>
        /// <param name="actionName">动作的名称。</param>
        /// <returns></returns>
        object Execute(ServiceContext serviceContext, string actionName);
    }
}
