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
    public enum JfglzsVersion
    {
        /// <summary>
        /// 9.99版以前
        /// </summary>
        V9_9,
        /// <summary>
        /// 9.99版
        /// </summary>
        V9_99,
        /// <summary>
        /// 10.1版
        /// </summary>
        V10_1,
        /// <summary>
        /// 10.2版
        /// </summary>
        V10_2,
        /// <summary>
        /// 11.03版
        /// </summary>
        V11_03,
        /// <summary>
        /// 11.06版
        /// </summary>
        V11_06,
        /// <summary>
        /// 11.6版
        /// </summary>
        V11_6,
    }

    public static class PasswordCracker
    {
        #region 生成临时密码
        /// <summary>
        /// 生成机房管理助手每日临时密码
        /// </summary>
        /// <returns></returns>
        public static string GenerateTemporaryPassword(int month,int day, int year)
        {
            //DateTime currentDate = DateTime.Now;
            long monthComponent = month * 13;
            long dayComponent = day * 57;
            long yearComponent = year * 91;
            long combinedValue = monthComponent + dayComponent + yearComponent;
            return "8"+(combinedValue * 16).ToString();
        }

        /// <summary>
        /// 生成机房管理助手每日临时密码
        /// </summary>
        /// <returns>密码</returns>
        public static string GenerateTemporaryPassword()
        {
            return GenerateTemporaryPassword(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year);
        }

        /// <summary>
        /// 生成机房管理助手每日临时密码(10.1版及以后)
        /// 注意：机房管理助手获取日期的方法是给百度发送请求获取的，可能是为了防止用户修改系统时间。
        /// </summary>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="year">年</param>
        /// <returns>密码</returns>
        public static string GenerateTemporaryPasswordV10_1(int month, int day, int year)
        {
            long monthComponent = month * 13;
            long dayComponent = day * 57;
            long yearComponent = year * 91;
            long combinedValue = monthComponent + dayComponent + yearComponent;
            return "8" + (combinedValue * 16 + 11).ToString();
        }

        /// <summary>
        /// 生成机房管理助手每日临时密码(10.1版及以后)
        /// </summary>
        /// <returns>密码</returns>
        public static string GenerateTemporaryPasswordV10_1()
        {
            return GenerateTemporaryPasswordV10_1(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year);
        }

        /// <summary>
        /// 生成机房管理助手每日临时密码(11.03版及以后)
        /// </summary>
        /// <param name="month">月份</param>
        /// <param name="day">日</param>
        /// <param name="year">年</param>
        /// <returns>临时密码</returns>
        public static string GenerateTemporaryPasswordV11_03(int month, int day, int year)
        {
            var result = (month * 123 + day * 456 + year * 789 + 111).ToString();
            return result;
        }

        /// <summary>
        /// 生成机房管理助手每日临时密码(11.03版及以后)
        /// </summary>
        /// <returns>密码</returns>
        public static string GenerateTemporaryPasswordV11_03()
        {
            return GenerateTemporaryPasswordV11_03(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year);
        }

        public static string GenerateTemporaryPasswordV11_06(int month, int day,char lastChar)
        {
            var total = 258 * lastChar + month * 159 + day * 357;

            // 转换为七进制
            string result = "";
            while (total > 0)
            {
                int remainder = (int)(total % 7);
                result = remainder.ToString() + result;
                total /= 7;
            }

            return result;
        }

        public static string GenerateTemporaryPasswordV11_06()
        {
            char lastChar = GetLastComputerNameCharacter();
            return GenerateTemporaryPasswordV11_06(DateTime.Now.Month, DateTime.Now.Day, lastChar);
        }

        private static char GetLastComputerNameCharacter()
        {
            string computerName = Environment.MachineName;
            if (string.IsNullOrEmpty(computerName))
            {
                return (char)0;
            }
            char lastChar = computerName[computerName.Length - 1];
            return lastChar;
        }
        #endregion

        /// <summary>
        /// 加密密码第一步
        /// </summary>
        /// <param name="inputString">密码</param>
        /// <returns>第一步加密后的字符串</returns>
        private static string DESEncryptAndBase64Encode(string inputString,JfglzsVersion passwordType = JfglzsVersion.V9_9)
        {
            string str1 = "C:\\WINDOWS";
            string str2 = "zm2025jfglzs";
            byte[] key;
            byte[] iv;
            if (passwordType == JfglzsVersion.V9_99 || passwordType == JfglzsVersion.V9_9||passwordType == JfglzsVersion.V10_1)
            {
                key = Encoding.UTF8.GetBytes(str1.Substring(0, 8));
                iv = Encoding.UTF8.GetBytes(str1.Substring(1, 8));
            }
            else if (passwordType == JfglzsVersion.V10_2)
            {
                key = Encoding.UTF8.GetBytes(str2.Substring(0, 8));
                iv = Encoding.UTF8.GetBytes(str2.Substring(1, 8));
            }
            else
            {
                throw new ArgumentException("Invalid password type");
            }

            using (var desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                desCryptoServiceProvider.Key = key;
                desCryptoServiceProvider.IV = iv;
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
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

        #region 9.99版以前
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

        #region 9.99版

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
        public static string EncryptPasswordV9_99(string encryptedPassword)
        {
            string str1 = DESEncrypt(encryptedPassword);
            string str2 = AsciiSubTen(str1);
            string str3 = ProcessString(str2);
            return str3;
        }

        /// <summary>
        /// 用暴力方式解密机房管理助手密码（9.99版）。
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
            foreach (byte left in base64StringCollection)
            {
                foreach (byte right in base64StringCollection)
                {
                    try
                    {
                        string str2 = AsciiAddTen(str1);
                        string str3 = $"{(char)left}{str2}{(char)right}";
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

        #region 10.1版
        public static string EncryptPasswordV10_1(string password)
        {
            var str1 = EncryptPassword(password);
            return str1.Substring(0, 20);
        }
        #endregion

        #region 10.2版及以后
        public static string EncryptPasswordV10_2(string password)
        {
            var str1 = DESEncryptAndBase64Encode(password, JfglzsVersion.V10_2);
            var str2 = ThirdStepOfEncryptingPassword(str1);
            var str3 = str2.Substring(0,20);
            return str3;
        }
        #endregion

        #region 11.03及以后
        public static string EncryptPasswordV11_03(string string_0)
        {
            string result;
            using (SHA256 sha = SHA256.Create())
            {
                byte[] array = sha.ComputeHash(Encoding.UTF8.GetBytes(string_0 + "bfdshgs"));
                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in array)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
                result = stringBuilder.ToString();
            }
            return result;
        }
        #endregion

        /// <summary>
        /// 设置加密后的密码到注册表
        /// </summary>
        /// <param name="encryptedPassword">加密后的密码</param>
        /// <param name="passwordType">密码类型</param>
        public static void SetEncryptedPassword(string encryptedPassword,JfglzsVersion passwordType = JfglzsVersion.V9_9) 
        { 
            if(passwordType != JfglzsVersion.V10_2)
            {
                using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software"))
                {
                    registryKey.SetValue("n", encryptedPassword);
                }
            }
            else
            {
                using (RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("Software"))
                {
                    registryKey.SetValue("zz", encryptedPassword);
                }
            }

        }

        /// <summary>
        /// 获取注册表中的加密密码，仅支持非10.2版
        /// </summary>
        /// <returns>加密的密码</returns>
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
