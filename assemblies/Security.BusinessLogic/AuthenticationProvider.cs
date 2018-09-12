using System;
using System.Collections.Generic;
using System.Linq;

namespace Security.BusinessLogic
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private Dictionary<string, string> tokens = new Dictionary<string, string>();

        public string GetNewUserToken(string email)
        {
            string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            tokens[email] = token;
            return token;
        }

        public string GetUserByToken(string token)
        {
            return tokens.FirstOrDefault(tok => tok.Value == token).Key;
        }
    }
}