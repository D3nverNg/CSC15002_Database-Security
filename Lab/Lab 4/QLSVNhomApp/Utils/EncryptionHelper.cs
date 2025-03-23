using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace QLSVNhomApp.Utils
{
    public static class EncryptionHelper
    {
        private static readonly string KeyStorageFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PrivateKeys.txt");

        public static byte[] HashPasswordSHA1(string input)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }

        public static (byte[] encryptedData, string publicKeyXml, string privateKeyXml) EncryptDataRSA(string plainText, byte[] hashedPassword, string manv)
        {
            string keyContainerName = Convert.ToBase64String(Encoding.UTF8.GetBytes(manv + "_" + Convert.ToBase64String(hashedPassword)));

            CspParameters cspParams = new CspParameters
            {
                KeyContainerName = keyContainerName
            };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                try
                {
                    rsa.PersistKeyInCsp = false;

                    string publicKeyXml = rsa.ToXmlString(false);
                    string privateKeyXml = rsa.ToXmlString(true);

                    byte[] dataToEncrypt = Encoding.UTF8.GetBytes(plainText);
                    byte[] encryptedData = rsa.Encrypt(dataToEncrypt, false);

                    return (encryptedData, publicKeyXml, privateKeyXml);
                }
                finally
                {
                    rsa.Clear();
                }
            }
        }

        public static string DecryptDataRSA(byte[] encryptedData, string privateKeyXml)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    rsa.PersistKeyInCsp = false;
                    rsa.FromXmlString(privateKeyXml);

                    byte[] decryptedBytes = rsa.Decrypt(encryptedData, false);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
                catch (CryptographicException ex)
                {
                    throw new Exception("Lỗi giải mã RSA: " + ex.Message);
                }
                finally
                {
                    rsa.Clear();
                }
            }
        }

        public static void SavePrivateKeyToFile(string manv, string privateKeyXml)
        {
            Dictionary<string, string> keyMap = LoadAllPrivateKeys();

            if (!keyMap.ContainsKey(manv))
            {
                keyMap[manv] = Convert.ToBase64String(Encoding.UTF8.GetBytes(privateKeyXml));

                using (StreamWriter writer = new StreamWriter(KeyStorageFile, false))
                {
                    foreach (var pair in keyMap)
                    {
                        writer.WriteLine($"{pair.Key}::{pair.Value}");
                    }
                }
            }
        }

        public static string LoadPrivateKeyFromFile(string manv)
        {
            Dictionary<string, string> keyMap = LoadAllPrivateKeys();
            if (keyMap.TryGetValue(manv, out string encodedPrivateKey))
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(encodedPrivateKey));
            }
            throw new Exception($"Không tìm thấy private key cho mã nhân viên: {manv}");
        }

        private static Dictionary<string, string> LoadAllPrivateKeys()
        {
            Dictionary<string, string> keyMap = new Dictionary<string, string>();
            if (!File.Exists(KeyStorageFile)) return keyMap;

            foreach (var line in File.ReadAllLines(KeyStorageFile))
            {
                Debug.WriteLine("Đọc dòng: " + line);

                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(new[] { "::" }, 2, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    Debug.WriteLine("Mã NV: " + parts[0]);
                    Debug.WriteLine("Base64 Key (rút gọn): " + parts[1].Substring(0, Math.Min(parts[1].Length, 30)) + "...");
                    keyMap[parts[0]] = parts[1];
                }
            }
            return keyMap;
        }

        public static void PrintAllPrivateKeys()
        {
            var keyMap = LoadAllPrivateKeys();

            if (keyMap.Count == 0)
            {
                Debug.WriteLine("Không có private key nào được lưu.");
                return;
            }

            Debug.WriteLine("Danh sách private key đã lưu:");
            foreach (var pair in keyMap)
            {
                string manv = pair.Key;
                string privateKeyXml = Encoding.UTF8.GetString(Convert.FromBase64String(pair.Value));

                Debug.WriteLine($"Mã nhân viên: {manv}");
                Debug.WriteLine($"Private Key:\n{privateKeyXml}\n");
            }
        }

        public static byte[] EncryptWithPublicKey(string plainText, string publicKeyXml)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    rsa.PersistKeyInCsp = false;
                    rsa.FromXmlString(publicKeyXml); // Import public key

                    byte[] dataToEncrypt = Encoding.UTF8.GetBytes(plainText);
                    return rsa.Encrypt(dataToEncrypt, false);
                }
                finally
                {
                    rsa.Clear();
                }
            }
        }

    }
}
