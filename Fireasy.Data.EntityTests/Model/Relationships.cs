// ------------------------------
// 本模块由CodeBuilder工具生成,该类适用于 Fireasy.Data.Entity 1.5 数据框架
// 版权所有 (C) Fireasy 2011

// 项目名称: 实体框架测试项目
// 模块名称: 关系定义
// 代码编写: Huangxd
// 文件路径: $FilePath$
// 创建时间: 2013/8/14 9:59:25
// ------------------------------

#region NAMESPACE
using Fireasy.Data.Entity;
#endregion NAMESPACE

[assembly: Relationship("Categories:Products", typeof(Fireasy.Data.Entity.Test.Model.Categories), typeof(Fireasy.Data.Entity.Test.Model.Products), "CategoryID=>CategoryID")]
[assembly: Relationship("Customers:Orders", typeof(Fireasy.Data.Entity.Test.Model.Customers), typeof(Fireasy.Data.Entity.Test.Model.Orders), "CustomerID=>CustomerID")]
[assembly: Relationship("Orders:Order Details", typeof(Fireasy.Data.Entity.Test.Model.Orders), typeof(Fireasy.Data.Entity.Test.Model.OrderDetails), "OrderID=>OrderID")]
[assembly: Relationship("Products:Order Details", typeof(Fireasy.Data.Entity.Test.Model.Products), typeof(Fireasy.Data.Entity.Test.Model.OrderDetails), "ProductID=>ProductID")]
[assembly: Relationship("Orders1:Order Details", typeof(Fireasy.Data.Entity.Test.Model.Orders), typeof(Fireasy.Data.Entity.Test.Model.OrderDetails), "OrderID=>OrderID")]
