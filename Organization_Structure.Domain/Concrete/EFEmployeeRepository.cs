using System.Collections.Generic;
using Organization_Structure.Domain.Abstract;
using Organization_Structure.Domain.Entities;

namespace Organization_Structure.Domain.Concrete
{
	public class EFEmployeeRepository : IEmployeeRepository
	{
		EFDbContext context = new EFDbContext();

		public IEnumerable<Employee> Employees
		{
			get { return context.Employees; }
		}

		public void SaveEmployee(Employee employee)
		{
			if (employee.Id == 0)
				context.Employees.Add(employee);
			else
			{
				Employee dbEntry = context.Employees.Find(employee.Id);
				if (dbEntry != null)
				{
					dbEntry.FIO = employee.FIO;
					dbEntry.GroupID = employee.GroupID;
					dbEntry.PositionId = employee.PositionId;
					
				}
			}
			context.SaveChanges();
		}

		public Employee DeleteEmployee(int? id)
		{
			Employee dbEntry = context.Employees.Find(id);
			if (dbEntry != null)
			{
				context.Employees.Remove(dbEntry);
				context.SaveChanges();
			}
			return dbEntry;
		}
	}
}
