using MTGTraderMarket.Components.Main;
using MTGTraderMarket.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components;

namespace MTGTraderMarket.Components.Pages
{
    public partial class Login
    {
        [Inject]
        ProtectedSessionStorage ProtectedSessionStorage { get; set; }

        private UserService userService = new UserService();

        public RegisteringUser logingUser { get; set; } = new RegisteringUser();

        void LoginUser()
        {
            User user = new User {
                UserId = 0,
                Username = logingUser.UserName,
                Password = logingUser.Password,
                CardIds = logingUser.UserCards
            };
            
            try {
                User? dbUser = userService.GetUserByUsername(user.Username);
                if (dbUser != null && dbUser.Password == user.Password) {
                    ProtectedSessionStorage.SetAsync("user", dbUser);
                }
            } catch (Exception e) {
                Console.WriteLine("[Login.cs] -> Could not login user: " + e.Message);
                throw new Exception("Could not login user: " + e.Message);
            }

           
        }
    }
}