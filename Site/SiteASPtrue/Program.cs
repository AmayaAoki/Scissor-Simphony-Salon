
using SiteASP.Interfaces;
using Microsoft.Extensions.Configuration;
using SiteASP.Data;
using SiteASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using SiteASP.Data.Repository;
using Microsoft.Extensions.Logging;


//////////////////////////////////////////////////////////////////////////////SERVICES.cs
///
/// 
/// 
// public Startup

var builder = WebApplication.CreateBuilder(args);


// Add dbsettings.json to the configuration
builder.Configuration.AddJsonFile("dbsettings.json");


// Use the configuration that's automatically set up
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
////////////////////////////////////////////////////////////////////////////////////////////////////////// public void ConfigureServices


// Add database
builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(connectionString));

// Add session support
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddTransient<IAllServices, ServiceRepository>();
builder.Services.AddTransient<IServicesCategory, CategoryRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IAllEmployee, EmployeeRepository>();
builder.Services.AddTransient<IAllAppointments, AppointmentsRepository>();
builder.Services.AddTransient<IAllReviews, ReviewsRepository>();

builder.Services.AddControllersWithViews();// Добавляем MVC сервис
//builder.Services.AddMvc();
builder.Services.AddAuthorization();

// Включаем использование сессий
builder.Services.AddSession();

//////////////////////////////////////////////////////////////////////////////////////////////////////////  public void Configure
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

// Включаем использование сессий
app.UseSession();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "services",
    pattern: "services",
    defaults: new { controller = "Services", action = "List" });

app.Run();


