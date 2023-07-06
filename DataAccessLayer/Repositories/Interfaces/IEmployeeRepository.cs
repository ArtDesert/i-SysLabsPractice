using DomainLayer.Entities.Models;
using System;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
	{
		Task<IEnumerable<Employee>> GetAllSubordinates(Employee employee);
	}
}
