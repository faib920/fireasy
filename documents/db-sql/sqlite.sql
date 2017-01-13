CREATE TABLE Categories (
	CategoryID int NOT NULL,
	CategoryName nvarchar(15) NOT NULL,
	Description text NULL,
	CONSTRAINT PK_Categories PRIMARY KEY (CategoryID)
);
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
);
CREATE TABLE Products
(
	ProductID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
	ProductName nvarchar(40) NOT NULL,
	SupplierID int NULL,
	CategoryID int NULL,
	QuantityPerUnit nvarchar(20) NULL,
	UnitPrice decimal(19,2) NULL,
	UnitsInStock smallint NULL,
	UnitsOnOrder smallint NULL,
	ReorderLevel smallint NULL,
	Discontinued bit NOT NULL
);
CREATE TABLE Orders
(
	OrderID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
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
	ShipCountry nvarchar(15) NULL
);
CREATE TABLE [Order Details] (
	OrderID int NOT NULL,
	ProductID int NOT NULL,
	UnitPrice decimal(19,2) NOT NULL,
	Quantity smallint NOT NULL,
	Discount decimal(18,2) NOT NULL,
	CONSTRAINT PK_Order_Details PRIMARY KEY (OrderID, ProductID)
);
CREATE TABLE Batchers (
	Id int NOT NULL,
	Name nvarchar(50) NOT NULL,
	Birthday datetime
);
CREATE TABLE Identitys (
	Id1  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
	Id2 int NOT NULL,
	Id3 varchar(50) NOT NULL
);