// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Fireasy.Web.Http.Definitions
{
    public class ParameterDescriptor
    {
        public string ParameterName { get; set; }

        public Type ParameterType { get; set; }

        public object DefaultValue { get; set; }

        /// <summary>
        /// 获取动作的自定义特性列表。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IEnumerable<T> GetCustomAttributes<T>() where T : Attribute
        {
            return new T[0];
        }
    }
}
