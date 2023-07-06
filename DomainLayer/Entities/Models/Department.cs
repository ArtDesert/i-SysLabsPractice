using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DepartmentCode { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
