--13.1
GO
CREATE OR ALTER PROCEDURE GreatestOrders
@OrdYear INT,
@LineQuant INT
 AS
 SELECT DISTINCT TOP(@LineQuant) LastName + FirstName AS 'Seller', 
 max(OrdDet.UnitPrice * OrdDet.Quantity - OrdDet.Discount) AS 'Cost'
 FROM Northwind.dbo.[Order Details] AS OrdDet, Northwind.dbo.Orders AS ord, Northwind.dbo.Employees AS empl
 WHERE year(ord.OrderDate) = @OrdYear and ord.OrderID = OrdDet.OrderID
 GROUP BY (empl.LastName + empl.FirstName), ord.OrderID
 ORDER BY max(OrdDet.UnitPrice * OrdDet.Quantity - OrdDet.Discount) DESC

 --13.2
 GO
 CREATE OR ALTER PROCEDURE ShippedOrdersDiff
 @SpecifiedDelay INT
 AS
 SELECT OrderId AS 'OrderID', OrderDate AS 'OrderDate', ShippedDate AS 'ShippedDate', 
 datediff(day, OrderDate, ShippedDate) AS 'ShippedDelay', @SpecifiedDelay AS 'SpecifiedDelay' 
 FROM Northwind.dbo.Orders
 WHERE (datediff(day, OrderDate, ShippedDate) > @SpecifiedDelay) or (ShippedDate is null)

 --13.3
 GO
 CREATE OR ALTER PROCEDURE SubordinationInfo
 @EmployeeID INT
 AS
	WITH emp_cte(EmployeeID, LastName, FirstName, RecursionLevel)
	AS (SELECT emp.EmployeeID, emp.LastName, emp.FirstName, 0
	FROM Northwind.dbo.Employees AS emp
	WHERE emp.ReportsTo = @EmployeeID
	UNION ALL
	SELECT emp.EmployeeID, emp.LastName, emp.FirstName, RecursionLevel+1
	FROM Northwind.dbo.Employees AS emp
	INNER JOIN emp_cte
	ON emp.ReportsTo = emp_cte.EmployeeID)
	SELECT EmployeeID AS 'Employee ID', LastName, FirstName, RecursionLevel
	FROM emp_cte
	/*print (emp_cte.LastName + ' ' + emp_cte.FirstName + ' has boss ' + @EmployeeID)*/

--13.4
GO
CREATE OR ALTER FUNCTION dbo.IsBoss (@EmployeeID INT)
RETURNS BIT
AS
BEGIN
DECLARE @IfExists BIT;
IF EXISTS (SELECT EmployeeId FROM Northwind.dbo.Employees WHERE ReportsTo = @EmployeeID)
	SET @IfExists = 1
ELSE
	SET @IfExists = 0
RETURN @IfExists;
END