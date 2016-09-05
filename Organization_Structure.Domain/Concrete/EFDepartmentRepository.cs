using System.Collections.Generic;
using Organization_Structure.Domain.Abstract;
using Organization_Structure.Domain.Entities;

namespace Organization_Structure.Domain.Concrete
{
	public class EFDepartmentRepository: IDepartmentRepository
	{
		EFDbContext context = new EFDbContext();

		public IEnumerable<Department> Departments
		{
			get { return context.Departments; }
		}


		public void SaveDepartment(Department department)
		{
			if (department.Id == 0)
				context.Departments.Add(department);
			else
			{
				Department dbEntry = context.Departments.Find(department.Id);
				if (dbEntry != null)
				{
					dbEntry.Id = department.Id;
					dbEntry.Title = department.Title;
					dbEntry.ManagementId = department.ManagementId;
				}
			}
			context.SaveChanges();
		}

		public Department DeleteDepartment(int Id)
		{
			Department dbEntry = context.Departments.Find(Id);
			if (dbEntry != null)
			{
				context.Departments.Remove(dbEntry);
				context.SaveChanges();
			}
			return dbEntry;
		}
	}
}
