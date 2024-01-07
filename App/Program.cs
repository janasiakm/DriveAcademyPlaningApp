using Application;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var Configuration = builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

builder.Services.AddApplication(Configuration);


builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ITimetableService, TimetableService>();

builder.Services.AddScoped<IInstructorRepository, InstructorRepositoryEF>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ITimetableRepository, TimetableRepository>();

builder.Services.AddDbContext<dbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DriveDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Timetable}/{action=List}/{id?}");

app.Run();
