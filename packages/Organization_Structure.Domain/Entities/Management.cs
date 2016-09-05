using System.Collections.Generic;

namespace Organization_Structure.Domain.Entities
{
	public class Management
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public virtual List<Department> Departments { get; set; }
	}
}