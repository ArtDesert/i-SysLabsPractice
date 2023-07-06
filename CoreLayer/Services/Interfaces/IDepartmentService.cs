using DomainLayer.Entities.Models;
using DomainLayer.Response;
using System;

namespace CoreLayer.Services.Interfaces
{
	public interface IDepartmentService
	{
		Task<IBaseResponse<IEnumerable<Department>>> GetDepartments();
	}
}
