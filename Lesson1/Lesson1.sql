Use Academy;

Create TABLE Groups(
    [Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(10) NOT NULL UNIQUE CHECK (LEN(Name) != 0),
    [Rating] INT NOT NULL CHECK (Rating < 5 AND Rating > 0),
    [Year] INT NOT NULL CHECK (Year > 1 AND Year < 5)
)

CREATE TABLE Departments(
    [Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Financing] MONEY NOT NULL DEFAULT 0 CHECK (LEN(Financing) > 0),
    [Name] NVARCHAR(10) NOT NULL UNIQUE CHECK (LEN(Name) != 0),
)


CREATE TABLE Faculties(
    [Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(10) NOT NULL UNIQUE CHECK (LEN(Name) != 0),
)


CREATE TABLE Teachers(
    [Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [EmploymentDate] DATE NOT NULL CHECK (EmploymentDate > '01.01.1990'),
    [Name] NVARCHAR(10) NOT NULL UNIQUE CHECK (LEN(Name) != 0),
    [Pemium] MONEY NOT NULL DEFAULT 0 CHECK (LEN(Pemium) > 0),
    [Salary] MONEY NOT NULL DEFAULT 0 CHECK (LEN(Salary) > 0),
    [Surname] NVARCHAR(10) NOT NULL UNIQUE CHECK (LEN(Surname) != 0),



)
