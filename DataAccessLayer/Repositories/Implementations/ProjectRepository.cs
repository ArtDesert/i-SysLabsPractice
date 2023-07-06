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
    public class ProjectRepository : IProjectRepository
	{
		private readonly CompanyStructureContext _context;

		public ProjectRepository(CompanyStructureContext context)
		{
			_context = context;
		}

		public async Task<bool> Create(Project entity)
		{
			await _context.Projects.AddAsync(entity);
			return true;
		}

		public async Task<bool> Delete(Project entity)
		{
			_context.Projects.Remove(entity);
			return true;
		}

		public async Task<Project> Get(int id)
		{
			return await _context.Projects.FindAsync(id);
		}

		public async Task<IEnumerable<Employee>> GetAllEmployees(Project project)
		{
			return await _context.Employees.Where(e => e.Projects.Contains(project)).ToListAsync();
		}

		public async Task<IEnumerable<Project>> Select()
		{
			return await _context.Projects.ToListAsync();
		}
	}
}
