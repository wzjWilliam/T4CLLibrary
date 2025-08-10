using EasyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HookLibrary
{
    public class MyEntryPoint : IEntryPoint
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall,SetLastError = true)]
        delegate bool TerminateProcessDelegate(IntPtr hProccess, uint uExitCode);

        public MyEntryPoint(RemoteHooking.IContext context, string channelName)
        {
            
        }

        public void Run(RemoteHooking.IContext context, string channelName)
        {
            try
            {
                var hook = LocalHook.Create(
                    LocalHook.GetProcAddress("kernel32.dll", "TerminateProcess"),
                    new TerminateProcessDelegate(HookedTP),
                    null
                    );
                hook.ThreadACL.SetExclusiveACL(new int[0]);
                RemoteHooking.WakeUpProcess();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}");
            }
        }

        private bool HookedTP(IntPtr hProcess, uint uExitCode)
        {
            return false;
        }

    }
}
