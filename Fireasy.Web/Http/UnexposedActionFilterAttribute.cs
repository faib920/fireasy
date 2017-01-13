// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Web.Http.Filters;
namespace Fireasy.Web.Http
{
    /// <summary>
    /// 标识该动作不暴露在 <see cref="Fireasy.Web.Http.Assistants.IDescriptorTextFormatter"/> 的输出中。
    /// </summary>
    public sealed class UnexposedActionFilterAttribute : ActionFilterAttribute
    {
    }
}
