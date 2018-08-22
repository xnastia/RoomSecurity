using Security.DataLayer;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class UserProvider
    {
        private readonly UserRepository _userRepository = new UserRepository();

        public bool IsUserValid(string email, string password)
        {
            return _userRepository.UserExistsByEmailAndPassword(email, password);
        }
    }
}