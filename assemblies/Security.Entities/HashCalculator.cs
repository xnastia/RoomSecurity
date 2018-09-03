using System.Security.Cryptography;
using System.Text;

namespace Security.Entities
{
    public class HashCalculator
    {
        public static string CalculateHash(string input)
        {
            var md5 = SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
                stringBuilder.Append(i.ToString("X2"));
            return stringBuilder.ToString();
        }
    }
}