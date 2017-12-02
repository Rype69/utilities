namespace RyanPenfold.Utilities.Security
{
    using System;
    using System.Security.Cryptography;

    public class Hasher
    {
        public static string Hash(string password, Guid salt)
        {
            // Generate a random salt
            var saltBytes = Guid.NewGuid().ToByteArray();
            
            // Generate the hash
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes) { IterationCount = 10000 };
            var hash = rfc2898DeriveBytes.GetBytes(20);
            
            // Return the salt and the hash
            return $"{Convert.ToBase64String(saltBytes)}|{Convert.ToBase64String(hash)}";
        }
    }
}
