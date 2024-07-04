using System.ComponentModel.DataAnnotations;

namespace MTGTraderMarket.Components.Main
{
	public class RegisteringUser
	{
		public int UserId { get; set; }

		[Required(ErrorMessage = "Please specify a user name")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Please specify a password")]
		[StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 8 and 20 characters")]
		public string Password { get; set; }

		public List<string> UserCards = new List<string>();
	}
}
