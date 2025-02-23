using ConsoleApp2;
using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;


public class Commands
{
    
    private const string ConnectionString = "Data Source=localhost; Initial Catalog=DataBase_1; Trust Server Certificate=true;";


    void InsertDataCar(Car newCar)
    {
        var sqlQuery = "INSERT INTO Cars (Brand, Model, Year, Price) VALUES (@Brand, @Model, @Year, @Price);";
        using var connection = new SqlConnection(ConnectionString);
        connection.Execute(sqlQuery, newCar);
    }
}

public class Program()
{
    void Main()
    {
        
    }
}