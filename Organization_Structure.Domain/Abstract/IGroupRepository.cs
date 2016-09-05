using System.Collections.Generic;
using Organization_Structure.Domain.Entities;

namespace Organization_Structure.Domain.Abstract
{
	public interface IGroupRepository
	{
		IEnumerable<Group> Groups { get; }
		void SaveGroup(Group group);
		Group DeleteGroup(int Id);
	}
}
