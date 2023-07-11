using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class ProjectRepository : IProjectRepository
	{
		private readonly CompanyStructureContext _context;

		public ProjectRepository(CompanyStructureContext context)
		{
			_context = context;
		}

		public async Task<bool> AddAsync(Project entity)
		{
			var result = true;
			try
			{
				await _context.Projects.AddAsync(entity);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public async Task<Project?> GetAsync(int id)
		{
			return await _context.Projects
				.Include(x => x.Employees)
				.Where(x => x.Id == id)
				.FirstOrDefaultAsync();
		}
		public async Task<IEnumerable<Project>> SelectAsync(int pageNum, int pageSize)
		{
			return await _context.Projects
				.Skip(pageNum * pageSize)
				.Take(pageSize)
				.ToListAsync();
		}

		public async Task<bool> UpdateAsync(int id, string name, string projectCode) //todo null
		{
			var result = true;
			try
			{
				var project = await GetAsync(id);
				project.Name = name;
				project.ProjectCode = projectCode;
				_context.Update(project);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public async Task<bool> RemoveAsync(int id) //todo null
		{
			var result = true;
			try
			{
				var project = await GetAsync(id);
				_context.Projects.Remove(project);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
	}
}
