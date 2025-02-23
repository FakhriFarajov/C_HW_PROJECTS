create database Database_1;
use DataBase_1;


CREATE TABLE Cars (
                      Id INT PRIMARY KEY IDENTITY(1,1),
                      Brand NVARCHAR(50) NOT NULL,
                      Model NVARCHAR(50) NOT NULL,
                      Year INT NOT NULL,
                      Price DECIMAL(18,2) NOT NULL
);

CREATE TABLE Owners (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        Name NVARCHAR(100) NOT NULL,
                        CarId INT NOT NULL,
                        FOREIGN KEY (CarId) REFERENCES Cars(Id) ON DELETE CASCADE
);


