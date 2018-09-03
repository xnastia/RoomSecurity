using System.ComponentModel.DataAnnotations;
using Security.Entities;

namespace Security.DataLayer.EF
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public string Email { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        private string _password;

        [DataType(DataType.Password)]
        public string Password
        {
            get { return _password; }
            set { _password = HashCalculator.CalculateHash(value); }
        }
        
        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}