using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Implementations
{
    public class DepartmentRepository : IDepartmentRepository
	{
		private readonly CompanyStructureContext _context;

		public DepartmentRepository(CompanyStructureContext context)
		{
			_context = context;
		}

		public async Task<bool> Create(Department entity)
		{
			await _context.Departments.AddAsync(entity);
			return true; //TODO
		}

		public async Task<bool> Delete(Department entity)
		{
			_context.Departments.Remove(entity);
			return true; //TODO
		}

		public async Task<Department> Get(int id)
		{
			return await _context.Departments.FindAsync(id);
		}

		public async Task<IEnumerable<Employee>> GetAllEmployees(Department department)
		{
			return await _context.Employees.Where(e => e.DepartmentId == department.Id).ToListAsync();
		}

		public async Task<IEnumerable<Department>> Select()
		{
			return await _context.Departments.ToListAsync();
		}
	}
}
