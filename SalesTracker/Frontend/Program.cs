using Application.Customers.Queries.GetCustomerList;
using Application.Employees.Queries.GetEmployeesList;
using Application.Interfaces;
using Application.Products.Queries.GetProductsList;
using Application.Sales.Queries.GetSaleDetail;
using Application.Sales.Queries.GetSalesList;
using Microsoft.AspNetCore.Mvc.Razor;
using Persistence;
using Presentation;

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
