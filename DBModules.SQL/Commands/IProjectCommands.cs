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
    public interface IProjectCommands
    {
        Task<ProjectResults> CreateProject(CreateProjectRequest projectRequest);
        Task<ProjectUpdatedResults> UpdateProject(Guid projectId, UpdateProjectRequest updatedProject);
        Task<ProjectUpdatedResults> DeleteProject(Guid projectId);
    }
    public class ProjectCommands : IProjectCommands
    {
        private readonly EFTestDbContext _dbContext;
        public ProjectCommands(EFTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProjectResults> CreateProject(CreateProjectRequest projectRequest)
        {

            Project proj = new Project()
            {
                Name = projectRequest.Name,
                Description = projectRequest.Description,
                SupervisorId = projectRequest.SupervisorId,
            };

            try {
                _dbContext.Projects.Add(proj);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            ProjectResults results = new ProjectResults()
            {
                Name= proj.Name,
                Description= proj.Description,
                SupervisorId= proj.SupervisorId,
            };
            return results;
        }

        public async Task<ProjectUpdatedResults> DeleteProject(Guid projectId)
        {
            var project = await _dbContext.Projects.FindAsync(projectId);
            if (project != null)
            {
                try
                {
                    _dbContext.Projects.Remove(project);
                    await _dbContext.SaveChangesAsync();
                    return new ProjectUpdatedResults { Success = true };
                }
                catch (Exception ex)
                {
                    return new ProjectUpdatedResults { Success = false, ErrorMessage = ex.Message };
                }
            }
            else
            {
                return new ProjectUpdatedResults { Success = false, ErrorMessage = "Project not found." };
            }
        }

        public async Task<ProjectUpdatedResults> UpdateProject(Guid projectId, UpdateProjectRequest updatedProject)
        {
            var project = await _dbContext.Projects.FindAsync(projectId);
            if (project != null)
            {
                project.Name = updatedProject.Name;
                project.Description = updatedProject.Description;
                project.SupervisorId = updatedProject.SupervisorId; 

                await _dbContext.SaveChangesAsync();

                return new ProjectUpdatedResults
                {
                    Success = true,
                    Name = project.Name,
                    Description = project.Description,
                    SupervisorId = project.SupervisorId,
                    
                };
            }
            else
            {
                return new ProjectUpdatedResults { Success = false, ErrorMessage = "Project not found." };
            }
        }
    }
}
