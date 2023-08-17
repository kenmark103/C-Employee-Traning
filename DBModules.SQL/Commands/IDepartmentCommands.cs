using DBModules.SQL.Models;
using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Commands
{
    public interface IDepartmentCommands
    {
        Task<DepartmentResults> CreateDepartment(CreateDepartmentRequest departmentRequest);
        Task<DepartmentUpdatedResults> UpdateDepartment(Guid departmentId, UpdateDepartmentRequest updatedDepartment);
        Task<DepartmentUpdatedResults> DeleteDepartment(Guid departmentId);
    }

    public class DepartmentCommands : IDepartmentCommands
    {
        private readonly EFTestDbContext _dbContext;

        public DepartmentCommands(EFTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DepartmentResults> CreateDepartment(CreateDepartmentRequest departmentRequest)
        {
            Department department = new Department()
            {
                 Description = departmentRequest.Description,
                 LocationId = departmentRequest.LocationId,
                 Name = departmentRequest.Name,
                 SupervisorId = departmentRequest.SupervisorId,
            };

            try {
                _dbContext.Departments.Add(department);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }   

            DepartmentResults results = new DepartmentResults()
            {
                 Description= department.Description,
                 LocationId= department.LocationId,
                 Name = department.Name,
                 SupervisorId= department.SupervisorId,
            };

            return results;
        }

        public async Task<DepartmentUpdatedResults> DeleteDepartment(Guid departmentId)
        {
            var department = await _dbContext.Departments.FindAsync(departmentId);
            if (department != null)
            {
                try
                {
                    _dbContext.Departments.Remove(department);
                    await _dbContext.SaveChangesAsync();
                    return new DepartmentUpdatedResults() {
                    Success = true,
                    };
                }
                catch(Exception ex)
                {
                    return new DepartmentUpdatedResults { Success = false, ErrorMessage = ex.Message };
                }
            }
            else { return new DepartmentUpdatedResults() {  Success = false, ErrorMessage = "Could not find department" }; }
        }

        public async Task<DepartmentUpdatedResults> UpdateDepartment(Guid departmentId, UpdateDepartmentRequest updatedDepartment)
        {
            var department = await _dbContext.Departments.FindAsync(departmentId);
            if(department != null)
            {
                department.Name = updatedDepartment.Name;
                department.SupervisorId = updatedDepartment.SupervisorId;
                department.LocationId = updatedDepartment.LocationId;
                department.Description = updatedDepartment.Description;

                await _dbContext.SaveChangesAsync();

                DepartmentUpdatedResults departmentUpdated = new DepartmentUpdatedResults() 
                {
                    Description = department.Description,
                    Name = department.Name,
                    SupervisorId = department.SupervisorId,
                    LocationId = department.LocationId,
                    Success = true
                };

                return departmentUpdated;
            }
            else
            {
                return new DepartmentUpdatedResults() { Success = false, ErrorMessage = "Couldnot find department" };
            }
            
        }
    }
}
