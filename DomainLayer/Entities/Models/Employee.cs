using DomainLayer.TableInitializators;

namespace DomainLayer.Entities.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public int? SupervisorId { get; set; }
        public virtual Employee Supervisor { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<Project> Projects { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

    }
}
