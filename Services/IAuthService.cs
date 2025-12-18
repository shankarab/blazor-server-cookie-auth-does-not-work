using System.Threading.Tasks;

namespace BlazorAuth.Services
{
	/// <summary>
	/// Authentication service interface
	/// </summary>
	public interface IAuthService
	{
		/// <summary>
		/// Validates user credentials
		/// </summary>
		Task<bool> ValidateUser(string username, string password);
	}
}