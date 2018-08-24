/* BEGIN Tables 

DataType mappings
http://msdn.microsoft.com/en-us/library/ms151817.aspx
http://docs.oracle.com/cd/B19306_01/gateways.102/b14270/apa.htm
http://weblogs.sqlteam.com/jamesw/archive/2010/08/04/datatypes-translation-between-oracle-and-sql-server-part-2-number.aspx
http://www.techonthenet.com/oracle/datatypes.php

*/

CREATE TABLE Employees (
	EmployeeID number(10) NOT NULL ,
	LastName varchar2 (20) NOT NULL ,
	FirstName varchar2 (10) NOT NULL ,
	Title varchar2 (30) NULL ,
	TitleOfCourtesy varchar2 (25) NULL ,
	BirthDate date NULL, 
	HireDate date NULL ,
	Address varchar2 (60) NULL ,
	City varchar2 (30) NULL ,
	Region varchar2 (15) NULL ,
	PostalCode varchar2 (10) NULL ,
	Country varchar2 (15) NULL ,
	HomePhone varchar2 (24) NULL ,
	Extension varchar2 (4) NULL ,
	Photo blob NULL ,
	Notes blob NULL ,
	ReportsTo number(10) NULL ,
	PhotoPath varchar2 (255) NULL,
	PRIMARY KEY(EmployeeID),
	CONSTRAINT FK_Employees_Employees FOREIGN KEY (ReportsTo) 
		REFERENCES Employees(EmployeeID)
	--CONSTRAINT CK_Birthdate CHECK (BirthDate < SYSDATE)
	);

CREATE INDEX EmployeesLastName ON Employees(LastName);
CREATE INDEX EmployeesPostalCode ON Employees(PostalCode);

CREATE TABLE Categories (
	CategoryID number(10) NOT NULL ,
	CategoryName varchar2(15) NOT NULL ,
	Description varchar2(500) NULL,
	Picture blob NULL,
	PRIMARY KEY(CategoryID)
	);

CREATE INDEX CategoriesCategoryName ON Categories(CategoryName);


CREATE TABLE Customers (
	CustomerID varchar2 (5) NOT NULL ,
	CompanyName varchar2 (40) NOT NULL ,
	ContactName varchar2 (30) NULL ,
	ContactTitle varchar2 (30) NULL ,
	Address varchar2 (60) NULL ,
	City varchar2 (30) NULL ,
	Region varchar2 (15) NULL ,
	PostalCode varchar2 (10) NULL ,
	Country varchar2 (15) NULL ,
	Phone varchar2 (24) NULL ,
	Fax varchar2 (24) NULL,
	PRIMARY KEY(CustomerID)
	);


CREATE INDEX CustomersCity ON Customers(City);
CREATE INDEX CustomersCompanyName ON Customers(CompanyName);
CREATE INDEX CustomersPostalCode ON Customers(PostalCode);
CREATE INDEX CustomersRegion ON Customers(Region);

CREATE TABLE Shippers (
	ShipperID number(10) NOT NULL ,
	CompanyName varchar2 (40) NOT NULL ,
	Phone varchar2 (24) NULL,
	PRIMARY KEY(ShipperID)
	);


CREATE TABLE Suppliers (
	SupplierID number(10) NOT NULL ,
	CompanyName varchar2 (40) NOT NULL ,
	ContactName varchar2 (30) NULL ,
	ContactTitle varchar2 (30) NULL ,
	Address varchar2 (60) NULL ,
	City varchar2 (30) NULL ,
	Region varchar2 (15) NULL ,
	PostalCode varchar2 (10) NULL ,
	Country varchar2 (15) NULL ,
	Phone varchar2 (24) NULL ,
	Fax varchar2 (24) NULL ,
	HomePage varchar2(2000) NULL,
	PRIMARY KEY(SupplierID)
	);

CREATE INDEX SuppliersCompanyName ON Suppliers(CompanyName);
CREATE INDEX SuppliersPostalCode ON Suppliers(PostalCode);

CREATE TABLE Orders (
	OrderID number(10) NOT NULL ,
	CustomerID varchar2 (5) NULL ,
	EmployeeID number(10) NULL ,
	OrderDate TIMESTAMP NULL ,
	RequiredDate TIMESTAMP NULL ,
	ShippedDate TIMESTAMP NULL ,
	ShipVia number(10) NULL ,
	Freight number(19,4) NULL,
	ShipName varchar2 (40) NULL ,
	ShipAddress varchar2 (60) NULL ,
	ShipCity varchar2 (30) NULL ,
	ShipRegion varchar2 (15) NULL ,
	ShipPostalCode varchar2 (10) NULL ,
	ShipCountry varchar2 (15) NULL,
	PRIMARY KEY(OrderID),
	CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) 
		REFERENCES Customers(CustomerID),
	CONSTRAINT FK_Orders_Employees FOREIGN KEY (EmployeeID) 
		REFERENCES Employees(EmployeeID),
	CONSTRAINT FK_Orders_Shippers FOREIGN KEY (ShipVia) 
		REFERENCES Shippers(ShipperID)
	);


CREATE INDEX OrdersCustomerID ON Orders(CustomerID);
--CREATE INDEX OrdersCustomersOrders ON Orders(CustomerID);
CREATE INDEX OrdersEmployeeID ON Orders(EmployeeID);
--CREATE INDEX OrdersEmployeesOrders ON Orders(EmployeeID);
CREATE INDEX OrdersOrderDate ON Orders(OrderDate);
CREATE INDEX OrdersShippedDate ON Orders(ShippedDate);
CREATE INDEX OrdersShippersOrders ON Orders(ShipVia);
CREATE INDEX OrdersShipPostalCode ON Orders(ShipPostalCode);


CREATE TABLE Products (
	ProductID number(10) NOT NULL,
	ProductName varchar2 (40) NOT NULL,
	SupplierID number(10) NULL,
	CategoryID number(10) NULL,
	QuantityPerUnit varchar2 (20) NULL,
	UnitPrice number(19,4) DEFAULT 0 NULL, 
	UnitsInStock number(5) DEFAULT 0 NULL,
	UnitsOnOrder number(5) DEFAULT 0 NULL,
	ReorderLevel number(5) DEFAULT 0 NULL,
	Discontinued number(3) DEFAULT 0 NOT NULL ,
	PRIMARY KEY(ProductID),
	CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryID) 
		REFERENCES Categories(CategoryID),
	CONSTRAINT FK_Products_Suppliers FOREIGN KEY (SupplierID) 
		REFERENCES Suppliers(SupplierID),
	CONSTRAINT CK_Products_UnitPrice 
		CHECK (UnitPrice >= 0),
	CONSTRAINT CK_UnitsInStock 
		CHECK (UnitsInStock >= 0),
	CONSTRAINT CK_UnitsOnOrder 
		CHECK (UnitsOnOrder >= 0),
	CONSTRAINT CK_ReorderLevel 
		CHECK (ReorderLevel >= 0)
	);

--CREATE INDEX ProductsCategoriesProducts ON Products(CategoryID);
CREATE INDEX ProductsCategoryID ON Products(CategoryID);
CREATE INDEX ProductsProductName ON Products(ProductName);
CREATE INDEX ProductsSupplierID ON Products(SupplierID);
--CREATE INDEX ProductsSuppliersProducts ON Products(SupplierID);

CREATE TABLE Order_Details (
	OrderID number(10) NOT NULL ,
	ProductID number(10) NOT NULL ,
	UnitPrice number(19,4) DEFAULT 0 NOT NULL,
	Quantity number(10) DEFAULT 1 NOT NULL,
	Discount float(23) DEFAULT 0 NOT NULL,
	CONSTRAINT PK_Order_Product PRIMARY KEY(OrderID, ProductID),
	CONSTRAINT FK_Order_Details_Orders FOREIGN KEY (OrderID) 
		REFERENCES Orders(OrderID),
	CONSTRAINT FK_Order_Details_Products FOREIGN KEY (ProductID) 
		REFERENCES Products(ProductID),
	CONSTRAINT "CK_UnitPrice" 
		CHECK (UnitPrice >= 0),
	CONSTRAINT "CK_Quantity" 
		CHECK (Quantity > 0),
	CONSTRAINT "CK_Discount" 
		CHECK (Discount >= 0 and (Discount <= 1))
	);

CREATE INDEX OrderDetailsOrderID ON Order_Details(OrderID);
--CREATE INDEX OrderDetailsOrders ON Order_Details(OrderID);
CREATE INDEX OrderDetailsProductID ON Order_Details(ProductID);
--CREATE INDEX OrderDetailsProducts ON Order_Details(ProductID);

CREATE TABLE CustomerCustomerDemo(
	CustomerID varchar2(5) NOT NULL,
	CustomerTypeID varchar2(10) NOT NULL);


CREATE TABLE CustomerDemographics(
	CustomerTypeID varchar2 (10) NOT NULL ,
	 CustomerDesc varchar2(200) NULL );

	
CREATE TABLE Region( 
	RegionID number NOT NULL ,
	RegionDescription varchar2 (50) NOT NULL);

CREATE TABLE Territories(
	TerritoryID varchar2 (20) NOT NULL ,
	TerritoryDescription varchar2 (50) NOT NULL ,
        RegionID number NOT NULL);

CREATE TABLE EmployeeTerritories(
	EmployeeID number NOT NULL,
	TerritoryID varchar2 (20) NOT NULL );

/* END Tables */


/* BEGIN Views */

CREATE VIEW  Customer_and_Suppliers_by_City  AS
	SELECT City, CompanyName, ContactName, 'Customers' TableFrom
	FROM Customers
	UNION 
	SELECT City, CompanyName, ContactName, 'Suppliers'
	FROM Suppliers;
--ORDER BY City, CompanyName

CREATE VIEW Alphabetical_list_of_products AS
	SELECT Products.*, Categories.CategoryName
	FROM Categories, Products
	WHERE Categories.CategoryID = Products.CategoryID
  		AND (((Products.Discontinued)=0));

CREATE VIEW Current_Product_List AS
	SELECT ProductID, ProductName
	FROM Products 
	WHERE (((Discontinued)=0));
	--ORDER BY Product_List.ProductName

CREATE VIEW Orders_Qry AS
	SELECT Orders.OrderID, Orders.CustomerID, Orders.EmployeeID, Orders.OrderDate, Orders.RequiredDate, 
		Orders.ShippedDate, Orders.ShipVia, Orders.Freight, Orders.ShipName, Orders.ShipAddress, Orders.ShipCity, 
		Orders.ShipRegion, Orders.ShipPostalCode, Orders.ShipCountry, 
		Customers.CompanyName, Customers.Address, Customers.City, Customers.Region, Customers.PostalCode, Customers.Country
	FROM Customers,Orders
	where Customers.CustomerID = Orders.CustomerID;

CREATE VIEW Products_Above_Average_Price AS
	SELECT Products.ProductName, Products.UnitPrice
	FROM Products
	WHERE Products.UnitPrice>(SELECT AVG(UnitPrice) From Products);
	--ORDER BY Products.UnitPrice DESC

CREATE VIEW Products_by_Category AS
	SELECT Categories.CategoryName, Products.ProductName, Products.QuantityPerUnit, Products.UnitsInStock, Products.Discontinued
	FROM Categories, Products
	WHERE Categories.CategoryID = Products.CategoryID
	 AND Products.Discontinued <> 1;
	--ORDER BY Categories.CategoryName, Products.ProductName


CREATE or REPLACE VIEW Quarterly_Orders AS
	SELECT DISTINCT Customers.CustomerID, Customers.CompanyName, Customers.City, Customers.Country
	FROM Customers, Orders 
	WHERE Customers.CustomerID = Orders.CustomerID
	  AND to_date(Orders.OrderDate, 'MM/DD/YYYY') BETWEEN to_date('19970101', 'YYYYMMDD') And to_date('19971231', 'YYYYMMDD');

CREATE VIEW Invoices AS
	SELECT Orders.ShipName, Orders.ShipAddress, Orders.ShipCity, Orders.ShipRegion, Orders.ShipPostalCode, 
		Orders.ShipCountry, Orders.CustomerID, Customers.CompanyName AS CustomerName, Customers.Address, Customers.City, 
		Customers.Region, Customers.PostalCode, Customers.Country, 
		(FirstName||' '||LastName) AS Salesperson, 
		Orders.OrderID, Orders.OrderDate, Orders.RequiredDate, Orders.ShippedDate, Shippers.CompanyName As ShipperName, 
		Order_Details.ProductID, Products.ProductName, Order_Details.UnitPrice, Order_Details.Quantity, 
		Order_Details.Discount, 
		Order_Details.UnitPrice*Quantity*(1-Discount)/100 *100  AS ExtendedPrice, Orders.Freight
	FROM 	Shippers, Products, Employees, Customers, Orders, Order_Details
	where Customers.CustomerID = Orders.CustomerID
	  and Employees.EmployeeID = Orders.EmployeeID
	  and Orders.OrderID = Order_Details.OrderID
	  and Products.ProductID = Order_Details.ProductID
	  and Shippers.ShipperID = Orders.ShipVia;

CREATE VIEW Order_Details_Extended AS
	SELECT Order_Details.OrderID, Order_Details.ProductID, Products.ProductName, 
		Order_Details.UnitPrice, Order_Details.Quantity, Order_Details.Discount, 
		Order_Details.UnitPrice*Quantity*(1-Discount)/100 * 100 AS ExtendedPrice
	FROM Products, Order_Details 
	where Products.ProductID = Order_Details.ProductID;
	--ORDER BY Order Details.OrderID

CREATE VIEW Order_Subtotals AS
	SELECT Order_Details.OrderID, Sum(Order_Details.UnitPrice*Quantity*(1-Discount)/100*100) AS Subtotal
	FROM Order_Details
	GROUP BY Order_Details.OrderID;

create or replace view Product_Sales_for_1997 AS
	SELECT Categories.CategoryName, Products.ProductName, 
	Sum(Order_Details.UnitPrice*Quantity*(1-Discount)/100*100) AS ProductSales
	FROM Categories , Products, Order_Details, Orders
	where Categories.CategoryID = Products.CategoryID
	and	  Orders.OrderID = Order_Details.OrderID 
	and	  Products.ProductID = Order_Details.ProductID
	and   to_date(Orders.ShippedDate, 'MM/DD/YYYY') Between to_date('19970101', 'YYYYMMDD') And to_date('19971231', 'YYYYMMDD')
	GROUP BY Categories.CategoryName, Products.ProductName;


CREATE VIEW Category_Sales_for_1997 AS
	SELECT Product_Sales_for_1997.CategoryName, Sum(Product_Sales_for_1997.ProductSales) AS CategorySales
	FROM Product_Sales_for_1997
	GROUP BY Product_Sales_for_1997.CategoryName;

create or replace view Sales_by_Category AS
	SELECT Categories.CategoryID, Categories.CategoryName, Products.ProductName, 
		Sum(Order_Details_Extended.ExtendedPrice) AS ProductSales
	FROM 	Categories, Products, Order_Details_Extended, Orders
	where  Orders.OrderID = Order_Details_Extended.OrderID 
	and    Products.ProductID = Order_Details_Extended.ProductID 
	and   Categories.CategoryID = Products.CategoryID
	and   to_date(Orders.OrderDate, 'MM/DD/YYYY') BETWEEN to_date('19970101', 'YYYYMMDD') And to_date('19971231', 'YYYYMMDD')
	GROUP BY Categories.CategoryID, Categories.CategoryName, Products.ProductName;
	--ORDER BY Products.ProductName

create or replace view Sales_Totals_by_Amount AS
	SELECT Order_Subtotals.Subtotal AS SaleAmount, Orders.OrderID, Customers.CompanyName, Orders.ShippedDate
	FROM 	Customers,  Order_Subtotals, Orders
	where Orders.OrderID = Order_Subtotals.OrderID 
	and  Customers.CustomerID = Orders.CustomerID
	and (Order_Subtotals.Subtotal >2500) AND (to_date(Orders.ShippedDate, 'MM/DD/YYYY') BETWEEN to_date('19970101', 'YYYYMMDD') And to_date('19971231', 'YYYYMMDD'));

CREATE VIEW Summary_of_Sales_by_Quarter AS
	SELECT Orders.ShippedDate, Orders.OrderID, Order_Subtotals.Subtotal
	FROM Orders, Order_Subtotals 
	where Orders.OrderID = Order_Subtotals.OrderID
	and Orders.ShippedDate IS NOT NULL;
	--ORDER BY Orders.ShippedDate

CREATE VIEW Summary_of_Sales_by_Year AS
	SELECT Orders.ShippedDate, Orders.OrderID, Order_Subtotals.Subtotal
	FROM Orders, Order_Subtotals 
	where Orders.OrderID = Order_Subtotals.OrderID
	and Orders.ShippedDate IS NOT NULL;
	--ORDER BY Orders.ShippedDate

/* END Views */