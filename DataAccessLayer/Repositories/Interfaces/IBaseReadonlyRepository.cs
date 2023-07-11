namespace DataAccessLayer.Repositories.Interfaces
{
	public interface IBaseReadonlyRepository<TEntity>
	{
		Task<TEntity?> GetAsync(int id);
		Task<IEnumerable<TEntity>> SelectAsync();
	}
}
