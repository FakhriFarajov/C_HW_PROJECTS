using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Lesson1;
using Microsoft.Identity.Client;


class Program
{
    static void Main()
    {
        string connectionString = "Data Source=localhost; Initial Catalog=Auth_3; Trust Server Certificate=true;";
        var newCar = new Car
        {
            Brand = "Toyota",
            Model = "Camry",
            Year = 2022,
            Price = 15900
        };
        
    }
}