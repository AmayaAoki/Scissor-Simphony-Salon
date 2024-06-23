using SiteASP.Models;

namespace SiteASP.Data.Repository
{
    public interface IUserRepository
    {
        User? Authenticate(string login, string password);
        IEnumerable<User> GetAllUsers();
    }
}
