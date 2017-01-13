// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Web;

namespace Fireasy.Web
{
    /// <summary>
    /// 扩展类。
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 往 <see cref="HttpResponse"/> 头里添加文件附件，以请求下载。
        /// </summary>
        /// <param name="response"></param>
        /// <param name="fileName"></param>
        public static void Attachment(this HttpResponse response, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                response.AddHeader("Content-Disposition", null);
            }
            else
            {
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + fileName + "\"");
            }
        }
    }
}
