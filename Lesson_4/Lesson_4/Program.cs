using System.Runtime.InteropServices;
using Lesson_4.Data.Context;
using Lesson_4.Data.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new CarDealershipContext())
{
    #region CRUD

    // Add car
    var car = new Car { Make = "Toyota", Model = "Corolla", Year = 2022, Price = 25000 };
    context.Cars.Add(car);
    
    //Update car
    var Car1 = context.Cars.FirstOrDefault(c => c.Make == "Toyota");
    Car1.Make = "Toyota1";
    context.SaveChanges();
    
    //delete The car
    var car1 = context.Cars.Where(c => c.Make == "Toyota").Select(Car => Car);
    if (car1 != null)
    {
        context.Cars.Remove(car);
        context.SaveChanges();
    }
    
    //Check all the cars
    var Cars = context.Cars.ToList();
    foreach (var Car in Cars)
    {
        Console.WriteLine(Car);
    }
    
    #endregion
    #region Linq
    //Task 1
    var CustomerIdUser = 1;
    var Cars_Linq = context.Sales.Where(s => s.CustomerId == CustomerIdUser).Select(s => s.Car).ToList();
    foreach (var Car in Cars_Linq)
    {
        Console.WriteLine(Car);
    }
    
    
    //Task2
    var UserSaleDate = DateTime.Now;
    var Sales_Linq = context.Sales.Where(s => s.SaleDate == UserSaleDate).Select(s => s.Car).ToList();
    foreach (var Car in Sales_Linq)
    {
        Console.WriteLine(Car);
    }
    
    
    //Task3 
    var salesCountByEmployee = context.Sales
        .GroupBy(s => s.Employee)
        .Select(group => new 
        {
            EmployeeName = group.Key.FirstName, // Имя менеджера
            SalesCount = group.Count()     // Количество продаж
        })
        .ToList();
    
    #endregion    
    
    // Add Customer
    var customer = new Customer { FirstName = "Иван", LastName = "Петров", Phone = "+79001234567" };
    context.Customers.Add(customer);
    
    // Add employee
    var employee = new Employee { FirstName = "Петр", LastName = "Сидоров", Position = "Менеджер" };
    context.Employees.Add(employee);
    
    // Add sale
    var sale = new Sale { Car = car, Customer = customer, Employee = employee, SaleDate = DateTime.Now, SalePrice = 24500 };
    context.Sales.Add(sale);

    // Add history
    var service = new ServiceHistory { Car = car, ServiceDate = DateTime.Now, Description = "Плановое ТО", Cost = 150 };
    context.ServiceHistories.Add(service);

    context.SaveChanges();
    
}
