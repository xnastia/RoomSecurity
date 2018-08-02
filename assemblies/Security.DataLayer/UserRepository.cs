using System.CodeDom;
using System.Linq;

namespace Security.DataLayer
{
    public class UserRepository
    {
        //private SecurityDbContext _securityDbContext = new SecurityDbContext();

        public User UserByEmailAndPassword(string email, string password)
        {
            //TODO: replace with correct request and validation
            //return _securityDbContext.Users.FirstOrDefault(x => x.Email == email && password == x.Password);
            //_securityDbContext.Dispose();
            User user = null;
            using (var db = new SecurityDbContext())
            {
                user = db.Users.FirstOrDefault(x => x.Email == email && password == x.Password);
            }

            return user;
        }

        public bool IsUserExistsByEmailAndPassword(string email, string password)
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