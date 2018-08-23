namespace Security.Entities.DB
{
    public interface IUserRepository
    {
        bool UserExistsByEmailAndPassword(string email, string password);
    }
}
