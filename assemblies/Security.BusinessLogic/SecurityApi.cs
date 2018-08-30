namespace Security.BusinessLogic
{
    public class SecurityApi
    {
        private readonly UserProvider _userProvider;

        public bool IsValidUser(string email, string password)
        {
            return _userProvider.IsUserValid(email, password);
        }
    }
}