﻿using DomainLayer.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
	{
		Task<IEnumerable<Employee>> GetAllEmployees(Department department);
	}
}
