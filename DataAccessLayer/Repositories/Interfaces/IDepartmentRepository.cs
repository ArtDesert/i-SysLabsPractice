using DomainLayer.Entities.Models;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
	{
		Task<bool> UpdateAsync(int id, string name, string departmentCode);
	}
}
