using DomainLayer.Entities.Models;
using CoreLayer.Response;
using DomainLayer.DTO;

namespace CoreLayer.Services.Interfaces
{
	public interface IProjectService : IBaseService<Project, ProjectDto>
	{
		Task<IBaseResponse<IEnumerable<ProjectDto>>> GetProjectsAsync(int pageNum, int pageSize);
		Task<IBaseResponse<bool>> UpdateAsync(int id, string name, string projectCode);
		Task<IBaseResponse<IEnumerable<EmployeeDto>>> GetAllEmployeesOnProjectAsync(int projectId, int pageNum, int pageSize);
	}
}
