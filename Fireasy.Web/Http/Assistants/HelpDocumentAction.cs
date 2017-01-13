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
using System.Linq;
using Fireasy.Common.Extensions;
using System.Text;
using System.IO;
using Fireasy.Web.Http.Definitions;
using Fireasy.Web.Http.Filters;

namespace Fireasy.Web.Http.Assistants
{
    /// <summary>
    /// 输出帮助文档的动作。
    /// </summary>
    public class HelpDocumentAction : ActionDescriptor
    {
        /// <summary>
        /// 初始化 <see cref="HelpDocumentAction"/> 类的新实例。
        /// </summary>
        /// <param name="serviceDescriptor"></param>
        public HelpDocumentAction(ServiceDescriptor serviceDescriptor)
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
                parameters.Add(new ParameterDescriptor
                    {
                        ParameterName = "lng",
                        ParameterType = typeof(string),
                        DefaultValue = "html"
                    });

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
            var lng = parameters["lng"].ToStringSafely();

            var sb = new StringBuilder();
            SetResponseContentType(lng);
            var formatter = CreateFormatter(lng);
            using (var writer = new StringWriter(sb))
            {
                formatter.Write(writer, ServiceDescriptor);
                return sb.ToString();
            }
        }

        protected virtual void SetResponseContentType(string lng)
        {
            switch (lng.ToLower())
            {
                case "html":
                    ResponseContentType = ContentType.Html;
                    break;
            }
        }

        protected virtual IDescriptorTextFormatter CreateFormatter(string lng)
        {
            switch (lng.ToLower())
            {
                case "html":
                    return new HtmlDocFormatter();
                default:
                    return null;
            }
        }
    }
}
