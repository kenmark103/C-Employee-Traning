using Microsoft.EntityFrameworkCore;
using DBModules.SQL.Models;
using Pomelo.EntityFrameworkCore.MySql;

namespace DBModules.SQL
{
    public class EFTestDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        // Constructor to pass options to the base DbContext

        public EFTestDbContext(DbContextOptions<EFTestDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees")
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany() // Assuming Role has no direct relationship with Employee other than the foreign key
                .HasForeignKey(e => e.RoleId);

            // Department
            modelBuilder.Entity<Department>().ToTable("Departments")
                .HasOne(d => d.Location)
                .WithMany(l => l.Departments)
                .HasForeignKey(d => d.LocationId);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.Supervisor)
                .WithMany(s => s.Departments)
                .HasForeignKey(d => d.SupervisorId);

            // Location
            modelBuilder.Entity<Location>().ToTable("Locations")
                .HasMany(l => l.Departments)
                .WithOne(d => d.Location)
                .HasForeignKey(d => d.LocationId);

            // Role
            modelBuilder.Entity<Role>().ToTable("Roles")
                .HasMany(r => r.Employees)
                .WithOne(e => e.Role)
                .HasForeignKey(e => e.RoleId);

            // Supervisor
            modelBuilder.Entity<Supervisor>().ToTable("Supervisors")
                .HasMany(s => s.Departments)
                .WithOne(d => d.Supervisor)
                .HasForeignKey(d => d.SupervisorId);

            // EmployeeProject
            modelBuilder.Entity<EmployeeProject>()
            .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProject)
                .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProject)
                .HasForeignKey(ep => ep.ProjectId);

            base.OnModelCreating(modelBuilder);
        }
    }
       
}