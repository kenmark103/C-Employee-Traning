using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Requests
{
    public class ProjectRequest
    {
    }
    public class CreateProjectRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid SupervisorId { get; set; }
    }
    public class UpdateProjectRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid SupervisorId { get; set; }

    }
    public class DeleteProjectRequest
    {
        public Guid Id { get; set; }
    }
}
