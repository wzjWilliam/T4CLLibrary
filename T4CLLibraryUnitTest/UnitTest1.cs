using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
namespace T4CLLibraryUnitTest
{
    [TestClass]
    public class PwdCrackerUnitTest
    {
        #region 私有字段, 用于测试
        /// <summary>
        /// 用于测试加密
        /// </summary>
        readonly byte[] data1 = { 0x14, 0x5b, 0x0f, 0x74, 0x15, 0x61, 0x0f, 0x7e, 0x15, 0x0f, 0x0f, 0x14 };

        /// <summary>
        /// 用于测试解密
        /// </summary>
        readonly byte[] data2 = { 0x33, 0x14, 0x0c, 0x56, 0x18, 0x22, 0x4f, 0x0f, 0x74, 0x27, 0xce, 0x20, 0x93, 0x74, 0xf8, 0x75, 0x01, 0x44, 0x53, 0x54, 0xc2, 0x7b, 0xee, 0x2f, 0x13, 0x12, 0xb2, 0x0d, 0x46, 0x4d, 0xdf, 0x30, 0x59, 0x78, 0xfd, 0x6d, 0xf5, 0x1c, 0x5b, 0x15, 0x74, 0x0f, 0x61, 0x15, 0x7e, 0x0f, 0x0f, 0x15, 0x2e, 0x53, 0xea, 0x6e, 0x50, 0x0f, 0x72, 0x4d, 0x6e, 0x3e, 0x71, 0x19, 0xb9, 0x67, 0xfe, 0x7b, 0x73, 0x2b, 0x25, 0x34, 0xb2, 0x3e, 0x4e, 0x04, 0xe6, 0x01, 0x41, 0x04, 0x0c, 0x6a, 0x98, 0x24, 0x26, 0x24, 0x04, 0x28, 0xbf, 0x78, 0xca, 0x67, 0x2a, 0x41, 0x6a, 0x39, 0x76, 0x74, 0x87, 0x75, 0x7a, 0x40, 0xaa, 0x3c, 0x6d, 0x6f, 0x01, 0x68, 0xd9, 0x60, 0xf4, 0x33 };

        /// <summary>
        /// 用于测试生成随机进程名
        /// </summary>
        readonly string text1 = "osorl";

        /// <summary>
        /// 用于测试机房管理助手加密
        /// </summary>
        readonly string text2 = "f4113b24d6c047647085b5";
        #endregion


        [TestMethod]
        public void DecryptMythwarePasswordMethodTest()
        {
            var result = T4CLLibrary.Mythware.PasswordCracker.DecryptPassword(data2);
            Assert.AreEqual("Tank", result);
        }

        [TestMethod]
        public void EncryptMythwarePasswordMethodTest()
        {  
            var result = T4CLLibrary.Mythware.PasswordCracker.EncryptPassword("Tank");
            bool areEqual = data1.SequenceEqual(result);
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void GetJfglzsRandomProcessNameMethod()
        {
            var result1 = T4CLLibrary.Jfglzs.ProcessKiller.GetRandomProcessName(63);
            var result2 = T4CLLibrary.Jfglzs.ProcessKiller.GetRandomProcessName(63);
            var flag = result1 == result2 && result1 == text1;
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void EncryptJfglzsPasswordMethodTest()
        {
            var encryptedPwd = T4CLLibrary.Jfglzs.PasswordCracker.EncryptPassword("Tank");
            Assert.AreEqual(text2, encryptedPwd);
        }
        [TestMethod]
        public void EncryptJfglzsPasswordNewMethodTest()
        {
            var result = T4CLLibrary.Jfglzs.PasswordCracker.EncryptPasswordNew("114514");
            Assert.AreEqual("YjP-b_P?-K", result);
        }
    }
}
