using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Commom.Security
{
    public class Cryptography
    {
        public static string CryptographPassword(string password)
        {
            byte[] encrypted;
            byte[] key = new byte[32];
            byte[] IV = new byte[16];

            Encoding.UTF8.GetBytes("Lulu").CopyTo(key, 0);
            Encoding.UTF8.GetBytes("Chandler").CopyTo(IV, 0);

            using (Aes myAes = Aes.Create())
            {
                encrypted = EncryptStringToBytes_Aes(password, key, IV);
            }
            return Convert.ToBase64String(encrypted);
        }

        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }
    }
}
