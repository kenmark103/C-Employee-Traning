using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Models
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid SupervisorId { get; set; }
        public Supervisor? Supervisor { get; set; }
        public ICollection<EmployeeProject>? EmployeeProject { get; set; }
    }
}
