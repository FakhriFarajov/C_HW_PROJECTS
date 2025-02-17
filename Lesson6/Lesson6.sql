CREATE DATABASE CarDealership;
GO
USE CarDealership;
GO

-- Таблица клиентов
CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Phone NVARCHAR(20) NOT NULL
);

-- Таблица автомобилей
CREATE TABLE Cars (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Brand NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    Year INT CHECK (Year >= 2000),
    Price DECIMAL(10,2) CHECK (Price > 0)
);

-- Таблица заказов
CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT FOREIGN KEY REFERENCES Customers(Id) ON DELETE CASCADE,
    CarId INT FOREIGN KEY REFERENCES Cars(Id) ON DELETE CASCADE,
    OrderDate DATETIME DEFAULT GETDATE()
);

-- Таблица истории цен автомобилей
CREATE TABLE CarPriceHistory (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CarId INT FOREIGN KEY REFERENCES Cars(Id) ON DELETE CASCADE,
    OldPrice DECIMAL(10,2),
    NewPrice DECIMAL(10,2),
    ChangeDate DATETIME DEFAULT GETDATE()
);

-- Таблица логов удалённых заказов
CREATE TABLE DeletedOrdersLog (
    Id INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT,
    CustomerId INT,
    CarId INT,
    OrderDate DATETIME,
    DeletedAt DATETIME DEFAULT GETDATE()
);



INSERT INTO Customers (Name, Email, Phone) VALUES
('Иван Петров', 'ivan.petrov@email.com', '123-456-789'),
('Мария Сидорова', 'maria.sidorova@email.com', '987-654-321'),
('Алексей Смирнов', 'alex.smirnov@email.com', '555-666-777');

INSERT INTO Cars (Brand, Model, Year, Price) VALUES
('Toyota', 'Camry', 2022, 30000),
('BMW', 'X5', 2023, 60000),
('Mercedes', 'C-Class', 2021, 50000);

INSERT INTO Orders (CustomerId, CarId) VALUES
(1, 1),
(2, 2),
(3, 3);


--1
create trigger RecordAdd on Cars
    for update
    as
    begin
        insert into CarPriceHistory (CarId, OldPrice, NewPrice, ChangeDate) SELECT deleted.Id, deleted.Price, inserted.Price, GETDATE() from deleted inner join inserted on deleted.Id = inserted.Id
        where deleted.Price != inserted.Price;
    end




--2
create TRIGGER CustomersDeleteCheck on Customers
    for delete
    as
    begin
        if(select count(*) from orders inner join Customers on orders.CustomerId = deleted.Id) > 0
            begin
               print(N'Student limit !');
               rollback transaction
            end
    end



--3
    create TRIGGER OrderDeleteTrigger on Orders
    for delete
    as
    begin
        insert into DeletedOrdersLog (OrderId, CustomerId, CarId, OrderDate, DeletedAt) SELECT deleted.Id, deleted.CustomerId, deleted.CarId, deleted.OrderDate, GETDATE() from deleted
    end



--4
    create TRIGGER AutoPriceChange on Cars
    for update
    as
    begin
        IF EXISTS (
            SELECT 1 FROM inserted INNER JOIN deleted ON inserted.Id = deleted.Id WHERE inserted.Year != deleted.Year)
        BEGIN
            UPDATE Cars SET Price = Price * 0.95 FROM Cars
            INNER JOIN inserted ON Cars.Id = inserted.Id
            INNER JOIN deleted ON inserted.Id = deleted.Id
            WHERE inserted.Year != deleted.Year;
        END
    end


--5
    create TRIGGER CopyCheck on Orders
    for update
    as
    begin
        if(select count(*) from Orders where Orders.CarId = inserted.CarId > 1)
        begin
            print('U cant make more than two orders to one car')
            rollback transaction
        end
    end

