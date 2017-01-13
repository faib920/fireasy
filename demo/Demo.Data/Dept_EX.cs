// ------------------------------
// 本模块由CodeBuilder工具生成,该类适用于 Fireasy.Data.Entity 1.5 数据框架
// 版权所有 (C) Fireasy 2014

// 项目名称: Demo
// 模块名称: 部门 实体类(数据验证元数据)
// 代码编写: Huangxd
// 文件路径: C:\Users\Admin\Desktop\Model\Dept_EX.cs
// 创建时间: 2015/5/18 15:42:29
// ------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using Fireasy.Data.Entity;
using Fireasy.Common.ComponentModel;

namespace Demo.Data.Model
{
    //如果要启用实体验证，请使用以下特性，并在 DeptMetadata 中定义验证特性。
    [MetadataType(typeof(DeptMetadata))]
    [EntityTreeMapping(InnerSign = "No")]
    public partial class Dept : ITreeNode<Dept>
    {
        string ITreeNode.Id
        {
            get { return Id.ToString(); }
            set { Id = Convert.ToInt32(value); }
        }

        public System.Collections.Generic.List<Dept> Children { get; set; }

        System.Collections.IList ITreeNode.Children
        {
            get
            {
                return Children;
            }
            set
            {
                Children = (System.Collections.Generic.List<Dept>)value;
            }
        }

        public bool HasChildren { get; set; }

        public bool IsLoaded { get; set; }
    }

    public class DeptMetadata
    {

        /// <summary>
        /// 属性 No 的验证特性。
        /// </summary>
        
        [StringLength(50)]
        public object No { get; set; }

        /// <summary>
        /// 属性 Name 的验证特性。
        /// </summary>
        
        [StringLength(50)]
        public object Name { get; set; }

        /// <summary>
        /// 属性 OrderNo 的验证特性。
        /// </summary>
        
        public object OrderNo { get; set; }

    }
}