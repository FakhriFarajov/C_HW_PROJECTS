using System;
using System.Collections.Generic;
using Lesson6;
using Microsoft.EntityFrameworkCore;


using var context = new AppDbContext();

context.Students.Add(new Student{Name = "John Doe"});


void AddStudentManually(string name){
    Task.Run(() =>
    {
        Student student = new Student(){Name = name};
        context.Students.Add(student);
        context.SaveChanges();
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
    }).GetAwaiter().GetResult();
}


void ShowAllStudentsManually()
{
    Task.Run(() =>
    {
        var students = context.Students.ToList();
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
        foreach (var student in students)
        {
            Console.WriteLine($"Student: {student.Name}");
        }
    }).GetAwaiter().GetResult();
}



AddStudentManually("John Doe");
ShowAllStudentsManually();

//
// async Task AddStudentAsync(string name)
// {
//     Student student = new Student(){Name = name}; 
//     context.Students.Add(student);
//     await context.SaveChangesAsync();
//     Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
// }
//
// async Task ShowAllStudentsAsync()
// {
//     var students = await context.Students.ToListAsync();
//
//     foreach (var student in students)
//     {
//         Console.WriteLine($"Student: {student.Name}");
//     }
//     Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
// }
//