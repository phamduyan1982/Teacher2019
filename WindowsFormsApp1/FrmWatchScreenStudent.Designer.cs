namespace Lecture
{
    partial class FrmWatchScreenStudent
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
            this.tlpListComputer = new System.Windows.Forms.TableLayoutPanel();
            this.UpdateIP = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tlpListComputer
            // 
            this.tlpListComputer.AutoSize = true;
            this.tlpListComputer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpListComputer.ColumnCount = 1;
            this.tlpListComputer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpListComputer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpListComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpListComputer.Location = new System.Drawing.Point(0, 0);
            this.tlpListComputer.Name = "tlpListComputer";
            this.tlpListComputer.RowCount = 1;
            this.tlpListComputer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.87156F));
            this.tlpListComputer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.12844F));
            this.tlpListComputer.Size = new System.Drawing.Size(800, 450);
            this.tlpListComputer.TabIndex = 1;
            // 
            // UpdateIP
            // 
            this.UpdateIP.Enabled = true;
            this.UpdateIP.Interval = 1000;
            this.UpdateIP.Tick += new System.EventHandler(this.UpdateIP_Tick);
            // 
            // FrmWatchScreenStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpListComputer);
            this.Name = "FrmWatchScreenStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmWatchScreenStudent";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmWatchScreenStudent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpListComputer;
        private System.Windows.Forms.Timer UpdateIP;
    }
}