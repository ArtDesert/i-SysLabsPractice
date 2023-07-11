using CoreLayer.Binders.Implementations;
using CoreLayer.Binders.Interfaces;
using CoreLayer.Response;
using CoreLayer.Services.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.DTO;
using DomainLayer.Entities.Models;
using System.Linq.Expressions;
using static DomainLayer.Enums.ResponseStatusCode;

namespace CoreLayer.Services.Implementations
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IEmployeeBinder _employeeBinder;
		public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeBinder employeeBinder)
		{
			_employeeRepository = employeeRepository;
			_employeeBinder = employeeBinder;
		}

		public async Task<IBaseResponse<bool>> CreateAsync(Employee entity)
		{
			var response = new BaseResponse<bool>();
			try
			{
				response.Data = await _employeeRepository.AddAsync(entity);
				response.Description = "Сотрудник успешно добавлен";
				response.StatusCode = OK;
			}
			catch (Exception ex)
			{
				response.Description = "Не удалось добавить сотрудника";
				response.Description += $"[CreateAsync] : {ex.Message}";
				response.StatusCode = UnknownError;
			}
			return response;
		}

		public async Task<IBaseResponse<EmployeeDto>> GetAsync(int id)
		{
			var response = new BaseResponse<EmployeeDto>();
			try
			{
				var employee = await _employeeRepository.GetAsync(id);
				if (employee == null)
				{
					response.Description = "Cотрудника с таким id не существует";
					response.StatusCode = NoContent;
				}
				else
				{
					var dto = await _employeeBinder.GetDtoFromEntityAsync(id);
					response.Data = dto;
					response.Description = "Сведения о сотруднике успешно найдены";
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

		public async Task<IBaseResponse<IEnumerable<EmployeeDto>>> GetEmployeesAsync(int pageNum, int pageSize)
		{
			var response = new BaseResponse<IEnumerable<EmployeeDto>>();
			try
			{
				var employees = await _employeeRepository.SelectAsync(pageNum, pageSize);
				if (employees.Count() == 0)
				{
					response.Description = "Сведения о сотрудниках отсутствуют либо введены некорректные параметры для фильтрации";
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
					response.Description = "Сведения о сотрудниках успешно найдены";
					response.StatusCode = OK;
				}
			}
			catch (Exception ex)
			{
				response.StatusCode = UnknownError;
				response.Description = $"[GetEmployeesAsync] : {ex.Message}";
			}
			return response;
		}

		public async Task<IBaseResponse<bool>> UpdateAsync(int id, string name, string post, DateTime birthday, string email, string number)
		{
			var response = new BaseResponse<bool>();
			try
			{
				response.Data = await _employeeRepository.UpdateAsync(id, name, post, birthday, email, number);
				response.Description = "Сведения о сотруднике успешно обновлены";
				response.StatusCode = OK;
			}
			catch (Exception ex)
			{
				response.Description = "Не удалось обновить сведения о сотруднике";
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
				response.Data = await _employeeRepository.RemoveAsync(id);
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

		public async Task<IBaseResponse<IEnumerable<EmployeeDto>>> GetAllSubordinatesFromEmployeeAsync(int supervisorId, int pageNum, int pageSize) 
		{
			var response = new BaseResponse<IEnumerable<EmployeeDto>>();
			try
			{
				var supervisor = await _employeeRepository.GetAsync(supervisorId);
				if (supervisor == null)
				{
					response.Description = "Сотрудника с таким id не существует";
					response.StatusCode = NoContent;
				}
				else
				{
					//var filter = Expression.Lambda<Func<Employee, bool>>
					//	(Expression.Call(new Func<Employee, bool>(x => x.SupervisorId == supervisorId).Method));
					Expression<Func<Employee, bool>> filter = x => x.SupervisorId == supervisorId;
					var subordinates = await _employeeRepository.SelectByFilterAsync(filter, pageNum, pageSize);
					if (subordinates.Count() == 0)
					{
						response.Description = "Сведения о подчиненных сотрудника отсутствуют либо введены некорректные параметры для фильтрации";
						response.StatusCode = NoContent;
					}
					else
					{
						var dtoList = new List<EmployeeDto>();
						foreach (var subordinate in subordinates)
						{
							dtoList.Add(await _employeeBinder.GetDtoFromEntityAsync(subordinate.Id));
						}
						response.Data = dtoList;
						response.Description = "Сведения о подчиненных сотрудника успешно найдены";
						response.StatusCode = OK;
					}
				}
			}
			catch (Exception ex)
			{
				response.StatusCode = UnknownError;
				response.Description = $"[GetAllSubordinatesFromEmployeeAsync] : {ex.Message}";
			}
			return response;
		}
	}
}
