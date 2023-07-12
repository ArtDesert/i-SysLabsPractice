using DomainLayer.Entities.Models;
using DomainLayer.Enums;
using System;

namespace DomainLayer.Entities.Models
{
    public class Status
    {
        public int Id { get; set; }
        public StatusToken Name { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
