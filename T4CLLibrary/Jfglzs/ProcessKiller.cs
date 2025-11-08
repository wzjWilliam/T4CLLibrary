using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using T4CLLibrary;

namespace T4CLLibrary.Jfglzs
{
    public static class ProcessKiller
    {
        private static readonly string[] unchangedProcessNames = { "jfglzs", "przs", "zmserv"};
        private static readonly string[] needKillProcessNamesV10_3 = { "jfglzsp", "przs"};
        private static readonly string[] needKillProcessNamesV11_6 = { "jfglzsn", "przs"};

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
        /// 获取随机进程名, 10.2
        /// </summary>
        /// <param name="num3">当天的月份乘日期</param>
        /// <param name="withExtensionName">是否返回扩展名</param>
        /// <returns></returns>
        public static string GetRandomProcessNameV10_2(int num3, bool withExtensionName = false)
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
        /// 获取随机进程名, 11.03
        /// </summary>
        /// <param name="num3"></param>
        /// <param name="withExtensionName"></param>
        /// <returns></returns>
        public static string GetRandomProcessNameV11_03(int num3, bool withExtensionName = false)
        {
            CustomRandom.Randomize(num3);
            long num8 = (long)Math.Round(CustomRandom.Rnd() * 100000.0 * 3.0 + 1.0);
            string text = "";
            var num9 = 1;
            do
            {
                long digit = num8 % 10L + 105L;
                text = ((char)digit).ToString() + text;
                num8 /= 10L;
                num9++;
            }
            while (num9 <= 5);
            return withExtensionName ? text + ".exe" : text;
        }

        public static string GetRandomProcessNameV11_03()
        {
            return GetRandomProcessNameV11_03(DateTime.Now.Month * DateTime.Now.Day);
        }

        /// <summary>
        /// 杀死机房管理助手所有进程，注意：11.03版本请勿使用！！！
        /// </summary>
        public static void KillAllProcesses()
        {
            foreach (var processName in unchangedProcessNames)
            {
                ProcessHelper.KillProcessByName(processName);
            }

            //暂时先使用结束两个随机进程名
            ProcessHelper.KillProcessByName(GetRandomProcessName(DateTime.Now.Month * DateTime.Now.Day));
            ProcessHelper.KillProcessByName(GetRandomProcessNameV10_2(DateTime.Now.Month * DateTime.Now.Day));
        }

        /// <summary>
        /// 杀死机房管理助手所有进程，请在11.03版本使用，因为11.03版本中zmserv进程被设为系统关键进程，结束后会蓝屏,所以改为停止服务
        /// </summary>
        public static void KillAllProcessV11_03()
        {
            foreach (var processName in needKillProcessNamesV10_3)
            {
                ProcessHelper.KillProcessByName(processName);
            }
            ProcessHelper.KillProcessByName(GetRandomProcessNameV11_03(DateTime.Now.Month * DateTime.Now.Day));
            var sc = new ServiceController("zmserv");
            if (sc.Status != ServiceControllerStatus.Stopped)
            {
                sc.Stop();
            }
        }

        /// <summary>
        /// 杀死机房管理助手所有进程，11.6
        /// </summary>
        public static void KillAllProcessV11_6()
        {
            foreach (var process in needKillProcessNamesV11_6)
            {
                ProcessHelper.KillProcessByName(process);
            }
            ProcessHelper.KillProcessByName(GetRandomProcessNameV11_03(DateTime.Now.Month * DateTime.Now.Day)); //11.6版本随机进程名与11.03版本相同
            var sc = new ServiceController("zmserv");
            if (sc.Status != ServiceControllerStatus.Stopped)
            {
                sc.Stop();
            }
        }

    }
}
