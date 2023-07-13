namespace DataContractsLayer.DTO
{
	public class DepartmentDto : BaseDto
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public DepartmentDto(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
