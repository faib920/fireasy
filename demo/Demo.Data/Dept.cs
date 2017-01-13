// ------------------------------
// 本模块由CodeBuilder工具生成,该类适用于 Fireasy.Data.Entity 1.5 数据框架
// 版权所有 (C) Fireasy 2014

// 项目名称: Demo
// 模块名称: 部门 实体类
// 代码编写: Huangxd
// 文件路径: C:\Users\Admin\Desktop\Model\Dept.cs
// 创建时间: 2015/5/18 15:42:29
// ------------------------------

using System;
using Fireasy.Data.Entity;

namespace Demo.Data.Model
{
    /// <summary>
    /// 部门 实体类。
    /// </summary>
    [Serializable]
    [EntityMapping("TB_DEPT", Description = "部门")]
    public partial class Dept : LighEntityObject<Dept>
    {
        
        /// <summary>
        /// 获取或设置ID。
        /// </summary>
        [PropertyMapping(ColumnName = "ID", Description = "ID", IsPrimaryKey = true, GenerateType = IdentityGenerateType.Generator, IsNullable = false, Length = 36)]
        public virtual int Id { get; set; }

        /// <summary>
        /// 获取或设置编码。
        /// </summary>
        [PropertyMapping(ColumnName = "NO", Description = "编码", Length = 50)]
        public virtual string No { get; set; }

        /// <summary>
        /// 获取或设置名称。
        /// </summary>
        [PropertyMapping(ColumnName = "NAME", Description = "名称", Length = 50)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 获取或设置排序。
        /// </summary>
        [PropertyMapping(ColumnName = "ORDER_NO", Description = "排序")]
        public virtual int? OrderNo { get; set; }

        
        

        
        /// <summary>
        /// 获取或设置 <see cref="Employee"/> 的子实体集。
        /// </summary>
        public virtual EntitySet<Employee> Employees { get; set; }

    }
}