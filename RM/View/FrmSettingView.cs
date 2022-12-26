using RM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM.View
{
    public partial class FrmSettingView : Form
    {
        public FrmSettingView()
        {
            InitializeComponent();
        }

        private void btnChangeInfor_Click(object sender, EventArgs e)
        {
            FrmChangeUserInfor frm = new FrmChangeUserInfor();
            MainClass.BlurBackground(frm);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FrmChangeAdvPass frm = new FrmChangeAdvPass();
            MainClass.BlurBackground(frm);
        }
    }
}
