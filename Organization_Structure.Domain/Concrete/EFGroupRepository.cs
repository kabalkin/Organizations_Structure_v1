using System.Collections.Generic;
using Organization_Structure.Domain.Abstract;
using Organization_Structure.Domain.Entities;

namespace Organization_Structure.Domain.Concrete
{
	public class EFGroupRepository : IGroupRepository
	{
		EFDbContext context = new EFDbContext();

		public IEnumerable<Group> Groups
		{
			get { return context.Groups; }
		}

		public void SaveGroup(Group group)
		{
			if (group.Id == 0)
				context.Groups.Add(group);
			else
			{
				Group dbEntry = context.Groups.Find(group.Id);
				if (dbEntry != null)
				{
					dbEntry.Title = group.Title;
					dbEntry.DepartmentId = group.DepartmentId;
				}
			}
			context.SaveChanges();
		}

		public Group DeleteGroup(int Id)
		{
			Group dbEntry = context.Groups.Find(Id);
			if (dbEntry != null)
			{
				context.Groups.Remove(dbEntry);
				context.SaveChanges();
			}
			return dbEntry;
		}
	}
}
