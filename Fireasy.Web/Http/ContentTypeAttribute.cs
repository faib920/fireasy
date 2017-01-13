// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;

namespace Fireasy.Web.Http
{
    /// <summary>
    /// 指定方法输出内容的类型或参数输入内容的类型。
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple=false)]
    public sealed class ContentTypeAttribute : Attribute
    {
        /// <summary>
        /// 初始化 <see cref="ContentTypeAttribute"/> 类的新实例。
        /// </summary>
        /// <param name="responseContentType">指定 ResponseContentType。</param>
        public ContentTypeAttribute(ContentType responseContentType)
        {
            ResponseContentType = responseContentType;
        }

        /// <summary>
        /// 获取或设置请求的内容类型。
        /// </summary>
        public ContentType RequestContentType { get; set; }

        /// <summary>
        /// 获取或设置响应的内容类型。
        /// </summary>
        public ContentType ResponseContentType { get; set; }
    }
}
