using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//hashing staff
using System.Text;
using Konscious.Security.Cryptography;
using System.Security.Cryptography;

namespace PasswordHashing
{
    public class Hash
    {
        //generates random salt 
        public static byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }

        //convert string to array bytes
        public static byte[] ConvertString(string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            return bytes;
        }   

        public static byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; 
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 1024; 
            return argon2.GetBytes(16);
        }

        public static bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }

        public static string HashPassword2(string password)
        {
            var salt = CreateSalt();
            //main hashing part (from string value)
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8;
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 1024;
            var Hashed = argon2.GetBytes(16);
            //storing of salt 
            //array for combining salt and hash value
            byte[] PasswordWSalt = new byte[salt.Length + Hashed.Length];
            //appendding to array
            for (int i=0;i<Hashed.Length;i++)
                PasswordWSalt[i] = Hashed[i];
            for (int i = 0; i < salt.Length; i++)
                PasswordWSalt[Hashed.Length + i] = salt[i];
            //converting to string
            string h = Convert.ToBase64String(PasswordWSalt);
            //Returns a string of hashedpassed w stored salt
            return h;
        }

        public static bool VerifyHash2(string passwordToCheck, string storedHash)
        {
    
            byte[] hashWSalt = Convert.FromBase64String(storedHash);


            //To get salt (16)
            byte[] salt = new byte[16];
            for (int i=salt.Length-1;i >= 0;i--)
            {
                //check last element in stored hash
                var last = hashWSalt.Last();
                salt[i] = last;
                //removing last element 
                hashWSalt = hashWSalt.Skip(hashWSalt.Length - 1).ToArray();
            }
            //hashing the inputed password 
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(passwordToCheck));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8;
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 1024;
            var Hashed = argon2.GetBytes(16);
            return hashWSalt.SequenceEqual(Hashed);

        }
    } 
}