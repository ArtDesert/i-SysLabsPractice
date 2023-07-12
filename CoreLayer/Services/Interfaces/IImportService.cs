using CoreLayer.Response;

namespace CoreLayer.Services.Interfaces
{
	public interface IImportService
	{
		Task<IBaseResponse<bool>> ImportDataFromJsonAsync(string jsonFilePath);
		string BuildJsonFilePath(string jsonFileName);
	}
}
