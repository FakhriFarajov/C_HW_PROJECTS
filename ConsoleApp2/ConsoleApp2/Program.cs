using ConsoleApp2;
using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

public class Commands
{
    
    private const string ConnectionString = "Data Source=localhost; Initial Catalog=DataBase_1; Trust Server Certificate=true;";
    
    public void InsertDataCar(Car newCar)
    {
        var sqlQuery = "INSERT INTO Cars (Brand, Model, Year, Price) VALUES (@Brand, @Model, @Year, @Price);";
        using var connection = new SqlConnection(ConnectionString);
        connection.Execute(sqlQuery, newCar);
    }

    public void InsertDataOwner(Owner newOwner)
    {
        var SqlQuery = "INSERT INTO Owners (Name, CarId) VALUES (@Name, @CarId);";
        using var connection = new SqlConnection(ConnectionString);
        connection.Execute(SqlQuery, newOwner);
    }


    public void UpdateCarOwner(int id,string Name)
    {
        var SqlQuery = "UPDATE Owners SET Name = @NewOwner WHERE CarId = @CarId";
        using var connection = new SqlConnection(ConnectionString);
        connection.Execute(SqlQuery, new { NewOwner = Name, CarId = id });
    }

    public void DeleteCarAndOwner(int Id)
    {
        var SqlQuery = """
                       DELETE FROM Owners WHERE CarId = @CarId
                       DELETE FROM Cars WHERE Id = @CarId
                       """;
        using var connection = new SqlConnection(ConnectionString);
        connection.Execute(SqlQuery, new { CarId = Id });
    }


    public List<CarOwner> GetCarsAndOwners()
    {
        var sqlQuery = """
                       SELECT c.Id, c.Brand, c.Model, c.Year, c.Price, o.Name AS OwnerName  
                       FROM Cars c  
                       INNER JOIN Owners o ON c.Id = o.CarId  
                       """;
        using var connection = new SqlConnection(ConnectionString);
        var result = connection.Query<CarOwner>(sqlQuery).ToList();
        return result;
    }


    public List<Car> GetCars(string OwnerName)
    {
        var SqlQuery = """
                       SELECT c.Id, c.Brand, c.Model, c.Year, c.Price  
                       FROM Cars c  
                       INNER JOIN Owners o ON c.Id = o.CarId  
                       WHERE o.Name = @OwnerName;
                       """;
        using var connection = new SqlConnection(ConnectionString);
        var result = connection.Query<Car>(SqlQuery, new { Name = OwnerName }).ToList();
        return result;
    }


    public void AdditionalStuff(string brand, string model, int year, decimal price, string ownerName, string newOwnerName)
    {
        
        //Task1
        var SqlQuery = "INSERT INTO Cars (Brand, Model, Year, Price) VALUES (@Brand, @Model, @Year, @Price);";
        using var connection = new SqlConnection(ConnectionString);
        connection.Execute(SqlQuery, new {Brand = brand, Model = model, Year = year, Price = price});
        
        
        //Task2
        var SqlQuery1 = "INSERT INTO Owners (Name, CarId) VALUES (@Name, @CarId);";
        using var connection1 = new SqlConnection(ConnectionString);
        connection1.Execute(SqlQuery1, new { Name = newOwnerName, CarId = 1 }); // Any CarId taht is in the table
        
        
        //Task3
        connection.Execute(
            "UPDATE Owners SET Name = @NewOwner WHERE CarId = @CarId",
            new { NewOwner = newOwnerName, CarId = 1 } // Any CarId
        );
    }
}

public class Program()
{
    void Main()
    {
        
    }
}