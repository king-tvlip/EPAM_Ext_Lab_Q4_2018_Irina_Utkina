-- 1.1
--������� ������, ������������ ����� 1998-05-06 ������������ � � ShipVia >= 2
SELECT OrderID, ShippedDate,ShipVia 
FROM Northwind.dbo.Orders
WHERE YEAR(ShippedDate) >= 1998 AND MONTH(ShippedDate) >= 05 AND DAY(ShippedDate) >= 06 AND ShipVia >= 2

--1.2
--������� �������������� ������. ������� ������ �� not shipped
SELECT OrderID, ShippedDate =
	CASE
	WHEN ShippedDate IS NULL 
	THEN 'Not Shipped'
	END
FROM Northwind.dbo.Orders
WHERE ShippedDate IS NULL

--1.3
--������� �������������� ������ ��� ������, ������������ ����� 1998-05-06 �� ������������
SELECT OrderID AS 'Order Number', 
ShippedDate =
	CASE
	WHEN ShippedDate IS NULL 
	THEN 'Not Shipped'
	END
FROM Northwind.dbo.Orders
WHERE (YEAR(ShippedDate) > 1998 AND MONTH(ShippedDate) > 05 AND DAY(ShippedDate) > 06) OR (YEAR(ShippedDate) > 1998) OR (ShippedDate IS NULL)

--2.1
--������� � ������� in ���������� �� USA, Canada. ����������� �� ����� � ����� ����������.
SELECT ContactName, Country 
FROM Northwind.dbo.Customers
WHERE Country IN ('USA', 'Canada')
ORDER BY ContactName, Country

--2.2
--������� ����������, �� ����������� � USA, Canada. ������� � in. ����������� �� ����� ���������
SELECT ContactName, Country 
FROM Northwind.dbo.Customers
WHERE Country NOT IN ('USA', 'Canada')
ORDER BY ContactName

--2.3
--������� ������ ���������� ����������. ������ ������ ���� ��������� ��������. ����������� �� �������� ������
--� �������� �������
SELECT DISTINCT Country 
FROM Northwind.dbo.Customers
ORDER BY Country DESC

--3.1
--������� ��� ������, ��� ������ � ��������� ������ ����� b, g � ���������� �� 3 �� 10 � �������������� between
SELECT DISTINCT OrderID 
FROM Northwind.dbo.[Order Details]
WHERE Quantity BETWEEN 3 AND 10

--3.2
--�������, ��������� between, ��� ������ � ��������� ������ ����� b, g. 
--���������, ��� � ��������� �������� Germany
PRINT N'start time'
PRINT (SYSDATETIME())
SELECT CustomerID, Country 
FROM Northwind.dbo.Customers
WHERE Country BETWEEN 'B%' AND 'H%'
ORDER BY Country
PRINT N'end time'
PRINT (SYSDATETIME())
--2019-02-10 13:17:20.1171125 -> 13:17:20.1171125

--3.3
--�������, �� ��������� between, ��� ������ � ��������� ������ ����� b, g. ����������, ����� ������ �����
--����� ����������������: 3.1 ��� 3.2
PRINT N'start time'
PRINT (SYSDATETIME())
SELECT CustomerID, Country 
FROM Northwind.dbo.Customers
WHERE Country > 'b%' AND Country < 'h%'
ORDER BY Country
PRINT N'end time '
PRINT (SYSDATETIME())
--2019-02-10 13:17:20.1171125 -> 13:17:20.1181138

--4.1
--������� ��������, � ������� ����������� chocolate. ����� ���� �������� ����� c � �������� �����.
SELECT ProductName 
FROM Northwind.dbo.Products
WHERE ProductName LIKE '%cho_olade%'

--5.1
--������� ����� ���� ������� � ������ ������ � ������� Totals.
SELECT ROUND(SUM(UnitPrice - Discount), 2)  AS Totals FROM Northwind.dbo.[Order Details]

--5.2
--����� ���������� �������������� �������. �� ������������ where, group by.
SELECT COUNT(CASE ShippedDate 
			 WHEN NULL THEN 1 
				ELSE 1 
			 END) - COUNT(ShippedDate) 
FROM Northwind.dbo.Orders

--5.3
--����� ���������� ��������� �����������, ��������� ������, �� ��������� group by, where.
SELECT COUNT(DISTINCT CustomerID) 
FROM Northwind.dbo.Orders

--6.1
--�� ������� Orders ����� ���������� ������� � ������������ �� �����. �������� ����������� ������.
SELECT DISTINCT YEAR(OrderDate) AS 'Year', COUNT(YEAR(OrderDate)) AS 'Total' 
FROM Northwind.dbo.Orders
GROUP BY YEAR(OrderDate)

/* check query
select count(OrderDate) from Northwind.dbo.Orders
*/

--6.2
--�� ������� Orders ����� ���������� �������, c�������� ������ ���������.����� �������� ������ ������ 
--������������ ����������� �� EmployeeID. ���������� ������� ������ ���� ����������� �� �������� ���������� �������.
SELECT (emp.FirstName + ' ' + emp.LastName) AS 'Seller', COUNT(ord.EmployeeID) AS 'Amount'
FROM Northwind.dbo.Employees AS emp, Northwind.dbo.Orders AS ord
GROUP BY (emp.FirstName + ' ' + emp.LastName)
ORDER BY COUNT(ord.EmployeeID) DESC

--6.3
--����� ���������� �������, ��������� � 1998 ����, ������� ���������� ��� ������� ��������. ������������
--����������� �������� ��� ��������� group by. ������� ����������� �� ID �������� � ����������. �����������
--���������� �� ��������, ���������� � �������� ���������� �������. �������� ������� ���������� � ��������.
SELECT ISNULL((SELECT Employees.LastName + ' ' + Employees.FirstName
FROM Northwind.dbo.Employees
WHERE Employees.EmployeeID = ord.EmployeeID), 'ALL') AS 'Seller',
ISNULL((SELECT Customers.ContactName 
FROM Northwind.dbo.Customers
WHERE Customers.CustomerID = ord.CustomerID), 'ALL') AS 'Customer',
COUNT(ord.OrderID) AS 'Amount'
FROM Northwind.dbo.Orders AS ord
WHERE YEAR(ord.OrderDate) = N'1998'
GROUP BY CUBE (ord.EmployeeID, ord.CustomerID)
ORDER BY COUNT(ord.OrderID) DESC

--6.4
--����� ����������� � ���������, ������� ����� � ����� ������. ���� � ������ ����� ������ ���� 
--��� ��������� ��������� ��� ������ ���� ��� ��������� �����������, �� ���������� � ����� �����������
--� ��������� �������� �������� � �������������� �����. �� ������������ ����������� JOIN.
--������������� ���������� ������� �� ������� �City� � �� �Person�.
SELECT cust.ContactName AS 'Person', cust.City AS 'City', 'Customer' AS 'Type'
FROM Northwind.dbo.Customers AS cust, Northwind.dbo.Employees AS emp
WHERE cust.City = emp.City
GROUP BY cust.City, cust.ContactName
UNION
SELECT emp.LastName AS 'Person', emp.City AS 'City', 'Seller' AS 'Type'
FROM Northwind.dbo.Employees AS emp, Northwind.dbo.Customers AS cust
WHERE emp.City = cust.City
GROUP BY emp.City, emp.LastName

--6.5
--����� ���� �����������, ������� ����� � ����� ������. � ������� ������������ ���������� ������� Customers
--c ����� - ��������������. ��������� ������� CustomerID � City. ������ �� ������ �����������
--����������� ������. ��� �������� �������� ������, ������� ����������� ������, ������� ����������� 
--����� ������ ���� � ������� Customers.
SELECT cust.City, cust.CustomerID
FROM Northwind.dbo.Customers AS cust INNER JOIN Northwind.dbo.Customers AS cus 
ON cust.City = cus.City AND cust.CustomerID <> cus.CustomerID
WHERE cust.City = cus.City

--6.6
--�� ������� Employees ����� ��� ������� �������� ��� ������������, �.�. ���� �� ������ �������. ��� ��
--�������� �������� � �������������� �����?
SELECT emp.LastName AS 'Last Name', bss.LastName AS 'Boss'
FROM Northwind.dbo.Employees AS emp INNER JOIN Northwind.dbo.Employees AS bss
ON emp.ReportsTo = bss.EmployeeID
WHERE emp.ReportsTo = bss.EmployeeID
--�� ����� ��������� ��������, ������� ������ ������ ���� ���� � ��, � ������� � ReportsTo ������ null

--7
--���������� ���������, ������� ����������� ������ &#39;Western&#39; (������� Region). ������ ������ 
--������������ JOIN � ����������� FROM.
SELECT emp.LastName AS [Last Name], ter.TerritoryDescription AS [Territory Description]
FROM (((Northwind.dbo.Employees AS emp inner join Northwind.dbo.EmployeeTerritories AS EmpTer ON emp.EmployeeID = EmpTer.EmployeeID)
INNER JOIN Northwind.dbo.Territories AS ter ON EmpTer.TerritoryID = ter.TerritoryID)
INNER JOIN Northwind.dbo.Region AS reg ON ter.RegionID = reg.RegionID)
WHERE reg.RegionDescription = 'Western'

--8
--��������� � ����������� ������� ����� ���� ���������� �� ������� Customers � ��������� ����������
--�� ������� �� ������� Orders. ������� �� ��������, ��� � ��������� ���������� ��� �������,
--�� ��� ����� ������ ���� �������� � ����������� �������. ����������� ���������� ������� 
--�� ����������� ���������� �������.
SELECT cust.ContactName AS 'Name', count(ord.OrderID) AS 'OrdersAmount'
FROM Northwind.dbo.Customers AS cust LEFT OUTER JOIN Northwind.dbo.Orders AS ord
ON cust.CustomerID = ord.CustomerID
GROUP BY cust.ContactName
ORDER BY COUNT(ord.OrderID)

--9
--��������� ���� ����������� ������� CompanyName � ������� Suppliers, � ������� ��� ���� �� ������ ��������
-- �� ������ (UnitsInStock � ������� Products ����� 0). ������������ ��������� SELECT ��� ����� �������
--� �������������� ��������� IN. ����� �� ������������ ������ ��������� IN �������� =?
SELECT CompanyName 
FROM (SELECT CompanyName, UnitsInStock 
	FROM (Northwind.dbo.Suppliers AS sup 
		JOIN Northwind.dbo.Products AS prod
		ON sup.SupplierID = prod.SupplierID) 
	WHERE UnitsInStock IN (0)) AS FT
--��, ����� ������������ = ������ in, ��� ��� in �������� � ������� ��������( ����� ������������ 1), � =
--�������� �������� ����������.

--10
--��������� ���� ���������, ������� ����� ����� 150 �������. ������������ ��������� ��������������� SELECT.
SELECT LastName FROM Northwind.dbo.Employees
WHERE (SELECT COUNT(ord.EmployeeID) 
FROM Northwind.dbo.Employees AS empl 
JOIN Northwind.dbo.Orders AS ord ON empl.EmployeeID = ord.EmployeeID) > 150

--11
--��������� ���� ���������� (������� Customers), ������� �� ����� �� ������ ������ (��������� �� ������� Orders). 
--������������ ��������������� SELECT � �������� EXISTS.
SELECT ContactName 
FROM Northwind.dbo.Customers
WHERE EXISTS (SELECT ord.CustomerID  
	FROM Northwind.dbo.Orders AS ord 
	WHERE ord.OrderDate IS NULL)

--12
--������� ������ ������ ��� ���� ��������, � ������� ���������� ������� Employees (������� LastName )
-- �� ���� �������. ���������� ������ ������ ���� ������������ �� �����������.
SELECT DISTINCT LOWER(SUBSTRING(LastName, 1, 1)) AS 'Alphabetical order' 
FROM Northwind.dbo.Employees
WHERE LOWER(SUBSTRING(LastName, 1, 1)) BETWEEN 'a' AND 'z' OR LOWER(SUBSTRING(LastName, 1, 1)) = 'z'
ORDER BY LOWER(SUBSTRING(LastName, 1, 1)) DESC

--13.1
EXECUTE dbo.GreatestOrders 1998, 7;
GO
--13.2
EXECUTE dbo.ShippedOrdersDiff 35;
GO

--13.3
EXECUTE dbo.SubordinationInfo 2;
GO

--13.4
DECLARE @retVar BIT;
EXEC @retVar = dbo.IsBoss 1
SELECT @retVar

