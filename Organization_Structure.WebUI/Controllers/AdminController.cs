using System.Linq;
using System.Web.Mvc;
using Organization_Structure.Domain.Abstract;
using Organization_Structure.Domain.Entities;

namespace Organization_Structure.WebUI.Controllers
{
	[Authorize]	
	public class AdminController : Controller
    {
		IEmployeeRepository repository;
	    IGroupRepository groupRepository;
		IDepartmentRepository depRepository;
		IPositionRepository posRepository;

		public AdminController(IEmployeeRepository repo, IGroupRepository grpDep,
			IDepartmentRepository depRep, IPositionRepository posRep)
		{
			repository = repo;
			groupRepository = grpDep;
			depRepository = depRep;
			posRepository = posRep;
		}


		public ViewResult Index()
		{
			return View(repository.Employees);
		}

		public ViewResult Edit(int? Id)
		{
			Employee employee = repository.Employees
				.FirstOrDefault(e => e.Id == Id);
			return View(employee);
		}

		public ViewResult Create()
		{
			return View("Edit", new Employee());
		}
	

		[HttpPost]
		public ActionResult Edit(Employee employee)
		{
			if (ModelState.IsValid)
			{
				repository.SaveEmployee(employee);
				TempData["message"] = string.Format("Employee  \"{0}\" has been saved", employee.FIO);
				return RedirectToAction("Index");
			}
			else
			{
				return View(employee);
			}
		}

		[HttpPost]
		public ActionResult Delete(int? id)
		{
			Employee deletedEmployee = repository.DeleteEmployee(id);
			if (deletedEmployee != null)
			{
				TempData["message"] = string.Format("Employee \"{0}\" has been deleted",
					deletedEmployee.FIO);
			}
			return RedirectToAction("Index");
		}

		public ViewResult EditGroup(int Id)
		{
			Group group = groupRepository.Groups
				.FirstOrDefault(g => g.Id == Id);
			return View(group);
		}


		[HttpPost]
		public ActionResult EditGroup(Group group)
		{
			if (ModelState.IsValid)
			{
				groupRepository.SaveGroup(group);
				TempData["message"] = string.Format("Group \"{0}\" has been saved", group.Title);
				return RedirectToAction("Index");
			}
			else
			{
				return View(group);
			}
		}


		public ViewResult CreateGroup()
		{
			return View("EditGroup", new Group());
		}


		[HttpPost]
		public ActionResult DeleteGroup(int Id)
		{
			if (repository.Employees.Where(s=>s.GroupID == Id).Count()!=0)
			{
				TempData["error"] = string.Format("Group {0}  can not be removed", groupRepository.Groups.FirstOrDefault(s => s.Id==Id).Title);
			}
			else
			{
				Group deletedGroup = groupRepository.DeleteGroup(Id);
				if (deletedGroup != null)
				{
					TempData["message"] = string.Format("Group \"{0}\" has been deleted",
						deletedGroup.Title);
				}
			}
			
			return RedirectToAction("Index");
		}


		public ViewResult EditDepartment(int Id)
		{
			Department department = depRepository.Departments
				.FirstOrDefault(g => g.Id == Id);
			return View(department);
		}


		[HttpPost]
		public ActionResult EditDepartment(Department department)
		{
			if (ModelState.IsValid)
			{
				depRepository.SaveDepartment(department);
				TempData["message"] = string.Format("Department \"{0}\" has been changed", department.Title);
				return RedirectToAction("Index");
			}
			else
			{
				return View(department);
			}
		}


		public ViewResult CreateDepartment()
		{
			return View("EditDepartment", new Department());
		}


		[HttpPost]
		public ActionResult DeleteDepartment(int Id)
		{
			if (groupRepository.Groups.Where(s => s.DepartmentId == Id).Count() != 0)
			{
				TempData["error"] = string.Format("Department  {0}  can not be removed",depRepository.Departments.FirstOrDefault(s => s.Id == Id).Title);
			}
			else
			{
				Department deletedDepartment = depRepository.DeleteDepartment(Id);
				if (deletedDepartment != null)
				{
					TempData["message"] = string.Format("Department \"{0}\" has been deleted",
						deletedDepartment.Title);
				}
			}

			return RedirectToAction("Index");
		}


		public ViewResult EditPosition(int Id)
		{
			Position position = posRepository.Positions
				.FirstOrDefault(g => g.Id == Id);
			return View(position);
		}


		[HttpPost]
		public ActionResult EditPosition(Position position)
		{
			if (ModelState.IsValid)
			{
				posRepository.SavePosition(position);
				TempData["message"] = string.Format("Position \"{0}\" has been changed", position.Description);
				return RedirectToAction("Index");
			}
			else
			{
				return View(position);
			}
		}

		public ViewResult CreatePosition()
		{
			return View("EditPosition", new Position());
		}


		[HttpPost]
		public ActionResult DeletePosition(int Id)
		{
			if (repository.Employees.Where(s => s.PositionId == Id).Count() != 0)
			{
				TempData["error"] = string.Format("Position {0}  can not be removed", posRepository.Positions.FirstOrDefault(s=>s.Id==Id).Description);
			}
			else
			{
				Position deletedPosition = posRepository.DeletePosition(Id);
				if (deletedPosition != null)
				{
					TempData["message"] = string.Format("Position \"{0}\" has benn deleted",
						deletedPosition.Description);
				}
			}

			return RedirectToAction("Index");
		}
	}
}