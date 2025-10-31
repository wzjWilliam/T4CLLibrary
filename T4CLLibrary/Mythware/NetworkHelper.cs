using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace T4CLLibrary.Mythware
{
    public static class NetworkHelper
    {
        private static List<uint> _data = new List<uint> {
            0x120004u,//args needed, maybe: local IPs
            0x120010u,//no args needed, 
            0x120014u,//no args needed, enable network
            0x120008u,//args needed
            0x12000cu,//args needed
            0x120018u,//args needed
        };
        const uint GENERIC_READ = 0x80000000;
        const uint GENERIC_WRITE = 0x40000000;
        const uint FILE_SHARE_READ = 0x00000001;
        const uint OPEN_EXISTING = 3;
        const string svcName = "TDNetFilter";

        public static void EnableNetwork()
        {

            IntPtr hNetFilter = WindowsAPIs.CreateFile("\\\\.\\TDNetFilter", GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
            if (hNetFilter == (IntPtr)0xffffffffffffffff)
            {
                WindowsAPIs.CloseHandle(hNetFilter);
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            bool ioControlResult = WindowsAPIs.DeviceIoControl(hNetFilter, 0x120014u, IntPtr.Zero, 0, IntPtr.Zero, 0, out _, IntPtr.Zero);
            if (!ioControlResult)
            {
                WindowsAPIs.CloseHandle(hNetFilter);
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            WindowsAPIs.CloseHandle(hNetFilter);
        }

        /// <summary>
        /// 暴力启用网络
        /// </summary>
        public static void EnableNetworkForce()
        {
            Jfglzs.ProcessKiller.KillAllProcesses();
            Mythware.ProcessManager.KillAllProcesses();

            var controller = new ServiceController(svcName);
            if(controller.Status != ServiceControllerStatus.Stopped)
            {
                controller.Stop();
            }
            
        }

        public static void Test(int index)
        {
            var num = _data[index];
            if(num == 0)
            {
                Test2();
                return;
            }
            IntPtr hNetFilter = WindowsAPIs.CreateFile("\\\\.\\TDNetFilter", GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
            if (hNetFilter == (IntPtr)0xffffffffffffffff)
            {
                WindowsAPIs.CloseHandle(hNetFilter);
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            bool ioControlResult;

            ioControlResult = WindowsAPIs.DeviceIoControl(hNetFilter, num, IntPtr.Zero, 0, IntPtr.Zero, 0, out uint bytesReturned, IntPtr.Zero);

            if (!ioControlResult)
            {
                WindowsAPIs.CloseHandle(hNetFilter);
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            WindowsAPIs.CloseHandle(hNetFilter);
        }
        public static void Test2()
        {
            var num = _data[0];

            List<string> list = new List<string>();
            List<uint> listBin = new List<uint>();
            uint[] arr = new uint[0x208];
            //Get local IPs
            var localIPs = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList;
            foreach (var ip in localIPs)
            {
                list.Add(ip.ToString());
            }
            foreach (var ip in list)
            {
                var ipBin = System.Net.IPAddress.Parse(ip).GetAddressBytes();
                uint ipInt = BitConverter.ToUInt32(ipBin, 0);
                listBin.Add(ipInt);
            }
            arr = listBin.ToArray();

            IntPtr hNetFilter = WindowsAPIs.CreateFile("\\\\.\\TDNetFilter", GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
            if (hNetFilter == (IntPtr)0xffffffffffffffff)
            {
                WindowsAPIs.CloseHandle(hNetFilter);
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            unsafe
            {
                fixed(uint* p = arr)
                {
                    bool ioControlResult = WindowsAPIs.DeviceIoControl(hNetFilter, num, (IntPtr)p, (uint)(arr.Length * sizeof(uint)), IntPtr.Zero, 0, out uint bytesReturned, IntPtr.Zero);
                    if (!ioControlResult)
                    {
                        WindowsAPIs.CloseHandle(hNetFilter);
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                }
            }
        }
    }
}
