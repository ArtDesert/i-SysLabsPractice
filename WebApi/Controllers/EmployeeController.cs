using CoreLayer.Services.Interfaces;
using DomainLayer.DTO;
using DomainLayer.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/employees")]
	public class EmployeeController : Controller
	{
		private readonly IEmployeeService _employeeService;
		private readonly ILogger<Employee> _logger;

		public EmployeeController(IEmployeeService employeeService, ILogger<Employee> logger)
		{
			_employeeService = employeeService;
			_logger = logger;
		}

		[HttpPost]
		public async Task<bool> AddEmployeeAsync(string name, string post, DateTime birthday, string email, string number, int? supervisorId,
			int departmentId, int statusId)
		{
			var employee = new Employee()
			{
				Name = name,
				Post = post,
				Birthday = birthday,
				Email = email,
				Number = number,
				SupervisorId = supervisorId,
				DepartmentId = departmentId,
				StatusId = statusId
			};
			var response = await _employeeService.CreateAsync(employee);
			return response.Data;
		}

		[HttpGet("{id}")]
		public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
		{
			var response = await _employeeService.GetAsync(id);
			return response.Data;
		}

		[HttpGet]
		public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(int pageNum, int pageSize)
		{
			var response = await _employeeService.GetEmployeesAsync(pageNum, pageSize);
			return response.Data;
		}

		[HttpPut]
		public async Task<bool> UpdateEmployeeAsync(int id, string name, string post, DateTime birthday, string email, string number)
		{
			var response = await _employeeService.UpdateAsync(id, name, post, birthday, email, number);
			return response.Data;
		}

		[HttpDelete("{id}")]
		public async Task<bool> DeleteEmployeeAsync(int id)
		{
			var response = await _employeeService.DeleteAsync(id);
			return response.Data;
		}

		[HttpGet("{id}/subordinates")]
		public async Task<IEnumerable<EmployeeDto>> GetAllSubordinatesFromEmployeeAsync(int id, int pageNum, int pageSize)
		{
			var response = await _employeeService.GetAllSubordinatesFromEmployeeAsync(id, pageNum, pageSize);
			return response.Data;
		}
	}
}
