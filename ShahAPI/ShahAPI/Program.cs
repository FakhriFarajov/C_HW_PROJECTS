using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ShahAPIDataBase.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<ShahContext>(ops =>
    ops.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.MapScalarApiReference();

app.Run();

