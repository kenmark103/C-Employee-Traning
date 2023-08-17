using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int salary_amount {get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
