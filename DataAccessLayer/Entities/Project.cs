using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
	internal class Project
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ProjectCode { get; set; }
		public virtual List<Employee> Employees { get; set; }
	}
}
