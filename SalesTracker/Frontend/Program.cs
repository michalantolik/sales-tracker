using Application.Interfaces;
using Frontend;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add framework services to the container.
builder.Services.AddControllersWithViews();

// Add application services to the container.
builder.Services.AddSingleton<IDatabaseService, DatabaseService>();

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
