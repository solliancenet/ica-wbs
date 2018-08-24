CREATE OR REPLACE
PROCEDURE GetCustomersTest(
	p_customer_id IN varchar2,
  p_param_test IN varchar2,
  cur_OUT OUT PKGENTLIB_ARCHITECTURE.CURENTLIB_ARCHITECTURE)
AS
BEGIN
  OPEN cur_OUT FOR SELECT * FROM Customers WHERE CustomerID = p_customer_id;
END;

CREATE OR REPLACE
PROCEDURE CustOrdersOrders(
	p_customer_id IN varchar2,
    cur_OUT OUT PKGENTLIB_ARCHITECTURE.CURENTLIB_ARCHITECTURE)
AS
BEGIN
  OPEN cur_OUT FOR 
  	SELECT 	OrderID, 
			OrderDate,
			RequiredDate,
			ShippedDate
		FROM Orders
		WHERE CustomerID = p_customer_id
		ORDER BY OrderID;
END;

CREATE OR REPLACE
PROCEDURE CustOrderHist(
	p_customer_id IN varchar2,
    cur_OUT OUT PKGENTLIB_ARCHITECTURE.CURENTLIB_ARCHITECTURE)
AS
BEGIN
  OPEN cur_OUT FOR 
  	SELECT ProductName, SUM(Quantity) AS Total
    FROM Products P, Order_Details OD, Orders O, Customers C 
    WHERE C.CustomerID = p_customer_id 
      AND C.CustomerID = O.CustomerID 
      AND O.OrderID = OD.OrderID 
      AND OD.ProductID = P.ProductID
    GROUP BY ProductName;
END;

CREATE OR REPLACE
PROCEDURE CustOrdersDetails(
	p_order_id IN number,
    cur_OUT OUT PKGENTLIB_ARCHITECTURE.CURENTLIB_ARCHITECTURE)
AS
BEGIN
  OPEN cur_OUT FOR 
  	SELECT ProductName,
		    ROUND(Od.UnitPrice, 2) As UnitPrice,
		    Quantity,
		    ROUND(Discount * 100, 0) As Discount,
		    ROUND((Quantity * (1 - Discount) * Od.UnitPrice), 4) As ExtendedPrice
    FROM Products P, Order_Details Od
    WHERE Od.ProductID = P.ProductID and Od.OrderID = p_order_id;
END;

CREATE OR REPLACE
PROCEDURE EmployeeSalesByCountry(
	p_begin_date IN TIMESTAMP,
	p_end_date IN TIMESTAMP,
    cur_OUT OUT PKGENTLIB_ARCHITECTURE.CURENTLIB_ARCHITECTURE)
AS
BEGIN
  OPEN cur_OUT FOR 
  	SELECT 	Employees.Country, 
  			Employees.LastName, 
  			Employees.FirstName, 
  			Orders.ShippedDate, 
  			Orders.OrderID, 
  			Order_Subtotals.Subtotal AS SaleAmount
    FROM Employees 
    INNER JOIN 
		(Orders INNER JOIN Order_Subtotals ON Orders.OrderID = Order_Subtotals.OrderID) 
		ON Employees.EmployeeID = Orders.EmployeeID
		WHERE Orders.ShippedDate Between p_begin_date And p_end_date;
END;

CREATE OR REPLACE
PROCEDURE SalesByYear(
	p_begin_date IN TIMESTAMP,
	p_end_date IN TIMESTAMP,
    cur_OUT OUT PKGENTLIB_ARCHITECTURE.CURENTLIB_ARCHITECTURE)
AS
BEGIN
  OPEN cur_OUT FOR 
  	SELECT  Orders.ShippedDate, 
            Orders.OrderID, 
            Order_Subtotals.Subtotal, 
            TO_CHAR(ShippedDate, 'YY') AS Year
    FROM Orders INNER JOIN Order_Subtotals ON Orders.OrderID = Order_Subtotals.OrderID
    WHERE Orders.ShippedDate Between p_begin_date And p_end_date;
END;

CREATE OR REPLACE
PROCEDURE SalesByCategory(
	p_category_name IN varchar2,
	p_order_year IN varchar2,
    cur_OUT OUT PKGENTLIB_ARCHITECTURE.CURENTLIB_ARCHITECTURE)
AS
l_order_year varchar2(4);
BEGIN
  l_order_year := p_order_year;
  
	IF p_order_year != '1996' AND p_order_year != '1997' AND p_order_year != '1998' THEN
    l_order_year := '1998';
	END IF;

  OPEN cur_OUT FOR 
    	SELECT ProductName,
            ROUND(SUM(OD.Quantity * (1-OD.Discount) * OD.UnitPrice), 2) As TotalPurchase
      FROM Order_Details OD, Orders O, Products P, Categories C
      WHERE OD.OrderID = O.OrderID 
        AND OD.ProductID = P.ProductID 
        AND P.CategoryID = C.CategoryID
        AND C.CategoryName = p_category_name
        AND TO_CHAR(O.OrderDate, 'YYYY') = l_order_year           
      GROUP BY ProductName
      ORDER BY ProductName;
END;

CREATE OR REPLACE
PROCEDURE TenMostExpensiveProducts(
    cur_OUT OUT PKGENTLIB_ARCHITECTURE.CURENTLIB_ARCHITECTURE)
AS
BEGIN
  OPEN cur_OUT FOR 
  	SELECT *  FROM (
	  	SELECT Products.ProductName AS TenMostExpensiveProducts, Products.UnitPrice
		FROM Products
		ORDER BY Products.UnitPrice DESC)
  	WHERE ROWNUM <= 10;
END;
