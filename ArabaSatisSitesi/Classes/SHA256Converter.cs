using System.Security.Cryptography;
using System.Text;

namespace ArabaSatisSitesi.Classes
{
    public class SHA256Converter
    {
        public static string ComputeSha256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();

                foreach (byte hashByte in hashBytes)
                {
                    builder.Append(hashByte.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
