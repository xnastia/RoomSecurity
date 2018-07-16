using System.Linq;
using Security.Entities;

namespace Security.DataLayer
{
    public class UserRepository
    {
        private SecurityDbContext _securityDbContext = new SecurityDbContext();

        public User UserByEmailAndPassword(string email, string password)
        {
            //TODO: replace with correct request and validation
            return _securityDbContext.Users.FirstOrDefault(x => x.Email == email && password == x.Password);
        }
    }
}