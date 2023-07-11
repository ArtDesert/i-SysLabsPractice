using CoreLayer.Response;
using System.Text.Json.Nodes;

namespace CoreLayer.Services.Interfaces
{
	public interface IImportService
	{
		Task<IBaseResponse<bool>> ImportAsync(JsonObject json);
	}
}
