using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Organization_Structure.Domain.Entities
{
	public class Department
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Please, enter management id")]
		public int ManagementId { get; set; }
		[Required(ErrorMessage = "Please, enter title")]
		public string Title { get; set; }
		public virtual List<Group> Groups { get; set; }
	}
}