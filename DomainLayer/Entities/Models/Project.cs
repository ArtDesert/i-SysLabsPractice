using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProjectCode { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
