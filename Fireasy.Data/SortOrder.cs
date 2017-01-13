// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
namespace Fireasy.Data
{
    /// <summary>
    /// 排序顺序。
    /// </summary>
    public enum SortOrder
    {
        /// <summary>
        /// 未定义。
        /// </summary>
        None,
        /// <summary>
        /// 升序。
        /// </summary>
        Ascending,
        /// <summary>
        /// 降序。
        /// </summary>
        Descending
    }

    /// <summary>
    /// 定义数据排序。
    /// </summary>
    public class SortDefinition
    {
        /// <summary>
        /// 表示一个空的定义。
        /// </summary>
        public static SortDefinition Empty = new SortDefinition();

        /// <summary>
        /// 获取或设置排序顺序。
        /// </summary>
        public SortOrder Order { get; set; }

        /// <summary>
        /// 获取或设置排序的成员名称。
        /// </summary>
        public string Member { get; set; }

        /// <summary>
        /// 使用一组值替换 Member 属性。
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        public SortDefinition Replace(Dictionary<string, string> members)
        {
            if (string.IsNullOrEmpty(Member))
            {
                return this;
            }

            if (members.ContainsKey(Member))
            {
                Member = members[Member];
            }

            return this;
        }

    }
}
