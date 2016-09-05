using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Organization_Structure.Domain.Entities
{
	public class Management
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Please, enter title")]
		public string Title { get; set; }
		public virtual List<Department> Departments { get; set; }
	}
}