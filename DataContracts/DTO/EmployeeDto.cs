namespace DataContractsLayer.DTO
{
	public class EmployeeDto : BaseDto
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public EmployeeDto(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
