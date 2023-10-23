using Application.Interfaces;
using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Customers;
using Persistence.Employees;
using Persistence.Products;
using Persistence.Sales;

namespace Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        private readonly IConfiguration configuration;

        public DatabaseService(IConfiguration configuration)
        {
            this.configuration = configuration;
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = this.configuration.GetConnectionString("SalesTracker");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new CustomerConfiguration().Configure(builder.Entity<Customer>());
            new EmployeeConfiguration().Configure(builder.Entity<Employee>());
            new ProductConfiguration().Configure(builder.Entity<Product>());
            new SaleConfiguration().Configure(builder.Entity<Sale>());
        }
    }
}
