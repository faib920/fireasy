// ------------------------------
// 本模块由CodeBuilder工具生成,该类适用于 Fireasy.Data.Entity 1.5 数据框架
// 版权所有 (C) Fireasy 2011

// 项目名称: 实体框架测试项目
// 模块名称: 订单表 实体类
// 代码编写: Huangxd
// 文件路径: C:\Users\Ruibron\Desktop\Model\Orders.cs
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
    [EntityMapping("orders", Description = "")]
    [MetadataType(typeof(OrdersMetadata))]
    public partial class Orders : LighEntityObject<Orders>
    {
        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "OrderID", Description = "", IsPrimaryKey = true, IsNullable = false)]
        public virtual long OrderID { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "CustomerID", Description = "", Length = 5, IsNullable = true)]
        public virtual string CustomerID { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "EmployeeID", Description = "", IsNullable = true)]
        public virtual long? EmployeeID { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "OrderDate", Description = "", Length = 2147483647, IsNullable = true)]
        public virtual DateTime? OrderDate { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "RequiredDate", Description = "", Length = 2147483647, IsNullable = true)]
        public virtual DateTime? RequiredDate { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "ShippedDate", Description = "", Length = 2147483647, IsNullable = true)]
        public virtual string ShippedDate { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "ShipVia", Description = "", IsNullable = true)]
        public virtual long? ShipVia { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "Freight", Description = "", IsNullable = true)]
        public virtual decimal? Freight { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "ShipName", Description = "", Length = 40, IsNullable = true)]
        public virtual string ShipName { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "ShipAddress", Description = "", Length = 60, IsNullable = true)]
        public virtual string ShipAddress { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "ShipCity", Description = "", Length = 15, IsNullable = true)]
        public virtual string ShipCity { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "ShipRegion", Description = "", Length = 15, IsNullable = true)]
        public virtual string ShipRegion { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "ShipPostalCode", Description = "", Length = 10, IsNullable = true)]
        public virtual string ShipPostalCode { get; set; }

        /// <summary>
        /// 获取或设置。
        /// </summary>

        [PropertyMapping(ColumnName = "ShipCountry", Description = "", Length = 15, IsNullable = true)]
        public virtual string ShipCountry { get; set; }

        /// <summary>
        /// 获取或设置关联 <see cref="customers"/> 对象。
        /// </summary>
        public virtual Customers Customers { get; set; }

        /// <summary>
        /// 获取或设置 <see cref="order details"/> 的子实体集。
        /// </summary>
        public virtual EntitySet<OrderDetails> OrderDetailses { get; set; }

    }

    public class OrdersMetadata
    {
        /// <summary>
        /// 属性 OrderID 的验证特性。
        /// </summary>
        [Required]
        public object OrderID { get; set; }

        /// <summary>
        /// 属性 CustomerID 的验证特性。
        /// </summary>
        [StringLength(5)]
        public object CustomerID { get; set; }

        /// <summary>
        /// 属性 EmployeeID 的验证特性。
        /// </summary>
        public object EmployeeID { get; set; }

        /// <summary>
        /// 属性 OrderDate 的验证特性。
        /// </summary>
        [StringLength(2147483647)]
        public object OrderDate { get; set; }

        /// <summary>
        /// 属性 RequiredDate 的验证特性。
        /// </summary>
        [StringLength(2147483647)]
        public object RequiredDate { get; set; }

        /// <summary>
        /// 属性 ShippedDate 的验证特性。
        /// </summary>
        [StringLength(2147483647)]
        public object ShippedDate { get; set; }

        /// <summary>
        /// 属性 ShipVia 的验证特性。
        /// </summary>
        public object ShipVia { get; set; }

        /// <summary>
        /// 属性 Freight 的验证特性。
        /// </summary>
        public object Freight { get; set; }

        /// <summary>
        /// 属性 ShipName 的验证特性。
        /// </summary>
        [StringLength(40)]
        public object ShipName { get; set; }

        /// <summary>
        /// 属性 ShipAddress 的验证特性。
        /// </summary>
        [StringLength(60)]
        public object ShipAddress { get; set; }

        /// <summary>
        /// 属性 ShipCity 的验证特性。
        /// </summary>
        [StringLength(15)]
        public object ShipCity { get; set; }

        /// <summary>
        /// 属性 ShipRegion 的验证特性。
        /// </summary>
        [StringLength(15)]
        public object ShipRegion { get; set; }

        /// <summary>
        /// 属性 ShipPostalCode 的验证特性。
        /// </summary>
        [StringLength(10)]
        public object ShipPostalCode { get; set; }

        /// <summary>
        /// 属性 ShipCountry 的验证特性。
        /// </summary>
        [StringLength(15)]
        public object ShipCountry { get; set; }

    }
}