using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Results
{
    public class DepartmentResults
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid LocationId { get; set; }
        public Guid SupervisorId { get; set; }
    }
    public class DepartmentUpdatedResults
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid LocationId { get; set; }
        public Guid SupervisorId { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
