using RM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        static FrmMain _obj;
        //for accessing FrmMain
        public static FrmMain Instance
        {
            get { if (_obj == null) { _obj = new FrmMain(); }return _obj; }
        }
        //method to add Controls in main form
        public void AddControls(Form f)
        {
            CenterPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            CenterPanel.Controls.Add(f);
            f.Show();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lbUser.Text = MainClass.USER;
            _obj = this;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //open home form 
            AddControls(new FrmHome());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            AddControls(new FrmCategoryView());
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            AddControls(new FrmTableView());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            AddControls(new FrmStaffView());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            AddControls(new FrmProductView());
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            FrmPOS frm = new FrmPOS();
            frm.Show();
        }
    }
}
