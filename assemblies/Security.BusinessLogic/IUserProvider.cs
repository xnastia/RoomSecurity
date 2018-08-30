namespace Security.BusinessLogic
{
    public interface IUserProvider
    {
        bool IsUserValid(string email, string password);
    }
}
