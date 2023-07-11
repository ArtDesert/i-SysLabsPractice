using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class DepartmentRepository : IDepartmentRepository
	{
		private readonly CompanyStructureContext _context;

		public DepartmentRepository(CompanyStructureContext context)
		{
			_context = context;
		}

		public async Task<bool> AddAsync(Department entity)
		{
			var result = true;
			try
			{
				await _context.Departments.AddAsync(entity);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public async Task<Department?> GetAsync(int id)
		{
			return await _context.Departments
				.Include(x=>x.Employees)
				.Where(x => x.Id == id)
				.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Department>> SelectAsync(int pageNum, int pageSize)
		{
			return await _context.Departments
				.Skip(pageNum * pageSize)
				.Take(pageSize)
				.ToListAsync();
		}

		public async Task<bool> UpdateAsync(int id, string name, string departmentCode) //todo null
		{
			var result = true;
			try
			{
				var department = await GetAsync(id);
				department.Name = name;
				department.DepartmentCode = departmentCode;
				_context.Update(department);
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
				var department = await GetAsync(id);
				_context.Departments.Remove(department);
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
