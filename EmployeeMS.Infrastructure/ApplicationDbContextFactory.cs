using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EmployeeMS.Infrastructure
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Get the current directory to look for appsettings.json
            var currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("Current Directory: " + currentDirectory);
            Console.WriteLine("Looking for config in: " + currentDirectory);
            // Load configuration from appsettings.json (either in API project or local if copied)
            var configuration = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            // Get connection string from "DefaultConnection"
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Build DB context options
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Return the db context with options
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
