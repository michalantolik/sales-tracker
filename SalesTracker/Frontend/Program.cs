using Application.Customers.Queries.GetCustomerList;
using Application.Employees.Queries.GetEmployeesList;
using Application.Interfaces;
using Application.Products.Queries.GetProductsList;
using Application.Sales.Commands.CreateSale;
using Application.Sales.Commands.CreateSale.Factory;
using Application.Sales.Queries.GetSaleDetail;
using Application.Sales.Queries.GetSalesList;
using Common.Dates;
using Infrastructure.Network;
using Microsoft.AspNetCore.Mvc.Razor;
using Persistence;
using Presentation;
using Presentation.Sales.Services;

var builder = WebApplication.CreateBuilder(args);

// Add framework services to the container.
builder.Services.AddControllersWithViews();

// Add application services to the container.
builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
builder.Services.AddScoped<IGetCustomersListQuery, GetCustomersListQuery>();
builder.Services.AddScoped<IGetEmployeesListQuery, GetEmployeesListQuery>();
builder.Services.AddScoped<IGetProductsListQuery, GetProductsListQuery>();
builder.Services.AddScoped<IGetSalesListQuery, GetSalesListQuery>();
builder.Services.AddScoped<IGetSaleDetailQuery, GetSaleDetailQuery>();
builder.Services.AddScoped<ICreateSaleViewModelFactory, CreateSaleViewModelFactory>();
builder.Services.AddScoped<ICreateSaleCommand, CreateSaleCommand>();
builder.Services.AddScoped<ISaleFactory, SaleFactory>();
builder.Services.AddScoped<IHttpClientWrapper, HttpClientWrapper>();
builder.Services.AddScoped<IDateService, DateService>();

// Customize the default convention for how views are located
builder.Services.Configure<RazorViewEngineOptions>(
    config => config.ViewLocationExpanders.Add(
        new CustomViewLocationExpander()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
