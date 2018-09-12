namespace Security.BusinessLogic
{
    public interface IAuthenticationProvider
    {
        string GetNewUserToken(string email);

        string GetUserByToken(string token);
    }
}