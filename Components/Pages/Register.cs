using MTGTraderMarket.Components.Main;
using MTGTraderMarket.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components;


namespace MTGTraderMarket.Components.Pages
{
	public partial class Register
	{

		[Inject]
		ProtectedSessionStorage ProtectedSessionStorage { get; set; }

		private UserService userService = new UserService();

		public RegisteringUser registeringUser { get; set; } = new RegisteringUser();

		void RegisterUser()
		{
			User user = new User
			{
				UserId = 0,
				Username = registeringUser.UserName,
				Password = registeringUser.Password,
				CardIds = registeringUser.UserCards
			};

			try
			{
				userService.AddUser(user);
				ProtectedSessionStorage.SetAsync("user", user);
			}
			catch (Exception e)
			{
				Console.WriteLine("[Register.cs] -> Could not add user to database: " + e.Message);
				throw new Exception("Could not add user to database: " + e.Message);
			}
		}
	}
}
