using System.Collections.Generic;
using Organization_Structure.Domain.Abstract;
using Organization_Structure.Domain.Entities;

namespace Organization_Structure.Domain.Concrete
{
	public class EFPositionsRepository : IPositionRepository
	{
		EFDbContext context = new EFDbContext();

		public IEnumerable<Position> Positions { get { return context.Positions; } }

		public void SavePosition(Position position)
		{
			if (position.Id == 0)
				context.Positions.Add(position);
			else
			{
				Position dbEntry = context.Positions.Find(position.Id);
				if (dbEntry != null)
				{
					dbEntry.Description = position.Description;
				}
			}
			context.SaveChanges();
		}

		public Position DeletePosition(int Id)
		{
			Position dbEntry = context.Positions.Find(Id);
			if (dbEntry != null)
			{
				context.Positions.Remove(dbEntry);
				context.SaveChanges();
			}
			return dbEntry;
		}
	}
}
