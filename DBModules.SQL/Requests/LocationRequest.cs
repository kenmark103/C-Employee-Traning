using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Requests
{
    public class LocationRequest
    {
    }
    public class CreateLocationRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
    public class DeleteLocationRequest
    {
        public Guid Id { get; set; }
    }
    public class UpdateLocationRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
