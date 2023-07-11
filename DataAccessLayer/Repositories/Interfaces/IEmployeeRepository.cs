using DomainLayer.Entities.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
	{
		Task<bool> UpdateAsync(int id, string name, string post, DateTime birthday, string email, string number);
		Task<IEnumerable<Employee>> SelectByFilterAsync(Expression<Func<Employee, bool>> filter, int pageNum, int pageSize);
	}
}
