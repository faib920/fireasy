using Fireasy.Web.Http.Definitions;
using Fireasy.Web.Http.Filters;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace Fireasy.Web.Http.Assistants
{
    /// <summary>
    /// 输出定义语言的动作。
    /// </summary>
    public class DefinitionLanguageAction : ActionDescriptor
    {
        /// <summary>
        /// 初始化 <see cref="DefinitionLanguageAction"/> 类的新实例。
        /// </summary>
        /// <param name="serviceDescriptor"></param>
        public DefinitionLanguageAction(ServiceDescriptor serviceDescriptor)
            : base(serviceDescriptor, "help")
        {
        }

        /// <summary>
        /// 获取返回类型。
        /// </summary>
        public override Type ReturnType
        {
            get { return typeof(string); }
        }

        /// <summary>
        /// 判断是否定义了自定义特性。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override bool IsDefined<T>()
        {
            if (typeof(T) == typeof(AllowAnonymousAttribute))
            {
                return true;
            }

            if (typeof(T) == typeof(UnexposedActionFilterAttribute))
            {
                return true;
            }

            return base.IsDefined<T>();
        }

        /// <summary>
        /// 获取参数定义的集合。
        /// </summary>
        public override ReadOnlyCollection<ParameterDescriptor> Parameters
        {
            get 
            {
                var parameters = new List<ParameterDescriptor>();
                return new ReadOnlyCollection<ParameterDescriptor>(parameters); 
            }
        }

        /// <summary>
        /// 执行该动作。
        /// </summary>
        /// <param name="parameters">动作的参数字典。</param>
        /// <returns></returns>
        public override object Execute(IDictionary<string, object> parameters)
        {
            ResponseContentType = ContentType.Xml;
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                new DefinitionLanguageFormatter().Write(writer, ServiceDescriptor);
                return sb.ToString();
            }
        }
    }
}
