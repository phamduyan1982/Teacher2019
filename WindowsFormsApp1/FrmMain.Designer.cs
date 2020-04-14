namespace Lecture
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.BtnDone = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.Stop = new System.Windows.Forms.Button();
            this.btnRemote = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShutdownAll = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.prgFile = new System.Windows.Forms.ProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctmsTaskbar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.TeachShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStopTeach = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRunWithWin = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.onPC = new System.Windows.Forms.Label();
            this.btnChatClient = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            this.btnListPC = new System.Windows.Forms.Button();
            this.ctmsTaskbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnDone
            // 
            this.BtnDone.Location = new System.Drawing.Point(281, 11);
            this.BtnDone.Name = "BtnDone";
            this.BtnDone.Size = new System.Drawing.Size(87, 29);
            this.BtnDone.TabIndex = 0;
            this.BtnDone.Text = "Start";
            this.BtnDone.UseVisualStyleBackColor = true;
            this.BtnDone.Click += new System.EventHandler(this.BtnDone_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(282, 49);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(88, 29);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // btnRemote
            // 
            this.btnRemote.Location = new System.Drawing.Point(283, 89);
            this.btnRemote.Name = "btnRemote";
            this.btnRemote.Size = new System.Drawing.Size(88, 25);
            this.btnRemote.TabIndex = 3;
            this.btnRemote.Text = "Remote";
            this.btnRemote.UseVisualStyleBackColor = true;
            this.btnRemote.Click += new System.EventHandler(this.btnRemote_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(176, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "VER 30.05.2019";
            // 
            // btnShutdownAll
            // 
            this.btnShutdownAll.Location = new System.Drawing.Point(8, 14);
            this.btnShutdownAll.Name = "btnShutdownAll";
            this.btnShutdownAll.Size = new System.Drawing.Size(64, 26);
            this.btnShutdownAll.TabIndex = 7;
            this.btnShutdownAll.Text = "Shutdown";
            this.btnShutdownAll.UseVisualStyleBackColor = true;
            this.btnShutdownAll.Click += new System.EventHandler(this.btnShutdownAll_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(8, 54);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(162, 20);
            this.txtFile.TabIndex = 8;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(184, 51);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(80, 25);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Send File";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // prgFile
            // 
            this.prgFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgFile.Location = new System.Drawing.Point(8, 83);
            this.prgFile.Name = "prgFile";
            this.prgFile.Size = new System.Drawing.Size(162, 20);
            this.prgFile.TabIndex = 13;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.ctmsTaskbar;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Hệ thống giảng viên";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // ctmsTaskbar
            // 
            this.ctmsTaskbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShow,
            this.TeachShow,
            this.tsmiStopTeach,
            this.tsmiRunWithWin,
            this.Exit});
            this.ctmsTaskbar.Name = "ctmsTaskbar";
            this.ctmsTaskbar.Size = new System.Drawing.Size(184, 114);
            // 
            // tsmiShow
            // 
            this.tsmiShow.Name = "tsmiShow";
            this.tsmiShow.Size = new System.Drawing.Size(183, 22);
            this.tsmiShow.Text = "Hiển thị";
            this.tsmiShow.Click += new System.EventHandler(this.tsmiShow_Click);
            // 
            // TeachShow
            // 
            this.TeachShow.Name = "TeachShow";
            this.TeachShow.Size = new System.Drawing.Size(183, 22);
            this.TeachShow.Text = "Giảng Bài";
            this.TeachShow.Click += new System.EventHandler(this.TeachShow_Click);
            // 
            // tsmiStopTeach
            // 
            this.tsmiStopTeach.CheckOnClick = true;
            this.tsmiStopTeach.Name = "tsmiStopTeach";
            this.tsmiStopTeach.Size = new System.Drawing.Size(183, 22);
            this.tsmiStopTeach.Text = "Ngừng giảng";
            this.tsmiStopTeach.CheckedChanged += new System.EventHandler(this.tsmiStopTeach_CheckedChanged);
            this.tsmiStopTeach.Click += new System.EventHandler(this.tsmiStopTeach_Click);
            // 
            // tsmiRunWithWin
            // 
            this.tsmiRunWithWin.Name = "tsmiRunWithWin";
            this.tsmiRunWithWin.Size = new System.Drawing.Size(183, 22);
            this.tsmiRunWithWin.Text = "Khởi động cùng Win";
            this.tsmiRunWithWin.Click += new System.EventHandler(this.tsmiRunWithWin_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(183, 22);
            this.Exit.Text = "Thoát";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(220, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(46, 27);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Hide";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // onPC
            // 
            this.onPC.AutoSize = true;
            this.onPC.ForeColor = System.Drawing.Color.Red;
            this.onPC.Location = new System.Drawing.Point(176, 101);
            this.onPC.Name = "onPC";
            this.onPC.Size = new System.Drawing.Size(39, 13);
            this.onPC.TabIndex = 16;
            this.onPC.Text = "PC on:";
            // 
            // btnChatClient
            // 
            this.btnChatClient.Location = new System.Drawing.Point(138, 14);
            this.btnChatClient.Name = "btnChatClient";
            this.btnChatClient.Size = new System.Drawing.Size(80, 26);
            this.btnChatClient.TabIndex = 17;
            this.btnChatClient.Text = "Chat Student";
            this.btnChatClient.UseVisualStyleBackColor = true;
            this.btnChatClient.Click += new System.EventHandler(this.btnChatClient_Click);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(81, 14);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(52, 27);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnListPC
            // 
            this.btnListPC.Location = new System.Drawing.Point(8, 105);
            this.btnListPC.Name = "btnListPC";
            this.btnListPC.Size = new System.Drawing.Size(50, 21);
            this.btnListPC.TabIndex = 19;
            this.btnListPC.Text = "List PC";
            this.btnListPC.UseVisualStyleBackColor = true;
            this.btnListPC.Click += new System.EventHandler(this.btnListPC_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 128);
            this.Controls.Add(this.btnListPC);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnChatClient);
            this.Controls.Add(this.onPC);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.prgFile);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnShutdownAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemote);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.BtnDone);
            this.MaximumSize = new System.Drawing.Size(404, 264);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hỗ trợ giảng dạy";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ctmsTaskbar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDone;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button btnRemote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShutdownAll;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ProgressBar prgFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip ctmsTaskbar;
        private System.Windows.Forms.ToolStripMenuItem tsmiShow;
        private System.Windows.Forms.ToolStripMenuItem tsmiStopTeach;
        private System.Windows.Forms.ToolStripMenuItem tsmiRunWithWin;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolStripMenuItem TeachShow;
        private System.Windows.Forms.Label onPC;
        private System.Windows.Forms.Button btnChatClient;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnListPC;
    }
}

