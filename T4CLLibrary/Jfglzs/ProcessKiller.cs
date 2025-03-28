using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace T4CLLibrary.Jfglzs
{
    public static class ProcessKiller
    {
        private static readonly string[] unchangedProcessNames = { "jfglzs", "przs.exe", "zmserv"};

        /// <summary>
        /// 根据进程名杀死进程
        /// </summary>
        /// <param name="processName">进程名</param>
        public static void KillProcessByName(string processName)
        {
            Process.GetProcessesByName(processName).ToList().ForEach(p => p.Kill());
        }

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
            return withExtensionName ? text + ".exe" : text;
        }

        public static void KillAllProcesses()
        {
            foreach (var processName in unchangedProcessNames)
            {
                KillProcessByName(processName);
            }
            KillProcessByName(GetRandomProcessName(DateTime.Now.Month * DateTime.Now.Day));
        }

        

    }
}
