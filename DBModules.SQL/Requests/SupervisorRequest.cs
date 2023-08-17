using DBModules.SQL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Requests
{
    public class SupervisorRequest
    {
    }
    public class CreateSupervisorRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Department>? Departments { get; set; }
    }
    public class UpdateSupervisorRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
    public class DeleteSupervisorRequest
    {
        public Guid Id { get; set; }
    }
}
