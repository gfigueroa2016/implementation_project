using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJMaxStore.Models
{
    //La clase SHA256 se usa para convertir el password usando criptografia y encriptarlo
    public class SHA256
    {
        public static string Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA256.Create();
            var encoder = new System.Text.ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }
    }
}