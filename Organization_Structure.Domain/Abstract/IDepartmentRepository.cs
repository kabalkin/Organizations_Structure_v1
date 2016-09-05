using System.Collections.Generic;
using Organization_Structure.Domain.Entities;

namespace Organization_Structure.Domain.Abstract
{
	public interface IDepartmentRepository
	{
		IEnumerable<Department> Departments { get; }
		void SaveDepartment(Department department);
		Department DeleteDepartment(int Id);
	}
}
