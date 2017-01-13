using Fireasy.Common.Extensions;
using Fireasy.Web.Http.Definitions;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Fireasy.Web.Http.Assistants
{
    /// <summary>
    /// hsdl 定义格式的输出。
    /// </summary>
    public class DefinitionLanguageFormatter : IDescriptorTextFormatter
    {
        public void Write(TextWriter writer, ServiceDescriptor serviceDescriptor)
        {
            var types = new List<Type>();

            using (var xml = new XmlTextWriter(writer))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement("service");
                xml.WriteAttributeString("xmlns", null, null, "http://www.fireasy.com/schema/develop/hsdl");

                xml.Formatting = Formatting.Indented;

                xml.WriteStartElement("actions");

                foreach (var action in serviceDescriptor.Actions.OrderBy(s => s.ActionName))
                {
                    if (action.IsDefined<UnexposedActionFilterAttribute>())
                    {
                        continue;
                    }

                    xml.WriteStartElement("action");
                    xml.WriteAttributeString("name", action.ActionName);

                    xml.WriteStartElement("return");
                    WriteArrayType(types, xml, action.ReturnType);
                    xml.WriteEndElement();

                    xml.WriteStartElement("parameters");

                    foreach (var p in action.Parameters)
                    {
                        xml.WriteStartElement("parameter");
                        xml.WriteAttributeString("name", p.ParameterName);

                        WriteArrayType(types, xml, p.ParameterType);

                        if (p.DefaultValue != DBNull.Value)
                        {
                            xml.WriteAttributeString("default", p.DefaultValue.ToString());
                        }

                        xml.WriteEndElement();
                    }

                    xml.WriteEndElement();
                    xml.WriteEndElement();
                }

                xml.WriteEndElement();

                xml.WriteStartElement("types");

                foreach (var type in types)
                {
                    if (type.IsEnum)
                    {
                        WriteEnum(xml, type);
                    }
                    else
                    {
                        WriteClass(xml, type);
                    }


                    xml.WriteEndElement();
                }

                xml.WriteEndElement();

                xml.WriteEndElement();
                xml.WriteEndDocument();
            }
        }

        private void WriteArrayType(List<Type> types, XmlTextWriter xml, Type type)
        {
            if (typeof(IEnumerable).IsAssignableFrom(type) && type != typeof(string))
            {
                xml.WriteAttributeString("array", "True");
                xml.WriteAttributeString("type", WriteTypeName(types, type.GetEnumerableElementType()));
            }
            else
            {
                xml.WriteAttributeString("type", WriteTypeName(types, type));
            }
        }

        private void WriteClass(XmlTextWriter xml, Type type)
        {
            xml.WriteStartElement("complexType");
            xml.WriteAttributeString("name", type.Name);

            xml.WriteStartElement("elements");
            foreach (var property in GetProperties(type))
            {
                xml.WriteStartElement("element");
                xml.WriteAttributeString("name", property.Name);
                WriteArrayType(null, xml, property.PropertyType);
                xml.WriteEndElement();
            }

            xml.WriteEndElement();
        }

        private void WriteEnum(XmlTextWriter xml, Type type)
        {
            xml.WriteStartElement("enumType");
            xml.WriteAttributeString("name", type.Name);
            xml.WriteStartElement("values");
            foreach (var field in type.GetFields())
            {
                if (field.Name == "value__")
                {
                    continue;
                }

                var value = ((int)Enum.Parse(type, field.Name, true)).ToString();
                xml.WriteStartElement("value");
                xml.WriteAttributeString("name", field.Name);
                xml.WriteAttributeString("value", value);
                xml.WriteEndElement();
            }

            xml.WriteEndElement();
        }

        private string WriteTypeName(List<Type> types, Type type)
        {
            if (types == null || types.Contains(type))
            {
                return type.Name;
            }

            if (type.IsGenericType)
            {
                var sb = new StringBuilder();
                var gname = type.Name.Substring(0, type.Name.IndexOf('`'));
                if (gname == "Result")
                {
                    sb.Append(WriteTypeName(types, typeof(Result)));
                }
                else
                {
                    sb.Append(gname);
                }

                sb.Append("<");
                foreach (var t in type.GetGenericArguments())
                {
                    sb.Append(WriteTypeName(types, t));
                }

                sb.Append(">");
                return sb.ToString();
            }
            else if (type.IsArray)
            {
                return WriteTypeName(types, type.GetElementType()) + "[]";
            }
            else
            {
                types.Add(type);

                if (!type.IsArray && !type.IsValueType && type != typeof(string) && type != typeof(object))
                {
                    foreach (var par in GetProperties(type))
                    {
                        WriteTypeName(types, par.PropertyType);
                    }
                }

                return type.Name;
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
