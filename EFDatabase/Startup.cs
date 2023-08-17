using DBModules.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EFDatabase
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Replace with your connection string.
            var connectionString = "server=localhost;user=kenny;password=12345;database=eftestdb";

            // Replace with your server version and type.
            // Use 'MariaDbServerVersion' for MariaDB.
            // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
            // For common usages, see pull request #1233.
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

            // Replace 'YourDbContext' with the name of your own DbContext derived class.
            services.AddDbContext<EFTestDbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, serverVersion)
                    // The following three options help with debugging, but should
                    // be changed or removed for production.
                    .LogTo(Console.WriteLine, LogLevel.Debug)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );
        }
    }
}
