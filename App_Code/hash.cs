using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//hashing staff
using System.Text;
using Konscious.Security.Cryptography;
using System.Security.Cryptography;
namespace AdvancedWebDevelopment.App_Code
{
    public class hash
    {
        public byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }

        public byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; 
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 1024; 
            return argon2.GetBytes(16);
        }

        public bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }
    }
}