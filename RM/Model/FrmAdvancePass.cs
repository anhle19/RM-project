using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM.Model
{
    public partial class FrmAdvancePass : Form
    {
        public FrmAdvancePass()
        {
            InitializeComponent();
        }

        public bool check = false;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string pass = txtPass.Text;
            if (MainClass.CheckAdvance(pass))
            {
                check = true;
                this.Close();
            }
            else
                guna2MessageDialog1.Show("Login failed");
        }
    }
}
