using System;

namespace Organization_Structure.WebUI.Models
{
	public class PagingInfo
	{	
		public int TotalEmployees { get; set; }

		public int EmployeesPerPage { get; set; }

		public int CurrentPage { get; set; }

		public int TotalPages
		{
			get { return (int)Math.Ceiling((decimal)TotalEmployees / EmployeesPerPage); }
		}
	}
}