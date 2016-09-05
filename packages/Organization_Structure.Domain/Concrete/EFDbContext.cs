using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organization_Structure.Domain.Entities;

namespace Organization_Structure.Domain.Concrete
{
	public class EFDbContext: DbContext
	{
		public EFDbContext() : base("OrganizationsStructure") { }

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Management> Managements { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Position> Positions { get; set; }
	}
}
