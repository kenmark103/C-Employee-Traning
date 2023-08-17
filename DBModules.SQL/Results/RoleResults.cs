using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Results
{
    
    public class RoleResults
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int salary_amount { get; set; }

    }
    public class RoleUpdatedResults
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int salary_amount { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }

    }
}
