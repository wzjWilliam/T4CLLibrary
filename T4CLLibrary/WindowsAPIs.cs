using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace T4CLLibrary
{
    internal static class WindowsAPIs
    {
        public const int WH_KEYBOARD_LL = 13;
        public const int WH_MOUSE_LL = 14;
        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);


        [DllImport(dllName: "user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(
            string lpClassName,
            string lpWindowName);

        [DllImport(dllName: "user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(
            IntPtr hwndParent,
            IntPtr hwndChildAfter,
            string lpszClass,
            string lpszWindow);
        [DllImport(dllName: "user32.dll", SetLastError = true)]
        public static extern long GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport(dllName: "user32.dll", SetLastError = true)]
        public static extern bool SendMessage(
            IntPtr hWnd,
            uint Msg,
            IntPtr wParam,
            IntPtr lParam);

        [DllImport(dllName: "kernel32.dll", SetLastError = true)]
        public static extern bool DeviceIoControl(
            IntPtr hDevice,
            uint dwIoControlCode,
            IntPtr lpInBuffer,
            uint nInBufferSize,
            IntPtr lpOutBuffer,
            uint nOutBufferSize,
            out uint lpBytesReturned,
            IntPtr lpOverlapped);

        [DllImport(dllName: "kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateFile(
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);
        [DllImport(dllName: "kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport(dllName: "user32.dll", SetLastError = true)]
        public static extern bool PostMessage(
            IntPtr hWnd,
            uint Msg,
            IntPtr wParam,
            IntPtr lParam);

        [DllImport(dllName: "user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(
            int idHook,
            HookProc lpfn,
            IntPtr hMod,
            uint dwThreadId);
        [DllImport(dllName: "user32.dll", SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

    }
}
