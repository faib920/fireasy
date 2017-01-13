// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Extensions;
using Fireasy.Common.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Fireasy.Web.Http.Definitions
{
    /// <summary>
    /// 默认的结果写入器。
    /// </summary>
    public class DefaultResultWriter : IResultWriter
    {
        /// <summary>
        /// 将值写入到客户端。
        /// </summary>
        /// <param name="serviceContext">上下文对象。</param>
        /// <param name="value">执行动作后得到的值。</param>
        public virtual void Write(ServiceContext serviceContext, object value)
        {
            var response = serviceContext.HttpContext.Response;
            var actionDescriptor = serviceContext.ActionDescriptor;
            var responseContentType = actionDescriptor.ResponseContentType;
            if (responseContentType == ContentType.Undefined)
            {
                responseContentType = serviceContext.Configuration.ResponseContentType;
            }

            ClearCache(response);

            switch (responseContentType)
            {
                case ContentType.Text:
                    response.ContentType = "application/plan";
                    WriteText(serviceContext, response, value.ToStringSafely());
                    break;
                case ContentType.Html:
                    response.ContentType = "text/html";
                    WriteText(serviceContext, response, value.ToStringSafely());
                    break;
                case ContentType.Json:
                    response.ContentType = "application/json";
                    WriteJson(serviceContext, response, value);
                    break;
                case ContentType.Xml:
                    response.ContentType = "text/xml";
                    WriteXml(serviceContext, response, value);
                    break;
                case ContentType.ByteArray:
                    var bytes = value as byte[];
                    if (bytes != null)
                    {
                        WriteByteArray(serviceContext, response, bytes);
                    }
                    break;
            }

            response.End();
        }

        /// <summary>
        /// 清除缓存。
        /// </summary>
        /// <param name="response"></param>
        protected virtual void ClearCache(HttpResponseBase response)
        {
            response.Cache.SetExpires(DateTime.Now.AddSeconds(0));
            response.Cache.SetNoStore();
            response.AddHeader("Pragma", "No-cache");
            response.AddHeader("Cache-Control", "no-cache");
            response.AddHeader("Expires", "0");
        }

        /// <summary>
        /// 输出 Json 字符串。
        /// </summary>
        /// <param name="serviceContext">上下文对象。</param>
        /// <param name="response"><see cref="HttpResponseBase"/> 对象。</param>
        /// <param name="value">要输出的值。</param>
        protected virtual void WriteJson(ServiceContext serviceContext, HttpResponseBase response, object value)
        {
            using (var streamWriter = new StreamWriter(response.OutputStream, response.ContentEncoding))
            {
                streamWriter.WriteLine(JsonSerialize(serviceContext, value));
            }
        }

        /// <summary>
        /// Json 序列化。
        /// </summary>
        /// <param name="serviceContext">上下文对象。</param>
        /// <param name="value">要输出的值。</param>
        /// <returns></returns>
        protected virtual string JsonSerialize(ServiceContext serviceContext, object value)
        {
            var jsoncallback = serviceContext.HttpContext.Request.Params["callback"];

            var converters = serviceContext.Converters.Where(s => s is JsonConverter).Cast<JsonConverter>();
            var option = new JsonSerializeOption();
            option.Converters.AddRange(converters);
            var json = new JsonSerializer(option).Serialize(value);

            if (!string.IsNullOrEmpty(jsoncallback))
            {
                return string.Format("{0}({1})", jsoncallback, json);
            }

            return json;
        }

        /// <summary>
        /// 输出 Xml 字符串。
        /// </summary>
        /// <param name="serviceContext">上下文对象。</param>
        /// <param name="response"><see cref="HttpResponseBase"/> 对象。</param>
        /// <param name="value">要输出的值。</param>
        protected virtual void WriteXml(ServiceContext serviceContext, HttpResponseBase response, object value)
        {
            var str = value as string;
            if (str != null && str.StartsWith("<"))
            {
                WriteText(serviceContext, response, value.ToString());
            }
            else if (value != null)
            {
                using (var streamWriter = new StreamWriter(response.OutputStream, response.ContentEncoding))
                {
                    streamWriter.WriteLine(XmlSerialize(serviceContext, value));
                }
            }
        }

        /// <summary>
        /// Xml 序列化。
        /// </summary>
        /// <param name="serviceContext">上下文对象。</param>
        /// <param name="value">要输出的值。</param>
        /// <returns></returns>
        protected virtual string XmlSerialize(ServiceContext serviceContext, object value)
        {
            var jsoncallback = serviceContext.HttpContext.Request.Params["callback"];

            var converters = serviceContext.Converters.Where(s => s is XmlConverter).Cast<XmlConverter>();
            var option = new XmlSerializeOption();
            option.Converters.AddRange(converters);
            return new XmlSerializer(option).Serialize(value);
        }

        /// <summary>
        /// 输出字节数组。
        /// </summary>
        /// <param name="serviceContext">上下文对象。</param>
        /// <param name="response"><see cref="HttpResponseBase"/> 对象。</param>
        /// <param name="byteArray">字节数组。</param>
        protected virtual void WriteByteArray(ServiceContext serviceContext, HttpResponseBase response, byte[] byteArray)
        {
            response.OutputStream.Write(byteArray, 0, byteArray.Length);
        }

        /// <summary>
        /// 输出文本。
        /// </summary>
        /// <param name="serviceContext">上下文对象。</param>
        /// <param name="response"><see cref="HttpResponseBase"/> 对象。</param>
        /// <param name="context">文本内容。</param>
        protected virtual void WriteText(ServiceContext serviceContext, HttpResponseBase response, string context)
        {
            response.Write(context);
        }
    }
}
