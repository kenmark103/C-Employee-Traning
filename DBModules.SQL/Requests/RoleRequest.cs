using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Requests
{
    public class RoleRequest
    {
        
    }
    public class CreateRoleRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int salary_amount { get; set; }
    }
    public class UpdateRoleRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int salary_amount { get; set; }

    }
    public class DeleteRoleRequest
    {
        public int Id { get; set; }
    }
}
