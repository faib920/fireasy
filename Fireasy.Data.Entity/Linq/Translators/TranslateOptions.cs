// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Fireasy.Data.Entity.Linq.Translators
{
    /// <summary>
    /// ELinq 表达式的翻译选项。无法继承此类。
    /// </summary>
    public sealed class TranslateOptions
    {
        /// <summary>
        /// 初始化 <see cref="TranslateOptions"/> 类的新实例。
        /// </summary>
        public TranslateOptions()
        {
        }

        /// <summary>
        /// 获取或设置是否隐藏列的别名。
        /// </summary>
        public bool HideColumnAliases { get; set; }

        /// <summary>
        /// 获取或设置是否隐藏表的别名。
        /// </summary>
        public bool HideTableAliases { get; set; }

        /// <summary>
        /// 获取或设置是否返回查询参数。默认为 false。
        /// </summary>
        public bool AttachParameter { get; set; }

        /// <summary>
        /// 获取或设置是否仅仅生成条件。
        /// </summary>
        public bool WhereOnly { get; set; }

        /// <summary>
        /// 获取或设置是否缓存。默认为 true。
        /// </summary>
        public bool UseCache { get; set; }
    }
}
