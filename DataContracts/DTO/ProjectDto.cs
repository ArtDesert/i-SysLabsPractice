namespace DataContractsLayer.DTO
{
	public class ProjectDto : BaseDto
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ProjectDto(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
