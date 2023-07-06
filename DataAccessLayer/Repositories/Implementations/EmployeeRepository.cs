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
    public class EmployeeRepository : IEmployeeRepository
	{
		private readonly CompanyStructureContext _context;

		public EmployeeRepository(CompanyStructureContext context)
		{
			_context = context;
		}

		public async Task<bool> Create(Employee entity)
		{
			await _context.Employees.AddAsync(entity);
			return true;
		}

		public async Task<bool> Delete(Employee entity)
		{
			_context.Employees.Remove(entity);
			return true;
		}

		public async Task<Employee> Get(int id)
		{
			return await _context.Employees.FindAsync(id);
		}

		public async Task<IEnumerable<Employee>> GetAllSubordinates(Employee employee)
		{
			return await _context.Employees.Where(e => e.SupervisorId == employee.Id).ToListAsync();
		}

		public async Task<IEnumerable<Employee>> Select()
		{
			return await _context.Employees.ToListAsync();
		}
	}
}
