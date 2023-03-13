using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Filtros_y_Seguridad.Encrypt
{
    public class AesEncrypt
    {
        private static readonly byte[] _salt = Encoding.ASCII.GetBytes("FiltroSeguridad");

        public static string EncryptString(string plainText, string password)
        {
            byte[] encryptedBytes;
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);

            using (Aes aes = Aes.Create())
            {
                var key = new Rfc2898DeriveBytes(password, _salt, 1000);
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);

                using (var encryptor = aes.CreateEncryptor())
                {
                    encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                }
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string DecryptString(string encryptedText, string password)
        {
            byte[] decryptedBytes;
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (Aes aes = Aes.Create())
            {
                var key = new Rfc2898DeriveBytes(password, _salt, 1000);
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);

                using (var decryptor = aes.CreateDecryptor())
                {
                    decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                }
            }

            return Encoding.Unicode.GetString(decryptedBytes);
        }

    }
}