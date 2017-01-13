// ------------------------------
// 本模块由CodeBuilder工具生成,该类适用于 Fireasy.Data.Entity 1.5 数据框架
// 版权所有 (C) Fireasy 2014

// 项目名称: Demo
// 模块名称: 员工 实体类(数据验证元数据)
// 代码编写: Huangxd
// 文件路径: C:\Users\Admin\Desktop\Model\Employee_EX.cs
// 创建时间: 2015/5/18 15:42:29
// ------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using Fireasy.Data.Entity;
using Fireasy.Data.Validation;

namespace Demo.Data.Model
{
    //如果要启用实体验证，请使用以下特性，并在 EmployeeMetadata 中定义验证特性。
    [MetadataType(typeof(EmployeeMetadata))] 
    public partial class Employee
    {
    }

    public class EmployeeMetadata
    {
        
        /// <summary>
        /// 属性 Id 的验证特性。
        /// </summary>
        
        [Required]
        [StringLength(36)]
        public object Id { get; set; }

        /// <summary>
        /// 属性 DeptId 的验证特性。
        /// </summary>
        
        public object DeptId { get; set; }

        /// <summary>
        /// 属性 No 的验证特性。
        /// </summary>
        
        [StringLength(20)]
        public object No { get; set; }

        /// <summary>
        /// 属性 Sex 的验证特性。
        /// </summary>
        
        public object Sex { get; set; }

        /// <summary>
        /// 属性 Name 的验证特性。
        /// </summary>
        
        [StringLength(20)]
        [Fireasy.Data.Entity.Validation.UniqueCode]
        public object Name { get; set; }

        /// <summary>
        /// 属性 Birthday 的验证特性。
        /// </summary>
        
        public object Birthday { get; set; }

        /// <summary>
        /// 属性 Post 的验证特性。
        /// </summary>
        
        public object Post { get; set; }

        /// <summary>
        /// 属性 Mobile 的验证特性。
        /// </summary>
        
        [StringLength(20)]
        [Mobile]
        public object Mobile { get; set; }

        /// <summary>
        /// 属性 Address 的验证特性。
        /// </summary>
        
        [StringLength(100)]
        public object Address { get; set; }

        /// <summary>
        /// 属性 Description 的验证特性。
        /// </summary>
        
        [StringLength(500)]
        public object Description { get; set; }

        /// <summary>
        /// 属性 State 的验证特性。
        /// </summary>
        
        public object State { get; set; }

        /// <summary>
        /// 属性 DelFlag 的验证特性。
        /// </summary>
        
        public object DelFlag { get; set; }

        /// <summary>
        /// 属性 Photo 的验证特性。
        /// </summary>
        
        [StringLength(200)]
        public object Photo { get; set; }

    }
}