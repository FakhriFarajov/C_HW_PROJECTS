use [master];
go

if db_id('Academy') is not null
begin
	drop database [Academy];
end
go

create database [Academy];
go

use [Academy];
go

create table [Curators]
(
	[Id] int not null identity(1, 1) primary key,
	[Name] nvarchar(max) not null check ([Name] <> N''),
	[Surname] nvarchar(max) not null check ([Surname] <> N'')
);
go

create table [Departments]
(
	[Id] int not null identity(1, 1) primary key,
	[Financing] money not null check ([Financing] >= 0.0) default 0.0,
	[Name] nvarchar(100) not null unique check ([Name] <> N''),
	[FacultyId] int not null
);
go

create table [Faculties]
(
	[Id] int not null identity(1, 1) primary key,
	[Financing] money not null check ([Financing] >= 0.0) default 0.0,
	[Name] nvarchar(100) not null unique check ([Name] <> N'')
);
go

create table [Groups]
(
	[Id] int not null identity(1, 1) primary key,
	[Name] nvarchar(100) not null unique check ([Name] <> N''),
	[Year] int not null check ([Year] between 1 and 5),
	[DepartmentId] int not null
);
go

create table [GroupsCurators]
(
	[Id] int not null identity(1, 1) primary key,
	[CuratorId] int not null,
	[GroupId] int not null
);
go

create table [GroupsLectures]
(
	[Id] int not null identity(1, 1) primary key,
	[GroupId] int not null,
	[LectureId] int not null
);
go

create table [Lectures]
(
	[Id] int not null identity(1, 1) primary key,
	[LectureRoom] nvarchar(max) not null check ([LectureRoom] <> N''),
	[SubjectId] int not null,
	[TeacherId] int not null
);
go

create table [Subjects]
(
	[Id] int not null identity(1, 1) primary key,
	[Name] nvarchar(100) not null unique check ([Name] <> N'')
);
go

create table [Teachers]
(
	[Id] int not null identity(1, 1) primary key,
	[Name] nvarchar(max) not null check ([Name] <> N''),
	[Salary] money not null check ([Salary] > 0.0),
	[Surname] nvarchar(max) not null check ([Surname] <> N'')
);
go

alter table [Departments]
add foreign key ([FacultyId]) references [Faculties]([Id]);
go

alter table [Groups]
add foreign key ([DepartmentId]) references [Departments]([Id]);
go

alter table [GroupsCurators]
add foreign key ([CuratorId]) references [Curators]([Id]);
go

alter table [GroupsCurators]
add foreign key ([GroupId]) references [Groups]([Id]);
go

alter table [GroupsLectures]
add foreign key ([GroupId]) references [Groups]([Id]);
go

alter table [GroupsLectures]
add foreign key ([LectureId]) references [Lectures]([Id]);
go

alter table [Lectures]
add foreign key ([SubjectId]) references [Subjects]([Id]);
go

alter table [Lectures]
add foreign key ([TeacherId]) references [Teachers]([Id]);
go




--1
SELECT * FROM Teachers CROSS JOIN Groups

--2

use [master];
go

if db_id('Academy') is not null
begin
	drop database [Academy];
end
go

create database [Academy];
go

use [Academy];
go

create table [Curators]
(
	[Id] int not null identity(1, 1) primary key,
	[Name] nvarchar(max) not null check ([Name] <> N''),
	[Surname] nvarchar(max) not null check ([Surname] <> N'')
);
go

create table [Departments]
(
	[Id] int not null identity(1, 1) primary key,
	[Financing] money not null check ([Financing] >= 0.0) default 0.0,
	[Name] nvarchar(100) not null unique check ([Name] <> N''),
	[FacultyId] int not null
);
go

create table [Faculties]
(
	[Id] int not null identity(1, 1) primary key,
	[Financing] money not null check ([Financing] >= 0.0) default 0.0,
	[Name] nvarchar(100) not null unique check ([Name] <> N'')
);
go

create table [Groups]
(
	[Id] int not null identity(1, 1) primary key,
	[Name] nvarchar(100) not null unique check ([Name] <> N''),
	[Year] int not null check ([Year] between 1 and 5),
	[DepartmentId] int not null
);
go

create table [GroupsCurators]
(
	[Id] int not null identity(1, 1) primary key,
	[CuratorId] int not null,
	[GroupId] int not null
);
go

create table [GroupsLectures]
(
	[Id] int not null identity(1, 1) primary key,
	[GroupId] int not null,
	[LectureId] int not null
);
go

create table [Lectures]
(
	[Id] int not null identity(1, 1) primary key,
	[LectureRoom] nvarchar(max) not null check ([LectureRoom] <> N''),
	[SubjectId] int not null,
	[TeacherId] int not null
);
go

create table [Subjects]
(
	[Id] int not null identity(1, 1) primary key,
	[Name] nvarchar(100) not null unique check ([Name] <> N'')
);
go

create table [Teachers]
(
	[Id] int not null identity(1, 1) primary key,
	[Name] nvarchar(max) not null check ([Name] <> N''),
	[Salary] money not null check ([Salary] > 0.0),
	[Surname] nvarchar(max) not null check ([Surname] <> N'')
);
go

alter table [Departments]
add foreign key ([FacultyId]) references [Faculties]([Id]);
go

alter table [Groups]
add foreign key ([DepartmentId]) references [Departments]([Id]);
go

alter table [GroupsCurators]
add foreign key ([CuratorId]) references [Curators]([Id]);
go

alter table [GroupsCurators]
add foreign key ([GroupId]) references [Groups]([Id]);
go

alter table [GroupsLectures]
add foreign key ([GroupId]) references [Groups]([Id]);
go

alter table [GroupsLectures]
add foreign key ([LectureId]) references [Lectures]([Id]);
go

alter table [Lectures]
add foreign key ([SubjectId]) references [Subjects]([Id]);
go

alter table [Lectures]
add foreign key ([TeacherId]) references [Teachers]([Id]);
go




--1
SELECT * FROM Teachers CROSS JOIN Groups

--2
SELECT
    Faculties.Name AS FacultyName FROM Faculties
inner join
    Departments ON Faculties.Id = Departments.FacultyId
WHERE
    Departments.Financing > Faculties.Financing;


--3
SELECT Curators.Surname AS CuratorSurname, Groups.Name AS GroupName FROM GroupsCurators
inner join Curators ON GroupsCurators.CuratorId = Curators.Id
inner join Groups ON GroupsCurators.GroupId = Groups.Id;


--4
SELECT Teachers.Name, Teachers.Surname from Teachers
inner join Lectures on Lectures.TeacherId = Teachers.Id
inner join GroupsLectures on GroupsLectures.LectureId = Lectures.Id
inner join Groups on GroupsLectures.GroupId = Groups.Id
where Groups.Name = 'P107'


--5
SELECT Teachers.Surname, Faculties.Name from Teachers
inner join Lectures on Lectures.TeacherId = Teachers.Id
inner join GroupsLectures on GroupsLectures.LectureId = Lectures.Id
inner join Groups on GroupsLectures.GroupId = Groups.Id
inner join Departments on Departments.Id = Groups.DepartmentId
inner join Faculties on Departments.FacultyId = Faculties.Id


--6
SELECT Departments.Name, Groups.Name from Departments
inner join Groups on DepartmentId = Groups.DepartmentId

--7
SELECT Subjects.Name AS SubjectName FROM Lectures
INNER JOIN Teachers ON Lectures.TeacherId = Teachers.Id
INNER JOIN Subjects ON Lectures.SubjectId = Subjects.Id
WHERE Teachers.Name = 'Samantha' AND Teachers.Surname = 'Adams';


--8
select Departments.Name from Departments
inner join Groups on Groups.DepartmentId = Departments.Id
inner join GroupsLectures on GroupsLectures.GroupId = Groups.Id
inner join Lectures on GroupsLectures.LectureId = Lectures.Id
inner join Subjects on Lectures.SubjectId = Subjects.Id
where Subjects.Name = 'DataBase theory'


--9
SELECT Groups.Name from Groups
inner join Departments on Departments.Id = Groups.DepartmentId
inner join Faculties on Faculties.Id = Departments.FacultyId
where Faculties.Name = 'Computer Science'

--10
select Groups.Name ,Faculties.Name from Groups
inner join Departments on Departments.Id = Groups.DepartmentId
inner join Faculties on Departments.FacultyId = Faculties.Id
where Groups.Year = 5

--11
SELECT
    Teachers.Name + ' ' + Teachers.Surname AS TeacherFullName,
    Subjects.Name AS SubjectName,
    Groups.Name AS GroupName
FROM
    Lectures
JOIN
    Teachers ON Lectures.TeacherId = Teachers.Id
JOIN
    Subjects ON Lectures.SubjectId = Subjects.Id
JOIN
    GroupsLectures ON Lectures.Id = GroupsLectures.LectureId
JOIN
    Groups ON GroupsLectures.GroupId = Groups.Id
WHERE
    Lectures.LectureRoom = 'B103';
