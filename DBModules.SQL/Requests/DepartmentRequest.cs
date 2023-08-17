using DBModules.SQL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Requests
{
    public class DepartmentRequest
    {
        
       
    }
    public class CreateDepartmentRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid LocationId { get; set; }
        public Guid SupervisorId { get; set; }
    }
    public class UpdateDepartmentRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid LocationId { get; set; }
        public Guid SupervisorId { get; set; }
    }
    public class DeleteDepartmentRequest
    {
        public Guid Id { get; set; }
    }
}
