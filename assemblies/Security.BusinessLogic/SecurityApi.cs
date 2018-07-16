using Security.Entities;

namespace Security.BusinessLogic
{
    public class SecurityApi
    {
        private readonly UserProvider _userProvider = new UserProvider();

        public User GetUser(string email, string password)
        {
            return _userProvider.GetUserByEmailAndPassword(email, password);
        }
    }
}