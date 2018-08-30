using Security.Entities.DB;

namespace Security.BusinessLogic
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userRepository;

        public UserProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsUserValid(string email, string password)
        {
            return _userRepository.UserExistsByEmailAndPassword(email, password);
        }
    }
}