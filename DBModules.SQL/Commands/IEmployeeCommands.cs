using DBModules.SQL.Requests;
using DBModules.SQL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Commands
{
    public interface IEmployeeCommands
    {
        Task <EmployeeResults> CreateEmployee(CreateEmployeeRequest employeeRequest);
        Task<EmployeeUpdatedResult> UpdateEmployee(Guid employeeId, UpdateEmployeeRequest updatedEmployee);
        Task<EmployeeUpdatedResult> DeleteEmployee(Guid employeeId);
    }
}
