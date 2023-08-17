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
    public interface IRoleCommands
    {
        Task<RoleResults> CreateRole(CreateRoleRequest roleRequest);
        Task<RoleUpdatedResults> UpdateRole(Guid roleId, UpdateRoleRequest updatedRole);
        Task<RoleUpdatedResults> DeleteRole(Guid roleId);
    }
    public class RoleCommands : IRoleCommands
    {
        private readonly EFTestDbContext _dbContext;
        public RoleCommands(EFTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RoleResults> CreateRole(CreateRoleRequest roleRequest)
        {

            Role rol = new Role()
            {
              Name = roleRequest.Name,
              Description = roleRequest.Description,
              salary_amount = roleRequest.salary_amount

            };
            try {
                _dbContext.Roles.Add(rol);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            
            RoleResults results = new RoleResults()
            {
                Name = rol.Name,
                Description = rol.Description,
                salary_amount=roleRequest.salary_amount
            };
            return results;
        }

        public async Task<RoleUpdatedResults> DeleteRole(Guid roleId)
        {
            var role = await _dbContext.Roles.FindAsync(roleId);
            if (role != null)
            {
                try
                {
                    _dbContext.Roles.Remove(role);
                    await _dbContext.SaveChangesAsync();
                    return new RoleUpdatedResults { Success = true };
                }
                catch (Exception ex)
                {
                    return new RoleUpdatedResults { Success = false, ErrorMessage = ex.Message };
                }
            }
            else
            {
                return new RoleUpdatedResults { Success = false, ErrorMessage = "Role not found." };
            }
        }

        public async Task<RoleUpdatedResults> UpdateRole(Guid roleId, UpdateRoleRequest updatedRole)
        {
            var role = await _dbContext.Roles.FindAsync(roleId);
            if (role != null)
            {
                role.Name = updatedRole.Name;
                role.Description = updatedRole.Description;
                role.salary_amount = updatedRole.salary_amount;

                await _dbContext.SaveChangesAsync();

                return new RoleUpdatedResults
                {
                    Success = true,
                    Name = role.Name,
                    Description = role.Description,
                    salary_amount = updatedRole.salary_amount
                };
            }
            else
            {
                return new RoleUpdatedResults { Success = false, ErrorMessage = "Role not found." };
            }
        }
    }
}
