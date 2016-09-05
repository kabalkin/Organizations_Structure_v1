using System.Data.Entity.ModelConfiguration;
using Organization_Structure.Domain.Entities;

namespace Organization_Structure.Domain.Concrete
{
	public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
	{
		public EmployeeConfiguration()
		{
			this.Property(c => c.FIO).IsRequired().HasMaxLength(30);
		}
	}
}
