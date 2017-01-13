// ------------------------------
// 本模块由CodeBuilder工具生成,该类适用于 Fireasy.Data.Entity 1.5 数据框架
// 版权所有 (C) Fireasy 2014

// 项目名称: Demo
// 模块名称: 数据上下文
// 代码编写: Huangxd
// 文件路径: $FilePath$
// 创建时间: 2015/5/18 15:42:29
// ------------------------------

#region NAMESPACE
using System;
using Fireasy.Data.Entity;
using Demo.Data.Model;
#endregion NAMESPACE

namespace Demo.Data.Model
{
    public class DbContext : EntityContext
    {
        
        /// <summary>
        /// 获取或设置 员工 实体仓储。
        /// </summary> 
        public EntityRepository<Employee> Employees { get; set; }

        /// <summary>
        /// 获取或设置 部门 实体仓储。
        /// </summary> 
        public EntityRepository<Dept> Depts { get; set; }

    }
}