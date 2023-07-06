using DomainLayer.Entities.Models;
using System;

namespace DataAccessLayer.Repositories.Interfaces
{
    public  interface IProjectRepository : IBaseRepository<Project>
	{
		Task<IEnumerable<Employee>> GetAllEmployees(Project project);
	}
}
