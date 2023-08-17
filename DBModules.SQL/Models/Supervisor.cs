using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Models
{
    public class Supervisor
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Department> Departments { get; set; }
    }
}
