using System.Collections.Generic;

namespace Organization_Structure.Domain.Entities
{
	public class Position
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public virtual List<Employee> Employees { get; set; }
	}
}