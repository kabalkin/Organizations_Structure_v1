using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Organization_Structure.Domain.Entities
{
	public class Position
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Please, enter description")]
		public string Description { get; set; }
		public virtual List<Employee> Employees { get; set; }
	}
}