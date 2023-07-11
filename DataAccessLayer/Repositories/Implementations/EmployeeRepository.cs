using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Entities.Models;
using DomainLayer.TableInitializators;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
	{
		private readonly CompanyStructureContext _context;

		public EmployeeRepository(CompanyStructureContext context)
		{
			_context = context;
			StatusInitializator.GetInstance(_context).TryInitialize();
		}

		public async Task<bool> AddAsync(Employee entity)
		{
			var result = true;
			try
			{
				await _context.Employees.AddAsync(entity);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public async Task<Employee?> GetAsync(int id)
		{
			var result = await _context.Employees
				.Where(x => x.Id == id)
				.FirstOrDefaultAsync();
			return result;
		}

		public async Task<IEnumerable<Employee>> SelectAsync(int pageNum, int pageSize)
		{
			return await _context.Employees
				.Skip(pageNum * pageSize)
				.Take(pageSize)
				.ToListAsync();
		}

		public async Task<bool> UpdateAsync(int id, string name, string post, DateTime birthday, string email, string number) //todo null
		{
			var result = true;
			try
			{
				var employee = await GetAsync(id);
				employee.Name = name;
				employee.Post = post;
				employee.Birthday = birthday;
				employee.Email = email;
				employee.Number = number;
				_context.Update(employee);
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
				var employee = await GetAsync(id);
				_context.Employees.Remove(employee);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public async Task<IEnumerable<Employee>> SelectByFilterAsync(Expression<Func<Employee, bool>> filter, int pageNum, int pageSize)
		{
			return await _context.Employees
				.Where(filter)
				.Skip(pageNum * pageSize)
				.Take(pageSize)
				.ToListAsync();
		}
	}
}
