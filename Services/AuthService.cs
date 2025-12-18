using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAuth.Services
{
	/// <summary>
	/// Authentication service implementation
	/// </summary>
	public class AuthService : IAuthService
	{
		private readonly Dictionary<string, string> _users = new Dictionary<string, string>
		{
			{ "admin", "admin123" },
			{ "user", "user123" },
			{ "demo", "demo123" }
		};

		/// <summary>
		/// Validates user credentials
		/// </summary>
		public Task<bool> ValidateUser(string username, string password)
		{
			if (_users.TryGetValue(username, out string storedPassword))
			{
				return Task.FromResult(storedPassword == password);
			}
			return Task.FromResult(false);
		}
	}
}