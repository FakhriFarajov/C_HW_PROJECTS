namespace Lesson1;
using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Lesson1;

public class Commands : ICommands
{
    private const string ConnectionString = "Data Source=localhost; Initial Catalog=Academy1; Trust Server Certificate=true;";

    public void Insert(Car newCar)
    {
        using var connection = new SqlConnection(ConnectionString);
        var sqlQuery = "INSERT INTO Cars (Brand, Model, Year, Price) VALUES (@Brand, @Model, @Year, @Price);";
        connection.Execute(sqlQuery, newCar);
    }

    public void Update(int id, float price)
    {
        using var connection = new SqlConnection(ConnectionString);
        var sqlQuery = "UPDATE Cars SET Price = @Price WHERE Id = @Id;";
        connection.Execute(sqlQuery, new { Id = id, Price = price });
    }

    public void Delete(int id)
    {
        using var connection = new SqlConnection(ConnectionString);
        var sqlQuery = "DELETE FROM Cars WHERE Id = @Id;";
        connection.Execute(sqlQuery, new { Id = id });
    }

    public void SelectAll()
    {
        using var connection = new SqlConnection(ConnectionString);
        var sqlQuery = "SELECT * FROM Cars";
        var cars = connection.Query<Car>(sqlQuery);

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }

    public void Filter(string brand)
    {
        using var connection = new SqlConnection(ConnectionString);
        var sqlQuery = "SELECT * FROM Cars WHERE Brand = @BrandName";
        var cars = connection.Query<Car>(sqlQuery, new { BrandName = brand });

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}