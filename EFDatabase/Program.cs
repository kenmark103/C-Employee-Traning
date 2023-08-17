using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DBModules.SQL;
using Microsoft.Extensions.Logging;
using EFDatabase;
using Microsoft.Extensions.Hosting;
using DBModules.SQL.Queries;
using DBModules.SQL.Commands;

public class Program
{
    public static void Main(string[] args)
    {
       var hostBuilder = CreateHostBuilder(args);
       // CreateHostBuilder(args).Build().Run();
       /** hostBuilder.Build().Run();
        var serviceCollection = new ServiceCollection();
        using (var serviceProvider = serviceCollection.BuildServiceProvider())
        {
            var qImplementations = serviceProvider.GetRequiredService<QueryImplementation>();
            var commandImplementation = serviceProvider.GetRequiredService<CommandImplementation>();
            commandImplementation.CreateLocation();
            commandImplementation.CreateRole();
            commandImplementation.CreateDepartment();
            //commandImplementation.CreateEmployeeInterface();
            //qImplementations.userInteraction();

        } 
        **/
        var host = hostBuilder.Build();

        using (var serviceProvider = host.Services.CreateScope())
        {
            //var qImplementations = serviceProvider.ServiceProvider.GetRequiredService<QueryImplementation>();
            var commandImplementation = serviceProvider.ServiceProvider.GetRequiredService<CommandImplementation>();
            //commandImplementation.CreateLocation();
            //commandImplementation.CreateRole();
            //commandImplementation.CreateSupervisor();
            //commandImplementation.CreateDepartment();
            //commandImplementation.CreateEmployeeInterface();
            //qImplementations.userInteraction();
            commandImplementation.CreateProject();
        }
        host.Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
        .ConfigureHostConfiguration(config =>
        {

        }).ConfigureServices(services =>
        {
            // Replace with your connection string.
            var connectionString = "server=localhost;user=kenny;password=12345 ;database=eftestdb";

            // Replace with your server version and type.
            // Use 'MariaDbServerVersion' for MariaDB.
            // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
            // For common usages, see pull request #1233.
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

            // Replace 'YourDbContext' with the name of your own DbContext derived class.
            //dependancy Injections can be added as transient,scope e.t.c
            services.AddDbContext<EFTestDbContext>(
                            dbContextOptions => dbContextOptions
                                .UseMySql(connectionString, serverVersion, s =>
                                {
                                    s.MigrationsAssembly("EFDatabase");

                                })

                                     // The following three options help with debugging, but should
                                     // be changed or removed for production.
                                     .LogTo(Console.WriteLine, LogLevel.Debug)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors());
            services.AddTransient<IEmployeeQueries, EmployeeQueries>();
            services.AddTransient<QueryImplementation>();
            
            services.AddTransient<CommandImplementation>();
            services.AddTransient<ILocationCommands, LocationCommands>();
            services.AddTransient<IRoleCommands, RoleCommands>();
            services.AddTransient<IDepartmentCommands, DepartmentCommands>();
            services.AddTransient<ISupervisorCommands, SupervisorCommands>();
            services.AddTransient<IEmployeeCommands, EmployeeCommands>();
            services.AddTransient<IProjectCommands, ProjectCommands>();
        });
    }
}