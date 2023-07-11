using CoreLayer.Response;
using CoreLayer.Services.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Entities.Models;

namespace CoreLayer.Services.Implementations
{
	public class StatusService : IStatusService
	{
		private readonly IStatusRepository _statusRepository;

		public StatusService(IStatusRepository statusRepository)
		{
			_statusRepository = statusRepository;
		}

		public async Task<IBaseResponse<Status>> GetAsync(int id)
		{
			await _statusRepository.GetAsync(id);
			return new BaseResponse<Status>();
		}

		public async Task<IBaseResponse<IEnumerable<Status>>> GetStatusesAsync()
		{
			await _statusRepository.SelectAsync();
			return new BaseResponse<IEnumerable<Status>>();
		}
	}
}
