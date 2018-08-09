using Security.DataLayer;

namespace Security.BusinessLogic
{
    public class UserProvider
    {
        private readonly UserRepository _userRepository = new UserRepository();

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _userRepository.UserByEmailAndPassword(email, password);
        }

        public bool IsUserValid(string email, string password)
        {
            return _userRepository.IsUserExistsByEmailAndPassword(email, password);
        }
    }
}