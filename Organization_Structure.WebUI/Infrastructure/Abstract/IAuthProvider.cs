namespace Organization_Structure.WebUI.Infrastructure.Abstract
{
	public interface IAuthProvider
	{
		bool Authenticate(string username, string password);
	}
}
