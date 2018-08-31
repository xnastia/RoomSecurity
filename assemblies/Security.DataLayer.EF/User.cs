using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

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
            set { _password = User.CalculateHash(value); }
        }


        public static string CalculateHash(string input)
        {
            SHA1 md5 = SHA1.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                stringBuilder.Append(i.ToString("X2"));
            }
            return stringBuilder.ToString();
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