using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Organization_Structure.Domain.Entities
{
	public class Employee
	{
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }
		[Required(ErrorMessage = "Please, enter group Id")]
		public int GroupID { get; set; }
		[Required(ErrorMessage = "Please, enter FIO")]
		public string FIO { get; set; }
		[Required(ErrorMessage = "Plesase, enter position Id")]
		public int PositionId { get; set; }
	}
}