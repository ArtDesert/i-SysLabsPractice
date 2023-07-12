using CoreLayer.Response;
using CoreLayer.Services.Interfaces;
using DomainLayer.Entities.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using static DomainLayer.Enums.ResponseStatusCode;

namespace CoreLayer.Services.Implementations
{
	public class ImportService : IImportService
	{
		private readonly CompanyStructureContext _context;

		public ImportService(CompanyStructureContext context)
		{
			_context = context;
		}

		public string BuildJsonFilePath(string jsonFileName)
		{
			var currentDir = Directory.GetCurrentDirectory();
            var dirInfo = new DirectoryInfo(currentDir);
			var jsonFilePatn = Path.Combine(dirInfo.Parent.FullName, string.Format("CoreLayer\\JsonFiles\\{0}", jsonFileName));
            return jsonFilePatn;
		}

		public async Task<IBaseResponse<bool>> ImportDataFromJsonAsync(string jsonFilePath) //TODO
		{
			var response = new BaseResponse<bool>();
			try
			{
				//var pattern = @"";
				var jsonData = File.ReadAllText(jsonFilePath);
				var options = new JsonSerializerOptions { WriteIndented = true };
				//var employees = JsonConvert.DeserializeObject<List<Employee>>(jsonData);
				//await _context.Employees.AddRangeAsync(employees);
				var departments = JsonSerializer.Deserialize<List<Department>>(jsonData, options);
				await _context.Departments.AddRangeAsync(departments);
				//var projects = JsonConvert.DeserializeObject<List<Project>>(jsonData);
				//await _context.Projects.AddRangeAsync(projects);
				await _context.SaveChangesAsync();
				response.StatusCode = OK;
				response.Description = "Данные успешно импортированы";
				response.Data = true;
			}
			catch (Exception ex)
			{
				response.StatusCode = UnknownError;
				response.Data = false;
				response.Description = $"[ImportDataFromJsonAsync] : {ex.Message}";
			}
			return response;
		}
	}
}
