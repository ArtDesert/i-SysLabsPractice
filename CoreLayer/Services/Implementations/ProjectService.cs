using CoreLayer.Response;
using CoreLayer.Services.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using DataContractsLayer.Binders.Interfaces;
using DataContractsLayer.DTO;
using DomainLayer.Entities.Models;
using static DomainLayer.Enums.ResponseStatusCode;

namespace CoreLayer.Services.Implementations
{
	public class ProjectService : IProjectService
	{

		private readonly IProjectRepository _projectRepository;
		private readonly IProjectBinder _projectBinder;
		private readonly IEmployeeBinder _employeeBinder;

		public ProjectService(IProjectRepository projectRepository, IProjectBinder projectBinder, IEmployeeBinder employeeBinder)
		{
			_projectRepository = projectRepository;
			_projectBinder = projectBinder;
			_employeeBinder = employeeBinder;
		}

		public async Task<IBaseResponse<bool>> CreateAsync(Project entity)
		{
			var response = new BaseResponse<bool>();
			try
			{
				response.Data = await _projectRepository.AddAsync(entity);
				response.Description = "Проект успешно добавлен";
				response.StatusCode = OK;
			}
			catch (Exception ex)
			{
				response.Description = "Не удалось добавить проект";
				response.Description += $"[CreateAsync] : {ex.Message}";
				response.StatusCode = UnknownError;
			}
			return response;
		}

		public async Task<IBaseResponse<ProjectDto>> GetAsync(int id)
		{
			var response = new BaseResponse<ProjectDto>();
			var dto = await _projectBinder.GetDtoFromEntityAsync(id);
			try
			{
				if (dto == null)
				{
					response.Description = "Проекта с таким id не существует";
					response.StatusCode = NoContent;
				}
				else
				{
					response.Data = dto;
					response.Description = "Сведения о проекте успешно найдены";
					response.StatusCode = OK;
				}
			}
			catch (Exception ex)
			{

				response.StatusCode = UnknownError;
				response.Description = $"[GetAsync] : {ex.Message}";
			}
			return response;
		}

		public async Task<IBaseResponse<IEnumerable<ProjectDto>>> GetProjectsAsync(int pageNum, int pageSize)
		{
			var response = new BaseResponse<IEnumerable<ProjectDto>>();
			try
			{
				var projects = await _projectRepository.SelectAsync(pageNum, pageSize);
				if (projects.Count() == 0)
				{
					response.Description = "Сведения о проектах отсутствуют либо введены некорректные параметры для фильтрации";
					response.StatusCode = NoContent;

				}
				else
				{
					var dtoList = new List<ProjectDto>();
					foreach (var project in projects)
					{
						dtoList.Add(await _projectBinder.GetDtoFromEntityAsync(project.Id));
					}
					response.Data = dtoList;
					response.Description = "Сведения о проектах успешно найдены";
					response.StatusCode = OK;
				}
			}
			catch (Exception ex)
			{
				response.StatusCode = UnknownError;
				response.Description = $"[GetProjectsAsync] : {ex.Message}";
			}
			return response;
		}

		public async Task<IBaseResponse<bool>> UpdateAsync(int id, string name, string projectCode)
		{
			var response = new BaseResponse<bool>();
			try
			{
				response.Data = await _projectRepository.UpdateAsync(id, name, projectCode);
				response.Description = "Сведения о проекте успешно обновлены";
				response.StatusCode = OK;
			}
			catch (Exception ex)
			{
				response.Description = "Не удалось обновить сведения о проекте";
				response.Description += $"[UpdateAsync] : {ex.Message}";
				response.StatusCode = UnknownError;
			}
			return response;
		}

		public async Task<IBaseResponse<bool>> DeleteAsync(int id)
		{
			var response = new BaseResponse<bool>();
			try
			{
				response.Data = await _projectRepository.RemoveAsync(id);
				response.Description = "Проект успешно удален";
				response.StatusCode = OK;
			}
			catch (Exception ex)
			{
				response.Description = "Не удалось удалить проект";
				response.Description += $"[DeleteAsync] : {ex.Message}";
				response.StatusCode = UnknownError;
			}
			return response;
		}

		public async Task<IBaseResponse<IEnumerable<EmployeeDto>>> GetAllEmployeesOnProjectAsync(int projectId, int pageNum, int pageSize)
		{
			var response = new BaseResponse<IEnumerable<EmployeeDto>>();
			try
			{
				var project = await _projectRepository.GetAsync(projectId);
				if (project == null)
				{
					response.Description = "Проекта с таким id не существует";
					response.StatusCode = NoContent;
				}
				else
				{
					var employees = project.Employees
						.Skip(pageNum * pageSize)
						.Take(pageSize)
						.ToList();
					if (employees.Count == 0)
					{
						response.Description = "Сведения о сотрудниках, работающих на одном проекте, отсутствуют либо введены некорректные параметры для фильтрации";
						response.StatusCode = NoContent;
					}
					else
					{
						var dtoList = new List<EmployeeDto>();
						foreach (var employee in employees)
						{
							dtoList.Add(await _employeeBinder.GetDtoFromEntityAsync(employee.Id));
						}
						response.Data = dtoList;
						response.Description = "Сведения о сотрудниках, работающих на одном проекте, успешно найдены";
						response.StatusCode = OK;
					}
				}
			}
			catch (Exception ex)
			{
				response.StatusCode = UnknownError;
				response.Description = $"[GetAllEmployeesOnProjectAsync] : {ex.Message}";
			}
			return response;
		}
	}
}
