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
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Fireasy.Web.Http.Definitions
{
    /// <summary>
    /// HTTP 服务执行指定 method 参数中指定的方法。
    /// </summary>
    public class ReflectionActionInvoker : ActionInvokerBase
    {
        /// <summary>
        /// 使用收集好的参数构造动作所需的参数对象组。
        /// </summary>
        /// <param name="actionDescriptor"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected override IDictionary<string, object> GenerateMethodParameters(ActionDescriptor actionDescriptor, IDictionary<string, string> parameters)
        {
            var methodPars = actionDescriptor.Parameters;
            var invokerPars = new Dictionary<string, object>();
            for (var i = 0; i < methodPars.Count; i++)
            {
                var paramName = methodPars[i].ParameterName;
                var defaultValue = methodPars[i].DefaultValue;
                var parameterType = methodPars[i].ParameterType;

                if (parameters.ContainsKey(paramName))
                {
                    object parValue = null;

                    //如果是 int, string 等系统内置可转换的类型
                    if (IsSystemType(parameterType))
                    {
                        parValue = parameters[paramName].ToType(parameterType);
                    }
                    else
                    {
                        parValue = FromDeserializeContent(methodPars[i], parameters[paramName].ToStringSafely());
                    }

                    invokerPars.Add(paramName, parValue);
                }
                else if (methodPars[i].GetCustomAttributes<ParamsGatherAttribute>().Count() > 0)
                {
                    invokerPars.Add(paramName, FromGatheredParameters(parameters, parameterType));
                }
                //判断是否有默认值
                else if (defaultValue != DBNull.Value)
                {
                    invokerPars.Add(paramName, defaultValue);
                }
                else
                {
                    invokerPars.Add(paramName, null);
                }
            }

            return invokerPars;
        }

        /// <summary>
        /// 判断类型是不是系统类的数据类型。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool IsSystemType(Type type)
        {
            switch (type.GetNonNullableType().FullName)
            {
                case "System.String":
                case "System.Boolean":
                case "System.Int16":
                case "System.Int32":
                case "System.Int63":
                case "System.Decimal":
                case "System.Single":
                case "System.Double":
                case "System.Byte":
                case "System.Char":
                case "System.DateTime":
                    return true;
                default: return false;
            }
        }

        /// <summary>
        /// 从 Request 的内容中反序列化对象。
        /// </summary>
        /// <param name="parameterDescriptor">Rest请求参数的格式。</param>
        /// <param name="parameterValue">表示对象的字符内容。</param>
        /// <returns></returns>
        protected virtual object FromDeserializeContent(ParameterDescriptor parameterDescriptor, string parameterValue)
        {
            var resultType = parameterDescriptor.ParameterType;
            var attr = parameterDescriptor.GetCustomAttributes<ContentTypeAttribute>().FirstOrDefault();
            var contentType = attr != null ? attr.ResponseContentType : ContentType.Json;
            switch (contentType)
            {
                case ContentType.Json:
                    var json = new JsonSerializer();
                    return json.Deserialize(parameterValue, resultType);

                case ContentType.Xml:
                    //var xmlSerializer = new XmlSerializer();
                    //return xmlSerializer.Deserialize(content, resultType);
                    return string.Empty;
            }

            return null;
        }

        /// <summary>
        /// 从收集的参数中构造对象。
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="resultType"></param>
        /// <returns></returns>
        private object FromGatheredParameters(IDictionary<string, string> parameters, Type resultType)
        {
            var result = resultType.New();

            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(result))
            {
                if (!pd.IsReadOnly && parameters.ContainsKey(pd.Name))
                {
                    pd.SetValue(result, parameters[pd.Name].ToType(pd.PropertyType));
                }
            }

            return result;
        }
    }
}
