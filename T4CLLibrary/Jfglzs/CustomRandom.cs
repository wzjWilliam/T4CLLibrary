using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CLLibrary.Jfglzs
{
    internal class CustomRandom
    {
        private static int m_rndSeed = 327680;

        public static void Randomize(double number)
        {
            int rndSeed = m_rndSeed;
            int num;
            if (!BitConverter.IsLittleEndian)
            {
                num = BitConverter.ToInt32(BitConverter.GetBytes(number), 0);
            }
            else
            {
                num = BitConverter.ToInt32(BitConverter.GetBytes(number), 4);
            }
            num = ((num & 0xFFFF) ^ (num >> 16)) << 8;
            rndSeed = (rndSeed & -16776961) | num;
            m_rndSeed = rndSeed;
        }

        public static float Rnd(float number = 1.0f)
        {
            int num = m_rndSeed;
            if (number != 0.0f)
            {
                if (number < 0.0f)
                {
                    num = BitConverter.ToInt32(BitConverter.GetBytes(number), 0);
                    long num2 = num & 0xFFFFFFFFu;
                    num = (int)((num2 + (num2 >> 24)) & 0xFFFFFF);
                }
                num = (int)((long)num * 1140671485L + 12820163 & 0xFFFFFF);
            }
            m_rndSeed = num;
            return num / 16777216.0f;
        }

        /// <summary>
        /// 重置随机数种子
        /// </summary>
        public static void Reset()
        {
            m_rndSeed = 327680;
        }
    }
}
