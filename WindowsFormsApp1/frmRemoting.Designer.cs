namespace Lecture
{
    partial class frmRemoting
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
            this.pteRemoting = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pteRemoting)).BeginInit();
            this.SuspendLayout();
            // 
            // pteRemoting
            // 
            this.pteRemoting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pteRemoting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pteRemoting.Location = new System.Drawing.Point(0, 0);
            this.pteRemoting.Name = "pteRemoting";
            this.pteRemoting.Size = new System.Drawing.Size(800, 450);
            this.pteRemoting.TabIndex = 3;
            this.pteRemoting.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmRemoting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pteRemoting);
            this.Name = "frmRemoting";
            this.Text = "frmRemoting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRemoting_FormClosing);
            this.Load += new System.EventHandler(this.frmRemoting_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRemoting_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmRemoting_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmRemoting_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmRemoting_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmRemoting_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmRemoting_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pteRemoting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pteRemoting;
        private System.Windows.Forms.Timer timer1;
    }
}