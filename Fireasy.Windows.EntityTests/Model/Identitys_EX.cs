// ------------------------------
// 本模块由CodeBuilder工具生成,该类适用于 Fireasy.Data.Entity 1.5 数据框架
// 版权所有 (C) Fireasy 2011

// 项目名称: 实体框架测试项目
// 模块名称: Identitys 实体类(数据验证元数据)
// 代码编写: Huangxd
// 文件路径: C:\Users\Ruibron\Desktop\Model\Identitys_EX.cs
// 创建时间: 2013/10/15 10:28:27
// ------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using Fireasy.Data.Entity;

namespace Fireasy.Data.Entity.Test.Model
{
    //如果要启用实体验证，请使用以下特性，并在 IdentitysMetadata 中定义验证特性。
    [MetadataType(typeof(IdentitysMetadata))] 
    public partial class Identitys
    {
    }

    public class IdentitysMetadata
    {
        
        /// <summary>
        /// 属性 Id1 的验证特性。
        /// </summary>
        //[Display(Description = "Id1")]
        [Required]
        public object Id1 { get; set; }

        /// <summary>
        /// 属性 Id2 的验证特性。
        /// </summary>
        //[Display(Description = "Id2")]
        [Required]
        public object Id2 { get; set; }

        /// <summary>
        /// 属性 Id3 的验证特性。
        /// </summary>
        //[Display(Description = "Id3")]
        [Required]
        public object Id3 { get; set; }

    }
}