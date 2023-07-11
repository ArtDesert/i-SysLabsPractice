using CoreLayer.Binders.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.DTO;
using DomainLayer.Entities.Models;

namespace CoreLayer.Binders.Implementations
{
	public class EmployeeBinder : IEmployeeBinder
	{
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeeBinder(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		public async Task<EmployeeDto?> GetDtoFromEntityAsync(int entityId)
		{
			var employee = await _employeeRepository.GetAsync(entityId);
			return new EmployeeDto(entityId, employee.Name); //TODO
		}

		public async Task<Employee> GetEntityFromDtoAsync(EmployeeDto dto)
		{
			var employee = await _employeeRepository.GetAsync(dto.Id);
			return employee; //TODO
		}
	}
}
