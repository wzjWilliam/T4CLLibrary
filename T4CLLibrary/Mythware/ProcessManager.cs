using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CLLibrary.Mythware
{
    public static class ProcessManager
    {
        static readonly string[] unchangedProcessNames = { "studentmain", "GATESRV", "masterhelper"};

        /// <summary>
        /// 杀死极域所有进程
        /// </summary>
        public static void KillAllProcesses()
        {
            foreach (var processName in unchangedProcessNames)
            {
                ProcessHelper.KillProcessByName(processName);
            }
        }

        /// <summary>
        /// 挂起极域主进程
        /// </summary>
        public static void SuspendMainProcess()
        {
            ProcessHelper.SuspendProcessByName("studentmain");
        }

        /// <summary>
        /// 恢复极域主进程
        /// </summary>
        public static void ResumeMainProcess()
        {
            ProcessHelper.ResumeProcessByName("studentmain");
        }
    }
}
