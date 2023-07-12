namespace DataAccessLayer.Repositories.Interfaces
{
	public interface IBaseRepository<TEntity>
	{
		Task<bool> AddAsync(TEntity entity);
		Task<TEntity?> GetAsync(int id);
		Task<IEnumerable<TEntity>> SelectAsync(int pageNum, int pageSize);
		Task<bool> RemoveAsync(int id);
	}
}
