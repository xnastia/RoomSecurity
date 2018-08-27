using System.Linq;
using Security.Entities.DB;

namespace Security.DataLayer.EF
{
    public class UserRepository : IUserRepository
    {
        public bool UserExistsByEmailAndPassword(string email, string password)
        {
            //TODO: replace with correct request and validation
            bool userExists;
            using (var securityDbContext = new SecurityDbContext())
            {
                userExists = securityDbContext.Users.Count(x => x.Email == email && password == x.Password) > 0;
            }
            return userExists;
        }
    }
}