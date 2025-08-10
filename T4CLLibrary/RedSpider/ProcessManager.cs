using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CLLibrary.RedSpider
{
    /// <summary>
    /// 红蜘蛛电子教室进程管理器
    /// </summary>
    public static class ProcessManager
    {
        /// <summary>
        /// 红蜘蛛电子教室进程列表
        /// </summary>
        private static readonly string[] processes = new string[]
        {
            "REDAgent",
            "checkrs",
            "rscheck"
        };

        /// <summary>
        /// 杀死红蜘蛛电子教室所有进程
        /// </summary>
        public static void KillAllProcesses()
        {
            processes.ToList().ForEach(processName =>
            {
                ProcessHelper.KillProcessByName(processName);
            });
        }

        /// <summary>
        /// 挂起红蜘蛛电子教室主进程
        /// </summary>
        public static void SuspendMainProcess()
        {
            ProcessHelper.SuspendProcessByName("REDAgent");
        }

        /// <summary>
        /// 恢复红蜘蛛电子教室主进程
        /// </summary>
        public static void ResumeMainProcess()
        {
            ProcessHelper.ResumeProcessByName("REDAgent");
        }

    }
}
