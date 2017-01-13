// ------------------------------
// 本模块由CodeBuilder工具生成,该类适用于 Fireasy.Data.Entity 1.5 数据框架
// 版权所有 (C) Fireasy 2014

// 项目名称: Demo
// 模块名称: 关系定义
// 代码编写: Huangxd
// 文件路径: $FilePath$
// 创建时间: 2015/5/18 15:42:29
// ------------------------------

#region NAMESPACE
using Fireasy.Data.Entity;
#endregion NAMESPACE

[assembly: Relationship("TB_DEPT:TB_EMPLOYEE", typeof(Demo.Data.Model.Dept), typeof(Demo.Data.Model.Employee), "Id=>DeptId")]

