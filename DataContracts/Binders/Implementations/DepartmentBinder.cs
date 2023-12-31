﻿using DataAccessLayer.Repositories.Interfaces;
using DataContractsLayer.Binders.Interfaces;
using DataContractsLayer.DTO;
using DomainLayer.Entities.Models;

namespace DataContractsLayer.Binders.Implementations
{
	public class DepartmentBinder : IDepartmentBinder
	{
		private readonly IDepartmentRepository _departmentRepository;

		public DepartmentBinder(IDepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}

		public async Task<DepartmentDto> GetDtoFromEntityAsync(int entityId)
		{
			var department = await _departmentRepository.GetAsync(entityId);
			return new DepartmentDto(entityId, department.Name); //TODO
		}

		public async Task<Department> GetEntityFromDtoAsync(DepartmentDto dto)
		{
			var department = await _departmentRepository.GetAsync(dto.Id);
			return department; //TODO
		}
	}
}
