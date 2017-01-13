// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Web;
using System.Web.Routing;

namespace Fireasy.Web.Http.Definitions
{
    /// <summary>
    /// 提供结果的写入到客户端的方法。
    /// </summary>
    public interface IResultWriter
    {
        /// <summary>
        /// 将值写入到客户端。
        /// </summary>
        /// <param name="serviceContext">上下文对象。</param>
        /// <param name="value">执行动作后得到的值。</param>
        void Write(ServiceContext serviceContext, object value);
    }
}
