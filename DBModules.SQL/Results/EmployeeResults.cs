using DBModules.SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Results
{
    public class EmployeeResults
    {
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public int RoleId { get; set; }
        public Guid Id { get; set; }
        public ICollection<EmployeeProject>? EmployeeProject { get; set; }
        public string? ErrorMessage { get; set; }
        public bool Success { get; set; }
    }
    public class EmployeeUpdatedResult
    {
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public int RoleId { get; set; }
        public Guid Id { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public ICollection<EmployeeProject>? EmployeeProject { get; set; }
    }
}
