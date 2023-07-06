using CoreLayer.Services.Interfaces;
using DomainLayer.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DepartmentController : Controller
	{
		private readonly IDepartmentService _departmentService;

		public DepartmentController(IDepartmentService departmentService)
		{
			_departmentService = departmentService;
		}

		[HttpGet]
		public async Task<IEnumerable<Department>> GetDepartments()
		{
			var response = await _departmentService.GetDepartments();
			return response.Data;
		}
	}
}
