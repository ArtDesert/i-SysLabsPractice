using CoreLayer.Services.Interfaces;
using DomainLayer.DTO;
using DomainLayer.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/departments")]
	public class DepartmentController : Controller
	{
        private readonly IDepartmentService _departmentService;
		private readonly ILogger<Department> _logger;

		public DepartmentController(IDepartmentService departmentService, ILogger<Department> logger)
		{
			_departmentService = departmentService;
			_logger = logger;
			_logger.LogInformation("created departmentController");
		}

		[HttpPost]
		public async Task<bool> AddDepartmentAsync(string name, string departmenttCode) //Почему в url видны параметры name и departmenttCode?
		{
			var department = new Department() { Name = name, DepartmentCode = departmenttCode };
			var response = await _departmentService.CreateAsync(department);
			return response.Data;
		}

		[HttpGet("{id}")]
		public async Task<DepartmentDto> GetDepartmentByIdAsync(int id)
		{
			var response = await _departmentService.GetAsync(id);
			return response.Data;
		}

		[HttpGet]
		public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync(int pageNum, int pageSize)
		{
			var response = await _departmentService.GetDepartmentsAsync(pageNum, pageSize);
			return response.Data;
		}

		[HttpPut]
		public async Task<bool> UpdateDepartmentAsyncById(int id, string name, string departmentCode) //Почему в url видны параметры name и departmenttCode?
		{
			var response = await _departmentService.UpdateAsync(id, name, departmentCode);
			return response.Data;
		}

		[HttpDelete("{id}")]
		public async Task<bool> DeleteDepartmentByIdAsync(int id) //why long type?
		{
			var response = await _departmentService.DeleteAsync(id);
			return response.Data;
		}

		[HttpGet("{id}/employees")]
		public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesOfDepartmentAsync(int id, int pageNum, int pageSize)
		{
			var response = await _departmentService.GetAllEmployeesOfDepartmentAsync(id, pageNum, pageSize);
			return response.Data;
		}
	}
}
