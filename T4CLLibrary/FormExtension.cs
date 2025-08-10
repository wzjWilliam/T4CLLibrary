using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T4CLLibrary
{
    /// <summary>
    /// 窗口显示亲和力
    /// </summary>
    public enum DisplayAffinity
    {
        /// <summary>
        /// 窗口可被截图
        /// </summary>
        None = 0x0,
        /// <summary>
        /// 窗口不可被截图，会显示为黑色
        /// </summary>
        Black = 0x1,
        /// <summary>
        /// 窗口不可被截图，会显示为透明色
        /// </summary>
        Transparent = 0x11,
    }
    

    public static class FormExtension
    {
        /// <summary>
        /// 设置窗口是否能被截图
        /// </summary>
        /// <param name="form">当前的Form实例，必须为本程序所有</param>
        /// <param name="affinity">是否能被截图</param>
        /// <exception cref="InvalidOperationException">句柄无效</exception>
        /// <exception cref="Win32Exception">调用的WindowsAPI不成功</exception>
        public static void SetDisplayAffinity(this Form form,DisplayAffinity affinity)
        {
            var handle = form.Handle;
            if(handle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Form handle is not created yet.");
            }
            if(!WindowsAPIs.SetWindowDisplayAffinity(handle, (int)affinity))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
    }
}
