namespace DataContractsLayer.Binders.Interfaces
{
	public interface IBaseBinder<TEntity, TDto>
	{
		public Task<TDto> GetDtoFromEntityAsync(int entityId);
		public Task<TEntity> GetEntityFromDtoAsync(TDto dto);
	}
}
