using CoreLayer.Services.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Entities.Models;
using DomainLayer.Response;
using static DomainLayer.Enums.StatusCode;
using System;

namespace CoreLayer.Services.Implementations
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IDepartmentRepository _departmentRepository;

		public DepartmentService(IDepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}

		public async Task<IBaseResponse<IEnumerable<Department>>> GetDepartments()
		{
			var baseResponse = new BaseResponse<IEnumerable<Department>>();
			try
			{
				var departments = await _departmentRepository.Select();
				if (departments.Count() == 0)
				{
					baseResponse.Description = "Найдено 0 элементов";
					baseResponse.StatusCode = OK; //TODO
					return baseResponse;
					
				}
				baseResponse.Data = departments;
				baseResponse.StatusCode = OK;
				return baseResponse;
			}
			catch (Exception ex)
			{

				return new BaseResponse<IEnumerable<Department>>()
				{
					Description = $"[GetDepartments] : {ex.Message}"
				};
			}
		}
	}
}
