using CoreLayer.Response;
using CoreLayer.Services.Interfaces;
using System.Text.Json.Nodes;

namespace CoreLayer.Services.Implementations
{
	public class ImportService : IImportService
	{
		public async Task<IBaseResponse<bool>> ImportAsync(JsonObject json) //TODO
		{
			throw new NotImplementedException();
		}
	}
}
