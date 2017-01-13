using Fireasy.Web.Http.Definitions;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.IO;

namespace Fireasy.Web.Http.Assistants
{
    /// <summary>
    /// 提供服务定义的文本格式化。
    /// </summary>
    public interface IDescriptorTextFormatter
    {
        /// <summary>
        /// 将服务定义输出到 <see cref="TextWriter"/> 对象中。
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="serviceDescriptor"></param>
        void Write(TextWriter writer, ServiceDescriptor serviceDescriptor);
    }
}
