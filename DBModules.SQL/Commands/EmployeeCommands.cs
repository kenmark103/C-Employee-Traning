using DBModules.SQL.Models;
using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using System.Linq;

namespace DBModules.SQL.Commands
{
    public class EmployeeCommands : IEmployeeCommands
    {
        private readonly EFTestDbContext _dbContext;
        public EmployeeCommands(EFTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmployeeResults> CreateEmployee(CreateEmployeeRequest employeeRequest)
        {

            Employee empl = new Employee()
            {
                Name = employeeRequest.Name,
                RoleId = employeeRequest.RoleId,
                DepartmentId = employeeRequest.DepartmentId,
                EmployeeProject=employeeRequest.EmployeeProject
            };
            try 
            {
                _dbContext.Employees.Add(empl);
                await _dbContext.SaveChangesAsync();
                EmployeeResults results = new EmployeeResults()
                {
                    Name = employeeRequest.Name,
                    RoleId = employeeRequest.RoleId,
                    DepartmentId = employeeRequest.DepartmentId,
                    Id = employeeRequest.Id

                };
                return results;
            }
            catch (Exception ex) 
            {
                return new EmployeeResults { Success = false, ErrorMessage = ex.Message };
            }
            
        }

        public async Task<EmployeeUpdatedResult> DeleteEmployee(Guid employeeId)
        {
            var employee = await _dbContext.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                try
                {
                    _dbContext.Employees.Remove(employee);
                    await _dbContext.SaveChangesAsync();
                    return new EmployeeUpdatedResult { Success = true };
                }
                catch (Exception ex)
                {
                    return new EmployeeUpdatedResult { Success = false, ErrorMessage = ex.Message };
                }
            }
            else
            {
                return new EmployeeUpdatedResult { Success = false, ErrorMessage = "Employee not found." };
            }
        }

        public async Task<EmployeeUpdatedResult> UpdateEmployee(Guid employeeId, UpdateEmployeeRequest updatedEmployee)
        {
            var employee = await _dbContext.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.RoleId = updatedEmployee.RoleId;
                employee.DepartmentId = updatedEmployee.DepartmentId;
                employee.EmployeeProject = updatedEmployee.EmployeeProject;

                await _dbContext.SaveChangesAsync();

                return new EmployeeUpdatedResult {
                    Name = employee.Name,
                    DepartmentId = employee.DepartmentId,
                    RoleId = employee.RoleId,
                    Id = employee.Id,
                    EmployeeProject = employee.EmployeeProject,
                    Success = true 
                };
            }
            else
            {
                return new EmployeeUpdatedResult { Success = false, ErrorMessage = "Employee not found." };
            }
        }
    }
}
