/* Constraints */

ALTER TABLE CustomerCustomerDemo
ADD CONSTRAINT PK_CustomerCustomerDemo PRIMARY KEY (CustomerID, CustomerTypeID);

ALTER TABLE CustomerDemographics
ADD CONSTRAINT PK_CustomerDemographics PRIMARY KEY  (CustomerTypeID);

ALTER TABLE CustomerCustomerDemo
ADD CONSTRAINT FK_CustomerCustomerDemo FOREIGN KEY (CustomerTypeID) 
  REFERENCES CustomerDemographics(CustomerTypeID);

ALTER TABLE CustomerCustomerDemo
ADD CONSTRAINT FK_CustomerCustDemo_Customers FOREIGN KEY (CustomerID) 
	REFERENCES Customers(CustomerID);

ALTER TABLE Region
ADD CONSTRAINT PK_Region PRIMARY KEY (RegionID);

ALTER TABLE Territories
ADD CONSTRAINT PK_Territories PRIMARY KEY (TerritoryID);

ALTER TABLE Territories
ADD CONSTRAINT FK_Territories_Region FOREIGN KEY (RegionID) 
	REFERENCES Region (RegionID);

ALTER TABLE EmployeeTerritories
ADD CONSTRAINT PK_EmployeeTerritories PRIMARY KEY (EmployeeID, TerritoryID);

ALTER TABLE EmployeeTerritories
ADD CONSTRAINT FK_EmployeeTerr_Employees FOREIGN KEY (EmployeeID)
	REFERENCES Employees(EmployeeID);

ALTER TABLE EmployeeTerritories	
ADD CONSTRAINT FK_EmployeeTerr_Territories FOREIGN KEY (TerritoryID)
	REFERENCES Territories(TerritoryID);
