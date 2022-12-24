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

namespace RM.Model
{
    public partial class FrmStaffAdd : SampleAdd
    {
        public FrmStaffAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        private void FrmStaffAdd_Load(object sender, EventArgs e)
        {

        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0)
            {
                qry = "Insert into staff Values(@Name, @phone, @role)";
            }
            else
            {
                qry = "Update staff Set sname = @Name, sPhone = @phone, sRole = @role where staffID = @id";
            }

            Hashtable ht = new Hashtable();
            if(txtName.Text != "" && txtPhone.Text != "" && cbRole.Text != "")
            {
                ht.Add("@id", id);
                ht.Add("@Name", txtName.Text);
                ht.Add("@phone", txtPhone.Text);
                ht.Add("@role", cbRole.Text);

                if (MainClass.SQl(qry, ht) > 0)
                {
                    guna2MessageDialog1.Show("Saved successfully...");
                    id = 0;
                    txtName.Text = "";
                    txtPhone.Text = "";
                    cbRole.SelectedIndex = -1;
                    txtName.Focus();
                }
            }
            else
                guna2MessageDialog1.Show("Check the information");
        }
    }
}
