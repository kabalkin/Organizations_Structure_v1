using System.Collections.Generic;
using Organization_Structure.Domain.Entities;

namespace Organization_Structure.Domain.Abstract
{
	public interface IEmployeeRepository
	{
		IEnumerable<Employee> Employees { get; }
		void SaveEmployee(Employee employee);
		Employee DeleteEmployee(int? id);
	}
}
