using System.Collections.Generic;
using System.Web.Mvc;
using Organization_Structure.Domain.Abstract;
using Organization_Structure.Domain.Entities;

namespace Organization_Structure.WebUI.Controllers
{
    public class NavController : Controller
    {
		private IGroupRepository repository;

		public NavController(IGroupRepository repo)
		{
			repository = repo;
		}

		public PartialViewResult Menu(int? group=null)
		{
			ViewBag.SelectedGroup = group;
			IEnumerable<Group> grops = repository.Groups;
			return PartialView(grops);
		}
	}
}