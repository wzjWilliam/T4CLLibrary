namespace DemoGUI
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonKillJF = new System.Windows.Forms.Button();
            this.buttonKillJY = new System.Windows.Forms.Button();
            this.buttonTmpPwd = new System.Windows.Forms.Button();
            this.groupBoxProc = new System.Windows.Forms.GroupBox();
            this.buttonKillRS = new System.Windows.Forms.Button();
            this.buttonSuspendRS = new System.Windows.Forms.Button();
            this.buttonResumeRS = new System.Windows.Forms.Button();
            this.buttonResume = new System.Windows.Forms.Button();
            this.buttonSuspend = new System.Windows.Forms.Button();
            this.textBoxProcName = new System.Windows.Forms.TextBox();
            this.buttonKill = new System.Windows.Forms.Button();
            this.buttonResumeJY = new System.Windows.Forms.Button();
            this.buttonSuspendJY = new System.Windows.Forms.Button();
            this.groupBoxPwd = new System.Windows.Forms.GroupBox();
            this.labelJFPwdCrackState = new System.Windows.Forms.Label();
            this.buttonGetJYPwd = new System.Windows.Forms.Button();
            this.buttonGetJFPwd = new System.Windows.Forms.Button();
            this.buttonJYPwd = new System.Windows.Forms.Button();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.buttonJFPwd = new System.Windows.Forms.Button();
            this.groupBoxUdp = new System.Windows.Forms.GroupBox();
            this.buttonGetPort = new System.Windows.Forms.Button();
            this.buttonSendReboot = new System.Windows.Forms.Button();
            this.buttonSendShutdown = new System.Windows.Forms.Button();
            this.buttonSendCmd = new System.Windows.Forms.Button();
            this.textBoxSendText = new System.Windows.Forms.TextBox();
            this.buttonSendMsg = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.buttonDbg = new System.Windows.Forms.Button();
            this.groupBoxOther = new System.Windows.Forms.GroupBox();
            this.radioButton1103 = new System.Windows.Forms.RadioButton();
            this.textBoxDbg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioBtn1001 = new System.Windows.Forms.RadioButton();
            this.radioButtonG1002 = new System.Windows.Forms.RadioButton();
            this.radioBtn0999 = new System.Windows.Forms.RadioButton();
            this.radioBtnL0999 = new System.Windows.Forms.RadioButton();
            this.buttonDefullScreen = new System.Windows.Forms.Button();
            this.buttonEnableNet = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageUniversal = new System.Windows.Forms.TabPage();
            this.tabPageSpecial = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxMachineName = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.comboBoxMac = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxTeacherIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRSHeartBeat = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxRSStdName = new System.Windows.Forms.TextBox();
            this.buttonRSRespondCheckIn = new System.Windows.Forms.Button();
            this.buttonRSCheckIn = new System.Windows.Forms.Button();
            this.buttonRSReboot = new System.Windows.Forms.Button();
            this.checkBoxRSForceOrMaximize = new System.Windows.Forms.CheckBox();
            this.buttonRSDisallowChat = new System.Windows.Forms.Button();
            this.buttonRSAllowChat = new System.Windows.Forms.Button();
            this.buttonRSShutdown = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxRSArgs = new System.Windows.Forms.TextBox();
            this.textBoxRSFilePath = new System.Windows.Forms.TextBox();
            this.buttonRSCmd = new System.Windows.Forms.Button();
            this.buttonRSUnblackScrn = new System.Windows.Forms.Button();
            this.buttonRSBlackScrn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.radioButton1160 = new System.Windows.Forms.RadioButton();
            this.groupBoxProc.SuspendLayout();
            this.groupBoxPwd.SuspendLayout();
            this.groupBoxUdp.SuspendLayout();
            this.groupBoxOther.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageUniversal.SuspendLayout();
            this.tabPageSpecial.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonKillJF
            // 
            this.buttonKillJF.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonKillJF.Location = new System.Drawing.Point(6, 460);
            this.buttonKillJF.Name = "buttonKillJF";
            this.buttonKillJF.Size = new System.Drawing.Size(404, 83);
            this.buttonKillJF.TabIndex = 0;
            this.buttonKillJF.Text = "结束机房管理助手";
            this.buttonKillJF.UseVisualStyleBackColor = true;
            this.buttonKillJF.Click += new System.EventHandler(this.buttonKillJF_Click);
            // 
            // buttonKillJY
            // 
            this.buttonKillJY.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonKillJY.Location = new System.Drawing.Point(6, 27);
            this.buttonKillJY.Name = "buttonKillJY";
            this.buttonKillJY.Size = new System.Drawing.Size(404, 83);
            this.buttonKillJY.TabIndex = 1;
            this.buttonKillJY.Text = "结束极域";
            this.buttonKillJY.UseVisualStyleBackColor = true;
            this.buttonKillJY.Click += new System.EventHandler(this.buttonKillJY_Click);
            // 
            // buttonTmpPwd
            // 
            this.buttonTmpPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTmpPwd.Location = new System.Drawing.Point(6, 27);
            this.buttonTmpPwd.Name = "buttonTmpPwd";
            this.buttonTmpPwd.Size = new System.Drawing.Size(463, 83);
            this.buttonTmpPwd.TabIndex = 4;
            this.buttonTmpPwd.Text = "获取机房管理助手临时密码";
            this.buttonTmpPwd.UseVisualStyleBackColor = true;
            this.buttonTmpPwd.Click += new System.EventHandler(this.buttonTmpPwd_Click);
            // 
            // groupBoxProc
            // 
            this.groupBoxProc.Controls.Add(this.buttonKillRS);
            this.groupBoxProc.Controls.Add(this.buttonSuspendRS);
            this.groupBoxProc.Controls.Add(this.buttonResumeRS);
            this.groupBoxProc.Controls.Add(this.buttonResume);
            this.groupBoxProc.Controls.Add(this.buttonSuspend);
            this.groupBoxProc.Controls.Add(this.textBoxProcName);
            this.groupBoxProc.Controls.Add(this.buttonKill);
            this.groupBoxProc.Controls.Add(this.buttonResumeJY);
            this.groupBoxProc.Controls.Add(this.buttonKillJF);
            this.groupBoxProc.Controls.Add(this.buttonSuspendJY);
            this.groupBoxProc.Controls.Add(this.buttonKillJY);
            this.groupBoxProc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxProc.Location = new System.Drawing.Point(6, 9);
            this.groupBoxProc.Name = "groupBoxProc";
            this.groupBoxProc.Size = new System.Drawing.Size(420, 778);
            this.groupBoxProc.TabIndex = 6;
            this.groupBoxProc.TabStop = false;
            this.groupBoxProc.Text = "进程相关";
            // 
            // buttonKillRS
            // 
            this.buttonKillRS.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonKillRS.Location = new System.Drawing.Point(6, 265);
            this.buttonKillRS.Name = "buttonKillRS";
            this.buttonKillRS.Size = new System.Drawing.Size(404, 83);
            this.buttonKillRS.TabIndex = 17;
            this.buttonKillRS.Text = "结束红蜘蛛";
            this.buttonKillRS.UseVisualStyleBackColor = true;
            this.buttonKillRS.Click += new System.EventHandler(this.buttonKillRS_Click);
            // 
            // buttonSuspendRS
            // 
            this.buttonSuspendRS.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSuspendRS.Location = new System.Drawing.Point(211, 355);
            this.buttonSuspendRS.Name = "buttonSuspendRS";
            this.buttonSuspendRS.Size = new System.Drawing.Size(199, 83);
            this.buttonSuspendRS.TabIndex = 16;
            this.buttonSuspendRS.Text = "挂起红蜘蛛";
            this.buttonSuspendRS.UseVisualStyleBackColor = true;
            this.buttonSuspendRS.Click += new System.EventHandler(this.buttonSuspendRS_Click);
            // 
            // buttonResumeRS
            // 
            this.buttonResumeRS.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonResumeRS.Location = new System.Drawing.Point(6, 354);
            this.buttonResumeRS.Name = "buttonResumeRS";
            this.buttonResumeRS.Size = new System.Drawing.Size(199, 83);
            this.buttonResumeRS.TabIndex = 15;
            this.buttonResumeRS.Text = "恢复红蜘蛛";
            this.buttonResumeRS.UseVisualStyleBackColor = true;
            this.buttonResumeRS.Click += new System.EventHandler(this.buttonResumeRS_Click);
            // 
            // buttonResume
            // 
            this.buttonResume.Location = new System.Drawing.Point(215, 636);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(199, 64);
            this.buttonResume.TabIndex = 14;
            this.buttonResume.Text = "恢复自定义进程";
            this.buttonResume.UseVisualStyleBackColor = true;
            this.buttonResume.Click += new System.EventHandler(this.buttonResume_Click);
            // 
            // buttonSuspend
            // 
            this.buttonSuspend.Location = new System.Drawing.Point(6, 636);
            this.buttonSuspend.Name = "buttonSuspend";
            this.buttonSuspend.Size = new System.Drawing.Size(207, 64);
            this.buttonSuspend.TabIndex = 13;
            this.buttonSuspend.Text = "挂起自定义进程";
            this.buttonSuspend.UseVisualStyleBackColor = true;
            this.buttonSuspend.Click += new System.EventHandler(this.buttonSuspend_Click);
            // 
            // textBoxProcName
            // 
            this.textBoxProcName.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxProcName.Location = new System.Drawing.Point(6, 581);
            this.textBoxProcName.Name = "textBoxProcName";
            this.textBoxProcName.Size = new System.Drawing.Size(408, 49);
            this.textBoxProcName.TabIndex = 12;
            // 
            // buttonKill
            // 
            this.buttonKill.Location = new System.Drawing.Point(6, 706);
            this.buttonKill.Name = "buttonKill";
            this.buttonKill.Size = new System.Drawing.Size(408, 64);
            this.buttonKill.TabIndex = 11;
            this.buttonKill.Text = "结束自定义进程";
            this.buttonKill.UseVisualStyleBackColor = true;
            this.buttonKill.Click += new System.EventHandler(this.buttonKill_Click);
            // 
            // buttonResumeJY
            // 
            this.buttonResumeJY.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonResumeJY.Location = new System.Drawing.Point(6, 116);
            this.buttonResumeJY.Name = "buttonResumeJY";
            this.buttonResumeJY.Size = new System.Drawing.Size(199, 83);
            this.buttonResumeJY.TabIndex = 3;
            this.buttonResumeJY.Text = "恢复极域";
            this.buttonResumeJY.UseVisualStyleBackColor = true;
            this.buttonResumeJY.Click += new System.EventHandler(this.buttonResumeJY_Click);
            // 
            // buttonSuspendJY
            // 
            this.buttonSuspendJY.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSuspendJY.Location = new System.Drawing.Point(211, 116);
            this.buttonSuspendJY.Name = "buttonSuspendJY";
            this.buttonSuspendJY.Size = new System.Drawing.Size(199, 83);
            this.buttonSuspendJY.TabIndex = 2;
            this.buttonSuspendJY.Text = "挂起极域";
            this.buttonSuspendJY.UseVisualStyleBackColor = true;
            this.buttonSuspendJY.Click += new System.EventHandler(this.buttonSuspendJY_Click);
            // 
            // groupBoxPwd
            // 
            this.groupBoxPwd.Controls.Add(this.labelJFPwdCrackState);
            this.groupBoxPwd.Controls.Add(this.buttonGetJYPwd);
            this.groupBoxPwd.Controls.Add(this.buttonGetJFPwd);
            this.groupBoxPwd.Controls.Add(this.buttonJYPwd);
            this.groupBoxPwd.Controls.Add(this.textBoxPwd);
            this.groupBoxPwd.Controls.Add(this.buttonJFPwd);
            this.groupBoxPwd.Controls.Add(this.buttonTmpPwd);
            this.groupBoxPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxPwd.Location = new System.Drawing.Point(469, 9);
            this.groupBoxPwd.Name = "groupBoxPwd";
            this.groupBoxPwd.Size = new System.Drawing.Size(479, 444);
            this.groupBoxPwd.TabIndex = 7;
            this.groupBoxPwd.TabStop = false;
            this.groupBoxPwd.Text = "密码相关";
            // 
            // labelJFPwdCrackState
            // 
            this.labelJFPwdCrackState.AutoSize = true;
            this.labelJFPwdCrackState.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelJFPwdCrackState.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelJFPwdCrackState.Location = new System.Drawing.Point(15, 378);
            this.labelJFPwdCrackState.Name = "labelJFPwdCrackState";
            this.labelJFPwdCrackState.Size = new System.Drawing.Size(230, 21);
            this.labelJFPwdCrackState.TabIndex = 8;
            this.labelJFPwdCrackState.Text = "labelJFPwdCrackState";
            // 
            // buttonGetJYPwd
            // 
            this.buttonGetJYPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonGetJYPwd.Location = new System.Drawing.Point(245, 116);
            this.buttonGetJYPwd.Name = "buttonGetJYPwd";
            this.buttonGetJYPwd.Size = new System.Drawing.Size(224, 83);
            this.buttonGetJYPwd.TabIndex = 13;
            this.buttonGetJYPwd.Text = "获取极域密码";
            this.buttonGetJYPwd.UseVisualStyleBackColor = true;
            this.buttonGetJYPwd.Click += new System.EventHandler(this.buttonGetJYPwd_Click);
            // 
            // buttonGetJFPwd
            // 
            this.buttonGetJFPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonGetJFPwd.Location = new System.Drawing.Point(6, 116);
            this.buttonGetJFPwd.Name = "buttonGetJFPwd";
            this.buttonGetJFPwd.Size = new System.Drawing.Size(222, 83);
            this.buttonGetJFPwd.TabIndex = 12;
            this.buttonGetJFPwd.Text = "获取机房管理助手密码";
            this.buttonGetJFPwd.UseVisualStyleBackColor = true;
            this.buttonGetJFPwd.Click += new System.EventHandler(this.buttonGetJFPwd_Click);
            // 
            // buttonJYPwd
            // 
            this.buttonJYPwd.Location = new System.Drawing.Point(245, 284);
            this.buttonJYPwd.Name = "buttonJYPwd";
            this.buttonJYPwd.Size = new System.Drawing.Size(224, 64);
            this.buttonJYPwd.TabIndex = 10;
            this.buttonJYPwd.Text = "设置极域密码";
            this.buttonJYPwd.UseVisualStyleBackColor = true;
            this.buttonJYPwd.Click += new System.EventHandler(this.buttonJYPwd_Click);
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPwd.Location = new System.Drawing.Point(6, 229);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.Size = new System.Drawing.Size(463, 49);
            this.textBoxPwd.TabIndex = 9;
            // 
            // buttonJFPwd
            // 
            this.buttonJFPwd.Location = new System.Drawing.Point(6, 284);
            this.buttonJFPwd.Name = "buttonJFPwd";
            this.buttonJFPwd.Size = new System.Drawing.Size(222, 64);
            this.buttonJFPwd.TabIndex = 8;
            this.buttonJFPwd.Text = "设置机房管理助手密码";
            this.buttonJFPwd.UseVisualStyleBackColor = true;
            this.buttonJFPwd.Click += new System.EventHandler(this.buttonJFPwd_Click);
            // 
            // groupBoxUdp
            // 
            this.groupBoxUdp.Controls.Add(this.buttonGetPort);
            this.groupBoxUdp.Controls.Add(this.buttonSendReboot);
            this.groupBoxUdp.Controls.Add(this.buttonSendShutdown);
            this.groupBoxUdp.Controls.Add(this.buttonSendCmd);
            this.groupBoxUdp.Controls.Add(this.textBoxSendText);
            this.groupBoxUdp.Controls.Add(this.buttonSendMsg);
            this.groupBoxUdp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxUdp.Location = new System.Drawing.Point(6, 6);
            this.groupBoxUdp.Name = "groupBoxUdp";
            this.groupBoxUdp.Size = new System.Drawing.Size(846, 295);
            this.groupBoxUdp.TabIndex = 8;
            this.groupBoxUdp.TabStop = false;
            this.groupBoxUdp.Text = "极域UDP重放攻击";
            // 
            // buttonGetPort
            // 
            this.buttonGetPort.Location = new System.Drawing.Point(560, 160);
            this.buttonGetPort.Name = "buttonGetPort";
            this.buttonGetPort.Size = new System.Drawing.Size(276, 124);
            this.buttonGetPort.TabIndex = 24;
            this.buttonGetPort.Text = "获取极域监听端口";
            this.buttonGetPort.UseVisualStyleBackColor = true;
            this.buttonGetPort.Click += new System.EventHandler(this.buttonGetPort_Click);
            // 
            // buttonSendReboot
            // 
            this.buttonSendReboot.Location = new System.Drawing.Point(383, 225);
            this.buttonSendReboot.Name = "buttonSendReboot";
            this.buttonSendReboot.Size = new System.Drawing.Size(171, 59);
            this.buttonSendReboot.TabIndex = 19;
            this.buttonSendReboot.Text = "发送重启命令";
            this.buttonSendReboot.UseVisualStyleBackColor = true;
            this.buttonSendReboot.Click += new System.EventHandler(this.buttonSendReboot_Click);
            // 
            // buttonSendShutdown
            // 
            this.buttonSendShutdown.Location = new System.Drawing.Point(383, 160);
            this.buttonSendShutdown.Name = "buttonSendShutdown";
            this.buttonSendShutdown.Size = new System.Drawing.Size(171, 59);
            this.buttonSendShutdown.TabIndex = 18;
            this.buttonSendShutdown.Text = "发送关机命令";
            this.buttonSendShutdown.UseVisualStyleBackColor = true;
            this.buttonSendShutdown.Click += new System.EventHandler(this.buttonSendShutdown_Click);
            // 
            // buttonSendCmd
            // 
            this.buttonSendCmd.Location = new System.Drawing.Point(383, 95);
            this.buttonSendCmd.Name = "buttonSendCmd";
            this.buttonSendCmd.Size = new System.Drawing.Size(171, 59);
            this.buttonSendCmd.TabIndex = 17;
            this.buttonSendCmd.Text = "发送为命令";
            this.buttonSendCmd.UseVisualStyleBackColor = true;
            this.buttonSendCmd.Click += new System.EventHandler(this.buttonSendCmd_Click);
            // 
            // textBoxSendText
            // 
            this.textBoxSendText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxSendText.Location = new System.Drawing.Point(10, 24);
            this.textBoxSendText.Multiline = true;
            this.textBoxSendText.Name = "textBoxSendText";
            this.textBoxSendText.Size = new System.Drawing.Size(367, 260);
            this.textBoxSendText.TabIndex = 16;
            // 
            // buttonSendMsg
            // 
            this.buttonSendMsg.Location = new System.Drawing.Point(383, 24);
            this.buttonSendMsg.Name = "buttonSendMsg";
            this.buttonSendMsg.Size = new System.Drawing.Size(171, 65);
            this.buttonSendMsg.TabIndex = 15;
            this.buttonSendMsg.Text = "发送为消息";
            this.buttonSendMsg.UseVisualStyleBackColor = true;
            this.buttonSendMsg.Click += new System.EventHandler(this.buttonSendMsg_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "端口:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPort.Location = new System.Drawing.Point(79, 85);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(221, 35);
            this.textBoxPort.TabIndex = 22;
            this.textBoxPort.Text = "4705";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "IP:";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxIP.Location = new System.Drawing.Point(55, 32);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(245, 35);
            this.textBoxIP.TabIndex = 20;
            this.textBoxIP.Text = "255.255.255.255";
            // 
            // buttonDbg
            // 
            this.buttonDbg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDbg.Location = new System.Drawing.Point(4, 27);
            this.buttonDbg.Name = "buttonDbg";
            this.buttonDbg.Size = new System.Drawing.Size(256, 83);
            this.buttonDbg.TabIndex = 25;
            this.buttonDbg.Text = "debug";
            this.buttonDbg.UseVisualStyleBackColor = true;
            this.buttonDbg.Click += new System.EventHandler(this.buttonDbg_Click);
            // 
            // groupBoxOther
            // 
            this.groupBoxOther.Controls.Add(this.radioButton1160);
            this.groupBoxOther.Controls.Add(this.radioButton1103);
            this.groupBoxOther.Controls.Add(this.textBoxDbg);
            this.groupBoxOther.Controls.Add(this.label3);
            this.groupBoxOther.Controls.Add(this.radioBtn1001);
            this.groupBoxOther.Controls.Add(this.radioButtonG1002);
            this.groupBoxOther.Controls.Add(this.radioBtn0999);
            this.groupBoxOther.Controls.Add(this.radioBtnL0999);
            this.groupBoxOther.Controls.Add(this.buttonDbg);
            this.groupBoxOther.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxOther.Location = new System.Drawing.Point(469, 539);
            this.groupBoxOther.Name = "groupBoxOther";
            this.groupBoxOther.Size = new System.Drawing.Size(479, 275);
            this.groupBoxOther.TabIndex = 26;
            this.groupBoxOther.TabStop = false;
            this.groupBoxOther.Text = "其他";
            // 
            // radioButton1103
            // 
            this.radioButton1103.AutoSize = true;
            this.radioButton1103.Location = new System.Drawing.Point(266, 200);
            this.radioButton1103.Name = "radioButton1103";
            this.radioButton1103.Size = new System.Drawing.Size(95, 28);
            this.radioButton1103.TabIndex = 34;
            this.radioButton1103.TabStop = true;
            this.radioButton1103.Text = "11.03";
            this.radioButton1103.UseVisualStyleBackColor = true;
            this.radioButton1103.CheckedChanged += new System.EventHandler(this.radioButton1103_CheckedChanged);
            // 
            // textBoxDbg
            // 
            this.textBoxDbg.Location = new System.Drawing.Point(6, 135);
            this.textBoxDbg.Name = "textBoxDbg";
            this.textBoxDbg.Size = new System.Drawing.Size(239, 35);
            this.textBoxDbg.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 24);
            this.label3.TabIndex = 32;
            this.label3.Text = "机房管理助手版本:";
            // 
            // radioBtn1001
            // 
            this.radioBtn1001.AutoSize = true;
            this.radioBtn1001.Location = new System.Drawing.Point(266, 132);
            this.radioBtn1001.Name = "radioBtn1001";
            this.radioBtn1001.Size = new System.Drawing.Size(83, 28);
            this.radioBtn1001.TabIndex = 31;
            this.radioBtn1001.TabStop = true;
            this.radioBtn1001.Text = "10.1";
            this.radioBtn1001.UseVisualStyleBackColor = true;
            this.radioBtn1001.CheckedChanged += new System.EventHandler(this.radioBtn1001_CheckedChanged);
            // 
            // radioButtonG1002
            // 
            this.radioButtonG1002.AutoSize = true;
            this.radioButtonG1002.Location = new System.Drawing.Point(266, 166);
            this.radioButtonG1002.Name = "radioButtonG1002";
            this.radioButtonG1002.Size = new System.Drawing.Size(83, 28);
            this.radioButtonG1002.TabIndex = 30;
            this.radioButtonG1002.TabStop = true;
            this.radioButtonG1002.Text = "10.2";
            this.radioButtonG1002.UseVisualStyleBackColor = true;
            this.radioButtonG1002.CheckedChanged += new System.EventHandler(this.radioButtonG1002_CheckedChanged);
            // 
            // radioBtn0999
            // 
            this.radioBtn0999.AutoSize = true;
            this.radioBtn0999.Location = new System.Drawing.Point(266, 96);
            this.radioBtn0999.Name = "radioBtn0999";
            this.radioBtn0999.Size = new System.Drawing.Size(83, 28);
            this.radioBtn0999.TabIndex = 29;
            this.radioBtn0999.TabStop = true;
            this.radioBtn0999.Text = "9.99";
            this.radioBtn0999.UseVisualStyleBackColor = true;
            this.radioBtn0999.CheckedChanged += new System.EventHandler(this.radioButton09991002_CheckedChanged);
            // 
            // radioBtnL0999
            // 
            this.radioBtnL0999.AutoSize = true;
            this.radioBtnL0999.Checked = true;
            this.radioBtnL0999.Location = new System.Drawing.Point(266, 62);
            this.radioBtnL0999.Name = "radioBtnL0999";
            this.radioBtnL0999.Size = new System.Drawing.Size(95, 28);
            this.radioBtnL0999.TabIndex = 28;
            this.radioBtnL0999.TabStop = true;
            this.radioBtnL0999.Text = "<9.99";
            this.radioBtnL0999.UseVisualStyleBackColor = true;
            this.radioBtnL0999.CheckedChanged += new System.EventHandler(this.radioBtnL0999_CheckedChanged);
            // 
            // buttonDefullScreen
            // 
            this.buttonDefullScreen.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDefullScreen.Location = new System.Drawing.Point(858, 110);
            this.buttonDefullScreen.Name = "buttonDefullScreen";
            this.buttonDefullScreen.Size = new System.Drawing.Size(256, 83);
            this.buttonDefullScreen.TabIndex = 27;
            this.buttonDefullScreen.Text = "窗口化极域";
            this.buttonDefullScreen.UseVisualStyleBackColor = true;
            this.buttonDefullScreen.Click += new System.EventHandler(this.buttonDefullScreen_Click);
            // 
            // buttonEnableNet
            // 
            this.buttonEnableNet.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEnableNet.Location = new System.Drawing.Point(858, 21);
            this.buttonEnableNet.Name = "buttonEnableNet";
            this.buttonEnableNet.Size = new System.Drawing.Size(256, 83);
            this.buttonEnableNet.TabIndex = 26;
            this.buttonEnableNet.Text = "开网";
            this.buttonEnableNet.UseVisualStyleBackColor = true;
            this.buttonEnableNet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonEnableNet_MouseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageUniversal);
            this.tabControl1.Controls.Add(this.tabPageSpecial);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1181, 852);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPageUniversal
            // 
            this.tabPageUniversal.Controls.Add(this.groupBoxProc);
            this.tabPageUniversal.Controls.Add(this.groupBoxOther);
            this.tabPageUniversal.Controls.Add(this.groupBoxPwd);
            this.tabPageUniversal.Location = new System.Drawing.Point(4, 28);
            this.tabPageUniversal.Name = "tabPageUniversal";
            this.tabPageUniversal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUniversal.Size = new System.Drawing.Size(1173, 820);
            this.tabPageUniversal.TabIndex = 0;
            this.tabPageUniversal.Text = "通用";
            this.tabPageUniversal.UseVisualStyleBackColor = true;
            // 
            // tabPageSpecial
            // 
            this.tabPageSpecial.Controls.Add(this.groupBox2);
            this.tabPageSpecial.Controls.Add(this.groupBox1);
            this.tabPageSpecial.Controls.Add(this.groupBoxUdp);
            this.tabPageSpecial.Controls.Add(this.buttonDefullScreen);
            this.tabPageSpecial.Controls.Add(this.buttonEnableNet);
            this.tabPageSpecial.Location = new System.Drawing.Point(4, 28);
            this.tabPageSpecial.Name = "tabPageSpecial";
            this.tabPageSpecial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpecial.Size = new System.Drawing.Size(1173, 820);
            this.tabPageSpecial.TabIndex = 1;
            this.tabPageSpecial.Text = "专门的工具";
            this.tabPageSpecial.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBoxMachineName);
            this.groupBox2.Controls.Add(this.textBoxUserName);
            this.groupBox2.Controls.Add(this.comboBoxMac);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxTeacherIP);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxIP);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxPort);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(861, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 358);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "UDP重放设置";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 24);
            this.label10.TabIndex = 32;
            this.label10.Text = "电脑名:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 24);
            this.label9.TabIndex = 31;
            this.label9.Text = "用户名:";
            // 
            // textBoxMachineName
            // 
            this.textBoxMachineName.Location = new System.Drawing.Point(103, 290);
            this.textBoxMachineName.Name = "textBoxMachineName";
            this.textBoxMachineName.Size = new System.Drawing.Size(197, 35);
            this.textBoxMachineName.TabIndex = 30;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(103, 232);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(197, 35);
            this.textBoxUserName.TabIndex = 29;
            // 
            // comboBoxMac
            // 
            this.comboBoxMac.FormattingEnabled = true;
            this.comboBoxMac.Location = new System.Drawing.Point(76, 185);
            this.comboBoxMac.Name = "comboBoxMac";
            this.comboBoxMac.Size = new System.Drawing.Size(224, 32);
            this.comboBoxMac.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 24);
            this.label8.TabIndex = 27;
            this.label8.Text = "MAC: ";
            // 
            // textBoxTeacherIP
            // 
            this.textBoxTeacherIP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTeacherIP.Location = new System.Drawing.Point(103, 135);
            this.textBoxTeacherIP.Name = "textBoxTeacherIP";
            this.textBoxTeacherIP.Size = new System.Drawing.Size(197, 35);
            this.textBoxTeacherIP.TabIndex = 25;
            this.textBoxTeacherIP.Text = "192.168.248.114";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 24);
            this.label6.TabIndex = 24;
            this.label6.Text = "老师IP:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonRSHeartBeat);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxRSStdName);
            this.groupBox1.Controls.Add(this.buttonRSRespondCheckIn);
            this.groupBox1.Controls.Add(this.buttonRSCheckIn);
            this.groupBox1.Controls.Add(this.buttonRSReboot);
            this.groupBox1.Controls.Add(this.checkBoxRSForceOrMaximize);
            this.groupBox1.Controls.Add(this.buttonRSDisallowChat);
            this.groupBox1.Controls.Add(this.buttonRSAllowChat);
            this.groupBox1.Controls.Add(this.buttonRSShutdown);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxRSArgs);
            this.groupBox1.Controls.Add(this.textBoxRSFilePath);
            this.groupBox1.Controls.Add(this.buttonRSCmd);
            this.groupBox1.Controls.Add(this.buttonRSUnblackScrn);
            this.groupBox1.Controls.Add(this.buttonRSBlackScrn);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(6, 307);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(846, 507);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "红蜘蛛Udp重放";
            // 
            // buttonRSHeartBeat
            // 
            this.buttonRSHeartBeat.Location = new System.Drawing.Point(360, 165);
            this.buttonRSHeartBeat.Name = "buttonRSHeartBeat";
            this.buttonRSHeartBeat.Size = new System.Drawing.Size(171, 65);
            this.buttonRSHeartBeat.TabIndex = 32;
            this.buttonRSHeartBeat.Text = "开始发送心跳数据";
            this.buttonRSHeartBeat.UseVisualStyleBackColor = true;
            this.buttonRSHeartBeat.Click += new System.EventHandler(this.buttonRSHeartBeat_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 455);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 24);
            this.label7.TabIndex = 31;
            this.label7.Text = "姓名:";
            // 
            // textBoxRSStdName
            // 
            this.textBoxRSStdName.Location = new System.Drawing.Point(82, 449);
            this.textBoxRSStdName.Name = "textBoxRSStdName";
            this.textBoxRSStdName.Size = new System.Drawing.Size(272, 35);
            this.textBoxRSStdName.TabIndex = 30;
            this.textBoxRSStdName.Text = "Tank";
            // 
            // buttonRSRespondCheckIn
            // 
            this.buttonRSRespondCheckIn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRSRespondCheckIn.Location = new System.Drawing.Point(183, 378);
            this.buttonRSRespondCheckIn.Name = "buttonRSRespondCheckIn";
            this.buttonRSRespondCheckIn.Size = new System.Drawing.Size(171, 65);
            this.buttonRSRespondCheckIn.TabIndex = 29;
            this.buttonRSRespondCheckIn.Text = "发送响应签到数据";
            this.buttonRSRespondCheckIn.UseVisualStyleBackColor = true;
            this.buttonRSRespondCheckIn.Click += new System.EventHandler(this.buttonRSRespondCheckIn_Click);
            // 
            // buttonRSCheckIn
            // 
            this.buttonRSCheckIn.Location = new System.Drawing.Point(6, 378);
            this.buttonRSCheckIn.Name = "buttonRSCheckIn";
            this.buttonRSCheckIn.Size = new System.Drawing.Size(171, 65);
            this.buttonRSCheckIn.TabIndex = 28;
            this.buttonRSCheckIn.Text = "发送签到数据";
            this.buttonRSCheckIn.UseVisualStyleBackColor = true;
            this.buttonRSCheckIn.Click += new System.EventHandler(this.buttonRSCheckIn_Click);
            // 
            // buttonRSReboot
            // 
            this.buttonRSReboot.Location = new System.Drawing.Point(183, 236);
            this.buttonRSReboot.Name = "buttonRSReboot";
            this.buttonRSReboot.Size = new System.Drawing.Size(171, 65);
            this.buttonRSReboot.TabIndex = 27;
            this.buttonRSReboot.Text = "发送重启命令";
            this.buttonRSReboot.UseVisualStyleBackColor = true;
            this.buttonRSReboot.Click += new System.EventHandler(this.buttonRSReboot_Click);
            // 
            // checkBoxRSForceOrMaximize
            // 
            this.checkBoxRSForceOrMaximize.AutoSize = true;
            this.checkBoxRSForceOrMaximize.Location = new System.Drawing.Point(10, 131);
            this.checkBoxRSForceOrMaximize.Name = "checkBoxRSForceOrMaximize";
            this.checkBoxRSForceOrMaximize.Size = new System.Drawing.Size(216, 28);
            this.checkBoxRSForceOrMaximize.TabIndex = 26;
            this.checkBoxRSForceOrMaximize.Text = "是否强制/最大化";
            this.toolTip1.SetToolTip(this.checkBoxRSForceOrMaximize, "勾选后，若使用关机/重启功能会强制重启，使用发送命令的功能会以最大化执行");
            this.checkBoxRSForceOrMaximize.UseVisualStyleBackColor = true;
            // 
            // buttonRSDisallowChat
            // 
            this.buttonRSDisallowChat.Location = new System.Drawing.Point(183, 307);
            this.buttonRSDisallowChat.Name = "buttonRSDisallowChat";
            this.buttonRSDisallowChat.Size = new System.Drawing.Size(171, 65);
            this.buttonRSDisallowChat.TabIndex = 25;
            this.buttonRSDisallowChat.Text = "发送禁止聊天数据";
            this.buttonRSDisallowChat.UseVisualStyleBackColor = true;
            this.buttonRSDisallowChat.Click += new System.EventHandler(this.buttonRSDisallowChat_Click);
            // 
            // buttonRSAllowChat
            // 
            this.buttonRSAllowChat.Location = new System.Drawing.Point(6, 307);
            this.buttonRSAllowChat.Name = "buttonRSAllowChat";
            this.buttonRSAllowChat.Size = new System.Drawing.Size(171, 65);
            this.buttonRSAllowChat.TabIndex = 24;
            this.buttonRSAllowChat.Text = "发送允许聊天数据";
            this.buttonRSAllowChat.UseVisualStyleBackColor = true;
            this.buttonRSAllowChat.Click += new System.EventHandler(this.buttonRSAllowChat_Click);
            // 
            // buttonRSShutdown
            // 
            this.buttonRSShutdown.Location = new System.Drawing.Point(6, 236);
            this.buttonRSShutdown.Name = "buttonRSShutdown";
            this.buttonRSShutdown.Size = new System.Drawing.Size(171, 65);
            this.buttonRSShutdown.TabIndex = 23;
            this.buttonRSShutdown.Text = "发送关机命令";
            this.buttonRSShutdown.UseVisualStyleBackColor = true;
            this.buttonRSShutdown.Click += new System.EventHandler(this.buttonRSShutdown_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 24);
            this.label5.TabIndex = 22;
            this.label5.Text = "参数:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 24);
            this.label4.TabIndex = 21;
            this.label4.Text = "文件路径:";
            // 
            // textBoxRSArgs
            // 
            this.textBoxRSArgs.Location = new System.Drawing.Point(311, 90);
            this.textBoxRSArgs.Name = "textBoxRSArgs";
            this.textBoxRSArgs.Size = new System.Drawing.Size(525, 35);
            this.textBoxRSArgs.TabIndex = 20;
            // 
            // textBoxRSFilePath
            // 
            this.textBoxRSFilePath.Location = new System.Drawing.Point(311, 31);
            this.textBoxRSFilePath.Name = "textBoxRSFilePath";
            this.textBoxRSFilePath.Size = new System.Drawing.Size(525, 35);
            this.textBoxRSFilePath.TabIndex = 19;
            // 
            // buttonRSCmd
            // 
            this.buttonRSCmd.Location = new System.Drawing.Point(10, 42);
            this.buttonRSCmd.Name = "buttonRSCmd";
            this.buttonRSCmd.Size = new System.Drawing.Size(171, 83);
            this.buttonRSCmd.TabIndex = 18;
            this.buttonRSCmd.Text = "发送命令";
            this.buttonRSCmd.UseVisualStyleBackColor = true;
            this.buttonRSCmd.Click += new System.EventHandler(this.buttonRSCmd_Click);
            // 
            // buttonRSUnblackScrn
            // 
            this.buttonRSUnblackScrn.Location = new System.Drawing.Point(6, 165);
            this.buttonRSUnblackScrn.Name = "buttonRSUnblackScrn";
            this.buttonRSUnblackScrn.Size = new System.Drawing.Size(171, 65);
            this.buttonRSUnblackScrn.TabIndex = 17;
            this.buttonRSUnblackScrn.Text = "发送解除黑屏数据";
            this.buttonRSUnblackScrn.UseVisualStyleBackColor = true;
            this.buttonRSUnblackScrn.Click += new System.EventHandler(this.buttonRSUnblackScrn_Click);
            // 
            // buttonRSBlackScrn
            // 
            this.buttonRSBlackScrn.Location = new System.Drawing.Point(183, 165);
            this.buttonRSBlackScrn.Name = "buttonRSBlackScrn";
            this.buttonRSBlackScrn.Size = new System.Drawing.Size(171, 65);
            this.buttonRSBlackScrn.TabIndex = 16;
            this.buttonRSBlackScrn.Text = "发送黑屏数据";
            this.buttonRSBlackScrn.UseVisualStyleBackColor = true;
            this.buttonRSBlackScrn.Click += new System.EventHandler(this.buttonRSBlackScrn_Click);
            // 
            // radioButton1160
            // 
            this.radioButton1160.AutoSize = true;
            this.radioButton1160.Location = new System.Drawing.Point(266, 234);
            this.radioButton1160.Name = "radioButton1160";
            this.radioButton1160.Size = new System.Drawing.Size(83, 28);
            this.radioButton1160.TabIndex = 35;
            this.radioButton1160.TabStop = true;
            this.radioButton1160.Text = "11.6";
            this.radioButton1160.UseVisualStyleBackColor = true;
            this.radioButton1160.CheckedChanged += new System.EventHandler(this.radioButton1160_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 876);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "T4CL库演示";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBoxProc.ResumeLayout(false);
            this.groupBoxProc.PerformLayout();
            this.groupBoxPwd.ResumeLayout(false);
            this.groupBoxPwd.PerformLayout();
            this.groupBoxUdp.ResumeLayout(false);
            this.groupBoxUdp.PerformLayout();
            this.groupBoxOther.ResumeLayout(false);
            this.groupBoxOther.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageUniversal.ResumeLayout(false);
            this.tabPageSpecial.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonKillJF;
        private System.Windows.Forms.Button buttonKillJY;
        private System.Windows.Forms.Button buttonTmpPwd;
        private System.Windows.Forms.GroupBox groupBoxProc;
        private System.Windows.Forms.Button buttonSuspendJY;
        private System.Windows.Forms.Button buttonResumeJY;
        private System.Windows.Forms.GroupBox groupBoxPwd;
        private System.Windows.Forms.Button buttonJYPwd;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.Button buttonJFPwd;
        private System.Windows.Forms.Button buttonGetJYPwd;
        private System.Windows.Forms.Button buttonGetJFPwd;
        private System.Windows.Forms.Label labelJFPwdCrackState;
        private System.Windows.Forms.GroupBox groupBoxUdp;
        private System.Windows.Forms.Button buttonSuspend;
        private System.Windows.Forms.TextBox textBoxProcName;
        private System.Windows.Forms.Button buttonKill;
        private System.Windows.Forms.Button buttonResume;
        private System.Windows.Forms.Button buttonSendReboot;
        private System.Windows.Forms.Button buttonSendShutdown;
        private System.Windows.Forms.Button buttonSendCmd;
        private System.Windows.Forms.TextBox textBoxSendText;
        private System.Windows.Forms.Button buttonSendMsg;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button buttonGetPort;
        private System.Windows.Forms.Button buttonDbg;
        private System.Windows.Forms.GroupBox groupBoxOther;
        private System.Windows.Forms.Button buttonEnableNet;
        private System.Windows.Forms.Button buttonDefullScreen;
        private System.Windows.Forms.RadioButton radioButtonG1002;
        private System.Windows.Forms.RadioButton radioBtn0999;
        private System.Windows.Forms.RadioButton radioBtnL0999;
        private System.Windows.Forms.RadioButton radioBtn1001;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageUniversal;
        private System.Windows.Forms.TabPage tabPageSpecial;
        private System.Windows.Forms.Button buttonKillRS;
        private System.Windows.Forms.Button buttonSuspendRS;
        private System.Windows.Forms.Button buttonResumeRS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonRSCmd;
        private System.Windows.Forms.Button buttonRSUnblackScrn;
        private System.Windows.Forms.Button buttonRSBlackScrn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxRSArgs;
        private System.Windows.Forms.TextBox textBoxRSFilePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonRSShutdown;
        private System.Windows.Forms.Button buttonRSDisallowChat;
        private System.Windows.Forms.Button buttonRSAllowChat;
        private System.Windows.Forms.CheckBox checkBoxRSForceOrMaximize;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonRSReboot;
        private System.Windows.Forms.TextBox textBoxDbg;
        private System.Windows.Forms.TextBox textBoxTeacherIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxRSStdName;
        private System.Windows.Forms.Button buttonRSRespondCheckIn;
        private System.Windows.Forms.Button buttonRSCheckIn;
        private System.Windows.Forms.Button buttonRSHeartBeat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxMac;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxMachineName;
        private System.Windows.Forms.RadioButton radioButton1103;
        private System.Windows.Forms.RadioButton radioButton1160;
    }
}

