using System.Linq;
using Security.Entities;
using Security.Entities.DB;

namespace Security.DataLayer.EF
{
    public class UserRepository : IUserRepository
    {
        public bool UserExistsByEmailAndPassword(string email, string password)
        {
            //TODO: replace with correct request and validation
            bool userExists;
            var hashedPass = HashCalculator.CalculateHash(password);
            using (var securityDbContext = new SecurityDbContext())
            {
                userExists = securityDbContext.Users.Count(x => x.Email == email && hashedPass == x.Password) > 0;
            }
            return userExists;
        }

        public void AddUser(string firstName, string lastName, string email, string password)
        {
            User user = new User(firstName, lastName, email, password);
            if (UserExistsByEmailAndPassword(email, password))
            {
                using (var securityDbContext = new SecurityDbContext())
                {
                    var users = securityDbContext.Set<User>();
                    users.Add(user);
                    securityDbContext.SaveChanges();
                }
            }
        }
    }
}