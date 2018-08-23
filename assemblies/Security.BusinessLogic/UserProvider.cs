using Security.DataLayer;
using Security.Entities.DB;

namespace Security.BusinessLogic
{
    public class UserProvider
    {
        private readonly IUserRepository _userRepository;

        public UserProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserProvider()
        {
            _userRepository = new UserRepository();
        }

        public bool IsUserValid(string email, string password)
        {
            return _userRepository.UserExistsByEmailAndPassword(email, password);
        }
    }
}