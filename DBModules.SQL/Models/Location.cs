using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Models
{
    public class Location
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [MaxLength(60)]
        public string? Name { get; set; }
        public DateTime CreatedDate { get; internal set; } = DateTime.Now;
        public ICollection<Department> Departments { get; set; }
    }
}
