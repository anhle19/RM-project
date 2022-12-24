namespace RM.View
{
    partial class FrmSettingView
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
            this.btnChangeInfor = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdvance = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.SuspendLayout();
            // 
            // btnChangeInfor
            // 
            this.btnChangeInfor.AutoRoundedCorners = true;
            this.btnChangeInfor.BorderRadius = 21;
            this.btnChangeInfor.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChangeInfor.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChangeInfor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChangeInfor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChangeInfor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChangeInfor.ForeColor = System.Drawing.Color.White;
            this.btnChangeInfor.Location = new System.Drawing.Point(53, 126);
            this.btnChangeInfor.Name = "btnChangeInfor";
            this.btnChangeInfor.Size = new System.Drawing.Size(180, 45);
            this.btnChangeInfor.TabIndex = 0;
            this.btnChangeInfor.Text = "Change login infor";
            this.btnChangeInfor.Click += new System.EventHandler(this.btnChangeInfor_Click);
            // 
            // btnAdvance
            // 
            this.btnAdvance.AutoRoundedCorners = true;
            this.btnAdvance.BorderRadius = 21;
            this.btnAdvance.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdvance.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdvance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdvance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdvance.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAdvance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdvance.ForeColor = System.Drawing.Color.White;
            this.btnAdvance.Location = new System.Drawing.Point(53, 201);
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.Size = new System.Drawing.Size(180, 45);
            this.btnAdvance.TabIndex = 1;
            this.btnAdvance.Text = "Change advance password";
            this.btnAdvance.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Setting";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(227, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 3;
            // 
            // FrmSettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 307);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdvance);
            this.Controls.Add(this.btnChangeInfor);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmSettingView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSettingView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnChangeInfor;
        private Guna.UI2.WinForms.Guna2Button btnAdvance;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}