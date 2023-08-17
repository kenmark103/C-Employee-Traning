using DBModules.SQL.Models;
using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Queries
{
    public partial interface IEmployeeQueries
    {
        Task<List<EmployeeResults>> ListEmployees();
        Task<List<EmployeeResults>> ListEmployeesByProjectsAndNamePrefix(List<Guid> projectIds, string namePrefix);
    }
}
