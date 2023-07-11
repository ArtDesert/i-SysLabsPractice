using DomainLayer.Entities.Models;

namespace DataAccessLayer.Repositories.Interfaces
{
    public  interface IProjectRepository : IBaseRepository<Project>
	{
		Task<bool> UpdateAsync(int id, string name, string projectCode);
	}
}
