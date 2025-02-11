
--CUSTOMERS

CREATE TABLE Customers (
    [CustomerID] INT PRIMARY KEY,
    [FirstName] VARCHAR(50),
    [LastName] VARCHAR(50),
    [Email] VARCHAR(100)
);


--1
INSERT INTO Customers (CustomerID,FirstName, LastName, Email)
VALUES (1,N'John', N'Smith', N'email@gamil.com')

--2
UPDATE Customers SET Email = 'gmail@email.com' where CustomerID = 1

--3
DELETE FROM Customers WHERE CustomerID = 5

--4
SELECT * FROM Customers ORDER BY LastName

--5
INSERT INTO Customers (CustomerID,FirstName, LastName, Email)
VALUES (2,N'Bob', N'John', N'email_john@gamil.com')

INSERT INTO Customers (CustomerID,FirstName, LastName, Email)
VALUES (3,N'Joshua', N'Patrick', N'email_Joshua@gamil.com')

INSERT INTO Customers (CustomerID,FirstName, LastName, Email)
VALUES (4,N'Patrishia', N'Patrick', N'email_Patrick@gamil.com')





--ORDERS
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);



--6
INSERT INTO Orders (OrderID,CustomerID,OrderDate, TotalAmount) VALUES (1,1,'2025-1-3', 20.1)

--7
UPDATE Orders SET TotalAmount = 10.1 WHERE OrderID = 2

--8
DELETE FROM Orders WHERE OrderID = 3

--9
SELECT * FROM Orders WHERE CustomerID = 1

--10
SELECT * FROM Orders WHERE YEAR(OrderDate) = 2023



--Products
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Price DECIMAL(10, 2)
);

--11
INSERT INTO Products (ProductID,ProductName, Price) VALUES (1,'TOMATOES',12.12)
INSERT INTO Products (ProductID,ProductName, Price) VALUES (2,'TOMA',16.12)

select * from Products

--12
UPDATE Products SET Price = 10.1 WHERE ProductID = 2

--13
DELETE FROM Products WHERE ProductID = 3

--14

SELECT * FROM Products WHERE Price > 100

--15
SELECT * FROM Products WHERE Price <= 50


--OrderDetails

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    Price DECIMAL(10, 2),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

--16
INSERT INTO OrderDetails (OrderDetailID,Quantity, Price) VALUES (1,20,20.1)

--17

UPDATE OrderDetails SET Quantity = 10 WHERE OrderDetailID = 2

--18
DELETE FROM OrderDetails WHERE OrderDetailID = 2

--19

SELECT * FROM OrderDetails WHERE OrderID = 1

--20
SELECT * FROM OrderDetails WHERE ProductID = 2


--TASKS



--21

SELECT Orders.OrderDate AS 'OrderDate', Orders.TotalAmount as 'TotalAmount', C.FirstName, C.LastName from Orders
inner join Customers C on Orders.CustomerID = C.CustomerID


--22
SELECT P.ProductName AS 'ProductName' , P.Price as 'Price' , OrderDetails.Quantity from OrderDetails
inner join Orders O on O.OrderID = OrderDetails.OrderID
inner join Customers C on O.CustomerID = C.CustomerID
inner join Products P on OrderDetails.ProductID = P.ProductID

--23
SELECT Orders.OrderID, Customers.FirstName, Customers.LastName
FROM Orders
LEFT JOIN Customers ON Orders.CustomerID = Customers.CustomerID;

--24
SELECT Orders.OrderID, Products.ProductName
FROM OrderDetails
INNER JOIN Orders ON OrderDetails.OrderID = Orders.OrderID
INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID;



--25
SELECT *, O.* FROM Customers
LEFT JOIN Orders O on Customers.CustomerID = O.CustomerID


--26

SELECT Products.ProductName, OrderDetails.*
FROM Products
RIGHT JOIN OrderDetails ON Products.ProductID = OrderDetails.ProductID;

--27
SELECT *, P.ProductName FROM OrderDetails
inner join Orders O on O.OrderID = OrderDetails.OrderID
inner join Customers C on O.CustomerID = C.CustomerID
inner join Products P on OrderDetails.ProductID = P.ProductID


--28
SELECT C.FirstName as 'FirstName',  O.*, P.Price as 'ProductPrice' FROM OrderDetails
inner join Orders O on O.OrderID = OrderDetails.OrderID
inner join Customers C on O.CustomerID = C.CustomerID
inner join Products P on OrderDetails.ProductID = P.ProductID


--29
SELECT Customers.FirstName from Customers
where CustomerID in (select CustomerID from Orders where TotalAmount > 500)

--30
SELECT Products.* FROM Products
INNER JOIN OrderDetails OD ON Products.ProductID = OD.ProductID
WHERE Products.ProductID IN (
    SELECT ProductID
    FROM OrderDetails
    GROUP BY ProductID
    HAVING SUM(Quantity) > 10
);


--31
select (select(SUM(TotalAmount)) from Orders where Customers.CustomerID = Orders.CustomerID) as 'Total' from Customers


--32
select Products.Price from Products
where (select AVG(Price) from Products) < Products.Price


--33
SELECT Orders.OrderID, Customers.FirstName, Products.ProductName
FROM Orders
INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID
INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID;


--34
SELECT *, Orders.OrderDate,Orders.TotalAmount,Products.ProductName, Products.Price, OrderDetails.Quantity from Customers
INNER JOIN Orders on Customers.CustomerID = Orders.CustomerID
INNER JOIN OrderDetails on Orders.OrderID = OrderDetails.OrderID
INNER JOIN Products on Products.ProductID = OrderDetails.ProductID


--35
SELECT Customers.FirstName, SUM(OrderDetails.Price * OrderDetails.Quantity) AS TotalSpent
FROM Customers
INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID
INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
GROUP BY Customers.FirstName;


--36
SELECT O.OrderID, SUM(OD.Quantity * OD.Price) AS TotalCost FROM Orders O
INNER JOIN OrderDetails OD ON O.OrderID = OD.OrderID
GROUP BY O.OrderID
HAVING SUM(OD.Quantity * OD.Price) > 1000;


--37
SELECT * FROM Customers
where (select SUM(TotalAmount) from Orders where Orders.CustomerID = Customers.CustomerID) > (select AVG(TotalAmount) from Orders)



--38
SELECT Customers.CustomerID , Count(Orders.OrderId)from Customers
LEFT JOIN Orders on Customers.CustomerID = Orders.CustomerID
GROUP BY Customers.CustomerID



--39

SELECT SUM(Quantity) as 'TotalQuantity' from OrderDetails
INNER JOIN Products P on P.ProductID = OrderDetails.ProductID
having (select SUM(Quantity) from OrderDetails) > 3



--40
SELECT Customers.CustomerID, SUM(OrderDetails.Quantity) from Customers
INNER JOIN Orders on Customers.CustomerID = Orders.CustomerID
INNER JOIN OrderDetails on Orders.OrderID = OrderDetails.OrderId
GROUP BY Customers.CustomerID


