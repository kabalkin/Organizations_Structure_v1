using System.Collections.Generic;

namespace Organization_Structure.Domain.Entities
{
	public class Group
	{
		public int Id { get; set; }
		public int DepartmentId { get; set; }
		public string Title { get; set; }
		public virtual List<Employee> Employees { get; set; }
	}
}