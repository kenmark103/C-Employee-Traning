using DBModules.SQL.Models;
using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Commands
{
    public interface ISupervisorCommands
    {
        Task<SupervisorResults> CreateSupervisor(CreateSupervisorRequest supervisorRequest);
        Task<SupervisorUpdatedResults> UpdateSupervisor(Guid supervisorId, UpdateSupervisorRequest updatedSupervisor);
        Task<SupervisorUpdatedResults> DeleteSupervisor(Guid supervisorId);
    }

    public class SupervisorCommands : ISupervisorCommands
    {
        private readonly EFTestDbContext _dbContext;
        public SupervisorCommands(EFTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SupervisorResults> CreateSupervisor(CreateSupervisorRequest supervisorRequest)
        {

            Supervisor supervisor = new Supervisor()
            { 
                Name = supervisorRequest.Name,
                CreatedAt = DateTime.Now,
                Departments = supervisorRequest.Departments,
            };

            _dbContext.Supervisors.Add(supervisor);
            await _dbContext.SaveChangesAsync();
            SupervisorResults results = new SupervisorResults()
            {
                Name = supervisor.Name,
                Id = supervisor.Id,
                Departments =supervisor.Departments,
            };
            return results;
        }

        public async Task<SupervisorUpdatedResults> DeleteSupervisor(Guid supervisorId)
        {
            var supervisor = await _dbContext.Supervisors.FindAsync(supervisorId);
            if (supervisor != null)
            {
                try
                {
                    _dbContext.Supervisors.Remove(supervisor);
                    await _dbContext.SaveChangesAsync();
                    return new SupervisorUpdatedResults { Success = true };
                }
                catch (Exception ex)
                {
                    return new SupervisorUpdatedResults { Success = false, ErrorMessage = ex.Message };
                }
            }
            else
            {
                return new SupervisorUpdatedResults { Success = false, ErrorMessage = "Supervisor not found." };
            }
        }

        public async Task<SupervisorUpdatedResults> UpdateSupervisor(Guid supervisorId, UpdateSupervisorRequest updatedSupervisor)
        {
            var supervisor = await _dbContext.Supervisors.FindAsync(supervisorId);
            if (supervisor != null)
            {
                supervisor.Name = updatedSupervisor.Name;
                supervisor.Departments = updatedSupervisor.Departments;
   
                await _dbContext.SaveChangesAsync();
                return new SupervisorUpdatedResults
                {
                  Departments = supervisor.Departments,
                  Name = supervisor.Name,
                  Success = true
                };
            }
            else
            {
                return new SupervisorUpdatedResults { Success = false, ErrorMessage = "Supervisor not found." };
            }
        }
    }
}
