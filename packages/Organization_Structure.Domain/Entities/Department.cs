using System.Collections.Generic;

namespace Organization_Structure.Domain.Entities
{
	public class Department
	{
		public int Id { get; set; }
		public int ManagementId { get; set; }
		public string Title { get; set; }
		public virtual List<Group> Groups { get; set; }
	}
}