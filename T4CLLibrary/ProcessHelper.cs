using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace T4CLLibrary
{
    public static class ProcessHelper
    {
        #region Win32 API
        [DllImport("ntdll.dll", SetLastError = true)]
        static extern bool NtSuspendProcess(IntPtr processHandle);
        [DllImport("ntdll.dll", SetLastError = true)]
        static extern bool NtResumeProcess(IntPtr processHandle);
        #endregion

        /// <summary>
        /// 根据进程名杀死进程
        /// </summary>
        /// <param name="processName">进程名</param>
        public static void KillProcessByName(string processName)
        {
            Process.GetProcessesByName(processName).ToList().ForEach(p => p.Kill());
        }

        /// <summary>
        /// 根据进程名挂起进程
        /// </summary>
        /// <param name="processName">进程名</param>
        public static void SuspendProcessByName(string processName)
        {
            Process.GetProcessesByName(processName).ToList().ForEach(p =>
            {
                IntPtr processHandle = p.Handle;
                NtSuspendProcess(processHandle);
            });
        }

        /// <summary>
        /// 根据进程名恢复进程
        /// </summary>
        /// <param name="processName">进程名</param>
        public static void ResumeProcessByName(string processName)
        {
            Process.GetProcessesByName(processName).ToList().ForEach(p =>
            {
                IntPtr processHandle = p.Handle;
                NtResumeProcess(processHandle);
            });
        }
    }
}
