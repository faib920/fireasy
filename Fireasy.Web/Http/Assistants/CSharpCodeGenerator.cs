// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common;
using Fireasy.Web.Http.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fireasy.Web.Http.Assistants
{
    public class CSharpCodeGenerator : CodeGeneratorBase
    {
        public override void Write(System.IO.TextWriter writer, ServiceDescriptor serviceDescriptor)
        {
            writer.WriteLine(string.Format("public class {0}", serviceDescriptor.ServiceName));
            writer.WriteLine("{");

            foreach (var action in serviceDescriptor.Actions.OrderBy(s => s.ActionName))
            {
                if (action.IsDefined<UnexposedActionFilterAttribute>())
                {
                    continue;
                }

                writer.Write(string.Format("    public {0} {1}(", WriteTypeName(action.ReturnType), action.ActionName));

                var assert = new AssertFlag();
                foreach (var p in action.Parameters)
                {
                    if (!assert.AssertTrue())
                    {
                        writer.Write(", ");
                    }

                    writer.Write(string.Format("{0} {1}", WriteTypeName(p.ParameterType), p.ParameterName));
                }

                writer.WriteLine(")");

                writer.WriteLine("    {");
                writer.WriteLine("    }");

                writer.WriteLine();
            }

            writer.WriteLine("}");
        }

        private string WriteTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                var sb = new StringBuilder();
                var gname = type.Name.Substring(0, type.Name.IndexOf('`'));
                if (gname == "Result")
                {
                    sb.Append(WriteTypeName(typeof(Result)));
                }
                else
                {
                    sb.Append(gname);
                }

                sb.Append("<");
                foreach (var t in type.GetGenericArguments())
                {
                    sb.Append(WriteTypeName(t));
                }

                sb.Append(">");
                return sb.ToString();
            }
            else if (type.IsArray)
            {
                return WriteTypeName(type.GetElementType()) + "[]";
            }
            else
            {
                return ConvertTypeName(type);
            }
        }

        private string ConvertTypeName(Type type)
        {
            switch (type.FullName)
            {
                case "System.Int16":
                    return "short";
                case "System.Int32":
                    return "int";
                case "System.Int64":
                    return "long";
                case "System.Decimal":
                    return "decimal";
                case "System.Double":
                    return "double";
                case "System.Single":
                    return "float";
                case "System.Boolean":
                    return "bool";
                case "System.Object":
                    return "object";
                case "System.Byte":
                    return "byte";
                case "System.String":
                    return "string";
                default:
                    return type.Name;
            }
        }
    }
}
