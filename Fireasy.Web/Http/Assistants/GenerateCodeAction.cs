// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Extensions;
using Fireasy.Web.Http.Definitions;
using Fireasy.Web.Http.Filters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Fireasy.Web.Http.Assistants
{
    /// <summary>
    /// 生成程序代码的动作。
    /// </summary>
    public class GenerateCodeAction : ActionDescriptor
    {
        /// <summary>
        /// 初始化类 <see cref="GenerateCodeAction"/> 类的新实例。
        /// </summary>
        /// <param name="serviceDescriptor"></param>
        public GenerateCodeAction(ServiceDescriptor serviceDescriptor)
            : base(serviceDescriptor, "gen")
        {
            ResponseContentType = ContentType.Text;
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
                        DefaultValue = "cs"
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
            var formatter = CreateGenerator(lng);
            using (var writer = new StringWriter(sb))
            {
                formatter.Write(writer, ServiceDescriptor);
                return sb.ToString();
            }
        }

        /// <summary>
        /// 根据语言标识创建一个生成器。
        /// </summary>
        /// <param name="lng"></param>
        /// <returns></returns>
        protected virtual CodeGeneratorBase CreateGenerator(string lng)
        {
            switch (lng)
            {
                case "cs":
                    return new CSharpCodeGenerator();
                case "vb":
                    return new VBCodeGenerator();
                case "java":
                    return new JavaCodeGenerator();
                case "js":
                    return new JavascriptCodeGenerator();
                default:
                    return null;
            }
        }
    }
}
