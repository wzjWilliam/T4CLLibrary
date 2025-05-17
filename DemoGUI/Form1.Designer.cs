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
            this.buttonKillJF = new System.Windows.Forms.Button();
            this.buttonKillJY = new System.Windows.Forms.Button();
            this.buttonTmpPwd = new System.Windows.Forms.Button();
            this.groupBoxProc = new System.Windows.Forms.GroupBox();
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.buttonSendReboot = new System.Windows.Forms.Button();
            this.buttonSendShutdown = new System.Windows.Forms.Button();
            this.buttonSendCmd = new System.Windows.Forms.Button();
            this.textBoxSendText = new System.Windows.Forms.TextBox();
            this.buttonSendMsg = new System.Windows.Forms.Button();
            this.buttonDbg = new System.Windows.Forms.Button();
            this.groupBoxOther = new System.Windows.Forms.GroupBox();
            this.radioButtonG1002 = new System.Windows.Forms.RadioButton();
            this.radioBtn0999 = new System.Windows.Forms.RadioButton();
            this.radioBtnL0999 = new System.Windows.Forms.RadioButton();
            this.buttonDefullScreen = new System.Windows.Forms.Button();
            this.buttonEnableNet = new System.Windows.Forms.Button();
            this.radioBtn1001 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxProc.SuspendLayout();
            this.groupBoxPwd.SuspendLayout();
            this.groupBoxUdp.SuspendLayout();
            this.groupBoxOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonKillJF
            // 
            this.buttonKillJF.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonKillJF.Location = new System.Drawing.Point(211, 27);
            this.buttonKillJF.Name = "buttonKillJF";
            this.buttonKillJF.Size = new System.Drawing.Size(199, 83);
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
            this.buttonKillJY.Size = new System.Drawing.Size(199, 83);
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
            this.buttonTmpPwd.Size = new System.Drawing.Size(404, 83);
            this.buttonTmpPwd.TabIndex = 4;
            this.buttonTmpPwd.Text = "获取机房管理助手临时密码";
            this.buttonTmpPwd.UseVisualStyleBackColor = true;
            this.buttonTmpPwd.Click += new System.EventHandler(this.buttonTmpPwd_Click);
            // 
            // groupBoxProc
            // 
            this.groupBoxProc.Controls.Add(this.buttonResume);
            this.groupBoxProc.Controls.Add(this.buttonSuspend);
            this.groupBoxProc.Controls.Add(this.textBoxProcName);
            this.groupBoxProc.Controls.Add(this.buttonKill);
            this.groupBoxProc.Controls.Add(this.buttonResumeJY);
            this.groupBoxProc.Controls.Add(this.buttonKillJF);
            this.groupBoxProc.Controls.Add(this.buttonSuspendJY);
            this.groupBoxProc.Controls.Add(this.buttonKillJY);
            this.groupBoxProc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxProc.Location = new System.Drawing.Point(12, 12);
            this.groupBoxProc.Name = "groupBoxProc";
            this.groupBoxProc.Size = new System.Drawing.Size(420, 444);
            this.groupBoxProc.TabIndex = 6;
            this.groupBoxProc.TabStop = false;
            this.groupBoxProc.Text = "进程相关";
            // 
            // buttonResume
            // 
            this.buttonResume.Location = new System.Drawing.Point(211, 284);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(199, 64);
            this.buttonResume.TabIndex = 14;
            this.buttonResume.Text = "恢复自定义进程";
            this.buttonResume.UseVisualStyleBackColor = true;
            this.buttonResume.Click += new System.EventHandler(this.buttonResume_Click);
            // 
            // buttonSuspend
            // 
            this.buttonSuspend.Location = new System.Drawing.Point(10, 284);
            this.buttonSuspend.Name = "buttonSuspend";
            this.buttonSuspend.Size = new System.Drawing.Size(199, 64);
            this.buttonSuspend.TabIndex = 13;
            this.buttonSuspend.Text = "挂起自定义进程";
            this.buttonSuspend.UseVisualStyleBackColor = true;
            this.buttonSuspend.Click += new System.EventHandler(this.buttonSuspend_Click);
            // 
            // textBoxProcName
            // 
            this.textBoxProcName.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxProcName.Location = new System.Drawing.Point(10, 229);
            this.textBoxProcName.Name = "textBoxProcName";
            this.textBoxProcName.Size = new System.Drawing.Size(400, 49);
            this.textBoxProcName.TabIndex = 12;
            // 
            // buttonKill
            // 
            this.buttonKill.Location = new System.Drawing.Point(10, 354);
            this.buttonKill.Name = "buttonKill";
            this.buttonKill.Size = new System.Drawing.Size(400, 64);
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
            this.groupBoxPwd.Location = new System.Drawing.Point(438, 12);
            this.groupBoxPwd.Name = "groupBoxPwd";
            this.groupBoxPwd.Size = new System.Drawing.Size(420, 444);
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
            this.buttonGetJYPwd.Location = new System.Drawing.Point(211, 116);
            this.buttonGetJYPwd.Name = "buttonGetJYPwd";
            this.buttonGetJYPwd.Size = new System.Drawing.Size(199, 83);
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
            this.buttonGetJFPwd.Size = new System.Drawing.Size(199, 83);
            this.buttonGetJFPwd.TabIndex = 12;
            this.buttonGetJFPwd.Text = "获取机房管理助手密码";
            this.buttonGetJFPwd.UseVisualStyleBackColor = true;
            this.buttonGetJFPwd.Click += new System.EventHandler(this.buttonGetJFPwd_Click);
            // 
            // buttonJYPwd
            // 
            this.buttonJYPwd.Location = new System.Drawing.Point(211, 284);
            this.buttonJYPwd.Name = "buttonJYPwd";
            this.buttonJYPwd.Size = new System.Drawing.Size(199, 64);
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
            this.textBoxPwd.Size = new System.Drawing.Size(404, 49);
            this.textBoxPwd.TabIndex = 9;
            // 
            // buttonJFPwd
            // 
            this.buttonJFPwd.Location = new System.Drawing.Point(6, 284);
            this.buttonJFPwd.Name = "buttonJFPwd";
            this.buttonJFPwd.Size = new System.Drawing.Size(199, 64);
            this.buttonJFPwd.TabIndex = 8;
            this.buttonJFPwd.Text = "设置机房管理助手密码";
            this.buttonJFPwd.UseVisualStyleBackColor = true;
            this.buttonJFPwd.Click += new System.EventHandler(this.buttonJFPwd_Click);
            // 
            // groupBoxUdp
            // 
            this.groupBoxUdp.Controls.Add(this.buttonGetPort);
            this.groupBoxUdp.Controls.Add(this.label2);
            this.groupBoxUdp.Controls.Add(this.textBoxPort);
            this.groupBoxUdp.Controls.Add(this.label1);
            this.groupBoxUdp.Controls.Add(this.textBoxIP);
            this.groupBoxUdp.Controls.Add(this.buttonSendReboot);
            this.groupBoxUdp.Controls.Add(this.buttonSendShutdown);
            this.groupBoxUdp.Controls.Add(this.buttonSendCmd);
            this.groupBoxUdp.Controls.Add(this.textBoxSendText);
            this.groupBoxUdp.Controls.Add(this.buttonSendMsg);
            this.groupBoxUdp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxUdp.Location = new System.Drawing.Point(12, 462);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "端口:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPort.Location = new System.Drawing.Point(636, 77);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(200, 35);
            this.textBoxPort.TabIndex = 22;
            this.textBoxPort.Text = "4705";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(560, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "IP:";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxIP.Location = new System.Drawing.Point(612, 24);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(224, 35);
            this.textBoxIP.TabIndex = 20;
            this.textBoxIP.Text = "127.0.0.1";
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
            // buttonDbg
            // 
            this.buttonDbg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDbg.Location = new System.Drawing.Point(0, 27);
            this.buttonDbg.Name = "buttonDbg";
            this.buttonDbg.Size = new System.Drawing.Size(256, 83);
            this.buttonDbg.TabIndex = 25;
            this.buttonDbg.Text = "debug";
            this.buttonDbg.UseVisualStyleBackColor = true;
            this.buttonDbg.Click += new System.EventHandler(this.buttonDbg_Click);
            // 
            // groupBoxOther
            // 
            this.groupBoxOther.Controls.Add(this.label3);
            this.groupBoxOther.Controls.Add(this.radioBtn1001);
            this.groupBoxOther.Controls.Add(this.radioButtonG1002);
            this.groupBoxOther.Controls.Add(this.radioBtn0999);
            this.groupBoxOther.Controls.Add(this.radioBtnL0999);
            this.groupBoxOther.Controls.Add(this.buttonDefullScreen);
            this.groupBoxOther.Controls.Add(this.buttonEnableNet);
            this.groupBoxOther.Controls.Add(this.buttonDbg);
            this.groupBoxOther.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxOther.Location = new System.Drawing.Point(864, 12);
            this.groupBoxOther.Name = "groupBoxOther";
            this.groupBoxOther.Size = new System.Drawing.Size(268, 745);
            this.groupBoxOther.TabIndex = 26;
            this.groupBoxOther.TabStop = false;
            this.groupBoxOther.Text = "其他";
            // 
            // radioButtonG1002
            // 
            this.radioButtonG1002.AutoSize = true;
            this.radioButtonG1002.Location = new System.Drawing.Point(6, 441);
            this.radioButtonG1002.Name = "radioButtonG1002";
            this.radioButtonG1002.Size = new System.Drawing.Size(107, 28);
            this.radioButtonG1002.TabIndex = 30;
            this.radioButtonG1002.TabStop = true;
            this.radioButtonG1002.Text = ">=10.2";
            this.radioButtonG1002.UseVisualStyleBackColor = true;
            this.radioButtonG1002.CheckedChanged += new System.EventHandler(this.radioButtonG1002_CheckedChanged);
            // 
            // radioBtn0999
            // 
            this.radioBtn0999.AutoSize = true;
            this.radioBtn0999.Location = new System.Drawing.Point(6, 371);
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
            this.radioBtnL0999.Location = new System.Drawing.Point(6, 337);
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
            this.buttonDefullScreen.Location = new System.Drawing.Point(0, 205);
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
            this.buttonEnableNet.Location = new System.Drawing.Point(0, 116);
            this.buttonEnableNet.Name = "buttonEnableNet";
            this.buttonEnableNet.Size = new System.Drawing.Size(256, 83);
            this.buttonEnableNet.TabIndex = 26;
            this.buttonEnableNet.Text = "开网";
            this.buttonEnableNet.UseVisualStyleBackColor = true;
            this.buttonEnableNet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonEnableNet_MouseClick);
            // 
            // radioBtn1001
            // 
            this.radioBtn1001.AutoSize = true;
            this.radioBtn1001.Location = new System.Drawing.Point(6, 407);
            this.radioBtn1001.Name = "radioBtn1001";
            this.radioBtn1001.Size = new System.Drawing.Size(83, 28);
            this.radioBtn1001.TabIndex = 31;
            this.radioBtn1001.TabStop = true;
            this.radioBtn1001.Text = "10.1";
            this.radioBtn1001.UseVisualStyleBackColor = true;
            this.radioBtn1001.CheckedChanged += new System.EventHandler(this.radioBtn1001_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-4, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 24);
            this.label3.TabIndex = 32;
            this.label3.Text = "机房管理助手版本:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 769);
            this.Controls.Add(this.groupBoxOther);
            this.Controls.Add(this.groupBoxUdp);
            this.Controls.Add(this.groupBoxPwd);
            this.Controls.Add(this.groupBoxProc);
            this.Name = "Form1";
            this.Text = "Demo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxProc.ResumeLayout(false);
            this.groupBoxProc.PerformLayout();
            this.groupBoxPwd.ResumeLayout(false);
            this.groupBoxPwd.PerformLayout();
            this.groupBoxUdp.ResumeLayout(false);
            this.groupBoxUdp.PerformLayout();
            this.groupBoxOther.ResumeLayout(false);
            this.groupBoxOther.PerformLayout();
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
    }
}

