using CoreLayer.Response;
using DomainLayer.Entities.Models;

namespace CoreLayer.Services.Interfaces
{
    public interface IStatusService
	{
		Task<IBaseResponse<Status>> GetAsync(int id);
		Task<IBaseResponse<IEnumerable<Status>>> GetStatusesAsync();
	}
}
