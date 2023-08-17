using DBModules.SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Results
{
    public class SupervisorResults
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
    public class SupervisorUpdatedResults
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
