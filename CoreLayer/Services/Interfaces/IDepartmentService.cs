using DomainLayer.Entities.Models;
using CoreLayer.Response;
using DataContractsLayer.DTO;

namespace CoreLayer.Services.Interfaces
{
	public interface IDepartmentService : IBaseService<Department, DepartmentDto>
	{
		Task<IBaseResponse<IEnumerable<DepartmentDto>>> GetDepartmentsAsync(int pageNum, int pageSize);
		Task<IBaseResponse<bool>> UpdateAsync(int id, string name, string departmentCode);
		Task<IBaseResponse<IEnumerable<EmployeeDto>>> GetAllEmployeesOfDepartmentAsync(int departmentId, int pageNum, int pageSize);
	}
}
