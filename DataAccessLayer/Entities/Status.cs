using System;

namespace DataAccessLayer.Entities
{
	internal class Status
	{
        public int Id { get; set; }
		public StatusToken StatusToken { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }

	enum StatusToken
	{
		Active,
		OnHoliday,
		Dismissed,
		Hospital,
		InDecree,
	}
}
