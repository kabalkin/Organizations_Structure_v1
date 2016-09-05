using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Organization_Structure.Domain.Entities
{
	public class Group
	{
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }
		[Required(ErrorMessage = "Please, enter department id")]
		public int DepartmentId { get; set; }
		[Required(ErrorMessage = "Please, enter title")]
		public string Title { get; set; }
		[HiddenInput(DisplayValue = false)]
		public virtual List<Employee> Employees { get; set; }
	}
}