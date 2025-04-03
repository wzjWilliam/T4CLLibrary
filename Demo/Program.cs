using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4CLLibrary;

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
            Console.WriteLine("机房管理助手:");
            Console.WriteLine("5. 机房管理助手进程名生成器");
            Console.WriteLine("6. 结束机房管理助手进程");
            Console.WriteLine("7. 设置机房管理助手密码");
            Console.WriteLine("8. 获取机房管理助手临时密码");
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
                        var processName = T4CLLibrary.Jfglzs.ProcessKiller.GetRandomProcessName(DateTime.Now.Month * DateTime.Now.Day,true);
                        Console.WriteLine($"生成的进程名为: {processName}");
                        break;
                    case "6":
                        T4CLLibrary.Jfglzs.ProcessKiller.KillAllProcesses();
                        Console.WriteLine("已结束机房管理助手进程");
                        break;
                    case "7":
                        Console.WriteLine("是否使用新版本的加密方式？(Y/N): ");
                        var useNewVer = Console.ReadLine() == "Y";
                        JfglzsPasswordCracker(useNewVer);
                        break;
                    case "8":
                        var tempPassword = T4CLLibrary.Jfglzs.PasswordCracker.GenerateTemporaryPassword();
                        Console.WriteLine($"生成的临时密码为: {tempPassword}");
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
                Console.ReadKey();
            }
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
    }
}
