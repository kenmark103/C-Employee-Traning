using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Models
{
    public class Department
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid LocationId { get; set; }
        public Location Location { get; set; }

        public Guid SupervisorId { get; set; }
        public Supervisor? Supervisor { get; set; }
        public ICollection<Employee>? Employees { get; set; }

    }
}
