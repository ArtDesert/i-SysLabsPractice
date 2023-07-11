using CoreLayer.Binders.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.DTO;
using DomainLayer.Entities.Models;

namespace CoreLayer.Binders.Implementations
{
	public class ProjectBinder : IProjectBinder
	{

		private readonly IProjectRepository _projectRepository;

		public ProjectBinder(IProjectRepository projectRepository)
		{
			_projectRepository = projectRepository;
		}

		public async Task<ProjectDto> GetDtoFromEntityAsync(int entityId)
		{
			var project = await _projectRepository.GetAsync(entityId);
			return new ProjectDto(entityId, project.Name); //TODO
		}

		public async Task<Project> GetEntityFromDtoAsync(ProjectDto dto)
		{
			var project = await _projectRepository.GetAsync(dto.Id);
			return project; //TODO
		}
	}
}
