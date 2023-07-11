using CoreLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/import")]
	public class ImportController : Controller
	{
		private readonly IImportService _importService;
		//private readonly ILogger<ImportClass> _logger;

		public ImportController(IImportService importService)
		{
			_importService = importService;
		}

		[HttpGet]
		public async Task<bool> ImportAsync(JsonObject json) //TODO
		{
			var response = await _importService.ImportAsync(json);
			return response.Data;
		}
	}
}
