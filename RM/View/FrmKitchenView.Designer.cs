namespace RM.View
{
    partial class FrmKitchenView
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
            this.KitchenPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.KitchenMessageBox = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.SuspendLayout();
            // 
            // KitchenPanel
            // 
            this.KitchenPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KitchenPanel.Location = new System.Drawing.Point(12, 34);
            this.KitchenPanel.Name = "KitchenPanel";
            this.KitchenPanel.Size = new System.Drawing.Size(1050, 572);
            this.KitchenPanel.TabIndex = 0;
            // 
            // KitchenMessageBox
            // 
            this.KitchenMessageBox.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.KitchenMessageBox.Caption = "RMS";
            this.KitchenMessageBox.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
            this.KitchenMessageBox.Parent = null;
            this.KitchenMessageBox.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            this.KitchenMessageBox.Text = null;
            // 
            // FrmKitchenView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1074, 618);
            this.Controls.Add(this.KitchenPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmKitchenView";
            this.Text = "FrmKitchenView";
            this.Load += new System.EventHandler(this.FrmKitchenView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel KitchenPanel;
        private Guna.UI2.WinForms.Guna2MessageDialog KitchenMessageBox;
    }
}