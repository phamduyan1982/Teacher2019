namespace Lecture
{
    partial class UCListComputer
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
            this.tlpListComputer = new System.Windows.Forms.TableLayoutPanel();
            this.UpdateIP = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tlpListComputer
            // 
            this.tlpListComputer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpListComputer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tlpListComputer.ColumnCount = 2;
            this.tlpListComputer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpListComputer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpListComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpListComputer.Location = new System.Drawing.Point(0, 0);
            this.tlpListComputer.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.tlpListComputer.Name = "tlpListComputer";
            this.tlpListComputer.RowCount = 2;
            this.tlpListComputer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.3871F));
            this.tlpListComputer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.6129F));
            this.tlpListComputer.Size = new System.Drawing.Size(747, 463);
            this.tlpListComputer.TabIndex = 0;
            this.tlpListComputer.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpListComputer_Paint);
            // 
            // UpdateIP
            // 
            this.UpdateIP.Enabled = true;
            this.UpdateIP.Interval = 1000;
            this.UpdateIP.Tick += new System.EventHandler(this.UpdateIP_Tick);
            // 
            // UCListComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpListComputer);
            this.Name = "UCListComputer";
            this.Size = new System.Drawing.Size(747, 463);
            this.Load += new System.EventHandler(this.UCListComputer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpListComputer;
        private System.Windows.Forms.Timer UpdateIP;


    }
}
