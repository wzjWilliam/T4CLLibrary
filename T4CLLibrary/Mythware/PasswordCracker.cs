using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CLLibrary.Mythware
{
    /// <summary>
    /// 极域电子教室密码破解器
    /// </summary>
    public static class PasswordCracker
    {
        #region 私有字段
        private static readonly byte[] XorKeys = { 0x15, 0x0F, 0x0F, 0x15 };
        private const string RegistryPath = @"SOFTWARE\WOW6432Node\TopDomain\e-Learning Class\Student";
        private const string ValueName = "Knock1";
        #endregion

        /// <summary>
        /// 从注册表获取加密后的密码
        /// </summary>
        /// <returns>加密后密码的字节数组</returns>
        public static byte[] GetEncryptedPassword()
        {
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(RegistryPath))
            {
                return registryKey.GetValue(ValueName) as byte[];
            }
        }

        /// <summary>
        /// 将加密后的密码写入注册表
        /// </summary>
        /// <param name="password">要设置的密码</param>
        public static void SetEncryptedPassword(byte[] password)
        {
            using (RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(RegistryPath))
            {
                registryKey.SetValue(ValueName, password, RegistryValueKind.Binary);
            }
        }


        private static void ApplyXorCipher(byte[] data)
        {
            for (int i = 0; i < data.Length; i += 4)
            {
                data[i + 0] = (byte)(data[i + 0] ^ 0x45 ^ 0x50);
                data[i + 1] = (byte)(data[i + 1] ^ 0x4c ^ 0x43);
                data[i + 2] = (byte)(data[i + 2] ^ 0x43 ^ 0x4c);
                data[i + 3] = (byte)(data[i + 3] ^ 0x50 ^ 0x45);
            }
        }

        /// <summary>
        /// 解密极域电子教室的密码
        /// </summary>
        /// <param name="bytes">加密后的字节数组</param>
        /// <returns>密码</returns>
        public static string DecryptPassword(byte[] encryptedData)
        {
            byte[] decryptedData = (byte[])encryptedData.Clone();
            ApplyXorCipher(decryptedData);

            int startIndex = decryptedData[0];
            StringBuilder password = new StringBuilder();

            for (int i = startIndex; i < decryptedData.Length; i += 2)
            {
                if (decryptedData[i] == 0)
                    break;
                password.Append((char)decryptedData[i]);
            }

            return password.ToString();
        }

        /// <summary>
        /// 加密极域电子教室的密码
        /// </summary>
        /// <param name="password">要加密的密码</param>
        /// <returns>加密后的字节数组</returns>
        public static byte[] EncryptPassword(string password)
        {
            password += '\0';
            var data = new List<byte>();
            byte[] uPwd = Encoding.Unicode.GetBytes(password);
            data.AddRange(uPwd);

            // 填充字节，直到 (Count % 4) == 2
            while (data.Count % 4 != 2)
            {
                data.Add(0);
            }

            data.Insert(0, 1); // 添加头部
            data.Add(1);       // 添加尾部

            byte[] buffer = data.ToArray();
            ApplyXorCipher(buffer);

            return buffer;
        }
    }
}