using System.Collections.Generic;
using Organization_Structure.Domain.Entities;

namespace Organization_Structure.Domain.Abstract
{
	public interface IPositionRepository
	{
		IEnumerable<Position> Positions { get; }
		void SavePosition(Position position);
		Position DeletePosition(int Id);
	}
}
