namespace DBModules.SQL.Models
{
    public class EmployeeProject
    {
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }

        // Navigation properties to establish the relationships
        public Employee Employee { get; set; }
        public Project Project { get; set; }

        // Any additional properties relevant to the relationship can be added here
        // For example, you might have a property representing an employee's role in the project
        public string EmployeeRole { get; set; }
    }
}