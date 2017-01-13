using System;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;

namespace Fireasy.Common.Serialization
{
    /// <summary>
    /// <see cref="ITextConverter"/> 的集合。
    /// </summary>
    public sealed class ConverterList : List<ITextConverter>
    {
        /// <summary>
        /// 获取指定类型的序列化转换器。
        /// </summary>
        /// <param name="type">要判断的类型。</param>
        /// <returns>一个 <see cref="ITextConverter"/> 对象。</returns>
        public ITextConverter GetConverter(Type type)
        {
            return this.FirstOrDefault(s => s.CanConvert(type));
        }
    }
}
