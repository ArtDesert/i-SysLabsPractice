using DomainLayer.Entities.Models;
using CoreLayer.Response;
using DataContractsLayer.DTO;

namespace CoreLayer.Services.Interfaces
{
	public interface IEmployeeService : IBaseService<Employee, EmployeeDto>
	{
		Task<IBaseResponse<IEnumerable<EmployeeDto>>> GetEmployeesAsync(int pageNum, int pageSize);
		Task<IBaseResponse<bool>> UpdateAsync(int id, string name, string post, DateTime birthday, string email, string number);
		Task<IBaseResponse<IEnumerable<EmployeeDto>>> GetAllSubordinatesFromEmployeeAsync(int supervisorId, int pageNum, int pageSize);
	}
}
