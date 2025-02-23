create table Cars(
    [Id] int primary key identity (1,1),
    [Brand] nvarchar(50),
    [Model] nvarchar(50),
    [Year] int,
    [Price] decimal(18,2),
)