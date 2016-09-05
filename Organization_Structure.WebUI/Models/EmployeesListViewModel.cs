using System.Collections.Generic;
using Organization_Structure.Domain.Entities;

namespace Organization_Structure.WebUI.Models
{
	public class EmployeesListViewModel
	{
		public IEnumerable<Employee> Employees { get; set; }
		public PagingInfo PagingInfo { get; set; }
		public int? CurrentGroup { get; set; }
	}
}