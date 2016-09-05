using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	}
}
