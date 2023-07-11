using CoreLayer.Binders.Implementations;
using CoreLayer.Binders.Interfaces;
using CoreLayer.Services.Implementations;
using CoreLayer.Services.Interfaces;
using DataAccessLayer.Repositories.Implementations;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.Entities.Models;
using DomainLayer.TableInitializators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

builder.Services.AddSingleton<IStatusInitializator, StatusInitializator>();

var app = builder.Build();

app.Services.GetRequiredService<CompanyStructureContext>().Database.Migrate();

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
