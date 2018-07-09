using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Security.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password;

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}