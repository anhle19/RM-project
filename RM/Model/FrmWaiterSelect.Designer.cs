namespace RM.Model
{
    partial class FrmWaiterSelect
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.picWaiterSelect = new Guna.UI2.WinForms.Guna2PictureBox();
            this.WaiterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWaiterSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.picWaiterSelect);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(738, 106);
            this.guna2Panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(130, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Waiter select";
            // 
            // picWaiterSelect
            // 
            this.picWaiterSelect.BackColor = System.Drawing.Color.Transparent;
            this.picWaiterSelect.Image = global::RM.Properties.Resources.Staff_icon;
            this.picWaiterSelect.ImageRotate = 0F;
            this.picWaiterSelect.Location = new System.Drawing.Point(21, 12);
            this.picWaiterSelect.Name = "picWaiterSelect";
            this.picWaiterSelect.Size = new System.Drawing.Size(92, 88);
            this.picWaiterSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWaiterSelect.TabIndex = 2;
            this.picWaiterSelect.TabStop = false;
            this.picWaiterSelect.UseTransparentBackground = true;
            // 
            // WaiterPanel
            // 
            this.WaiterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WaiterPanel.Location = new System.Drawing.Point(0, 106);
            this.WaiterPanel.Name = "WaiterPanel";
            this.WaiterPanel.Size = new System.Drawing.Size(738, 336);
            this.WaiterPanel.TabIndex = 2;
            // 
            // FrmWaiterSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 442);
            this.Controls.Add(this.WaiterPanel);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmWaiterSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmWaiterSelect_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWaiterSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public System.Windows.Forms.Label label1;
        public Guna.UI2.WinForms.Guna2PictureBox picWaiterSelect;
        public System.Windows.Forms.FlowLayoutPanel WaiterPanel;
    }
}