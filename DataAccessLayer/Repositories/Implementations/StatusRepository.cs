using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Entities.Models;

namespace DataAccessLayer.Repositories.Implementations
{
    public class StatusRepository : IStatusRepository
	{
		private readonly CompanyStructureContext _context;

		public StatusRepository(CompanyStructureContext context)
		{
			_context = context;
		}

		public Task<bool> Create(Status entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(Status entity)
		{
			throw new NotImplementedException();
		}

		public async Task<Status> Get(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Status>> Select()
		{
			throw new NotImplementedException();
		}
	}
}
