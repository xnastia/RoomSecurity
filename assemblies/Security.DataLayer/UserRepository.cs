using Security.Entities;

namespace Security.DataLayer
{
    public class UserRepository
    {
        public User UserByEmailAndPassword(string email, string password)
        {
            //TODO: replace with correct request and validation
            if (email == "ivanov@ukr.net" && password == "1234")
                return new User
                {
                    Email = email,
                    FirstName = "Ivan",
                    LastName = "Ivanov"
                };
            return null;
        }
    }
}