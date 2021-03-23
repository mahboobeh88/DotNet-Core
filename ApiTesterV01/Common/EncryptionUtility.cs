using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiTesterV01.Common
{
    public class EncryptionUtility
    {
        public string Encription( string input)
        {
            using (var sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder str = new StringBuilder();
                
                for(int i = 0; i< bytes.Length; i++)
                {
                    str.Append(bytes[i].ToString("x2"));
                }
                
                return str.ToString();
            }

        }
        public string HashWithSalt(string input , string passSalt)
        {
            return Encription(input) + passSalt;
        }
    }
}
