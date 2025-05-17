using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using T4CLLibrary;

namespace T4CLLibrary.Jfglzs
{
    public static class ProcessKiller
    {
        private static readonly string[] unchangedProcessNames = { "jfglzs", "przs.exe", "zmserv"};

        /// <summary>
        /// 获取随机进程名
        /// </summary>
        /// <param name="num3">当天的月份乘日期</param>
        /// <param name="withExtensionName">返回值是否有扩展名</param>
        /// <returns>随机进程名</returns>
        public static string GetRandomProcessName(int num3, bool withExtensionName = false)
        {
            CustomRandom.Randomize(num3);
            long num8 = (long)Math.Round(CustomRandom.Rnd() * 100000.0 * 3.0 + 1.0);
            string text = "";
            int num9 = 1;

            while (num9 <= 5)
            {
                long num10 = num8 % 10L + 107L;
                text = ((char)num10).ToString() + text;
                num8 /= 10L;
                num9++;
            }
            CustomRandom.Reset();
            return withExtensionName ? text + ".exe" : text;
        }

        /// <summary>
        /// 获取随机进程名, 10.1+
        /// </summary>
        /// <param name="num3">当天的月份乘日期</param>
        /// <param name="withExtensionName">是否返回扩展名</param>
        /// <returns></returns>
        public static string GetRandomProcessName1002(int num3, bool withExtensionName = false)
        {
            CustomRandom.Randomize(num3);
            long num8 = (long)Math.Round(CustomRandom.Rnd() * 100000.0 * 3.0 + 1.0);
            string text = "";
            var num9 = 1;
            do
            {
                long digit = num8 % 10L + 109L;
                text = ((char)digit).ToString() + text;
                num8 /= 10L;
                num9++;
            }
            while (num9 <= 5);
            return withExtensionName ? text + ".exe" : text;
        }

        /// <summary>
        /// 杀死机房管理助手所有进程
        /// </summary>
        public static void KillAllProcesses()
        {
            foreach (var processName in unchangedProcessNames)
            {
                ProcessHelper.KillProcessByName(processName);
            }

            //暂时先使用结束两个随机进程名
            ProcessHelper.KillProcessByName(GetRandomProcessName(DateTime.Now.Month * DateTime.Now.Day));
            ProcessHelper.KillProcessByName(GetRandomProcessName1002(DateTime.Now.Month * DateTime.Now.Day));
        }
    }
}
