using RM.Model;
using System;
using System.Collections;
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
    public partial class FrmStaffView : SampleView
    {
        public FrmStaffView()
        {
            InitializeComponent();
        }

        private void FrmStaffView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            string qry = "Select * From staff where sName like '%" + txtSearch.Text + "%'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvRole);

            MainClass.LoadData(qry, DataGridViewStaff, lb);

        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            //FrmCategoryAdd frm = new FrmCategoryAdd();
            //frm.ShowDialog();
            MainClass.BlurBackground(new FrmStaffAdd());
            GetData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Edit selected row
            if (DataGridViewStaff.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                //This is change as we have to set form text propties before open
                FrmStaffAdd frm = new FrmStaffAdd();
                frm.id = Convert.ToInt32(DataGridViewStaff.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(DataGridViewStaff.CurrentRow.Cells["dgvName"].Value);
                frm.txtPhone.Text = Convert.ToString(DataGridViewStaff.CurrentRow.Cells["dgvPhone"].Value);
                frm.cbRole.Text = Convert.ToString(DataGridViewStaff.CurrentRow.Cells["dgvRole"].Value);
                MainClass.BlurBackground(frm);
                GetData();
            }
            //Delete selected row
            //Need to confirm before delete
            if (DataGridViewStaff.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if (guna2MessageDialog1.Show("Are you sure you want to delete?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(DataGridViewStaff.CurrentRow.Cells["dgvid"].Value);
                    string qry = "Delete from staff where staffID= " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageBox.Show("Deleted successfully");
                    GetData();
                }

            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
