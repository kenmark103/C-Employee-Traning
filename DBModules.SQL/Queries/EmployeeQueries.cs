using DBModules.SQL.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DBModules.SQL.Queries
{
    //add more queries that accept parameters to filter the list of students
    public class EmployeeQueries : IEmployeeQueries
    {
        private readonly EFTestDbContext _dbContext;
        public EmployeeQueries(EFTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //return list of employees
        public async Task<List<EmployeeResults>> ListEmployees()
        {
            var employeeList = await _dbContext.Employees.Select(e => new EmployeeResults
            {
                DepartmentId = e.DepartmentId,
                Name = e.Name,
                RoleId = e.RoleId,
                Id = e.Id,
            }).ToListAsync();

            return employeeList;
        }

        //list 10 employees by the projects they belong to and their names starting with a particular prefix
        //List<Guid> projectIds = new List<Guid> { projectId1, projectId2 }; // Replace with your project IDs
        public async Task<List<EmployeeResults>> ListEmployeesByProjectsAndNamePrefix(List<Guid> projectIds, string namePrefix)
        {
            var employeeList = await _dbContext.Employees
                .Where(e => e.EmployeeProject.Any(ep => projectIds.Contains(ep.ProjectId)) && e.Name.StartsWith(namePrefix))
                .Take(10) // Retrieve only the first 10 employees
                .Select(e => new EmployeeResults
                {
                    DepartmentId = e.DepartmentId,
                    Name = e.Name,
                    RoleId = e.RoleId,
                    Id = e.Id,
                })
                .ToListAsync();

            return employeeList;
        }

        //Get employees who belong to a particular supervisor// supervisor heads department and employee belongs to a department
        public async Task<List<EmployeeResults>> ListEmployeesUnderSupervisor(Guid supervisorId)
        {
            var departmentIds = await _dbContext.Departments
                .Where(d => d.SupervisorId == supervisorId)
                .Select(d => d.Id)
                .ToListAsync();

            var employeeList = await _dbContext.Employees
                .Where(e => departmentIds.Contains(e.DepartmentId))
                .Select(e => new EmployeeResults
                {
                    DepartmentId = e.DepartmentId,
                    Name = e.Name,
                    RoleId = e.RoleId,
                    Id = e.Id,
                })
                .ToListAsync();

            return employeeList;
        }
    }
}
