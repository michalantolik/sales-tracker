using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public class DatabaseService :DbContext, IDatabaseService
    {
        private readonly IConfiguration configuration;

        public DatabaseService(IConfiguration configuration)
        {
            this.configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = this.configuration.GetConnectionString("SalesTracker");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
