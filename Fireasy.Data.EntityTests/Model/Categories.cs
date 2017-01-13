// ------------------------------
// 本模块由CodeBuilder工具生成,该类适用于 Fireasy.Data.Entity 1.5 数据框架
// 版权所有 (C) Fireasy 2011

// 项目名称: 实体框架测试项目
// 模块名称: 分类表 实体类
// 代码编写: Huangxd
// 文件路径: C:\Users\Ruibron\Desktop\Model\Categories.cs
// 创建时间: 2013/8/14 9:59:25
// ------------------------------

using System;
using Fireasy.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Fireasy.Data.Entity.Test.Model
{
    /// <summary>
    ///  实体类。
    /// </summary>
    [Serializable]
    [EntityMapping("Categories", Description = "")]
    [MetadataType(typeof(CategoriesMetadata))]
    public partial class Categories : LighEntityObject<Categories>
    {
        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "CategoryID", Description = "", IsPrimaryKey = true, IsNullable = false)]
        public virtual long CategoryID { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "CategoryName", Description = "", Length = 15, IsNullable = false)]
        public virtual string CategoryName { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "Description", Description = "", Length = 2147483647, IsNullable = true)]
        public virtual string Description { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "Picture", Description = "", IsNullable = true)]
        public virtual byte[] Picture { get; set; }

        /// <summary>
        /// 获取或设置 <see cref="products"/> 的子实体集。
        /// </summary>
        public virtual EntitySet<Products> productses { get; set; }

    }

    public class CategoriesMetadata
    {
        /// <summary>
        /// 属性 CategoryID 的验证特性。
        /// </summary>
        [Required]
        public object CategoryID { get; set; }

        /// <summary>
        /// 属性 CategoryName 的验证特性。
        /// </summary>
        [Required]
        [StringLength(15)]
        public object CategoryName { get; set; }

        /// <summary>
        /// 属性 Description 的验证特性。
        /// </summary>
        [StringLength(2147483647)]
        public object Description { get; set; }

        /// <summary>
        /// 属性 Picture 的验证特性。
        /// </summary>
        public object Picture { get; set; }

    }
}