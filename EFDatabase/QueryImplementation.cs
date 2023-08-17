using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModules.SQL.Queries;

namespace EFDatabase
{
    public class QueryImplementation
    {

        private readonly IEmployeeQueries _employeeQueries;//anything injected should be readonly so that you can only get but not set

        public QueryImplementation(IEmployeeQueries employeeQueries)
        {
            _employeeQueries = employeeQueries;
        }

        public async void userInteraction()
        {
            var employees = await _employeeQueries.ListEmployees();
            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee ID: {employee.Id}, Name: {employee.Name}");
            }

        }

    }
}
