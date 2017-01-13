// ------------------------------
// 本模块由CodeBuilder工具生成,该类适用于 Fireasy.Data.Entity 1.5 数据框架
// 版权所有 (C) Fireasy 2014

// 项目名称: Demo
// 模块名称: 员工 实体类
// 代码编写: Huangxd
// 文件路径: C:\Users\Admin\Desktop\Model\Employee.cs
// 创建时间: 2015/5/18 15:42:29
// ------------------------------

using System;
using Fireasy.Data.Entity;

namespace Demo.Data.Model
{
    /// <summary>
    /// 员工 实体类。
    /// </summary>
    [Serializable]
    [EntityMapping("TB_EMPLOYEE", Description = "员工")]
    public partial class Employee : LighEntityObject<Employee>
    {
        
        /// <summary>
        /// 获取或设置ID。
        /// </summary>
        [PropertyMapping(ColumnName = "ID", Description = "ID", IsPrimaryKey = true, IsNullable = false, Length = 36)]
        public virtual string Id { get; set; }

        /// <summary>
        /// 获取或设置部门ID。
        /// </summary>
        [PropertyMapping(ColumnName = "DEPT_ID", Description = "部门ID")]
        public virtual int DeptId { get; set; }

        /// <summary>
        /// 获取或设置编号。
        /// </summary>
        [PropertyMapping(ColumnName = "NO", Description = "编号", Length = 20)]
        public virtual string No { get; set; }

        /// <summary>
        /// 获取或设置性别。
        /// </summary>
        [PropertyMapping(ColumnName = "SEX", Description = "性别")]
        public virtual Sex Sex { get; set; }

        /// <summary>
        /// 获取或设置姓名。
        /// </summary>
        [PropertyMapping(ColumnName = "NAME", Description = "姓名", Length = 20)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 获取或设置出生日期。
        /// </summary>
        [PropertyMapping(ColumnName = "BIRTHDAY", Description = "出生日期")]
        public virtual DateTime? Birthday { get; set; }

        /// <summary>
        /// 获取或设置职务。
        /// </summary>
        [PropertyMapping(ColumnName = "POST", Description = "职务")]
        public virtual int? Post { get; set; }

        /// <summary>
        /// 获取或设置手机号码。
        /// </summary>
        [PropertyMapping(ColumnName = "MOBILE", Description = "手机号码", Length = 20)]
        public virtual string Mobile { get; set; }

        /// <summary>
        /// 获取或设置家庭住址。
        /// </summary>
        [PropertyMapping(ColumnName = "ADDRESS", Description = "家庭住址", Length = 100)]
        public virtual string Address { get; set; }

        /// <summary>
        /// 获取或设置个人说明。
        /// </summary>
        [PropertyMapping(ColumnName = "DESCRIPTION", Description = "个人说明", Length = 500)]
        public virtual string Description { get; set; }

        /// <summary>
        /// 获取或设置状态。
        /// </summary>
        [PropertyMapping(ColumnName = "STATE", Description = "状态", IsNullable = false, DefaultValue = 1)]
        public virtual int State { get; set; }

        /// <summary>
        /// 获取或设置删除标记。
        /// </summary>
        [PropertyMapping(ColumnName = "DEL_FLAG", Description = "删除标记", IsNullable = false, IsDeletedKey = true, DefaultValue = 0)]
        public virtual int DelFlag { get; set; }

        /// <summary>
        /// 获取或设置照片。
        /// </summary>
        [PropertyMapping(ColumnName = "PHOTO", Description = "照片", Length = 200)]
        public virtual string Photo { get; set; }

        
        
        /// <summary>
        /// 获取或设置关联的 <see cref="Dept"/> 对象。
        /// </summary>
        public virtual Dept Dept { get; set; }


        
    }
}