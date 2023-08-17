using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Results
{
    public class LocationResults
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
    public class LocationUpdatedResults
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
