using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace DockSabbath.Helpers
{
    public class HashingHelper
    {
        public static string Hash(string data, string token)
        {
            string hash = null;
            try
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(token + data));
                    hash = BytesToHex(hashBytes);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return hash;
        }

        public static bool Verify(string hash, string data, string token)
        {
            string hashedData = Hash(data, token);
            return hash.Equals(hashedData, StringComparison.OrdinalIgnoreCase);
        }

        private static string BytesToHex(byte[] bytes)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString("x2"));
            }
            return result.ToString();
        }
    }
}
