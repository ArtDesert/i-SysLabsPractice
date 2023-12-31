﻿using CoreLayer.Services.Interfaces;
using DataContractsLayer.DTO;
using DomainLayer.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/projects")]
	public class ProjectController : Controller
	{
		private readonly IProjectService _projectService;
		private readonly ILogger<Project> _logger;

		public ProjectController(IProjectService projectService, ILogger<Project> logger)
		{
			_projectService = projectService;
			_logger = logger;
		}

		[HttpPost]
		public async Task<bool> AddProjectAsync(string name, string projectCode)
		{
			var project = new Project() { Name = name, ProjectCode = projectCode };
			var response = await _projectService.CreateAsync(project);
			return response.Data;
		}

		[HttpGet("{id}")]
		public async Task<ProjectDto> GetProjectByIdAsync(int id)
		{
			var response = await _projectService.GetAsync(id);
			return response.Data;
		}

		[HttpGet]
		public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync(int pageNum, int pageSize)
		{
			var response = await _projectService.GetProjectsAsync(pageNum, pageSize);
			return response.Data;
		}

		[HttpPut]
		public async Task<bool> UpdateProjectAsync(int id, string name, string projectCode)
		{
			var response = await _projectService.UpdateAsync(id, name, projectCode);
			return response.Data;
		}

		[HttpDelete("{id}")]
		public async Task<bool> DeleteProjectAsync(int id)
		{
			var response = await _projectService.DeleteAsync(id);
			return response.Data;
		}

		[HttpGet("{id}/employees")]
		public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesOnProjectAsync(int id, int pageNum, int pageSize)
		{
			var response = await _projectService.GetAllEmployeesOnProjectAsync(id, pageNum, pageSize);
			return response.Data;
		}
	}
}
