using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organization_Structure.Domain.Entities;

namespace Organization_Structure.Domain.Abstract
{
	public interface IEmployeeRepository
	{
		IEnumerable<Employee> Employees { get; }
	}
}
