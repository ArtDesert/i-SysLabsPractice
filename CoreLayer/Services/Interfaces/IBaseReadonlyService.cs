namespace CoreLayer.Services.Interfaces
{
	public interface IBaseReadonlyService<TEntity>
	{
		Task<TEntity> GetAsync(int id);
		Task<IEnumerable<TEntity>> SelectAsync();
	}
}
