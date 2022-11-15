using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core.Common
{
    public static class Security
    {
        public static string EncryptToBase64(this string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string DecryptToBase64(this string plainText)
        {
            var base64EndodedBytes = Convert.FromBase64String(plainText);
            return Encoding.UTF8.GetString(base64EndodedBytes);
        }
    }
}
