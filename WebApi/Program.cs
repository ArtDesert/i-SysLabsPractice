using CoreLayer.Services.Implementations;
using CoreLayer.Services.Interfaces;
using DataAccessLayer.Repositories.Implementations;
using DataAccessLayer.Repositories.Interfaces;
using DataContractsLayer.Binders.Implementations;
using DataContractsLayer.Binders.Interfaces;
using DomainLayer.Entities.Models;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
	var builder = WebApplication.CreateBuilder(args);

	// Add services to the container.

	builder.Services.AddControllers();
	// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();

	// NLog: Setup NLog for Dependency injection
	builder.Logging.ClearProviders();
	builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
	builder.Host.UseNLog();

	builder.Services.AddDbContext<CompanyStructureContext>(optionsBuilder =>
		optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("NpgsqlConnection")), ServiceLifetime.Transient, ServiceLifetime.Transient);

	builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
	builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
	builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
	builder.Services.AddScoped<IStatusRepository, StatusRepository>();

	builder.Services.AddScoped<IDepartmentService, DepartmentService>();
	builder.Services.AddScoped<IEmployeeService, EmployeeService>();
	builder.Services.AddScoped<IProjectService, ProjectService>();
	builder.Services.AddScoped<IStatusService, StatusService>();
	builder.Services.AddScoped<IImportService, ImportService>();

	builder.Services.AddScoped<IDepartmentBinder, DepartmentBinder>();
	builder.Services.AddScoped<IEmployeeBinder, EmployeeBinder>();
	builder.Services.AddScoped<IProjectBinder, ProjectBinder>();

	var app = builder.Build();

	app.Services.GetRequiredService<CompanyStructureContext>().Database.Migrate();

	//await StatusInitializator.TryInitializeAsync(); //undone

	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseHttpsRedirection();

	app.UseAuthorization();

	app.MapControllers();

	app.Run();

}
catch (Exception ex)
{
	// NLog: catch setup errors
	logger.Error(ex, "Stopped program because of exception");
	throw;
}
finally
{
	// Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
	LogManager.Shutdown();
}