// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Fireasy.Web.Http.Assistants;
using Fireasy.Web.Http.Filters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Routing;

namespace Fireasy.Web.Http.Definitions
{
    /// <summary>
    /// 表示 HTTP 服务的定义。
    /// </summary>
    public class ServiceDescriptor
    {
        private Dictionary<string, ActionDescriptor> actionMaps = new Dictionary<string, ActionDescriptor>();

        /// <summary>
        /// 初始化 <see cref="ServiceDescriptor"/> 类的新实例。
        /// </summary>
        /// <param name="serviceName">服务名称。</param>
        /// <param name="serviceType">服务类型。</param>
        protected ServiceDescriptor(string serviceName, Type serviceType)
        {
            ServiceName = serviceName;
            ServiceType = serviceType;
            InitializeActions(actionMaps);
            RegisterAssistants(actionMaps);
        }

        /// <summary>
        /// 获取服务的名称。
        /// </summary>
        public string ServiceName { get; private set; }

        /// <summary>
        /// 获取服务的类型。
        /// </summary>
        public Type ServiceType { get; private set; }

        /// <summary>
        /// 根据名称查找动作定义。
        /// </summary>
        /// <param name="name">动作名称。</param>
        /// <returns></returns>
        public virtual ActionDescriptor FindAction(string name)
        {
            ActionDescriptor action;
            actionMaps.TryGetValue(name.ToLower(), out action);
            return action;
        }

        /// <summary>
        /// 获取所有的动作定义。
        /// </summary>
        public ReadOnlyCollection<ActionDescriptor> Actions
        {
            get
            {
                return new ReadOnlyCollection<ActionDescriptor>(actionMaps.Values.ToList());
            }
        }

        /// <summary>
        /// 获取服务的过滤器特性列表。
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<FilterAttribute> GetFilters()
        {
            return new FilterAttribute[0];
        }

        /// <summary>
        /// 判断是否定义了自定义特性。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual bool IsDefined<T>() where T : Attribute
        {
            return false;
        }

        /// <summary>
        /// 获取服务的自定义特性列表。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IEnumerable<T> GetCustomAttributes<T>() where T : Attribute
        {
            return new T[0];
        }

        /// <summary>
        /// 初始化所有动作。
        /// </summary>
        /// <param name="map"></param>
        protected virtual void InitializeActions(IDictionary<string, ActionDescriptor> map)
        {
        }

        /// <summary>
        /// 检查是否增加辅助动作定义。
        /// </summary>
        protected virtual void RegisterAssistants(IDictionary<string, ActionDescriptor> map)
        {
            //在debug下添加 help、gen、hsdl 几个方法
            var cmp  = (CompilationSection)ConfigurationManager.GetSection("system.web/compilation");
            if (cmp.Debug && typeof(IServiceAssistant).IsAssignableFrom(ServiceType))
            {
                map.Add("help", new HelpDocumentAction(this));
                map.Add("gen", new GenerateCodeAction(this));
                map.Add("hsdl", new DefinitionLanguageAction(this));
            }
        }
    }
}
