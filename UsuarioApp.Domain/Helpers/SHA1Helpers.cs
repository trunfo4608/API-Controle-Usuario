using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioApp.Domain.Helpers
{
    public class SHA1Helpers
    {
        public static string Encrypt(string input)
        {
            using (var sha1 = SHA1.Create()) 
            {
                var inputsBytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = sha1.ComputeHash(inputsBytes);

                var stringBuilder = new StringBuilder();
                foreach (var item in hashBytes)
                {
                    stringBuilder.Append(item.ToString("x2"));
                }

                return stringBuilder.ToString();

            } 
        }
    }
}
