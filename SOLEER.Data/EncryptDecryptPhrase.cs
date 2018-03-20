using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SOLEER.Data
{
    class EncryptDecryptPhrase 
    {
        public static string Encrypt(string text, byte[] key, byte[] iv)
        {
            try
            {
                return Convert.ToBase64String(Transform(UTF8Encoding.UTF8.GetBytes(text), TripleDESCryptoServiceProvider.Create().CreateEncryptor(key, iv)));
            }
            catch (Exception)
            {
                return "¡Error...!";
            }
        }

        public static string Decrypt(string text, byte[] key, byte[] iv)
        {
            try
            {
                return UTF8Encoding.UTF8.GetString(Transform(Convert.FromBase64String(text), TripleDESCryptoServiceProvider.Create().CreateDecryptor(key, iv)));
            }
            catch (Exception)
            {
                return "¡Error...!";
            }
        }

        private static byte[] Transform(byte[] input, ICryptoTransform CryptoTransform)
        {
            //create the necessary streams
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(memStream, CryptoTransform, CryptoStreamMode.Write);
            cryptStream.Write(input, 0, input.Length);
            cryptStream.FlushFinalBlock();
            memStream.Position = 0;
            byte[] result = new byte[memStream.Length];
            memStream.Read(result, 0, result.Length);
            memStream.Close();
            cryptStream.Close();
            return result;
        }
    }
}
