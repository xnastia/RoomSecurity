﻿using Security.DataLayer;

namespace Security.BusinessLogic
{
    public class SecurityApi
    {
        private readonly UserProvider _userProvider = new UserProvider();

        public User GetUser(string email, string password)
        {
            return _userProvider.GetUserByEmailAndPassword(email, password);
        }

        public bool IsValidtUser(string email, string password)
        {
            return _userProvider.IsUserValid(email, password);
        }
    }
}