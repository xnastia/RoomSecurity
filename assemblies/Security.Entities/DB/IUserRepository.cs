namespace Security.Entities.DB
{
    public interface IUserRepository
    {
        bool UserExistsByEmailAndPassword(string email, string password);
        void AddUser(string firstName, string lastName, string email, string password);
    }
}
