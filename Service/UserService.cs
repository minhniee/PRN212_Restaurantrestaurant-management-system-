using Repository;
using Repository.Entities;

namespace Service
{
    public class UserService
    {
        private UserContainer _container = new();

        public User IsUserValid(string userName, string password)
        {
            return _container.IsValidUser(userName, password);
        }
    }
}
