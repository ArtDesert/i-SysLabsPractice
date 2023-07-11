using CoreLayer.Response;

namespace CoreLayer.Services.Interfaces
{
	public interface IBaseService<TEntity, TDto>
	{
		Task<IBaseResponse<bool>> CreateAsync(TEntity entity);
		Task<IBaseResponse<TDto>> GetAsync(int id);
		Task<IBaseResponse<bool>> DeleteAsync(int id);
	}
}
