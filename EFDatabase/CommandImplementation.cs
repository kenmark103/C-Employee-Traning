using DBModules.SQL;
using DBModules.SQL.Commands;
using DBModules.SQL.Queries;
using DBModules.SQL.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDatabase
{
    public class CommandImplementation
    {
        private readonly IEmployeeCommands _employeeCommands;
        private readonly IDepartmentCommands _deptCommands;
        private readonly ILocationCommands _locationCommands;
        private readonly IRoleCommands _roleCommands;
        private readonly ISupervisorCommands _supervisorCommands;
        private readonly IProjectCommands _projectCommands;
        private readonly EFTestDbContext _dbContext;
        public CommandImplementation(EFTestDbContext dbContext,IEmployeeCommands employeeCommands,
            IDepartmentCommands deptCommands, ILocationCommands locationCommands, IProjectCommands projectCommands,
            IRoleCommands roleCommands, ISupervisorCommands supervisorCommands)
        {
            _employeeCommands = employeeCommands;
            _deptCommands = deptCommands;
            _locationCommands = locationCommands;
            _roleCommands = roleCommands;
            _dbContext = dbContext;
            _supervisorCommands = supervisorCommands;
            _projectCommands = projectCommands;
        }

        public async void CreateLocation()
        {
            Console.WriteLine("Enter new location");
            var locRequest = new CreateLocationRequest 
            { 
                Id=Guid.NewGuid(),
               Name = Console.ReadLine(),
             };

            var result = await _locationCommands.CreateLocation(locRequest);
            Console.WriteLine($"location has been created as {result.Name}");
        }
        public async void CreateRole()
        {
            Console.WriteLine("Please enter new role");
            var roleRequest = new CreateRoleRequest
            {
                Description = "Testing role",
                Name = Console.ReadLine(),
                Id = 1,
                salary_amount = 0,

            };

            var result = await _roleCommands.CreateRole(roleRequest);
            Console.WriteLine($"Create Role Result: {result.Name}");
        }

        public async void CreateSupervisor()
        {
            Console.WriteLine("Enter new supervisor details");
            var supRequest = new CreateSupervisorRequest
            {
                Id = Guid.NewGuid(),
                Name = Console.ReadLine(),
            };

            var result = await _supervisorCommands.CreateSupervisor(supRequest);
            Console.WriteLine($"Supervisor has been created as {result.Name}");
        }
        
        
        public async void CreateDepartment()
        {
            Console.WriteLine("Enter department details as follows: Department Name:");
            string namedept = Console.ReadLine();
            Console.WriteLine("Description:");
            string descript = Console.ReadLine();
            var dept = _dbContext.Locations.FirstOrDefault();
            var supervisa = _dbContext.Supervisors.FirstOrDefault();

            var deptRequest = new CreateDepartmentRequest
            {
                Description= descript,
                Name = namedept,
                Id = Guid.NewGuid(),
                LocationId = dept.Id,
                SupervisorId = supervisa.Id
            };

            var result = await _deptCommands.CreateDepartment(deptRequest);
            Console.WriteLine($"Create Employee Result: {result.Name}");

        }

        public async void CreateEmployeeInterface()
        {
            Console.WriteLine("Enter the name of your Employee");
            string name = Console.ReadLine();
            var department = _dbContext.Departments.FirstOrDefault();
            var role = _dbContext.Roles.FirstOrDefault();
            

            var employeeRequest = new CreateEmployeeRequest
            {
                Name = name,
                DepartmentId = department.Id,
                Id = Guid.NewGuid(),
                RoleId = role.Id,

            };

            var createResult = await _employeeCommands.CreateEmployee(employeeRequest);

            Console.WriteLine($"Create Employee Result: {createResult.Name}");
        }

        public async void CreateProject()
        {
            Console.WriteLine("Enter project name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter description");
            string description = Console.ReadLine();
            var supervisor = _dbContext.Supervisors.FirstOrDefault();
            var projectRequest = new CreateProjectRequest
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                SupervisorId = supervisor.Id
            };

            var result = await _projectCommands.CreateProject(projectRequest);
            Console.WriteLine($"Created Project Result: {result.Name}");
        }
    }
}
