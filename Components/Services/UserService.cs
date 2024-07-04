namespace MTGTraderMarket.Models

{
    public class UserService
    {
        private readonly DBContext dbContext;

        public UserService()
        {
            dbContext = new DBContext();
        }

        public User? GetUserById(int? id)
        {
            return dbContext.Users.Find(id);
        }

        public void AddUser(User user)
        {
            if (user.UserId == 0)
            {
                user.UserId = dbContext.Users.Any() ? dbContext.Users.Max(u => u.UserId) + 1 : 1;
            }
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public User GetUserByUsername(string username)
        {
            return dbContext.Users.FirstOrDefault(u => u.Username == username);
        }

        public List<List<string>?> GetUserCardIds(int userId)
        {
            return dbContext.Users.Where(uc => uc.UserId == userId).Select(uc => uc.CardIds).ToList();
        }
    }
}