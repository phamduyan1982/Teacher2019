namespace Lecture
{
    partial class UCScreenCapture
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.runtime = new System.Windows.Forms.Timer(this.components);
            this.labComputerName = new System.Windows.Forms.Label();
            this.pteScreenCapture = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.thôngTinSinhViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeSpace = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiError = new System.Windows.Forms.ToolStripMenuItem();
            this.xemCấuHìnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.pteScreenCapture)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // runtime
            // 
            this.runtime.Enabled = true;
            this.runtime.Interval = 1000;
            this.runtime.Tick += new System.EventHandler(this.runtime_Tick);
            // 
            // labComputerName
            // 
            this.labComputerName.AutoSize = true;
            this.labComputerName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labComputerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labComputerName.Location = new System.Drawing.Point(0, 0);
            this.labComputerName.Name = "labComputerName";
            this.labComputerName.Size = new System.Drawing.Size(52, 17);
            this.labComputerName.TabIndex = 1;
            this.labComputerName.Text = "label1";
            // 
            // pteScreenCapture
            // 
            this.pteScreenCapture.ContextMenuStrip = this.contextMenuStrip1;
            this.pteScreenCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pteScreenCapture.Image = global::Teacher.Properties.Resources.Internet_Disconnect;
            this.pteScreenCapture.Location = new System.Drawing.Point(0, 0);
            this.pteScreenCapture.Name = "pteScreenCapture";
            this.pteScreenCapture.Size = new System.Drawing.Size(228, 219);
            this.pteScreenCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pteScreenCapture.TabIndex = 0;
            this.pteScreenCapture.TabStop = false;
            this.pteScreenCapture.DoubleClick += new System.EventHandler(this.pteScreenCapture_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinSinhViênToolStripMenuItem,
            this.chatToolStripMenuItem,
            this.logoffToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.shutdownToolStripMenuItem,
            this.tsmiChangeSpace,
            this.tsmiError,
            this.xemCấuHìnhToolStripMenuItem,
            this.tsm});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(199, 202);
            // 
            // thôngTinSinhViênToolStripMenuItem
            // 
            this.thôngTinSinhViênToolStripMenuItem.Name = "thôngTinSinhViênToolStripMenuItem";
            this.thôngTinSinhViênToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.thôngTinSinhViênToolStripMenuItem.Text = "Thông tin sinh viên";
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.chatToolStripMenuItem.Text = "Chat";
            // 
            // logoffToolStripMenuItem
            // 
            this.logoffToolStripMenuItem.CheckOnClick = true;
            this.logoffToolStripMenuItem.Name = "logoffToolStripMenuItem";
            this.logoffToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.logoffToolStripMenuItem.Text = "Logoff";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.CheckOnClick = true;
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.CheckOnClick = true;
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            // 
            // tsmiChangeSpace
            // 
            this.tsmiChangeSpace.Name = "tsmiChangeSpace";
            this.tsmiChangeSpace.Size = new System.Drawing.Size(198, 22);
            this.tsmiChangeSpace.Text = "Đổi chỗ máy sinh viên";
            // 
            // tsmiError
            // 
            this.tsmiError.Name = "tsmiError";
            this.tsmiError.Size = new System.Drawing.Size(198, 22);
            this.tsmiError.Text = "Lỗi máy tính";
            // 
            // xemCấuHìnhToolStripMenuItem
            // 
            this.xemCấuHìnhToolStripMenuItem.Name = "xemCấuHìnhToolStripMenuItem";
            this.xemCấuHìnhToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.xemCấuHìnhToolStripMenuItem.Text = "Cấu hình của máy";
            // 
            // tsm
            // 
            this.tsm.CheckOnClick = true;
            this.tsm.Name = "tsm";
            this.tsm.Size = new System.Drawing.Size(198, 22);
            this.tsm.Text = "Cảnh báo đến sinh viên";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pteScreenCapture);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labComputerName);
            this.splitContainer1.Size = new System.Drawing.Size(228, 272);
            this.splitContainer1.SplitterDistance = 219;
            this.splitContainer1.TabIndex = 2;
            // 
            // UCScreenCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UCScreenCapture";
            this.Size = new System.Drawing.Size(228, 272);
            ((System.ComponentModel.ISupportInitialize)(this.pteScreenCapture)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer runtime;
        private System.Windows.Forms.PictureBox pteScreenCapture;
        private System.Windows.Forms.Label labComputerName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thôngTinSinhViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeSpace;
        private System.Windows.Forms.ToolStripMenuItem tsmiError;
        private System.Windows.Forms.ToolStripMenuItem xemCấuHìnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsm;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
