using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Models
{
    public class Employee
    {
        [Key] public Guid Id { get; set; }
        [Required] public string Name { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<EmployeeProject>? EmployeeProject { get; set; }

    }
}
