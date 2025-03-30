using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace T4CLLibrary.Jfglzs
{
    public static class PasswordCracker
    {
        /// <summary>
        /// 加密密码第一步
        /// </summary>
        /// <param name="inputString">密码</param>
        /// <returns>第一步加密后的字符串</returns>
        private static string DESEncryptAndBase64Encode(string inputString)
        {
           
            byte[] key = Encoding.UTF8.GetBytes("C:\\WINDOWS".Substring(0, 8));
            byte[] iv = Encoding.UTF8.GetBytes("C:\\WINDOWS".Substring(1, 8));
            using (var desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                desCryptoServiceProvider.Key = key;
                desCryptoServiceProvider.IV = iv;
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    using (var cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, desCryptoServiceProvider.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new System.IO.StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(inputString);
                            streamWriter.Flush();
                            cryptoStream.FlushFinalBlock();
                        }
                        byte[] encryptedBytes = memoryStream.ToArray();
                        string encryptedString = Convert.ToBase64String(encryptedBytes);
                        return encryptedString;
                    }
                }
            }
        }

        private static string SecondStepOfEncryptingPassword(string inputString)
        {
            int stringLength = inputString.Length;
            byte b = 1;
            byte b3 = (byte)stringLength;
            string text = "";
            while (b <= b3)
            {
                string tmp = inputString.Substring((int)b - 1, 1);
                string String = ((char)(tmp[0] - 10)).ToString();
                text += String;
                b += 1;
            }
            return text;
        }

        private static string ThirdStepOfEncryptingPassword(string inputString)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(inputString);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                var str = sb.ToString().Substring(0, 32);
                var result = str.Substring(10,22);
                return result;
            }
        }

        /// <summary>
        /// 加密机房管理助手密码
        /// </summary>
        /// <param name="encryptedPassword"要加密的密码></param>
        /// <returns>加密后的密码</returns>
        public static string EncryptPassword(string encryptedPassword)
        {
            var result = DESEncryptAndBase64Encode(encryptedPassword);
            result = SecondStepOfEncryptingPassword(result);
            result = ThirdStepOfEncryptingPassword(result);
            return result;
        }

        public static void SetEncryptedPassword(string encryptedPassword) 
        { 
            using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software"))
            {
                registryKey.SetValue("n", encryptedPassword);
            }
        }

    }
}
