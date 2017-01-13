USE 'fireasy-db';
CREATE TABLE Categories (
	CategoryID int NOT NULL,
	CategoryName nvarchar(15) NOT NULL,
	Description text NULL,
	CONSTRAINT PK_Categories PRIMARY KEY (CategoryID)
)
COMMENT='分类表';
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
COMMENT='客户表';
CREATE TABLE Products
(
	ProductID int NOT NULL AUTO_INCREMENT COMMENT '产品ID',
	ProductName nvarchar(40) NOT NULL COMMENT '产品名称',
	SupplierID int NULL COMMENT '供应商ID',
	CategoryID int NULL COMMENT '分类ID',
	QuantityPerUnit nvarchar(20) NULL,
	UnitPrice decimal(19,2) NULL COMMENT '单价',
	UnitsInStock smallint NULL COMMENT '库存量',
	UnitsOnOrder smallint NULL COMMENT '订单量',
	ReorderLevel smallint NULL,
	Discontinued bit NOT NULL,
	CONSTRAINT PK_Products PRIMARY KEY (ProductID)
)
COMMENT='产品表';
CREATE TABLE Orders
(
	OrderID int NOT NULL AUTO_INCREMENT COMMENT '订单ID',
	CustomerID nchar(5) COMMENT '客户ID',
	EmployeeID int NULL COMMENT '员工ID',
	OrderDate datetime NULL COMMENT '订单日期',
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
COMMENT='订单表';
CREATE TABLE `Order Details` (
	OrderID int NOT NULL,
	ProductID int NOT NULL,
	UnitPrice decimal(19,2) NOT NULL,
	Quantity smallint NOT NULL,
	Discount decimal(18,2) NOT NULL,
	CONSTRAINT PK_Order_Details PRIMARY KEY (OrderID, ProductID)
)
COMMENT='订单明细表';
CREATE TABLE Batchers (
	Id int NOT NULL,
	Name nvarchar(50) NOT NULL,
	Birthday datetime
);

CREATE TABLE Identitys (
	Id1 int NOT NULL AUTO_INCREMENT,
	Id2 int NOT NULL,
	CONSTRAINT PK_Identity PRIMARY KEY (Id1, Id2)
);