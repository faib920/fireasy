// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.ComponentModel;
using Fireasy.Common.Serialization;
using System;
using System.Text;

namespace Fireasy.Utilities.Web
{
    /// <summary>
    /// 用于转换分页数据。
    /// </summary>
    public class PaginalResulJsonConverter : JsonConverter
    {
        /// <summary>
        /// 判断类型是否为可转换的 <see cref="IPaginalResult"/> 类型。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override bool CanConvert(Type type)
        {
            return typeof(IPaginalResult).IsAssignableFrom(type);
        }

        /// <summary>
        /// 输出 Json 字符串。
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override string WriteJson(JsonSerializer serializer, object obj)
        {
            var p = obj as IPaginalResult;
            if (p == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            sb.AppendFormat("{{\"total\":{0},", p.RecordCount);
            sb.AppendFormat("\"rows\": {0}}}", serializer.Serialize(p.Data));
            return sb.ToString();
        }
    }
}
