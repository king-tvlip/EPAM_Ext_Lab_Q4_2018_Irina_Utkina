-- 1.1
--выбрать заказы, доставленные после 1998-05-06 включительно и с ShipVia >= 2
SELECT OrderID, ShippedDate,ShipVia 
FROM Northwind.dbo.Orders
WHERE YEAR(ShippedDate) >= 1998 AND MONTH(ShippedDate) >= 05 AND DAY(ShippedDate) >= 06 AND ShipVia >= 2

--1.2
--выбрать недоставленные заказы. сделать замену на not shipped
SELECT OrderID, ShippedDate =
	CASE
	WHEN ShippedDate IS NULL 
	THEN 'Not Shipped'
	END
FROM Northwind.dbo.Orders
WHERE ShippedDate IS NULL

--1.3
--выбрать недоставленные заказы или заказы, доставленные после 1998-05-06 не включительно
SELECT OrderID AS 'Order Number', 
ShippedDate =
	CASE
	WHEN ShippedDate IS NULL 
	THEN 'Not Shipped'
	END
FROM Northwind.dbo.Orders
WHERE (YEAR(ShippedDate) > 1998 AND MONTH(ShippedDate) > 05 AND DAY(ShippedDate) > 06) OR (YEAR(ShippedDate) > 1998) OR (ShippedDate IS NULL)

--2.1
--выбрать с помощью in заказчиков из USA, Canada. упорядочить по имени и месту проживания.
SELECT ContactName, Country 
FROM Northwind.dbo.Customers
WHERE Country IN ('USA', 'Canada')
ORDER BY ContactName, Country

--2.2
--выбрать заказчиков, не проживающих в USA, Canada. сделать с in. упорядочить по имени заказчика
SELECT ContactName, Country 
FROM Northwind.dbo.Customers
WHERE Country NOT IN ('USA', 'Canada')
ORDER BY ContactName

--2.3
--выбрать страны проживания заказчиков. страны должны быть упомянуты единожды. упорядочить по названию страны
--в обратном порядке
SELECT DISTINCT Country 
FROM Northwind.dbo.Customers
ORDER BY Country DESC

--3.1
--выбрать все заказы, где страны с начальной буквой между b, g и количество от 3 до 10 с использованием between
SELECT DISTINCT OrderID 
FROM Northwind.dbo.[Order Details]
WHERE Quantity BETWEEN 3 AND 10

--3.2
--выбрать, используя between, все страны с начальной буквой между b, g. 
--проверить, что в результат попадает Germany
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
--выбрать, не используя between, все страны с начальной буквой между b, g. определить, какой запрос будет
--более предпочтительным: 3.1 или 3.2
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
--выбрать продукты, в которых встречается chocolate. может быть изменена буква c в середине слова.
SELECT ProductName 
FROM Northwind.dbo.Products
WHERE ProductName LIKE '%cho_olade%'

--5.1
--вывести сумму всех заказов с учетом скидки в колонку Totals.
SELECT ROUND(SUM(UnitPrice - Discount), 2)  AS Totals FROM Northwind.dbo.[Order Details]

--5.2
--найти количество недоставленных заказов. не использовать where, group by.
SELECT COUNT(CASE ShippedDate 
			 WHEN NULL THEN 1 
				ELSE 1 
			 END) - COUNT(ShippedDate) 
FROM Northwind.dbo.Orders

--5.3
--найти количество различных покупателей, сделавших заказы, не используя group by, where.
SELECT COUNT(DISTINCT CustomerID) 
FROM Northwind.dbo.Orders

--6.1
--По таблице Orders найти количество заказов с группировкой по годам. написать проверочный запрос.
SELECT DISTINCT YEAR(OrderDate) AS 'Year', COUNT(YEAR(OrderDate)) AS 'Total' 
FROM Northwind.dbo.Orders
GROUP BY YEAR(OrderDate)

/* check query
select count(OrderDate) from Northwind.dbo.Orders
*/

--6.2
--По таблице Orders найти количество заказов, cделанных каждым продавцом.Также основной запрос должен 
--использовать группировку по EmployeeID. Результаты запроса должны быть упорядочены по убыванию количества заказов.
SELECT (emp.FirstName + ' ' + emp.LastName) AS 'Seller', COUNT(ord.EmployeeID) AS 'Amount'
FROM Northwind.dbo.Employees AS emp, Northwind.dbo.Orders AS ord
GROUP BY (emp.FirstName + ' ' + emp.LastName)
ORDER BY COUNT(ord.EmployeeID) DESC

--6.3
--Найти количество заказов, сделанных в 1998 году, каждого покупателя для каждого продавца. Использовать
--специальный оператор для выражения group by. Сделать группировки по ID продавца и покупателя. Упорядочить
--результаты по продавцу, покупателю и убыванию количества заказов. Добавить сводную информацию о продажах.
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
--Найти покупателей и продавцов, которые живут в одном городе. Если в городе живут только один 
--или несколько продавцов или только один или несколько покупателей, то информация о таких покупателях
--и продавцах недолжна попадать в результирующий набор. Не использовать конструкцию JOIN.
--Отсортировать результаты запроса по колонке ‘City’ и по ‘Person’.
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
--Найти всех покупателей, которые живут в одном городе. В запросе использовать соединение таблицы Customers
--c собой - самосоединение. Высветить колонки CustomerID и City. Запрос не должен высвечивать
--дублируемые записи. Для проверки написать запрос, который высвечивает города, которые встречаются 
--более одного раза в таблице Customers.
SELECT cust.City, cust.CustomerID
FROM Northwind.dbo.Customers AS cust INNER JOIN Northwind.dbo.Customers AS cus 
ON cust.City = cus.City AND cust.CustomerID <> cus.CustomerID
WHERE cust.City = cus.City

--6.6
--По таблице Employees найти для каждого продавца его руководителя, т.е. кому он делает репорты. Все ли
--продавцы попадают в результирующий набор?
SELECT emp.LastName AS 'Last Name', bss.LastName AS 'Boss'
FROM Northwind.dbo.Employees AS emp INNER JOIN Northwind.dbo.Employees AS bss
ON emp.ReportsTo = bss.EmployeeID
WHERE emp.ReportsTo = bss.EmployeeID
--не будут высвечены продавцы, которые делают отчеты сами себе и те, у которых в ReportsTo указан null

--7
--Определить продавцов, которые обслуживают регион &#39;Western&#39; (таблица Region). Запрос должен 
--использовать JOIN в предложении FROM.
SELECT emp.LastName AS [Last Name], ter.TerritoryDescription AS [Territory Description]
FROM (((Northwind.dbo.Employees AS emp inner join Northwind.dbo.EmployeeTerritories AS EmpTer ON emp.EmployeeID = EmpTer.EmployeeID)
INNER JOIN Northwind.dbo.Territories AS ter ON EmpTer.TerritoryID = ter.TerritoryID)
INNER JOIN Northwind.dbo.Region AS reg ON ter.RegionID = reg.RegionID)
WHERE reg.RegionDescription = 'Western'

--8
--Высветить в результатах запроса имена всех заказчиков из таблицы Customers и суммарное количество
--их заказов из таблицы Orders. Принять во внимание, что у некоторых заказчиков нет заказов,
--но они также должны быть выведены в результатах запроса. Упорядочить результаты запроса 
--по возрастанию количества заказов.
SELECT cust.ContactName AS 'Name', count(ord.OrderID) AS 'OrdersAmount'
FROM Northwind.dbo.Customers AS cust LEFT OUTER JOIN Northwind.dbo.Orders AS ord
ON cust.CustomerID = ord.CustomerID
GROUP BY cust.ContactName
ORDER BY COUNT(ord.OrderID)

--9
--Высветить всех поставщиков колонка CompanyName в таблице Suppliers, у которых нет хотя бы одного продукта
-- на складе (UnitsInStock в таблице Products равно 0). Использовать вложенный SELECT для этого запроса
--с использованием оператора IN. Можно ли использовать вместо оператора IN оператор =?
SELECT CompanyName 
FROM (SELECT CompanyName, UnitsInStock 
	FROM (Northwind.dbo.Suppliers AS sup 
		JOIN Northwind.dbo.Products AS prod
		ON sup.SupplierID = prod.SupplierID) 
	WHERE UnitsInStock IN (0)) AS FT
--да, можно использовать = вместо in, так как in работает с набором значений( набор размерностью 1), а =
--является бинарным оператором.

--10
--Высветить всех продавцов, которые имеют более 150 заказов. Использовать вложенный коррелированный SELECT.
SELECT LastName FROM Northwind.dbo.Employees
WHERE (SELECT COUNT(ord.EmployeeID) 
FROM Northwind.dbo.Employees AS empl 
JOIN Northwind.dbo.Orders AS ord ON empl.EmployeeID = ord.EmployeeID) > 150

--11
--Высветить всех заказчиков (таблица Customers), которые не имеют ни одного заказа (подзапрос по таблице Orders). 
--Использовать коррелированный SELECT и оператор EXISTS.
SELECT ContactName 
FROM Northwind.dbo.Customers
WHERE EXISTS (SELECT ord.CustomerID  
	FROM Northwind.dbo.Orders AS ord 
	WHERE ord.OrderDate IS NULL)

--12
--Вывести список только тех букв алфавита, с которых начинаются фамилии Employees (колонка LastName )
-- из этой таблицы. Алфавитный список должен быть отсортирован по возрастанию.
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

