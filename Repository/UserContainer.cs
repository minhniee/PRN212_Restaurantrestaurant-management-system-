using Repository.Entities;

namespace Repository
{
    public class UserContainer
    {
        private RestaurantsManagerV2Context _context;

        public User IsValidUser(string userName, string password)
        {
            _context = new RestaurantsManagerV2Context();

            var user = _context.Users.FirstOrDefault(x => x.Username == userName && x.Password == password);
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}
