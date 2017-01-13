// ------------------------------
// 本模块由CodeBuilder工具生成,该类适用于 Fireasy.Data.Entity 1.5 数据框架
// 版权所有 (C) Fireasy 2011

// 项目名称: 实体框架测试项目
// 模块名称: 产品表 实体类
// 代码编写: Huangxd
// 文件路径: C:\Users\Ruibron\Desktop\Model\Products.cs
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
    [EntityMapping("products", Description = "")]
    [MetadataType(typeof(ProductsMetadata))]
    public partial class Products : LighEntityObject<Products>, IIntegralQueryable
    {
        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "ProductID", Description = "", IsPrimaryKey = true, IsNullable = false)]
        public virtual long ProductID { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "ProductName", Description = "", Length = 40, IsNullable = false)]
        [InterfaceMemberMapping(typeof(IIntegralQueryable), "ProductName")]
        public virtual string ProductName { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "SupplierID", Description = "", IsNullable = true)]
        public virtual long? SupplierID { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "CategoryID", Description = "", IsNullable = true)]
        public virtual long? CategoryID { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "QuantityPerUnit", Description = "", Length = 20, IsNullable = true)]
        public virtual string QuantityPerUnit { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "UnitPrice", Description = "", IsNullable = true)]
        public virtual double? UnitPrice { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "UnitsInStock", Description = "", IsNullable = true)]
        public virtual long? UnitsInStock { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "UnitsOnOrder", Description = "", IsNullable = true)]
        public virtual long? UnitsOnOrder { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "ReorderLevel", Description = "", IsNullable = true)]
        public virtual RecorderLevel ReorderLevel { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "Discontinued", Description = "", IsNullable = false)]
        public virtual bool Discontinued { get; set; }

        /// <summary>
        /// 获取或设置关联 <see cref="categories"/> 对象。
        /// </summary>
        public virtual Categories categories { get; set; }

        /// <summary>
        /// 获取或设置 <see cref="order details"/> 的子实体集。
        /// </summary>
        public virtual EntitySet<OrderDetails> OrderDetailses { get; set; }

        public string Name { get; set; }
    }

    public class ProductsMetadata
    {
        /// <summary>
        /// 属性 ProductID 的验证特性。
        /// </summary>
        [Required]
        public object ProductID { get; set; }

        /// <summary>
        /// 属性 ProductName 的验证特性。
        /// </summary>
        [Required]
        [StringLength(40)]
        public object ProductName { get; set; }

        /// <summary>
        /// 属性 SupplierID 的验证特性。
        /// </summary>
        public object SupplierID { get; set; }

        /// <summary>
        /// 属性 CategoryID 的验证特性。
        /// </summary>
        public object CategoryID { get; set; }

        /// <summary>
        /// 属性 QuantityPerUnit 的验证特性。
        /// </summary>
        [StringLength(20)]
        public object QuantityPerUnit { get; set; }

        /// <summary>
        /// 属性 UnitPrice 的验证特性。
        /// </summary>
        public object UnitPrice { get; set; }

        /// <summary>
        /// 属性 UnitsInStock 的验证特性。
        /// </summary>
        public object UnitsInStock { get; set; }

        /// <summary>
        /// 属性 UnitsOnOrder 的验证特性。
        /// </summary>
        public object UnitsOnOrder { get; set; }

        /// <summary>
        /// 属性 ReorderLevel 的验证特性。
        /// </summary>
        public object ReorderLevel { get; set; }

        /// <summary>
        /// 属性 Discontinued 的验证特性。
        /// </summary>
        [Required]
        public object Discontinued { get; set; }

    }

    
    public interface IIntegralQueryable : IEntity
    {
        string Name { get; set; }
    }

}