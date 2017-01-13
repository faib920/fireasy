CREATE DATABASE [fireasy-db]
GO
USE [fireasy-db]
GO
CREATE TABLE Categories (
	CategoryID int NOT NULL,
	CategoryName nvarchar(15) NOT NULL,
	Description ntext NULL,
	CONSTRAINT PK_Categories PRIMARY KEY (CategoryID)
)
GO
CREATE TABLE Customers (
	CustomerID nvarchar(50) NOT NULL ,
	CompanyName nvarchar(100) NULL ,
	ContactName nvarchar(100) NULL ,
	ContactTitle nvarchar(100) NULL ,
	Address nvarchar(100) NULL ,
	City nvarchar(20) NULL ,
	Region nvarchar(20) NULL ,
	PostalCode nvarchar(10) NULL ,
	Country nvarchar(20) NULL ,
	Phone nvarchar(100) NULL ,
	Fax nvarchar(100) NULL ,
	CONSTRAINT PK_Customers PRIMARY KEY (CustomerID)
)
GO
sp_addextendedproperty 'MS_Description', '客户表', 'user', 'dbo', 'table', 'Customers', NULL, NULL
GO
sp_addextendedproperty 'MS_Description', '分类表', 'user', 'dbo', 'table', 'Categories', NULL, NULL
GO
CREATE TABLE Products
(
	ProductID int NOT NULL IDENTITY(1, 1),
	ProductName nvarchar(40) NOT NULL,
	SupplierID int NULL,
	CategoryID int NULL,
	QuantityPerUnit nvarchar(20) NULL,
	UnitPrice decimal(19,2) NULL,
	UnitsInStock smallint NULL,
	UnitsOnOrder smallint NULL,
	ReorderLevel smallint NULL,
	Discontinued bit NOT NULL,
	CONSTRAINT PK_Products PRIMARY KEY (ProductID)
)
GO
sp_addextendedproperty 'MS_Description', '产品表', 'user', 'dbo', 'table', 'Products', NULL, NULL
GO
sp_addextendedproperty 'MS_Description', '产品ID', 'user', 'dbo', 'table', 'Products', 'column', 'ProductID'
GO
sp_addextendedproperty 'MS_Description', '产品名称', 'user', 'dbo', 'table', 'Products', 'column', 'ProductName'
GO
sp_addextendedproperty 'MS_Description', '供应商ID', 'user', 'dbo', 'table', 'Products', 'column', 'SupplierID'
GO
sp_addextendedproperty 'MS_Description', '分类ID', 'user', 'dbo', 'table', 'Products', 'column', 'CategoryID'
GO
sp_addextendedproperty 'MS_Description', '单价', 'user', 'dbo', 'table', 'Products', 'column', 'UnitPrice'
GO
sp_addextendedproperty 'MS_Description', '库存量', 'user', 'dbo', 'table', 'Products', 'column', 'UnitsInStock'
GO
sp_addextendedproperty 'MS_Description', '订单量', 'user', 'dbo', 'table', 'Products', 'column', 'UnitsOnOrder'
GO
CREATE TABLE Orders
(
	OrderID int NOT NULL IDENTITY(1, 1),
	CustomerID nchar(5),
	EmployeeID int NULL,
	OrderDate datetime NULL,
	RequiredDate datetime NULL,
	ShippedDate datetime NULL,
	ShipVia int NULL,
	Freight decimal(19,2) NULL,
	ShipName nvarchar(40) NULL,
	ShipAddress nvarchar(60) NULL,
	ShipCity nvarchar(15) NULL,
	ShipRegion nvarchar(15) NULL,
	ShipPostalCode nvarchar(10) NULL,
	ShipCountry nvarchar(15) NULL,
	CONSTRAINT PK_Orders PRIMARY KEY (OrderID)
)
GO
sp_addextendedproperty 'MS_Description', '订单表', 'user', 'dbo', 'table', 'Orders', NULL, NULL
GO
sp_addextendedproperty 'MS_Description', '订单ID', 'user', 'dbo', 'table', 'Orders', 'column', 'OrderID'
GO
sp_addextendedproperty 'MS_Description', '客户ID', 'user', 'dbo', 'table', 'Orders', 'column', 'CustomerID'
GO
sp_addextendedproperty 'MS_Description', '员工ID', 'user', 'dbo', 'table', 'Orders', 'column', 'EmployeeID'
GO
sp_addextendedproperty 'MS_Description', '订单日期', 'user', 'dbo', 'table', 'Orders', 'column', 'OrderDate'
GO
CREATE TABLE [Order Details] (
	OrderID int NOT NULL,
	ProductID int NOT NULL,
	UnitPrice decimal(19,2) NOT NULL,
	Quantity smallint NOT NULL,
	Discount decimal(18,2) NOT NULL,
	CONSTRAINT PK_Order_Details PRIMARY KEY (OrderID, ProductID)
)
GO
sp_addextendedproperty 'MS_Description', '订单明细表', 'user', 'dbo', 'table', 'Order Details', NULL, NULL
GO
CREATE TABLE Batchers (
	Id int NOT NULL,
	Name nvarchar(50) NOT NULL,
	Birthday datetime
)
GO

CREATE TABLE Identitys (
	Id1 int NOT NULL IDENTITY(1, 1),
	Id2 int NOT NULL,
	CONSTRAINT PK_Identity PRIMARY KEY (Id1, Id2)
)
GO