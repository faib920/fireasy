// ------------------------------
// 本模块由CodeBuilder工具生成,该类适用于 Fireasy.Data.Entity 1.5 数据框架
// 版权所有 (C) Fireasy 2011

// 项目名称: 实体框架测试项目
// 模块名称: 订单明细表 实体类
// 代码编写: Huangxd
// 文件路径: C:\Users\Ruibron\Desktop\Model\OrderDetails.cs
// 创建时间: 2013/8/14 9:59:25
// ------------------------------

using System;
using Fireasy.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Fireasy.Data.Entity.Test.Model
{
    [Serializable]
    [EntityMapping("order details", Description = "")]
    [MetadataType(typeof(OrderDetailsMetadata))]
    public partial class OrderDetails : LighEntityObject<OrderDetails>
    {
        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "OrderID", Description = "", IsPrimaryKey = true, IsNullable = false)]
        public virtual long OrderID { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "ProductID", Description = "", IsPrimaryKey = true, IsNullable = false)]
        public virtual long ProductID { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "UnitPrice", Description = "", IsNullable = false)]
        public virtual double UnitPrice { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "Quantity", Description = "", IsNullable = false)]
        public virtual long Quantity { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "Discount", Description = "", IsNullable = false)]
        public virtual double Discount { get; set; }

        /// <summary>
        /// 获取或设置关联 <see cref="products"/> 对象。
        /// </summary>
        public virtual Products Products { get; set; }

        /// <summary>
        /// 获取或设置关联 <see cref="orders"/> 对象。
        /// </summary>
        public virtual Orders Orders { get; set; }

    }

    public class OrderDetailsMetadata
    {
        /// <summary>
        /// 属性 OrderID 的验证特性。
        /// </summary>
        [Required]
        public object OrderID { get; set; }

        /// <summary>
        /// 属性 ProductID 的验证特性。
        /// </summary>
        [Required]
        public object ProductID { get; set; }

        /// <summary>
        /// 属性 UnitPrice 的验证特性。
        /// </summary>
        [Required]
        public object UnitPrice { get; set; }

        /// <summary>
        /// 属性 Quantity 的验证特性。
        /// </summary>
        [Required]
        public object Quantity { get; set; }

        /// <summary>
        /// 属性 Discount 的验证特性。
        /// </summary>
        [Required]
        public object Discount { get; set; }

    }
}