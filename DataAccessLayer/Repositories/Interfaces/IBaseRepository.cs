using DomainLayer.Entities;
using System;

namespace DataAccessLayer.Repositories.Interfaces
{
	public interface IBaseRepository<TEntity>
	{
		Task<bool> Create(TEntity entity);
		Task<TEntity> Get(int id);
		Task<IEnumerable<TEntity>> Select();
		Task<bool> Delete(TEntity entity);
	}
}
