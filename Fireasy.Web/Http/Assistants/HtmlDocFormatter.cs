// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;
using Fireasy.Common.Extensions;
using Fireasy.Common;
using Fireasy.Web.Http.Definitions;

namespace Fireasy.Web.Http.Assistants
{
    /// <summary>
    /// Html 文档格式化。
    /// </summary>
    public class HtmlDocFormatter : IDescriptorTextFormatter
    {
        /// <summary>
        /// 将服务定义输出到 <see cref="TextWriter"/> 对象中。
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="serviceDescriptor"></param>
        public void Write(TextWriter writer, ServiceDescriptor serviceDescriptor)
        {
            var types = new List<Type>();

            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            writer.WriteLine("<head>");
            writer.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            writer.WriteLine("<meta name=\"Generator\" content=\"Fireasy Web\" />");
            writer.WriteLine("<meta name=\"Robots\" content=\"none\" />");
            writer.WriteLine("<title>服务 {0} 的帮助文档</title>", serviceDescriptor.ServiceName);
            writer.WriteLine("<style>");
            writer.WriteLine("body {font-size:11pt;margin:5px;font-family:微软雅黑;}");
            writer.WriteLine("table {background-color:#dddddd;table-layout:fixed;}");
            writer.WriteLine("table td {background-color:#ffffff;word-break:break-all;word-wrap:break-word;}");
            writer.WriteLine(".title {font-size:16pt;text-align:center;width:800px;}");
            writer.WriteLine("a:link,a:visited {color:blue;}");
            writer.WriteLine("a:hover {color:red;}");
            writer.WriteLine("</style>");
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");

            writer.WriteLine("<div class='title'>服务 {0} 的帮助文档</span></div>", serviceDescriptor.ServiceName);

            foreach (var action in serviceDescriptor.Actions.OrderBy(s => s.ActionName))
            {
                if (action.IsDefined<UnexposedActionFilterAttribute>())
                {
                    continue;
                }

                var actDesc = action.GetCustomAttributes<DescriptionAttribute>().FirstOrDefault();
                writer.WriteLine("<table  cellpadding='5' cellspacing='1' style='width:800px'>");
                writer.WriteLine("<tr><td style='width:80px;text-align:center'>名称</td><td>{0}</td></tr>", action.ActionName);
                writer.WriteLine("<tr><td style='width:80px;text-align:center'>说明</td><td>{0}</td></tr>", actDesc.AssertNotNull(s => s.Description));
                writer.WriteLine("<tr><td style='width:80px;text-align:center'>参数</td><td>");

                if (action.Parameters.Count == 0)
                {
                    writer.WriteLine("无");
                }
                else
                {
                    writer.WriteLine("<table cellpadding='5' cellspacing='1' style='width:100%'>");
                    writer.WriteLine("<tr style='text-align:center;'><td style='width:120px'>名称</td><td style='width:120px'>类型</td><td style='width:80px'>默认值</td><td>说明</td></tr>");
                    foreach (var parameter in action.Parameters)
                    {
                        var parDesc = parameter.GetCustomAttributes<DescriptionAttribute>().FirstOrDefault();
                        writer.WriteLine("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", 
                            parameter.ParameterName,
                            WriteClassName(types, parameter.ParameterType), 
                            parameter.DefaultValue, 
                            parDesc.AssertNotNull(s => s.Description));
                    }
                    writer.WriteLine("</table>");
                }

                writer.WriteLine("</td></tr>");

                writer.WriteLine("<tr><td style='width:80px;text-align:center'>返回</td><td>{0}</td></tr>", WriteClassName(types, action.ReturnType));
                writer.WriteLine("<tr><td style='width:80px;text-align:center'>备注</td><td></td></tr>");

                writer.WriteLine("</table>");
                writer.WriteLine("<br />");
            }

            writer.WriteLine("<div class='title'>附：元数据列表</span></div>");
            
            WriteClassDefinitions(writer, types);

            writer.WriteLine("</body>");
        }

        /// <summary>
        /// 输出类名。
        /// </summary>
        /// <param name="types"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private string WriteClassName(List<Type> types, Type type)
        {
            if (types.Contains(type))
            {
                return string.Format("<a href='#{0}'>{0}</a>", type.Name);
            }

            if (type.IsGenericType)
            {
                var sb = new StringBuilder();
                var gname = type.Name.Substring(0, type.Name.IndexOf('`'));
                if (gname == "Result")
                {
                    sb.Append(WriteClassName(types, typeof(Result)));
                }
                else
                {
                    sb.Append(gname);
                }

                sb.Append("&lt;");
                foreach (var t in type.GetGenericArguments())
                {
                    sb.Append(WriteClassName(types, t));
                }

                sb.Append("&gt;");
                return sb.ToString();
            }
            else if (type.IsEnum || (!type.IsArray && !type.IsValueType && type != typeof(string) && type != typeof(object)))
            {
                types.Add(type);
                foreach (var par in GetProperties(type))
                {
                    WriteClassName(types, par.PropertyType);
                }

                return string.Format("<a href='#{0}'>{0}</a>", type.Name);
            }
            else
            {
                return type.Name;
            }
        }

        /// <summary>
        /// 输出所有类的定义。
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="types"></param>
        private void WriteClassDefinitions(TextWriter writer, List<Type> types)
        {
            foreach (var type in types)
            {
                writer.WriteLine("<table  cellpadding='5' cellspacing='1' style='width:800px'>");
                writer.WriteLine("<tr><td style='width:80px;text-align:center'><a name='{0}'>名称</a></td><td>{0}</td></tr>", type.Name);
                writer.WriteLine("<tr><td style='width:80px;text-align:center'>说明</td><td></td></tr>");
                writer.WriteLine("<tr><td style='width:80px;text-align:center'>属性</td><td>");
                writer.WriteLine("<table cellpadding='5' cellspacing='1' style='width:100%'>");

                if (type.IsEnum)
                {
                    writer.WriteLine("<tr style='text-align:center;'><td style='width:120px'>名称</td><td style='width:80px'>值</td><td>说明</td></tr>");
                    WriteEnum(writer, type);
                }
                else
                {
                    writer.WriteLine("<tr style='text-align:center;'><td style='width:120px'>名称</td><td style='width:120px'>类型</td><td>说明</td></tr>");
                    WriteClass(writer, types, type);
                }

                writer.WriteLine("</table>");
                writer.WriteLine("</td></tr>");

                writer.WriteLine("</table>");
                writer.WriteLine("<br />");
            }
        }

        /// <summary>
        /// 输出枚举定义。
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="type"></param>
        private void WriteEnum(TextWriter writer, Type type)
        {
            foreach (var field in type.GetFields())
            {
                if (field.Name == "value__")
                {
                    continue;
                }

                var value = Enum.Parse(type, field.Name, true).To<int>();
                var attr = field.GetCustomAttributes<EnumDescriptionAttribute>().FirstOrDefault();
                writer.WriteLine("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", field.Name,
                    value,
                    attr != null ? attr.Description : string.Empty);
            }
        }

        /// <summary>
        /// 输出类的定义。
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="types"></param>
        /// <param name="type"></param>
        private void WriteClass(TextWriter writer, List<Type> types, Type type)
        {
            foreach (var property in GetProperties(type))
            {
                var proptDesc = property.GetCustomAttributes<DescriptionAttribute>().FirstOrDefault();
                writer.WriteLine("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", property.Name,
                    WriteClassName(types, property.PropertyType),
                    proptDesc.AssertNotNull(s => s.Description));
            }
        }

        private IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            foreach (var par in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (par.DeclaringType != type)
                {
                    continue;
                }

                yield return par;
            }
        }
    }
}
