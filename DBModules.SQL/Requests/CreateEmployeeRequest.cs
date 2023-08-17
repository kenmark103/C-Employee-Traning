using DBModules.SQL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Requests
{
    public class CreateEmployeeRequest
    {
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public int RoleId { get; set; }
        public Guid Id { get; set; }
        public ICollection<EmployeeProject>? EmployeeProject { get; set; }
    }
    public class UpdateEmployeeRequest
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public ICollection<EmployeeProject>? EmployeeProject { get; set; }
    }

    public class DeleteEmployeeRequest
    {
        public Guid EmployeeId { get; set; }
    }
}
