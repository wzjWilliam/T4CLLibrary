using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace T4CLLibrary.Mythware
{
    public static class OtherTools
    {
        static int MakeWParam(int low, int high)
        {
            return (low & 0xFFFF) | (high << 16);
        }

        /// <summary>
        /// 将广播窗口设置为窗口化
        /// </summary>
        /// <exception cref="Exception">异常</exception>
        public static void SetBroadcastWindowToNormal()
        { 
            IntPtr hBdCst = WindowsAPIs.FindWindow(null, "屏幕广播");
            if (hBdCst == IntPtr.Zero)
            {
                throw new Exception("Broadcast window not found");
            }
            IntPtr hMenuBar = WindowsAPIs.FindWindowEx(hBdCst, IntPtr.Zero, "AfxWnd80u", null);
            if (hMenuBar == IntPtr.Zero)
            {
                throw new Exception("Menu bar not found");
            }
            long lStyle = WindowsAPIs.GetWindowLong(hBdCst, -16/*GWL_STYLE*/);
            bool bWindowing = (lStyle & (0x00C00000L | 0x00040000L)) != 0;
            if (bWindowing)
            {
                throw new Exception("Broadcast window already in windowed mode");
            }
            IntPtr wParam = (IntPtr)MakeWParam(1004, 0xF5);
            WindowsAPIs.PostMessage(hBdCst, 0x0111/*WM_COMMAND*/, wParam, IntPtr.Zero);

        }

        /// <summary>
        /// 尝试将广播窗口设置为默认值
        /// </summary>
        /// <returns>是否成功</returns>
        public static bool TrySetBroadcastWindowToNormal()
        {
            try
            {
                SetBroadcastWindowToNormal();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static WindowsAPIs.HookProc hookProc = HookProcImpl;

        static IntPtr HookProcImpl(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return IntPtr.Zero;
        }

        /// <summary>
        /// 通过反复挂钩子启用键盘，阻塞线程，请使用Thread执行
        /// </summary>
        public static void EnableKeyboardByHook()
        {
            while (true)
            {
                IntPtr hHook = WindowsAPIs.SetWindowsHookEx(WindowsAPIs.WH_KEYBOARD_LL, hookProc, IntPtr.Zero, 0);
                Thread.Sleep(50);
                WindowsAPIs.UnhookWindowsHookEx(hHook);
            }

        }

        /// <summary>
        /// 通过反复挂钩子启用鼠标，阻塞线程，请使用Thread执行
        /// </summary>
        public static void EnableMouseByHook()
        {
            while (true)
            {
                IntPtr hHook = WindowsAPIs.SetWindowsHookEx(WindowsAPIs.WH_MOUSE_LL, hookProc, IntPtr.Zero, 0);
                Thread.Sleep(50);
                WindowsAPIs.UnhookWindowsHookEx(hHook);
            }
        }
    }

}
