using System.Linq;
using System.Web.Mvc;
using Organization_Structure.Domain.Abstract;
using Organization_Structure.WebUI.Models;

namespace Organization_Structure.WebUI.Controllers
{
	public class EmployeeController : Controller
	{
		private IEmployeeRepository repository;
		private int pageSize = 6;

		public EmployeeController(IEmployeeRepository repo)
		{
			repository = repo;
		}

		public ViewResult List(int? group, int page = 1)
		{
			EmployeesListViewModel model = new EmployeesListViewModel
			{
				Employees = repository.Employees
					.Where(g => group == null || g.GroupID == group)
					.OrderBy(e => e.Id)
					.Skip((page - 1)*pageSize)
					.Take(pageSize),
				PagingInfo = new PagingInfo
				{
					CurrentPage = page,
					EmployeesPerPage = pageSize,
					TotalEmployees = group == null
						? repository.Employees.Count()
						: repository.Employees.Where(game => game.GroupID == group).Count()
				},
				CurrentGroup = group
			};
			return View(model);
		}
	}
}