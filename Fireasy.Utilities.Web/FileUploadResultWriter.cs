// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Web.Http;
using Fireasy.Web.Http.Definitions;
using System.Web;

namespace Fireasy.Utilities.Web
{
    /// <summary>
    /// 针对文件上传的结果写入器。
    /// </summary>
    public class FileUploadResultWriter : DefaultResultWriter
    {
        protected override void WriteJson(ServiceContext serviceContext, HttpResponseBase response, object value)
        {
            response.ContentType = "text/json";
            response.Write(JsonSerialize(serviceContext, value));
        }
    }
}