namespace Organization_Structure.Domain.Entities
{
	public class Employee
	{
		public int Id { get; set; }
		public int GroupID { get; set; }
		public string FIO { get; set; }
		public int PositionId { get; set; }
	}
}