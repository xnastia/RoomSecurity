using Security.DataLayer;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class SecurityApi
    {
        private readonly UserProvider _userProvider = new UserProvider();

        public bool IsValidUser(string email, string password)
        {
            return _userProvider.IsUserValid(email, password);
        }
    }
}