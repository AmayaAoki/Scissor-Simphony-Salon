using SiteASP.Interfaces;
using SiteASP.Models;

namespace SiteASP.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContent _appDBContent;
        public UserRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _appDBContent.User.ToList();
        }
        public User? Authenticate(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = _appDBContent.User.FirstOrDefault(u => u.Login == login);

            if (user == null || user.Password != password)
            {
                return null;
            }

            return user;
        }
        
    }
}
