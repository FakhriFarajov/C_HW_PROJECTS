using Lesson5;
using Lesson5.Context;
using Lesson5.Models;
using Microsoft.EntityFrameworkCore;




public class Program
{
    public static void Main(string[] args)
    {
        
        using var context = new ShowRoomsContext();
        context.Cars.ToList().ForEach(car => Console.WriteLine(car));
    
        //Task 7

        var CarsAndDealrers = context.Cars.Include(dealer => dealer.Dealer).ToList();


        //Task 8
        var car = context.Cars.Find(1);
        context.Entry(car).Reference(c => c.Dealer).Load();

        //Task 10
        var result = context.Cars.FromSqlRaw("select * from  Cars WHERE MAKE = {0}","Toyota").ToList();
        
        
        
        //Task 11 CRUD
        var new_Car = new Car() { Model = "Toyota", Make = "China", Year = 2025 };
        context.Cars.Add(new_Car);
        context.SaveChanges();

        context.Remove(new_Car);
        context.SaveChanges();
        
        
        var car1 = context.Cars.Find(1);
        car1.Model = "Toyota";
        context.SaveChanges();
        
        
    }
}




