using System.Data.Entity;
using Organization_Structure.Domain.Entities;

namespace Organization_Structure.Domain.Concrete
{
	public class EFDbContext : DbContext
	{
		public EFDbContext() : base("OrganizationStructure")
		{
		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Management> Managements { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Position> Positions { get; set; }


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new EmployeeConfiguration());
		}

	}
}
