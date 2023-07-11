using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class StatusRepository : IStatusRepository
	{
		private readonly CompanyStructureContext _context;

		public StatusRepository(CompanyStructureContext context)
		{
			_context = context;
		}

		public async Task<Status?> GetAsync(int id)
		{
			return await _context.Statuses.
				Where(x => x.Id == id).
				FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Status>> SelectAsync()
		{
			return await _context.Statuses.ToListAsync();
		}


	}
}
