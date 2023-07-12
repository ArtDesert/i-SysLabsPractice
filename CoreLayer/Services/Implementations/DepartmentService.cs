using CoreLayer.Services.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Entities.Models;
using CoreLayer.Response;
using static DomainLayer.Enums.ResponseStatusCode;
using DomainLayer.DTO;
using CoreLayer.Binders.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;

namespace CoreLayer.Services.Implementations
{
    public class DepartmentService : IDepartmentService
	{
		private readonly IDepartmentRepository _departmentRepository;
		private readonly IDepartmentBinder _departmentBinder;
		private readonly IEmployeeBinder _employeeBinder;
		private readonly ILogger<DepartmentService> _logger;

		public DepartmentService(IDepartmentRepository departmentRepository, IDepartmentBinder binder, IEmployeeBinder employeeBinder, ILogger<DepartmentService> logger)
		{
			_departmentRepository = departmentRepository;
			_departmentBinder = binder;
			_employeeBinder = employeeBinder;
			_logger = logger;
		}

		public async Task<IBaseResponse<bool>> CreateAsync(Department entity)
		{
			_logger.LogInformation("CreateAsync is invoked");
			var response = new BaseResponse<bool>();
			try
			{
				response.Data = await _departmentRepository.AddAsync(entity);
				response.Description = "Подразделение успешно добавлено";
				response.StatusCode = OK;
				_logger.LogInformation("CreateAsync completed successfully");
			}
			catch (Exception ex)
			{
				response.Description = "Не удалось добавить подразделение";
				response.Description += $"[CreateAsync] : {ex.Message}";
				response.StatusCode = UnknownError;
				_logger.LogError($"[CreateAsync threw an exception] : {ex}");
			}
			return response;
		}

		public async Task<IBaseResponse<DepartmentDto>> GetAsync(int id)
		{
			var response = new BaseResponse<DepartmentDto>();
			var dto = await _departmentBinder.GetDtoFromEntityAsync(id);
			try
			{
				if (dto == null)
				{
					response.Description = "Подразделения с таким id не существует";
					response.StatusCode = NoContent;
				}
				else
				{
					response.Data = dto;
					response.Description = "Сведения о подразделении успешно найдены";
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

		public async Task<IBaseResponse<IEnumerable<DepartmentDto>>> GetDepartmentsAsync(int pageNum, int pageSize)
		{
			var response = new BaseResponse<IEnumerable<DepartmentDto>>();
			try
			{
				var departments = await _departmentRepository.SelectAsync(pageNum, pageSize);
				if (departments.Count() == 0)
				{
					response.Description = "Сведения о подразделениях отсутствуют либо введены некорректные параметры для фильтрации";
					response.StatusCode = NoContent;

				}
				else 
				{
					var dtoList = new List<DepartmentDto>();
					foreach (var department in departments)
					{
						dtoList.Add(await _departmentBinder.GetDtoFromEntityAsync(department.Id));
					}
					response.Data = dtoList;
					response.Description = "Сведения о подразделениях успешно найдены";
					response.StatusCode = OK;
				}
			}
			catch (Exception ex)
			{
				response.StatusCode = UnknownError;
				response.Description = $"[GetDepartmentsAsync] : {ex.Message}";
			}
			return response;
		}

		public async Task<IBaseResponse<bool>> UpdateAsync(int id, string name, string departmentCode)
		{
			var response = new BaseResponse<bool>();
			try
			{
				response.Data = await _departmentRepository.UpdateAsync(id, name, departmentCode);
				response.Description = "Сведения о подразделении успешно обновлены";
				response.StatusCode = OK;
			}
			catch (Exception ex)
			{
				response.Description = "Не удалось обновить сведения о подразделении";
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
				response.Data = await _departmentRepository.RemoveAsync(id);
				response.Description = "Подразделение успешно удалено";
				response.StatusCode = OK;
			}
			catch (Exception ex)
			{
				response.Description = "Не удалось удалить подразделение";
				response.Description += $"[DeleteAsync] : {ex.Message}";
				response.StatusCode = UnknownError;
			}
			return response;
		}

		public async Task<IBaseResponse<IEnumerable<EmployeeDto>>> GetAllEmployeesOfDepartmentAsync(int departmentId, int pageNum, int pageSize)
		{
			var response = new BaseResponse<IEnumerable<EmployeeDto>>();
			try
			{
				var department = await _departmentRepository.GetAsync(departmentId);
				if (department == null)
				{
					response.Description = "Подразделения с таким id не существует";
					response.StatusCode = NoContent;
				}
				else
				{
					var employees = department.Employees
						.Skip(pageNum * pageSize)
						.Take(pageSize)
						.ToList();
					if (employees.Count == 0)
					{
						response.Description = "Сведения о сотрудниках подразделения отсутствуют либо введены некорректные параметры для фильтрации";
						response.StatusCode = NoContent;
					}
					else
					{
						var dtoList = new List<EmployeeDto>();
						foreach (var employee in employees)
						{
							dtoList.Add(await _employeeBinder.GetDtoFromEntityAsync(employee.Id));
						}
						response.Data = dtoList;;
						response.Description = "Сведения о сотрудниках подразделения успешно найдены";
						response.StatusCode = OK;
					}
				}
			}
			catch (Exception ex)
			{
				response.StatusCode = UnknownError;
				response.Description = $"[GetAllEmployeesOfDepartmentAsync] : {ex.Message}";
			}
			return response;
		}
	}
}
