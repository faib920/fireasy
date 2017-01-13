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
using System.Linq;

namespace Fireasy.Web.Http
{
    /// <summary>
    /// 过滤器集合。
    /// </summary>
    public class FilterAttributeCollection : IList<FilterAttribute>
    {
        private List<FilterAttribute> inner = new List<FilterAttribute>();

        /// <summary>
        /// 移除指定类型的实例。
        /// </summary>
        /// <param name="filterType">过滤器的类型。</param>
        public void Remove(Type filterType)
        {
            var list = inner.Where(s => s.GetType() == filterType).ToArray();

            foreach (var item in list)
            {
                inner.Remove(item);
            }
        }

        public int IndexOf(FilterAttribute item)
        {
            return inner.IndexOf(item);
        }

        public void Insert(int index, FilterAttribute item)
        {
            inner.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            inner.RemoveAt(index);
        }

        public FilterAttribute this[int index]
        {
            get { return inner[index]; }
            set { inner[index] = value; }
        }

        /// <summary>
        /// 将过 <paramref name="item"/> 添加到结尾处。
        /// </summary>
        /// <param name="item"></param>
        public void Add(FilterAttribute item)
        {
            inner.Add(item);
        }

        public void Clear()
        {
            inner.Clear();
        }

        public bool Contains(FilterAttribute item)
        {
            return inner.Contains(item);
        }

        public void CopyTo(FilterAttribute[] array, int arrayIndex)
        {
            inner.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// 获取元素的个数。
        /// </summary>
        public int Count
        {
            get { return inner.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(FilterAttribute item)
        {
            return inner.Remove(item);
        }

        public IEnumerator<FilterAttribute> GetEnumerator()
        {
            return inner.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return inner.GetEnumerator();
        }

        public void AddRange(IEnumerable<FilterAttribute> items)
        {
            inner.AddRange(items);
        }
    }
}
