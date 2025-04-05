using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace T4CLLibrary.Jfglzs
{
    public static class PasswordCracker
    {
        /// <summary>
        /// 生成机房管理助手每日临时密码
        /// </summary>
        /// <returns></returns>
        public static string GenerateTemporaryPassword(int month,int day, int year)
        {
            DateTime currentDate = DateTime.Now;
            long monthComponent = month * 13;
            long dayComponent = day * 57;
            long yearComponent = year * 91;
            long combinedValue = monthComponent + dayComponent + yearComponent;
            return "8"+(combinedValue * 16).ToString();
        }

        public static string GenerateTemporaryPassword()
        {
            return GenerateTemporaryPassword(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year);
        }


        #region 9.99版以前
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
        #endregion

        #region 9.99版及以后

        private static string AsciiSubTen(string input)
        {
            try
            {
                StringBuilder result = new StringBuilder(input.Length);
                foreach (char c in input)
                {
                    result.Append((char)(c - 10));
                }
                return result.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        private static bool IsAsciiPrintableChar(char c)
        {
            return c >= 32 && c <= 126; // ASCII 可打印字符范围
        }

        private static bool IsAsciiPrintableString(string str)
        {
            foreach (char c in str)
            {
                if (!IsAsciiPrintableChar(c))
                {
                    return false;
                }
            }
            return true;
        }

        private static string AsciiAddTen(string input)
        {
            try
            {
                StringBuilder result = new StringBuilder(input.Length);
                foreach (char c in input)
                {
                    result.Append((char)(c + 10));
                }
                return result.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        private static string DESEncrypt(string input)
        {
            string key = "C:\\WINDO";
            string iv = ":\\WINDOW";

            // 使用DES加密
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = Encoding.UTF8.GetBytes(key);
                des.IV = Encoding.UTF8.GetBytes(iv);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(input);
                    }

                    string encryptedBase64 = Convert.ToBase64String(ms.ToArray());
                    return encryptedBase64;
                }
            }  
        }

        private static string DESDecrypt(string inputBase64Str)
        {
            byte[] decodedInput;
            try
            {
                decodedInput = Convert.FromBase64String(inputBase64Str);
            }
            catch (Exception)
            {
                return null;
            }
            // 使用固定的密钥和初始化向量（原始代码从Windows目录获取但被硬编码覆盖）
            string key = "C:\\WINDO";   // 取前8个字符
            string iv = ":\\WINDOW";    // 从第2个字符开始取8个字符
            // 使用DES解密
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = Encoding.UTF8.GetBytes(key);
                des.IV = Encoding.UTF8.GetBytes(iv);
                using (MemoryStream ms = new MemoryStream(decodedInput))
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs))
                {
                   
                    var result = sr.ReadToEnd();
                    return result;
                }
            }
        }

        private static string ProcessString(string input)
        {
            if (input.Length < 3)
                return "c";

            return input.Substring(1, input.Length - 2);
        }

        /// <summary>
        /// 加密机房管理助手密码（9.99版及以后）
        /// </summary>
        /// <param name="encryptedPassword"></param>
        /// <returns></returns>
        public static string EncryptPasswordNew(string encryptedPassword)
        {
            string str1 = DESEncrypt(encryptedPassword);
            string str2 = AsciiSubTen(str1);
            string str3 = ProcessString(str2);
            return str3;
        }

        /// <summary>
        /// 用暴力方式解密机房管理助手密码（9.99版及以后）。
        /// 由于加密方式的原因，解密后的密码可能会有多个结果,
        /// 大约需要30秒钟。
        /// </summary>
        /// <param name="encryptedPassword">密文</param>
        /// <param name="getAllProbablyPassword">是否获取所有可能的密码</param>
        /// <returns>密码明文</returns>
        public static string[] DecryptPassword(string encryptedPassword, bool getAllProbablyPassword = false)
        {
            List<string> decryptedPasswords = new List<string>();

            string base64StringCollection = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

            string str1 = encryptedPassword;
            foreach(byte left in base64StringCollection)
            {
                foreach (byte right in base64StringCollection)
                {
                    try
                    {
                        string str2 = (char)left + str1 + (char)right;
                        string str3 = AsciiAddTen(str2);
                        string str4 = DESDecrypt(str3);
                        if (!(str4 is null) && IsAsciiPrintableString(str4))
                        {
                            if (getAllProbablyPassword)
                            {
                                decryptedPasswords.Add(str4);
                            }
                            else
                            {
                                // 只返回第一个找到的密码
                                return new string[] { str4 };
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // 捕获异常但不处理
                        // 继续循环以尝试下一个字符组合
                        continue;
                    }
                }
            }
            return decryptedPasswords.ToArray();
        }
        #endregion

        public static void SetEncryptedPassword(string encryptedPassword) 
        { 
            using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software"))
            {
                registryKey.SetValue("n", encryptedPassword);
            }
        }

        public static string GetEncryptedPassword()
        {
            using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software"))
            {
                if (registryKey != null)
                {
                    string encryptedPassword = registryKey.GetValue("n") as string;
                    return encryptedPassword;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
