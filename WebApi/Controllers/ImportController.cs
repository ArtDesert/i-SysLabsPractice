using CoreLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/import")]
	public class ImportController : Controller
	{
		private readonly IImportService _importService;
		//private readonly ILogger<ImportClass> _logger; // todo create ImportClass

		public ImportController(IImportService importService)
		{
			_importService = importService;
		}

		/// <summary>
		/// Импорт сведений о сотрудниках, подразделениях и проектах из внешней системы (json-файла).
		/// </summary>
		/// <param name="json"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<bool> ImportAsync(string jsonFileName)
		{
			var jsonFilePath = _importService.BuildJsonFilePath(jsonFileName);
			var response = await _importService.ImportDataFromJsonAsync(jsonFilePath);
			return response.Data;
		}
	}
}
